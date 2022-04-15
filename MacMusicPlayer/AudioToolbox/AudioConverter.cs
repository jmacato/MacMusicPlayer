//
// AudioConverter.cs: AudioConverter wrapper class
//
// Authors:
//   Marek Safar (marek.safar@gmail.com)
//
// Copyright 2013 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#nullable enable

//using Foundation;
using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;
#if !NETXXX
using NativeHandle = System.IntPtr;
#endif

namespace MacMusicPlayer.AudioToolbox
{
#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
    public class AudioConverter : DisposableObject
    {
        private delegate AudioConverterError AudioConverterComplexInputDataShared(IntPtr inAudioConverter,
            ref int ioNumberDataPackets, IntPtr ioData,
            IntPtr outDataPacketDescription, IntPtr inUserData);

        private IntPtr packetDescriptions;
        private int packetDescriptionSize;
        private static readonly AudioConverterComplexInputDataShared ComplexInputDataShared = FillComplexBufferShared;

        public event AudioConverterComplexInputData? InputData;

        //[Preserve (Conditional = true)]
        internal AudioConverter(NativeHandle handle, bool owns)
            : base(handle, owns)
        {
        }

        public uint MinimumInputBufferSize => GetUIntProperty(AudioConverterPropertyID.MinimumInputBufferSize);

        public uint MinimumOutputBufferSize => GetUIntProperty(AudioConverterPropertyID.MinimumOutputBufferSize);

        public uint MaximumInputPacketSize => GetUIntProperty(AudioConverterPropertyID.MaximumInputPacketSize);

        public uint MaximumOutputPacketSize => GetUIntProperty(AudioConverterPropertyID.MaximumOutputPacketSize);

        public uint CalculateInputBufferSize => GetUIntProperty(AudioConverterPropertyID.CalculateInputBufferSize);

        public uint CalculateOutputBufferSize => GetUIntProperty(AudioConverterPropertyID.CalculateOutputBufferSize);

        public double SampleRateConverterInitialPhase
        {
            get => GetDoubleProperty(AudioConverterPropertyID.SampleRateConverterInitialPhase);
            set => SetProperty(AudioConverterPropertyID.SampleRateConverterInitialPhase, value);
        }

        public AudioConverterSampleRateConverterComplexity SampleRateConverterComplexity
        {
            get => (AudioConverterSampleRateConverterComplexity) GetUIntProperty(AudioConverterPropertyID
                .SampleRateConverterComplexity);
            set => SetProperty(AudioConverterPropertyID.SampleRateConverterComplexity, (uint) value);
        }

        public AudioConverterQuality SampleRateConverterQuality
        {
            get => (AudioConverterQuality) GetUIntProperty(AudioConverterPropertyID.SampleRateConverterQuality);
            set => SetProperty(AudioConverterPropertyID.SampleRateConverterQuality, (uint) value);
        }

        public AudioConverterQuality CodecQuality
        {
            get => (AudioConverterQuality) GetUIntProperty(AudioConverterPropertyID.CodecQuality);
            set => SetProperty(AudioConverterPropertyID.CodecQuality, (uint) value);
        }

        public AudioConverterPrimeMethod PrimeMethod
        {
            get => (AudioConverterPrimeMethod) GetUIntProperty(AudioConverterPropertyID.PrimeMethod);
            set => SetProperty(AudioConverterPropertyID.PrimeMethod, (uint) value);
        }

        public unsafe AudioConverterPrimeInfo PrimeInfo
        {
            get
            {
                AudioConverterPrimeInfo value;
                var size = sizeof(AudioConverterPrimeInfo);
                var res = AudioConverterGetProperty(Handle, AudioConverterPropertyID.PrimeInfo, ref size, out value);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());

                return value;
            }
        }

        public int[]? ChannelMap => GetArray<int>(AudioConverterPropertyID.ChannelMap, sizeof(int));

        public byte[]? CompressionMagicCookie
        {
            get
            {
                int size;
                bool writable;
                if (AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.CompressionMagicCookie, out size,
                        out writable) != AudioConverterError.None)
                    return null;

                var cookie = new byte [size];
                if (AudioConverterGetProperty(Handle, AudioConverterPropertyID.CompressionMagicCookie, ref size,
                        cookie) != AudioConverterError.None)
                    return null;

                return cookie;
            }

            set
            {
                if (value is null)
                    ThrowHelper.ThrowArgumentNullException(nameof(value));

                var res = AudioConverterSetProperty(Handle, AudioConverterPropertyID.CompressionMagicCookie,
                    value.Length, value);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());
            }
        }

        public byte[]? DecompressionMagicCookie
        {
            get
            {
                int size;
                bool writable;
                if (AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.DecompressionMagicCookie, out size,
                        out writable) != AudioConverterError.None)
                    return null;

                var cookie = new byte [size];
                if (AudioConverterGetProperty(Handle, AudioConverterPropertyID.DecompressionMagicCookie, ref size,
                        cookie) != AudioConverterError.None)
                    return null;

                return cookie;
            }
            set
            {
                if (value is null)
                    ThrowHelper.ThrowArgumentNullException(nameof(value));

                var res = AudioConverterSetProperty(Handle, AudioConverterPropertyID.DecompressionMagicCookie,
                    value.Length, value);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());
            }
        }

        public uint EncodeBitRate
        {
            get => GetUIntProperty(AudioConverterPropertyID.EncodeBitRate);
            set => SetProperty(AudioConverterPropertyID.EncodeBitRate, value);
        }

        public double EncodeAdjustableSampleRate
        {
            get => GetDoubleProperty(AudioConverterPropertyID.EncodeAdjustableSampleRate);
            set => SetProperty(AudioConverterPropertyID.EncodeAdjustableSampleRate, value);
        }

        public AudioChannelLayout? InputChannelLayout
        {
            get
            {
                int size;
                bool writable;
                if (AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.InputChannelLayout, out size,
                        out writable) != AudioConverterError.None)
                    return null;

                var ptr = Marshal.AllocHGlobal(size);
                var res = AudioConverterGetProperty(Handle, AudioConverterPropertyID.InputChannelLayout, ref size, ptr);
                var layout = res == AudioConverterError.None ? new AudioChannelLayout(ptr) : null;
                Marshal.FreeHGlobal(ptr);
                return layout;
            }
        }

        public AudioChannelLayout? OutputChannelLayout
        {
            get
            {
                int size;
                bool writable;
                if (AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.OutputChannelLayout, out size,
                        out writable) != AudioConverterError.None)
                    return null;

                var ptr = Marshal.AllocHGlobal(size);
                var res = AudioConverterGetProperty(Handle, AudioConverterPropertyID.OutputChannelLayout, ref size,
                    ptr);
                var layout = res == AudioConverterError.None ? new AudioChannelLayout(ptr) : null;
                Marshal.FreeHGlobal(ptr);
                return layout;
            }
        }

        public AudioValueRange[]? ApplicableEncodeBitRates =>
            GetAudioValueRange(AudioConverterPropertyID.ApplicableEncodeBitRates);

        public AudioValueRange[]? AvailableEncodeBitRates =>
            GetAudioValueRange(AudioConverterPropertyID.AvailableEncodeBitRates);

        public AudioValueRange[]? ApplicableEncodeSampleRates =>
            GetAudioValueRange(AudioConverterPropertyID.ApplicableEncodeSampleRates);

        public AudioValueRange[]? AvailableEncodeSampleRates =>
            GetAudioValueRange(AudioConverterPropertyID.AvailableEncodeSampleRates);

        public AudioChannelLayoutTag[]? AvailableEncodeChannelLayoutTags =>
            GetArray<AudioChannelLayoutTag>(AudioConverterPropertyID.AvailableEncodeChannelLayoutTags,
                sizeof(AudioChannelLayoutTag));

        public unsafe AudioStreamBasicDescription CurrentOutputStreamDescription
        {
            get
            {
                int size;
                bool writable;
                var res = AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.CurrentOutputStreamDescription,
                    out size, out writable);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());

                var ptr = Marshal.AllocHGlobal(size);
                res = AudioConverterGetProperty(Handle, AudioConverterPropertyID.CurrentOutputStreamDescription,
                    ref size, ptr);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());

                var asbd = *(AudioStreamBasicDescription*) ptr;
                Marshal.FreeHGlobal(ptr);
                return asbd;
            }
        }

        public unsafe AudioStreamBasicDescription CurrentInputStreamDescription
        {
            get
            {
                int size;
                bool writable;
                var res = AudioConverterGetPropertyInfo(Handle, AudioConverterPropertyID.CurrentInputStreamDescription,
                    out size, out writable);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());

                var ptr = Marshal.AllocHGlobal(size);
                res = AudioConverterGetProperty(Handle, AudioConverterPropertyID.CurrentInputStreamDescription,
                    ref size, ptr);
                if (res != AudioConverterError.None)
                    throw new ArgumentException(res.ToString());

                var asbd = *(AudioStreamBasicDescription*) ptr;
                Marshal.FreeHGlobal(ptr);
                return asbd;
            }
        }

        public int BitDepthHint
        {
            get => (int) GetUIntProperty(AudioConverterPropertyID.PropertyBitDepthHint);
            set => SetProperty(AudioConverterPropertyID.PropertyBitDepthHint, value);
        }

        public unsafe AudioFormat[]? FormatList =>
            GetArray<AudioFormat>(AudioConverterPropertyID.PropertyFormatList, sizeof(AudioFormat));

#if !MONOMAC
        public bool CanResumeFromInterruption =>
            GetUIntProperty(AudioConverterPropertyID.CanResumeFromInterruption) != 0;
#endif

        public static AudioConverter? Create(AudioStreamBasicDescription sourceFormat,
            AudioStreamBasicDescription destinationFormat)
        {
            AudioConverterError res;
            return Create(sourceFormat, destinationFormat, out res);
        }

        public static AudioConverter? Create(AudioStreamBasicDescription sourceFormat,
            AudioStreamBasicDescription destinationFormat, out AudioConverterError error)
        {
            var ptr = new IntPtr();
            error = AudioConverterNew(ref sourceFormat, ref destinationFormat, ref ptr);
            if (error != AudioConverterError.None)
                return null;

            return new AudioConverter(ptr, true);
        }

        public static AudioConverter? Create(AudioStreamBasicDescription sourceFormat,
            AudioStreamBasicDescription destinationFormat, AudioClassDescription[] descriptions)
        {
            if (descriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(descriptions));

            var ptr = new IntPtr();
            var res = AudioConverterNewSpecific(ref sourceFormat, ref destinationFormat, descriptions.Length,
                ref descriptions, ref ptr);
            if (res != AudioConverterError.None)
                return null;

            return new AudioConverter(ptr, true);
        }

        public static AudioFormatType[]? DecodeFormats => GetFormats(AudioFormatProperty.DecodeFormatIDs);

        public static AudioFormatType[]? EncodeFormats => GetFormats(AudioFormatProperty.EncodeFormatIDs);

        protected override void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero && Owns)
                AudioConverterDispose(Handle);

            if (packetDescriptions != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(packetDescriptions);
                packetDescriptions = IntPtr.Zero;
            }

            base.Dispose(disposing);
        }

        public AudioConverterError ConvertBuffer(byte[] input, byte[] output)
        {
            if (input is null)
                ThrowHelper.ThrowArgumentNullException(nameof(input));
            if (output is null)
                ThrowHelper.ThrowArgumentNullException(nameof(output));

            var outSize = output.Length;
            return AudioConverterConvertBuffer(Handle, input.Length, input, ref outSize, output);
        }

        public AudioConverterError ConvertComplexBuffer(int numberPCMFrames, AudioBuffers inputData,
            AudioBuffers outputData)
        {
            if (inputData is null)
                ThrowHelper.ThrowArgumentNullException(nameof(inputData));
            if (outputData is null)
                ThrowHelper.ThrowArgumentNullException(nameof(outputData));

            return AudioConverterConvertComplexBuffer(Handle, numberPCMFrames, (IntPtr) inputData, (IntPtr) outputData);
        }

        public AudioConverterError FillComplexBuffer(ref int outputDataPacketSize,
            AudioBuffers outputData, AudioStreamPacketDescription[] packetDescription,
            AudioConverterComplexInputData newInputDataHandler)
        {
            if (outputData is null)
                ThrowHelper.ThrowArgumentNullException(nameof(outputData));

            if (newInputDataHandler is null)
                ThrowHelper.ThrowArgumentNullException(nameof(newInputDataHandler));

            return FillComplexBuffer(ref outputDataPacketSize, outputData, packetDescription,
                new Tuple<AudioConverter, AudioConverterComplexInputData?>(this, newInputDataHandler));
        }

        public AudioConverterError FillComplexBuffer(ref int outputDataPacketSize,
            AudioBuffers outputData, AudioStreamPacketDescription[] packetDescription)
        {
            if (outputData is null)
                ThrowHelper.ThrowArgumentNullException(nameof(outputData));

            return FillComplexBuffer(ref outputDataPacketSize, outputData, packetDescription,
                new Tuple<AudioConverter, AudioConverterComplexInputData?>(this, null));
        }

        private AudioConverterError FillComplexBuffer(ref int outputDataPacketSize,
            AudioBuffers outputData, AudioStreamPacketDescription[] packetDescription,
            Tuple<AudioConverter, AudioConverterComplexInputData?> instanceData)
        {
            var this_handle = GCHandle.Alloc(instanceData);

            try
            {
                var this_ptr = GCHandle.ToIntPtr(this_handle);

                if (packetDescription is null)
                    return AudioConverterFillComplexBuffer(Handle, ComplexInputDataShared, this_ptr,
                        ref outputDataPacketSize, (IntPtr) outputData, IntPtr.Zero);

                unsafe
                {
                    fixed (AudioStreamPacketDescription* pdesc = &packetDescription[0])
                    {
                        return AudioConverterFillComplexBuffer(Handle, ComplexInputDataShared, this_ptr,
                            ref outputDataPacketSize, (IntPtr) outputData, (IntPtr) pdesc);
                    }
                }
            }
            finally
            {
                this_handle.Free();
            }
        }

        //
        // outDataPacketDescription should be `ref IntPtr' but using IntPtr we get easier access to pointer address
        //
        // // [MonoPInvokeCallback (typeof (AudioConverterComplexInputDataShared))]
        private static AudioConverterError FillComplexBufferShared(IntPtr inAudioConverter, ref int ioNumberDataPackets,
            IntPtr ioData,
            IntPtr outDataPacketDescription, IntPtr inUserData)
        {
            var handler = GCHandle.FromIntPtr(inUserData);
            var instanceData = handler.Target as Tuple<AudioConverter, AudioConverterComplexInputData?>;

            if (instanceData is null)
                ThrowHelper.ThrowArgumentNullException(nameof(instanceData));

            var inst = instanceData.Item1;
            var callback = instanceData.Item2;

            // Invoke event handler with an argument
            // since callback is not provided, must come from the old FillComplexBuffer call
            if (callback is null && inst.InputData is null)
                ThrowHelper.ThrowArgumentNullException("InputData");
            // Check if subscribed to event and provided a callback, error out if true
            else if (callback is not null && inst.InputData is not null)
                throw new InvalidOperationException(
                    "Please either only subscribe to InputData event or provide newInputDataHandler in FillComplexBuffer, using both is unsuported.");

            using (var buffers = new AudioBuffers(ioData))
            {
                //
                // Callback is supposed to fill outDataPacketDescription when outDataPacketDescription is not NULL
                // Using 0-size array as marker because the size of pre-allocated memory is not known
                //
                var data = outDataPacketDescription == IntPtr.Zero ? null : new AudioStreamPacketDescription [0];

                var res = inst.InputData is not null
                    ? inst.InputData(ref ioNumberDataPackets, buffers, ref data)
                    : callback!(ref ioNumberDataPackets, buffers, ref data);

                if (outDataPacketDescription != IntPtr.Zero)
                {
                    if (ioNumberDataPackets > 0)
                    {
                        if (data is null || data.Length == 0)
                            throw new ArgumentException("ref argument outDataPacketDescription has to be set");

                        //
                        // Apple doc says the output buffer has to be pre-allocated using last argument to 
                        // AudioConverterFillComplexBuffer but even if NULL is passed and convertor requires
                        // packet description outDataPacketDescription is not NULL and it such case we will
                        // write at some unknown pointer location, similar situation happens when initialization
                        // size does not match data size
                        //
                        var size = Marshal.SizeOf(data[0]);
                        // Clear our buffer if it's not big enough
                        if (inst.packetDescriptionSize < data.Length && inst.packetDescriptions != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(inst.packetDescriptions);
                            inst.packetDescriptions = IntPtr.Zero;
                        }

                        // Create a new buffer if we don't already have one
                        if (inst.packetDescriptions == IntPtr.Zero)
                        {
                            inst.packetDescriptionSize = data.Length;
                            inst.packetDescriptions = Marshal.AllocHGlobal(data.Length * size);
                        }

                        unsafe
                        {
                            fixed (void* source = data)
                            {
                                Buffer.MemoryCopy(source, (void*) inst.packetDescriptions,
                                    inst.packetDescriptionSize * size, data.Length * size);
                            }
                        }

                        Marshal.WriteIntPtr(outDataPacketDescription, inst.packetDescriptions);
                    }
                    else
                    {
                        Marshal.WriteIntPtr(outDataPacketDescription, IntPtr.Zero);
                    }
                }

                return res;
            }
        }

        public AudioConverterError Reset()
        {
            return AudioConverterReset(Handle);
        }

        private static unsafe AudioFormatType[]? GetFormats(AudioFormatProperty prop)
        {
            int size;
            if (AudioFormatPropertyNative.AudioFormatGetPropertyInfo(prop, 0, IntPtr.Zero, out size) != 0)
                return null;

            var elementSize = sizeof(AudioFormatType);
            var data = new AudioFormatType[size / elementSize];
            fixed (AudioFormatType* ptr = data)
            {
                var res = AudioFormatPropertyNative.AudioFormatGetProperty(prop, 0, IntPtr.Zero, ref size,
                    (IntPtr) ptr);
                if (res != 0)
                    return null;

                Array.Resize(ref data, elementSize);
                return data;
            }
        }

        private uint GetUIntProperty(AudioConverterPropertyID propertyID)
        {
            uint value;
            var size = sizeof(uint);
            var res = AudioConverterGetProperty(Handle, propertyID, ref size, out value);
            if (res != AudioConverterError.None)
                throw new ArgumentException(res.ToString());

            return value;
        }

        private double GetDoubleProperty(AudioConverterPropertyID propertyID)
        {
            double value;
            var size = sizeof(double);
            var res = AudioConverterGetProperty(Handle, propertyID, ref size, out value);
            if (res != AudioConverterError.None)
                throw new ArgumentException(res.ToString());

            return value;
        }

        private unsafe AudioValueRange[]? GetAudioValueRange(AudioConverterPropertyID prop)
        {
            return GetArray<AudioValueRange>(prop, sizeof(AudioValueRange));
        }

        private unsafe T[]? GetArray<T>(AudioConverterPropertyID prop, int elementSize)
        {
            int size;
            bool writable;
            if (AudioConverterGetPropertyInfo(Handle, prop, out size, out writable) != AudioConverterError.None)
                return null;

            var data = new T [size / elementSize];
            var array_handle =
                GCHandle.Alloc(data,
                    GCHandleType
                        .Pinned); // This requires a pinned GCHandle, since it's not possible to use unsafe code to get the address of a generic object.

            try
            {
                var ptr = array_handle.AddrOfPinnedObject();
                var res = AudioConverterGetProperty(Handle, prop, ref size, ptr);
                if (res != 0)
                    return null;

                Array.Resize(ref data, size / elementSize);
                return data;
            }
            finally
            {
                array_handle.Free();
            }
        }

        private void SetProperty(AudioConverterPropertyID propertyID, uint value)
        {
            var res = AudioConverterSetProperty(Handle, propertyID, sizeof(uint), ref value);
            if (res != AudioConverterError.None)
                throw new ArgumentException(res.ToString());
        }

        private void SetProperty(AudioConverterPropertyID propertyID, int value)
        {
            var res = AudioConverterSetProperty(Handle, propertyID, sizeof(int), ref value);
            if (res != AudioConverterError.None)
                throw new ArgumentException(res.ToString());
        }

        private void SetProperty(AudioConverterPropertyID propertyID, double value)
        {
            var res = AudioConverterSetProperty(Handle, propertyID, sizeof(double), ref value);
            if (res != AudioConverterError.None)
                throw new ArgumentException(res.ToString());
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterNew(ref AudioStreamBasicDescription inSourceFormat,
            ref AudioStreamBasicDescription inDestinationFormat, ref IntPtr outAudioConverter);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterNewSpecific(
            ref AudioStreamBasicDescription inSourceFormat, ref AudioStreamBasicDescription inDestinationFormat,
            int inNumberClassDescriptions, ref AudioClassDescription[] inClassDescriptions,
            ref IntPtr outAudioConverter);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterDispose(IntPtr inAudioConverter);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterReset(IntPtr inAudioConverter);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterConvertComplexBuffer(IntPtr inAudioConverter,
            int inNumberPCMFrames,
            IntPtr inInputData, IntPtr outOutputData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, out uint outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, out int outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, out double outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, byte[] outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, out AudioConverterPrimeInfo outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            ref int ioPropertyDataSize, IntPtr outPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterGetPropertyInfo(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            out int outSize, [MarshalAs(UnmanagedType.I1)] out bool outWritable);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterSetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            int inPropertyDataSize, ref uint inPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterSetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            int inPropertyDataSize, ref int inPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterSetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            int inPropertyDataSize, ref double inPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterSetProperty(IntPtr inAudioConverter,
            AudioConverterPropertyID inPropertyID,
            int inPropertyDataSize, byte[] inPropertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterConvertBuffer(IntPtr inAudioConverter,
            int inInputDataSize, byte[] inInputData,
            ref int ioOutputDataSize, byte[] outOutputData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioConverterError AudioConverterFillComplexBuffer(IntPtr inAudioConverter,
            AudioConverterComplexInputDataShared inInputDataProc, IntPtr inInputDataProcUserData,
            ref int ioOutputDataPacketSize, IntPtr outOutputData,
            IntPtr outPacketDescription);
    }
}
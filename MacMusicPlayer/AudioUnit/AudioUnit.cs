//
// AudioUnit.cs: AudioUnit wrapper class
//
// Authors:
//   AKIHIRO Uehara (u-akihiro@reinforce-lab.com)
//   Marek Safar (marek.safar@gmail.com)
//
// Copyright 2010 Reinforce Lab.
// Copyright 2011-2013 Xamarin Inc
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

// Adding this warning disable since AudioUnitPropertyIDType is removed from public API but used internally
#pragma warning disable CS0618

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using AudioToolbox;
using ObjCRuntime;
using CoreFoundation;


namespace AudioUnit
{
    public class AudioUnitException : Exception
    {
        private static string Lookup(int k)
        {
            return (AudioUnitStatus) k switch
            {
                AudioUnitStatus.InvalidProperty => "Invalid Property",
                AudioUnitStatus.InvalidParameter => "Invalid Parameter",
                AudioUnitStatus.InvalidElement => "Invalid Element",
                AudioUnitStatus.NoConnection => "No Connection",
                AudioUnitStatus.FailedInitialization => "Failed Initialization",
                AudioUnitStatus.TooManyFramesToProcess => "Too Many Frames To Process",
                AudioUnitStatus.InvalidFile => "Invalid File",
                AudioUnitStatus.FormatNotSupported => "Format Not Supported",
                AudioUnitStatus.Uninitialized => "Uninitialized",
                AudioUnitStatus.InvalidScope => "Invalid Scope",
                AudioUnitStatus.PropertyNotWritable => "Property Not Writable",
                AudioUnitStatus.CannotDoInCurrentContext => "Cannot Do In Current Context",
                AudioUnitStatus.InvalidPropertyValue => "Invalid Property Value",
                AudioUnitStatus.PropertyNotInUse => "Property Not In Use",
                AudioUnitStatus.Initialized => "Initialized",
                AudioUnitStatus.InvalidOfflineRender => "Invalid Offline Render",
                AudioUnitStatus.Unauthorized => "Unauthorized",
                _ => $"Unknown error code: 0x{k:x}"
            };
        }

        internal AudioUnitException(AudioUnitStatus status)
            : this((int) status)
        {
        }

        internal AudioUnitException(int k) : base(Lookup(k))
        {
        }
    }

    public delegate AudioUnitStatus RenderDelegate(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
        uint busNumber, uint numberFrames, AudioBuffers data);

    public delegate AudioUnitStatus InputDelegate(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
        uint busNumber, uint numberFrames, AudioUnit audioUnit);

    internal delegate AudioUnitStatus CallbackShared(IntPtr /* void* */ clientData,
        ref AudioUnitRenderActionFlags /* AudioUnitRenderActionFlags* */ actionFlags,
        ref AudioTimeStamp /* AudioTimeStamp* */ timeStamp, uint /* UInt32 */ busNumber, uint /* UInt32 */ numberFrames,
        IntPtr /* AudioBufferList* */ data);

    [StructLayout(LayoutKind.Sequential)]
    internal struct AURenderCallbackStruct
    {
        public Delegate Proc;
        public IntPtr ProcRefCon;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AudioUnitConnection
    {
        public IntPtr SourceAudioUnit;

        public uint /* UInt32 */
            SourceOutputNumber;

        public uint /* UInt32 */
            DestInputNumber;
    }

    public class SamplerInstrumentData
    {
        public const byte DefaultPercussionBankMSB = 0x78;
        public const byte DefaultMelodicBankMSB = 0x79;
        public const byte DefaultBankLSB = 0x00;

        public SamplerInstrumentData(CFUrl fileUrl, InstrumentType instrumentType)
        {
            if (fileUrl is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(fileUrl));

            this.FileUrl = fileUrl;
            this.InstrumentType = instrumentType;
        }

        public CFUrl FileUrl { get; private set; }
        public InstrumentType InstrumentType { get; private set; }
        public byte BankMSB { get; set; }
        public byte BankLSB { get; set; }
        public byte PresetID { get; set; }

        internal AUSamplerInstrumentData ToStruct()
        {
            var data = new AUSamplerInstrumentData();
            data.FileUrl = FileUrl.Handle;
            data.InstrumentType = InstrumentType;
            data.BankMSB = BankMSB;
            data.BankLSB = BankLSB;
            data.PresetID = PresetID;
            return data;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AUSamplerInstrumentData
    {
        public IntPtr FileUrl;
        public InstrumentType InstrumentType;
        public byte BankMSB;
        public byte BankLSB;
        public byte PresetID;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct AudioUnitParameterInfoNative // AudioUnitParameterInfo in Obj-C
    {
        private fixed byte /* char[52] */
            name[52]; // unused

        public IntPtr /* CFStringRef */
            UnitName;

        public AudioUnitClumpID /* UInt32 */
            ClumpID;

        public IntPtr /* CFStringRef */
            NameString;

        public AudioUnitParameterUnit /* AudioUnitParameterUnit */
            Unit;

        public float /* AudioUnitParameterValue = Float32 */
            MinValue;

        public float /* AudioUnitParameterValue = Float32 */
            MaxValue;

        public float /* AudioUnitParameterValue = Float32 */
            DefaultValue;

        public AudioUnitParameterFlag /* UInt32 */
            Flags;
    }

    public class AudioUnitParameterInfo
    {
        public string? UnitName { get; private set; }
        public AudioUnitClumpID ClumpID { get; private set; }
        public string? Name { get; private set; }
        public AudioUnitParameterUnit Unit { get; private set; }
        public float MinValue { get; private set; }
        public float MaxValue { get; private set; }
        public float DefaultValue { get; private set; }
        public AudioUnitParameterFlag Flags { get; private set; }
        public AudioUnitParameterType Type { get; private set; }

        internal static AudioUnitParameterInfo Create(AudioUnitParameterInfoNative native, AudioUnitParameterType type)
        {
            var info = new AudioUnitParameterInfo();

            // Remove obj-c noise
            info.Flags = native.Flags &
                         ~(AudioUnitParameterFlag.HasCFNameString | AudioUnitParameterFlag.CFNameRelease);
            info.Unit = native.Unit;
            info.MinValue = native.MinValue;
            info.MaxValue = native.MaxValue;
            info.DefaultValue = native.DefaultValue;
            info.ClumpID = native.ClumpID;
            info.Type = type;

            if ((native.Flags & AudioUnitParameterFlag.HasCFNameString) != 0)
            {
                info.Name = CFString.FromHandle(native.NameString);

                if ((native.Flags & AudioUnitParameterFlag.CFNameRelease) != 0)
                    CFObject.CFRelease(native.NameString);
            }

            if (native.Unit == AudioUnitParameterUnit.CustomUnit)
            {
                info.UnitName = CFString.FromHandle(native.UnitName);
            }

            return info;
        }
    }

    public enum AUParameterEventType : uint
    {
        Immediate = 1,
        Ramped = 2,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioUnitParameterEvent
    {
        public uint Scope;
        public uint Element;
        public uint Parameter;
        public AUParameterEventType EventType;

        [StructLayout(LayoutKind.Explicit)]
        public struct EventValuesStruct
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RampStruct
            {
                public int StartBufferOffset;
                public uint DurationInFrames;
                public float StartValue;
                public float EndValue;
            }


            [FieldOffset(0)] public RampStruct Ramp;

            [StructLayout(LayoutKind.Sequential)]
            public struct ImmediateStruct
            {
                public uint BufferOffset;
                public float Value;
            }

            [FieldOffset(0)] public ImmediateStruct Immediate;
        }

        public EventValuesStruct EventValues;
    }

    public class AudioUnit : DisposableObject
    {
        private static readonly CallbackShared CreateRenderCallback = RenderCallbackImpl;
        private static readonly CallbackShared CreateInputCallback = InputCallbackImpl;

        private GCHandle gcHandle;
        private bool _isPlaying;

        private Dictionary<uint, RenderDelegate>? renderer;
        private Dictionary<uint, InputDelegate>? inputs;

        ////[Preserve (Conditional = true)]
        internal AudioUnit(System.IntPtr handle, bool owns)
            : base(handle, owns)
        {
        }

        private static IntPtr Create(AudioComponent component)
        {
            if (component is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(component));

            var err = AudioComponentInstanceNew(component.GetCheckedHandle(), out var handle);
            if (err != 0)
                throw new AudioUnitException(err);

            return handle;
        }

        public AudioUnit(AudioComponent component)
            : this(Create(component), true)
        {
        }

        public AudioComponent Component
        {
            get { return new AudioComponent(AudioComponentInstanceGetComponent(Handle), false); }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
        }


        public AudioUnitStatus SetFormat(AudioToolbox.AudioStreamBasicDescription audioFormat, AudioUnitScopeType scope,
            uint audioUnitElement = 0)
        {
            return (AudioUnitStatus) AudioUnitSetProperty(Handle,
                AudioUnitPropertyIDType.StreamFormat,
                scope,
                audioUnitElement,
                ref audioFormat,
                (uint) Marshal.SizeOf(audioFormat));
        }

        public uint GetCurrentDevice(AudioUnitScopeType scope, uint audioUnitElement = 0)
        {
            uint device = 0;
            int size = Marshal.SizeOf(typeof(uint));
            var err = AudioUnitGetProperty(Handle,
                AudioUnitPropertyIDType.CurrentDevice,
                scope,
                audioUnitElement,
                ref device,
                ref size);
            if (err != 0)
                throw new AudioUnitException((int) err);
            return device;
        }

        public AudioUnitStatus SetCurrentDevice(uint inputDevice, AudioUnitScopeType scope, uint audioUnitElement = 0)
        {
            return AudioUnitSetProperty(Handle,
                AudioUnitPropertyIDType.CurrentDevice,
                scope,
                audioUnitElement,
                ref inputDevice,
                (uint) Marshal.SizeOf(inputDevice));
        }

        public AudioStreamBasicDescription GetAudioFormat(AudioUnitScopeType scope, uint audioUnitElement = 0)
        {
            var audioFormat = new AudioStreamBasicDescription();
            uint size = (uint) Marshal.SizeOf(audioFormat);

            var err = AudioUnitGetProperty(Handle,
                AudioUnitPropertyIDType.StreamFormat,
                scope,
                audioUnitElement,
                ref audioFormat,
                ref size);
            if (err != 0)
                throw new AudioUnitException((int) err);

            return audioFormat;
        }

        public unsafe AudioUnitParameterInfo[]? GetParameterList(AudioUnitScopeType scope = AudioUnitScopeType.Global,
            uint audioUnitElement = 0)
        {
            uint size;
            bool writable;
            if (AudioUnitGetPropertyInfo(Handle, AudioUnitPropertyIDType.ParameterList, scope, audioUnitElement,
                    out size, out writable) != 0)
                return null;

            // Array of AudioUnitParameterID = UInt32
            var data = new uint [size / sizeof(uint)];
            fixed (uint* ptr = data)
            {
                if (AudioUnitGetProperty(Handle, AudioUnitPropertyIDType.ParameterList, scope, audioUnitElement, ptr,
                        ref size) != 0)
                    return null;
            }

            var info = new AudioUnitParameterInfo [data.Length];
            size = (uint) sizeof(AudioUnitParameterInfoNative);

            for (int i = 0; i < data.Length; ++i)
            {
                var native = new AudioUnitParameterInfoNative();
                if (AudioUnitGetProperty(Handle, AudioUnitPropertyIDType.ParameterInfo, scope, data[i], ref native,
                        ref size) != 0)
                    return null;

                info[i] = AudioUnitParameterInfo.Create(native, (AudioUnitParameterType) data[i]);
            }

            return info;
        }

        public AudioUnitStatus LoadInstrument(SamplerInstrumentData instrumentData,
            AudioUnitScopeType scope = AudioUnitScopeType.Global, uint audioUnitElement = 0)
        {
            if (instrumentData is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(instrumentData));

            var data = instrumentData.ToStruct();
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.LoadInstrument, scope, audioUnitElement,
                ref data, Marshal.SizeOf(typeof(AUSamplerInstrumentData)));
        }

        public AudioUnitStatus MakeConnection(AudioUnit sourceAudioUnit, uint sourceOutputNumber, uint destInputNumber)
        {
            var auc = new AudioUnitConnection
            {
                SourceAudioUnit = sourceAudioUnit.GetHandle(),
                SourceOutputNumber = sourceOutputNumber,
                DestInputNumber = destInputNumber
            };

            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.MakeConnection, AudioUnitScopeType.Input, 0,
                ref auc, Marshal.SizeOf(typeof(AudioUnitConnection)));
        }

        public AudioUnitStatus SetEnableIO(bool enableIO, AudioUnitScopeType scope, uint audioUnitElement = 0)
        {
            // EnableIO: UInt32          
            uint flag = enableIO ? (uint) 1 : 0;
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.EnableIO, scope, audioUnitElement, ref flag,
                sizeof(uint));
        }

        public AudioUnitStatus SetMaximumFramesPerSlice(uint value, AudioUnitScopeType scope, uint audioUnitElement = 0)
        {
            // MaximumFramesPerSlice: UInt32
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.MaximumFramesPerSlice, scope, audioUnitElement,
                ref value, sizeof(uint));
        }

        public uint GetMaximumFramesPerSlice(AudioUnitScopeType scope = AudioUnitScopeType.Global,
            uint audioUnitElement = 0)
        {
            // MaximumFramesPerSlice: UInt32
            uint value = 0;
            uint size = sizeof(uint);
            var res = AudioUnitGetProperty(Handle, AudioUnitPropertyIDType.MaximumFramesPerSlice, scope,
                audioUnitElement, ref value, ref size);

            if (res != 0)
                throw new AudioUnitException((int) res);

            return value;
        }

        public AudioUnitStatus SetElementCount(AudioUnitScopeType scope, uint count)
        {
            // ElementCount: UInt32
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.ElementCount, scope, 0, ref count,
                sizeof(uint));
        }

        public uint GetElementCount(AudioUnitScopeType scope)
        {
            // ElementCount: UInt32
            uint value = 0;
            uint size = sizeof(uint);
            var res = AudioUnitGetProperty(Handle, AudioUnitPropertyIDType.ElementCount, scope,
                0, ref value, ref size);

            if (res != 0)
                throw new AudioUnitException((int) res);

            return value;
        }

        public AudioUnitStatus SetSampleRate(double sampleRate, AudioUnitScopeType scope = AudioUnitScopeType.Output,
            uint audioUnitElement = 0)
        {
            // ElementCount: Float64
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.SampleRate, scope, 0, ref sampleRate,
                sizeof(double));
        }

        public AudioUnitStatus MusicDeviceMIDIEvent(uint status, uint data1, uint data2, uint offsetSampleFrame = 0)
        {
            return MusicDeviceMIDIEvent(Handle, status, data1, data2, offsetSampleFrame);
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement, ref double outData, ref uint ioDataSize);

        public double GetLatency()
        {
            uint size = sizeof(double);
            double latency = 0;
            var err = AudioUnitGetProperty(Handle, AudioUnitPropertyIDType.Latency, AudioUnitScopeType.Global, 0,
                ref latency, ref size);
            if (err != 0)
                throw new AudioUnitException((int) err);
            return latency;
        }

        public AudioUnitStatus SetRenderCallback(RenderDelegate renderDelegate,
            AudioUnitScopeType scope = AudioUnitScopeType.Global, uint audioUnitElement = 0)
        {
            if (renderer is null)
                Interlocked.CompareExchange(ref renderer, new Dictionary<uint, RenderDelegate>(), null);

            renderer[audioUnitElement] = renderDelegate;

            if (!gcHandle.IsAllocated)
                gcHandle = GCHandle.Alloc(this);

            var cb = new AURenderCallbackStruct();
            cb.Proc = CreateRenderCallback;
            cb.ProcRefCon = GCHandle.ToIntPtr(gcHandle);
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.SetRenderCallback, scope, audioUnitElement,
                ref cb, Marshal.SizeOf(cb));
        }

        // // [MonoPInvokeCallback (typeof (CallbackShared))]
        private static AudioUnitStatus RenderCallbackImpl(IntPtr clientData, ref AudioUnitRenderActionFlags actionFlags,
            ref AudioTimeStamp timeStamp, uint busNumber, uint numberFrames, IntPtr data)
        {
            GCHandle gch = GCHandle.FromIntPtr(clientData);
            var au = (AudioUnit?) gch.Target;
            var renderer = au?.renderer;

            if (renderer is null)
                return AudioUnitStatus.Uninitialized;

            if (!renderer.TryGetValue(busNumber, out var render))
                return AudioUnitStatus.Uninitialized;

            using (var buffers = new AudioBuffers(data))
            {
                return render(actionFlags, timeStamp, busNumber, numberFrames, buffers);
            }
        }

        public AudioUnitStatus SetInputCallback(InputDelegate inputDelegate,
            AudioUnitScopeType scope = AudioUnitScopeType.Global, uint audioUnitElement = 0)
        {
            if (inputs is null)
                Interlocked.CompareExchange(ref inputs, new Dictionary<uint, InputDelegate>(), null);

            inputs[audioUnitElement] = inputDelegate;

            if (!gcHandle.IsAllocated)
                gcHandle = GCHandle.Alloc(this);

            var cb = new AURenderCallbackStruct();
            cb.Proc = CreateInputCallback;
            cb.ProcRefCon = GCHandle.ToIntPtr(gcHandle);
            return AudioUnitSetProperty(Handle, AudioUnitPropertyIDType.SetInputCallback, scope, audioUnitElement,
                ref cb, Marshal.SizeOf(cb));
        }

        // // [MonoPInvokeCallback (typeof (CallbackShared))]
        private static AudioUnitStatus InputCallbackImpl(IntPtr clientData, ref AudioUnitRenderActionFlags actionFlags,
            ref AudioTimeStamp timeStamp, uint busNumber, uint numberFrames, IntPtr data)
        {
            GCHandle gch = GCHandle.FromIntPtr(clientData);
            var au = gch.Target as AudioUnit;
            if (au is null)
                return AudioUnitStatus.Uninitialized;

            var inputs = au.inputs;
            if (inputs is null)
                return AudioUnitStatus.Uninitialized;

            if (!inputs.TryGetValue(busNumber, out var input))
                return AudioUnitStatus.Uninitialized;

            return input(actionFlags, timeStamp, busNumber, numberFrames, au);
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioComponentStatus AudioOutputUnitPublish(AudioComponentDescription inDesc,
            IntPtr /* CFStringRef */ inName, uint /* UInt32 */ inVersion, IntPtr /* AudioUnit */ inOutputUnit);

        public AudioComponentStatus AudioOutputUnitPublish(AudioComponentDescription description, string name,
            uint version = 1)
        {
            if (name is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(name));

            var nameHandle = CFString.CreateNative(name);
            try
            {
                return AudioOutputUnitPublish(description, nameHandle, version, Handle);
            }
            finally
            {
                CFString.ReleaseNative(nameHandle);
            }
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern IntPtr AudioOutputUnitGetHostIcon(IntPtr /* AudioUnit */ au, float /* float */ desiredPointSize);


        public int Initialize()
        {
            return (int) AudioUnitInitialize(Handle);
        }

        public int Uninitialize()
        {
            return (int) AudioUnitUninitialize(Handle);
        }

        public void Start()
        {
            AudioUnitStatus rv = 0;
            if (!_isPlaying)
            {
                rv = AudioOutputUnitStart(Handle);
                _isPlaying = true;
            }
        }

        public void Stop()
        {
            AudioUnitStatus rv = 0;
            if (_isPlaying)
            {
                rv = AudioOutputUnitStop(Handle);
                _isPlaying = false;
            }
        }

        public AudioUnitStatus Render(ref AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
            uint busNumber, uint numberFrames, AudioBuffers data)
        {
            if ((IntPtr) data == IntPtr.Zero)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(data));
            return AudioUnitRender(Handle, ref actionFlags, ref timeStamp, busNumber, numberFrames, (IntPtr) data);
        }

        public AudioUnitStatus SetParameter(AudioUnitParameterType type, float value, AudioUnitScopeType scope,
            uint audioUnitElement = 0)
        {
            return AudioUnitSetParameter(Handle, type, scope, audioUnitElement, value, 0);
        }

        public AudioUnitStatus ScheduleParameter(AudioUnitParameterEvent inParameterEvent, uint inNumParamEvents)
        {
            return AudioUnitScheduleParameters(Handle, inParameterEvent, inNumParamEvents);
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern int AudioComponentInstanceDispose(IntPtr inInstance);

        protected override void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero && Owns)
            {
                Stop();
                AudioUnitUninitialize(Handle);
                AudioComponentInstanceDispose(Handle);
            }

            if (gcHandle.IsAllocated)
                gcHandle.Free();
            base.Dispose(disposing);
        }

        [DllImport(Constants.AudioUnitLibrary, EntryPoint = "AudioComponentInstanceNew")]
        private static extern AudioUnitStatus AudioComponentInstanceNew(IntPtr inComponent, out IntPtr inDesc);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern IntPtr AudioComponentInstanceGetComponent(IntPtr inComponent);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitInitialize(IntPtr inUnit);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitUninitialize(IntPtr inUnit);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioOutputUnitStart(IntPtr ci);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioOutputUnitStop(IntPtr ci);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitRender(IntPtr inUnit, ref AudioUnitRenderActionFlags ioActionFlags,
            ref AudioTimeStamp inTimeStamp,
            uint inOutputBusNumber, uint inNumberFrames, IntPtr ioData);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern int AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID, AudioUnitScopeType inScope,
            uint inElement,
            ref AudioStreamBasicDescription inData,
            uint inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref uint inData, uint inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref double inData, uint inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref IntPtr inData, int inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AURenderCallbackStruct inData, int inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AudioUnitConnection inData, int inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AUSamplerInstrumentData inData, int inDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AudioStreamBasicDescription outData,
            ref uint ioDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref IntPtr outData,
            ref int ioDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref uint outData,
            ref int ioDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern unsafe AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            uint* outData,
            ref uint ioDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern unsafe AudioUnitStatus AudioUnitGetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AudioUnitParameterInfoNative outData,
            ref uint ioDataSize);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern int AudioUnitGetProperty(IntPtr inUnit,
            [MarshalAs(UnmanagedType.U4)] AudioUnitPropertyIDType inID,
            [MarshalAs(UnmanagedType.U4)] AudioUnitScopeType inScope,
            [MarshalAs(UnmanagedType.U4)] uint inElement,
            ref uint flag,
            ref uint ioDataSize
        );


        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitGetPropertyInfo(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            out uint outDataSize, [MarshalAs(UnmanagedType.I1)] out bool outWritable);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetParameter(IntPtr inUnit, AudioUnitParameterType inID,
            AudioUnitScopeType inScope,
            uint inElement, float inValue, uint inBufferOffsetInFrames);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitScheduleParameters(IntPtr inUnit,
            AudioUnitParameterEvent inParameterEvent, uint inNumParamEvents);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus MusicDeviceMIDIEvent(IntPtr /* MusicDeviceComponent = void* */ inUnit,
            uint /* UInt32 */ inStatus, uint /* UInt32 */ inData1, uint /* UInt32 */ inData2,
            uint /* UInt32 */ inOffsetSampleFrame);

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AUScheduledAudioFileRegion.ScheduledAudioFileRegion inData, int inDataSize);

        public AudioUnitStatus SetScheduledFileRegion(AUScheduledAudioFileRegion region)
        {
            if (region is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(region));

            var safr = region.GetAudioFileRegion();
            return AudioUnitSetProperty(GetCheckedHandle(), AudioUnitPropertyIDType.ScheduledFileRegion,
                AudioUnitScopeType.Global, 0, ref safr, Marshal.SizeOf(safr));
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            ref AudioTimeStamp inData, int inDataSize);

        public AudioUnitStatus SetScheduleStartTimeStamp(AudioTimeStamp timeStamp)
        {
            return AudioUnitSetProperty(GetCheckedHandle(), AudioUnitPropertyIDType.ScheduleStartTimeStamp,
                AudioUnitScopeType.Global, 0, ref timeStamp, Marshal.SizeOf(timeStamp));
        }

        public AudioUnitStatus SetScheduledFiles(AudioFile audioFile)
        {
            if (audioFile is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(audioFile));

            var audioFilehandle = audioFile.Handle;
            return AudioUnitSetProperty(GetCheckedHandle(), AudioUnitPropertyIDType.ScheduledFileIDs,
                AudioUnitScopeType.Global, 0, ref audioFilehandle, Marshal.SizeOf(Handle));
        }

        [DllImport(Constants.AudioUnitLibrary)]
        private static extern AudioUnitStatus AudioUnitSetProperty(IntPtr inUnit, AudioUnitPropertyIDType inID,
            AudioUnitScopeType inScope, uint inElement,
            IntPtr inData, int inDataSize);

        public unsafe AudioUnitStatus SetScheduledFiles(AudioFile[] audioFiles)
        {
            if (audioFiles is null)
                ObjCRuntime.ThrowHelper.ThrowArgumentNullException(nameof(audioFiles));

            int count = audioFiles.Length;
            IntPtr[] handles = new IntPtr[count];
            for (int i = 0; i < count; i++)
                handles[i] = audioFiles[i].Handle;

            fixed (IntPtr* ptr = handles)
                return AudioUnitSetProperty(GetCheckedHandle(), AudioUnitPropertyIDType.ScheduledFileIDs,
                    AudioUnitScopeType.Global, 0, (IntPtr) ptr, IntPtr.Size * count);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AudioObjectPropertyAddress
    {
        public uint /* UInt32 */
            Selector;

        public uint /* UInt32 */
            Scope;

        public uint /* UInt32 */
            Element;

        public AudioObjectPropertyAddress(uint selector, uint scope, uint element)
        {
            Selector = selector;
            Scope = scope;
            Element = element;
        }

        public AudioObjectPropertyAddress(AudioObjectPropertySelector selector, AudioObjectPropertyScope scope,
            AudioObjectPropertyElement element)
        {
            Selector = (uint) selector;
            Scope = (uint) scope;
            Element = (uint) element;
        }
    }

    public unsafe class AURenderEventEnumerator : INativeObject
        , IEnumerator<AURenderEvent>
    {
        private AURenderEvent* current;

        public System.IntPtr Handle { get; private set; }

        public bool IsEmpty
        {
            get { return Handle == IntPtr.Zero; }
        }

        public bool IsAtEnd
        {
            get { return current is null; }
        }

        public AURenderEventEnumerator(System.IntPtr ptr)
            : this(ptr, false)
        {
        }

        ////[Preserve (Conditional = true)]
        internal AURenderEventEnumerator(System.IntPtr handle, bool owns)
        {
            Handle = handle;
            current = (AURenderEvent*) (IntPtr) handle;
        }

        public void Dispose()
        {
            Handle = System.IntPtr.Zero;
            current = null;
        }

        public AURenderEvent* UnsafeFirst
        {
            get { return (AURenderEvent*) (IntPtr) Handle; }
        }

        public AURenderEvent First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Can not get First on AURenderEventEnumerator when empty");
                return *(AURenderEvent*) (IntPtr) Handle;
            }
        }

        public AURenderEvent Current
        {
            get
            {
                if (IsAtEnd)
                    throw new InvalidOperationException("Can not get Current on AURenderEventEnumerator when at end");
                return *current;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        private bool IsAt(nint now)
        {
            return current is not null && (current->Head.EventSampleTime == now);
        }

        public IEnumerable<AURenderEvent> EnumeratorCurrentEvents(nint now)
        {
            if (IsAtEnd)
                throw new InvalidOperationException("Can not enumerate events on AURenderEventEnumerator when at end");

            do
            {
                yield return Current;
                MoveNext();
            } while (IsAt(now));
        }

        public bool /*IEnumerator<AURenderEvent>.*/ MoveNext()
        {
            if (current is not null)
                current = ((AURenderEvent*) current)->Head.UnsafeNext;
            return current is not null;
        }

        public void /*IEnumerator<AURenderEvent>.*/ Reset()
        {
            current = (AURenderEvent*) (IntPtr) Handle;
        }
    }

    public enum AURenderEventType : byte
    {
        Parameter = 1,
        ParameterRamp = 2,
        Midi = 8,
        MidiSysEx = 9,
        MidiEventList = 10,
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AURenderEventHeader
    {
        public AURenderEvent* UnsafeNext;

        public AURenderEvent? Next
        {
            get
            {
                if (UnsafeNext is not null)
                    return (AURenderEvent?) Marshal.PtrToStructure((IntPtr) UnsafeNext, typeof(AURenderEvent));
                return null;
            }
        }

        public long EventSampleTime;

        public AURenderEventType EventType;

        public byte Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AUParameterObserverToken
    {
        public IntPtr ObserverToken;

        public AUParameterObserverToken(IntPtr observerToken)
        {
            ObserverToken = observerToken;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AUParameterEvent
    {
        public AURenderEvent* UnsafeNext;

        public AURenderEvent? Next
        {
            get
            {
                if (UnsafeNext is not null)
                    return (AURenderEvent?) Marshal.PtrToStructure((IntPtr) UnsafeNext, typeof(AURenderEvent));
                return null;
            }
        }

        public long EventSampleTime;

        public AURenderEventType EventType;

        internal byte reserved1, reserved2, reserved3;

        public uint RampDurationSampleFrames;

        public ulong ParameterAddress;

        public float Value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct AURenderEvent
    {
        [FieldOffset(0)] public AURenderEventHeader Head;

        [FieldOffset(0)] public AUParameterEvent Parameter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AURecordedParameterEvent
    {
        public ulong HostTime;

        public ulong Address;

        public float Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AUParameterAutomationEvent
    {
        public ulong HostTime;
        public ulong Address;
        public float Value;
        public AUParameterAutomationEventType EventType;
        private ulong Reserved;
    }
}
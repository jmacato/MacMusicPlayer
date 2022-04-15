// 
// AudioFile.cs:
//
// Authors:
//    Miguel de Icaza (miguel@novell.com)
//     
// Copyright 2009 Novell, Inc
// Copyright 2011-2013 Xamarin Inc.
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

using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;
// //using Foundation;
using AudioFileStreamID = System.IntPtr;

namespace MacMusicPlayer.AudioToolbox;

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

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
public class AudioFileStream : IDisposable
{
    private IntPtr handle;
    private GCHandle gch;

    ~AudioFileStream()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Close()
    {
        Dispose();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            if (gch.IsAllocated)
                gch.Free();
        if (handle != IntPtr.Zero)
        {
            AudioFileStreamClose(handle);
            handle = IntPtr.Zero;
        }
    }

    private delegate void AudioFileStream_PropertyListenerProc(IntPtr clientData,
        AudioFileStreamID audioFileStream,
        AudioFileStreamProperty propertyID,
        ref AudioFileStreamPropertyFlag ioFlags);

    private delegate void AudioFileStream_PacketsProc(IntPtr clientData,
        int numberBytes,
        int numberPackets,
        IntPtr inputData,
        IntPtr packetDescriptions);

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern int AudioFileStreamOpen(
        IntPtr clientData,
        AudioFileStream_PropertyListenerProc propertyListenerProc,
        AudioFileStream_PacketsProc packetsProc,
        AudioFileType fileTypeHint,
        out IntPtr file_id);

    private static readonly AudioFileStream_PacketsProc dInPackets = InPackets;
    private static readonly AudioFileStream_PropertyListenerProc dPropertyListener = PropertyListener;

    // [MonoPInvokeCallback(typeof(AudioFileStream_PacketsProc))]
    private static void InPackets(IntPtr clientData, int numberBytes, int numberPackets, IntPtr inputData,
        IntPtr packetDescriptions)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var afs = handle.Target as AudioFileStream;

        var desc = AudioFile.PacketDescriptionFrom(numberPackets, packetDescriptions);
        afs!.OnPacketDecoded(numberBytes, inputData, desc);
    }

    public EventHandler<PacketReceivedEventArgs>? PacketDecoded;

    protected virtual void OnPacketDecoded(int numberOfBytes, IntPtr inputData,
        AudioStreamPacketDescription[]? packetDescriptions)
    {
        var p = PacketDecoded;
        if (p is not null)
            p(this, new PacketReceivedEventArgs(numberOfBytes, inputData, packetDescriptions));
    }

    public EventHandler<PropertyFoundEventArgs>? PropertyFound;

    protected virtual void OnPropertyFound(AudioFileStreamProperty propertyID, ref AudioFileStreamPropertyFlag ioFlags)
    {
        var p = PropertyFound;
        if (p is not null)
        {
            var pf = new PropertyFoundEventArgs(propertyID, ioFlags);
            p(this, pf);
            ioFlags = pf.Flags;
        }
    }

    // [MonoPInvokeCallback(typeof(AudioFileStream_PropertyListenerProc))]
    private static void PropertyListener(IntPtr clientData, AudioFileStreamID audioFileStream,
        AudioFileStreamProperty propertyID, ref AudioFileStreamPropertyFlag ioFlags)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var afs = handle.Target as AudioFileStream;

        afs!.OnPropertyFound(propertyID, ref ioFlags);
    }

    public AudioFileStream(AudioFileType fileTypeHint)
    {
        IntPtr h;
        gch = GCHandle.Alloc(this);
        var code = AudioFileStreamOpen(GCHandle.ToIntPtr(gch), dPropertyListener, dInPackets, fileTypeHint, out h);
        if (code == 0)
        {
            handle = h;
            return;
        }

        throw new Exception($"Unable to create AudioFileStream, code: 0x{code:x}");
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamParseBytes(
        AudioFileStreamID inAudioFileStream,
        int inDataByteSize,
        IntPtr inData,
        uint inFlags);

    public AudioFileStreamStatus ParseBytes(int size, IntPtr data, bool discontinuity)
    {
        if (data == IntPtr.Zero)
            ThrowHelper.ThrowArgumentNullException(nameof(data));
        return LastError = AudioFileStreamParseBytes(handle, size, data, discontinuity ? (uint) 1 : (uint) 0);
    }

    public AudioFileStreamStatus ParseBytes(byte[] bytes, bool discontinuity)
    {
        if (bytes is null)
            ThrowHelper.ThrowArgumentNullException(nameof(bytes));
        unsafe
        {
            fixed (byte* bp = &bytes[0])
            {
                return LastError = AudioFileStreamParseBytes(handle, bytes.Length, (IntPtr) bp,
                    discontinuity ? (uint) 1 : (uint) 0);
            }
        }
    }

    public AudioFileStreamStatus ParseBytes(byte[] bytes, int offset, int count, bool discontinuity)
    {
        if (bytes is null)
            ThrowHelper.ThrowArgumentNullException(nameof(bytes));
        if (offset < 0)
            throw new ArgumentException("offset");
        if (count < 0)
            throw new ArgumentException("count");
        if (offset + count > bytes.Length)
            throw new ArgumentException("offset+count");

        unsafe
        {
            fixed (byte* bp = &bytes[0])
            {
                return LastError = AudioFileStreamParseBytes(handle, count, (IntPtr) (bp + offset),
                    discontinuity ? (uint) 1 : (uint) 0);
            }
        }
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamSeek(AudioFileStreamID inAudioFileStream,
        long inPacketOffset,
        out long outDataByteOffset,
        ref int ioFlags);

    public AudioFileStreamStatus Seek(long packetOffset, out long dataByteOffset, out bool isEstimate)
    {
        var v = 0;
        LastError = AudioFileStreamSeek(handle, packetOffset, out dataByteOffset, ref v);
        if (LastError != AudioFileStreamStatus.Ok)
            isEstimate = false;
        else
            isEstimate = (v & 1) == 1;

        return LastError;
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamGetPropertyInfo(
        AudioFileStreamID inAudioFileStream,
        AudioFileStreamProperty inPropertyID,
        out int outPropertyDataSize,
        [MarshalAs(UnmanagedType.I1)] out bool isWritable);

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamGetProperty(
        AudioFileStreamID inAudioFileStream,
        AudioFileStreamProperty inPropertyID,
        ref int ioPropertyDataSize,
        IntPtr outPropertyData);

    public bool GetProperty(AudioFileStreamProperty property, ref int dataSize, IntPtr outPropertyData)
    {
        if (outPropertyData == IntPtr.Zero)
            ThrowHelper.ThrowArgumentNullException(nameof(outPropertyData));
        return AudioFileStreamGetProperty(handle, property, ref dataSize, outPropertyData) == 0;
    }

    public IntPtr GetProperty(AudioFileStreamProperty property, out int size)
    {
        bool writable;

        LastError = AudioFileStreamGetPropertyInfo(handle, property, out size, out writable);
        if (LastError != 0)
            return IntPtr.Zero;

        var buffer = Marshal.AllocHGlobal(size);
        if (buffer == IntPtr.Zero)
            return IntPtr.Zero;

        LastError = AudioFileStreamGetProperty(handle, property, ref size, buffer);
        if (LastError == 0)
            return buffer;
        Marshal.FreeHGlobal(buffer);
        return IntPtr.Zero;
    }

    private int GetInt(AudioFileStreamProperty property)
    {
        unsafe
        {
            var val = 0;
            var size = 4;
            LastError = AudioFileStreamGetProperty(handle, property, ref size, (IntPtr) (&val));
            if (LastError == 0)
                return val;
            return 0;
        }
    }

    private double GetDouble(AudioFileStreamProperty property)
    {
        unsafe
        {
            double val = 0;
            var size = 8;
            LastError = AudioFileStreamGetProperty(handle, property, ref size, (IntPtr) (&val));
            if (LastError == 0)
                return val;
            return 0;
        }
    }

    private long GetLong(AudioFileStreamProperty property)
    {
        unsafe
        {
            long val = 0;
            var size = 8;
            LastError = AudioFileStreamGetProperty(handle, property, ref size, (IntPtr) (&val));
            if (LastError == 0)
                return val;
            return 0;
        }
    }

    private unsafe T? GetProperty<T>(AudioFileStreamProperty property) where T : struct
    {
        int size;
        bool writable;

        LastError = AudioFileStreamGetPropertyInfo(handle, property, out size, out writable);
        if (LastError != 0)
            return null;
        var buffer = Marshal.AllocHGlobal(size);
        if (buffer == IntPtr.Zero)
            return null;
        try
        {
            LastError = AudioFileStreamGetProperty(handle, property, ref size, buffer);
            if (LastError == 0) return (T) Marshal.PtrToStructure(buffer, typeof(T))!;

            return null;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamSetProperty(
        AudioFileStreamID inAudioFileStream,
        AudioFileStreamProperty inPropertyID,
        int inPropertyDataSize,
        IntPtr inPropertyData);

    public bool SetProperty(AudioFileStreamProperty property, int dataSize, IntPtr propertyData)
    {
        if (propertyData == IntPtr.Zero)
            ThrowHelper.ThrowArgumentNullException(nameof(propertyData));
        LastError = AudioFileStreamSetProperty(handle, property, dataSize, propertyData);
        return LastError == 0;
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern AudioFileStreamStatus AudioFileStreamClose(AudioFileStreamID inAudioFileStream);

    public bool ReadyToProducePackets => GetInt(AudioFileStreamProperty.ReadyToProducePackets) == 1;

    public AudioFileType FileType => (AudioFileType) GetInt(AudioFileStreamProperty.FileFormat);

    // ////[Advice ("Use 'DataFormat' instead.")]
    public AudioStreamBasicDescription StreamBasicDescription => DataFormat;

    public AudioStreamBasicDescription DataFormat =>
        GetProperty<AudioStreamBasicDescription>(AudioFileStreamProperty.DataFormat) ??
        default(AudioStreamBasicDescription);

    public unsafe AudioFormat[]? FormatList
    {
        get
        {
            int size;
            var r = GetProperty(AudioFileStreamProperty.FormatList, out size);
            if (r == IntPtr.Zero)
                return null;

            var records = (AudioFormat*) r;
            var itemSize = sizeof(AudioFormat);
            var items = size / itemSize;
            var ret = new AudioFormat [items];

            for (var i = 0; i < items; i++)
                ret[i] = records[i];

            Marshal.FreeHGlobal(r);
            return ret;
        }
    }

    public AudioFilePacketTableInfo? PacketTableInfo =>
        GetProperty<AudioFilePacketTableInfo>(AudioFileStreamProperty.PacketTableInfo);

    public byte[] MagicCookie
    {
        get
        {
            int size;
            var h = GetProperty(AudioFileStreamProperty.MagicCookieData, out size);
            if (h == IntPtr.Zero)
                return Array.Empty<byte>();

            var cookie = new byte [size];
            Marshal.Copy(h, cookie, 0, size);
            Marshal.FreeHGlobal(h);

            return cookie;
        }
    }

    public long DataByteCount => GetLong(AudioFileStreamProperty.AudioDataByteCount);

    public long DataPacketCount => GetLong(AudioFileStreamProperty.AudioDataPacketCount);

    public int MaximumPacketSize => GetInt(AudioFileStreamProperty.MaximumPacketSize);

    public long DataOffset => GetLong(AudioFileStreamProperty.DataOffset);

    public AudioChannelLayout? ChannelLayout
    {
        get
        {
            int size;
            var h = GetProperty(AudioFileStreamProperty.ChannelLayout, out size);
            if (h == IntPtr.Zero)
                return null;

            var layout = AudioChannelLayout.FromHandle(h);
            Marshal.FreeHGlobal(h);

            return layout;
        }
    }

    public long PacketToFrame(long packet)
    {
        AudioFramePacketTranslation buffer;
        buffer.Packet = packet;

        unsafe
        {
            var p = &buffer;
            var size = sizeof(AudioFramePacketTranslation);
            LastError = AudioFileStreamGetProperty(handle, AudioFileStreamProperty.PacketToFrame, ref size, (IntPtr) p);
            if (LastError == 0)
                return buffer.Frame;
            return -1;
        }
    }

    public long FrameToPacket(long frame, out int frameOffsetInPacket)
    {
        AudioFramePacketTranslation buffer;
        buffer.Frame = frame;

        unsafe
        {
            var p = &buffer;
            var size = sizeof(AudioFramePacketTranslation);
            LastError = AudioFileStreamGetProperty(handle, AudioFileStreamProperty.FrameToPacket, ref size, (IntPtr) p);
            if (LastError == 0)
            {
                frameOffsetInPacket = buffer.FrameOffsetInPacket;
                return buffer.Packet;
            }

            frameOffsetInPacket = 0;
            return -1;
        }
    }

    public long PacketToByte(long packet, out bool isEstimate)
    {
        AudioBytePacketTranslation buffer;
        buffer.Packet = packet;

        unsafe
        {
            var p = &buffer;
            var size = sizeof(AudioBytePacketTranslation);
            LastError = AudioFileStreamGetProperty(handle, AudioFileStreamProperty.PacketToByte, ref size, (IntPtr) p);
            if (LastError == 0)
            {
                isEstimate = (buffer.Flags & BytePacketTranslationFlags.IsEstimate) != 0;
                return buffer.Byte;
            }

            isEstimate = false;
            return -1;
        }
    }

    public long ByteToPacket(long byteval, out int byteOffsetInPacket, out bool isEstimate)
    {
        AudioBytePacketTranslation buffer;
        buffer.Byte = byteval;

        unsafe
        {
            var p = &buffer;
            var size = sizeof(AudioBytePacketTranslation);
            LastError = AudioFileStreamGetProperty(handle, AudioFileStreamProperty.ByteToPacket, ref size, (IntPtr) p);
            if (LastError == 0)
            {
                isEstimate = (buffer.Flags & BytePacketTranslationFlags.IsEstimate) != 0;
                byteOffsetInPacket = buffer.ByteOffsetInPacket;
                return buffer.Packet;
            }

            byteOffsetInPacket = 0;
            isEstimate = false;
            return -1;
        }
    }

    public int BitRate => GetInt(AudioFileStreamProperty.BitRate);

    public int PacketSizeUpperBound => GetInt(AudioFileStreamProperty.PacketSizeUpperBound);

    public double AverageBytesPerPacket => GetDouble(AudioFileStreamProperty.AverageBytesPerPacket);

    public AudioFileStreamStatus LastError { get; private set; }
}
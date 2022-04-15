// 
// AudioFile.cs:
//
// Authors:
//    Miguel de Icaza (miguel@xamarin.com)
//    Marek Safar (marek.safar@gmail.com)
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
using MacMusicPlayer.CoreFoundation;
using MacMusicPlayer.ObjCRuntime;
using AudioFileID = System.IntPtr;

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
    public class AudioFile : DisposableObject
    {
        internal AudioFile()
        {
            // This ctor is used by AudioSource that will set the handle later.
        }

#if !NETXXX
        protected internal AudioFile(bool x)
        {
        }
#endif

        // //[Preserve (Conditional = true)]
        internal AudioFile(NativeHandle handle, bool owns)
            : base(handle, owns)
        {
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileClose(AudioFileID handle);

        protected override void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero && Owns)
                AudioFileClose(Handle);
            base.Dispose(disposing);
        }

        public long Length => GetLong(AudioFileProperty.AudioDataByteCount);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileCreateWithURL(IntPtr cfurlref_infile, AudioFileType inFileType,
            ref AudioStreamBasicDescription inFormat, AudioFileFlags inFlags, out AudioFileID file_id);

        public static AudioFile? Create(string url, AudioFileType fileType, AudioStreamBasicDescription format,
            AudioFileFlags inFlags)
        {
            if (url is null)
                ThrowHelper.ThrowArgumentNullException(nameof(url));

            using (var cfurl = CFUrl.FromUrlString(url, null)!)
            {
                return Create(cfurl, fileType, format, inFlags);
            }
        }

        public static AudioFile? Create(CFUrl url, AudioFileType fileType, AudioStreamBasicDescription format,
            AudioFileFlags inFlags)
        {
            if (url is null)
                ThrowHelper.ThrowArgumentNullException(nameof(url));

            IntPtr h;

            if (AudioFileCreateWithURL(url.Handle, fileType, ref format, inFlags, out h) == 0)
                return new AudioFile(h, true);
            return null;
        }

        // public static AudioFile? Create (NSUrl url, AudioFileType fileType, AudioStreamBasicDescription format, AudioFileFlags inFlags)
        // {
        // 	if (url is null)
        // 		ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (url));
        //
        // 	IntPtr h;
        //
        // 	if (AudioFileCreateWithURL (url.Handle, fileType, ref format, inFlags, out h) == 0)
        // 		return new AudioFile (h, true);
        // 	return null;
        // }


        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioFileError AudioFileOpenURL(IntPtr cfurlref_infile, byte permissions,
            AudioFileType fileTypeHint, out IntPtr file_id);

        public static AudioFile? OpenRead(string url, AudioFileType fileTypeHint = 0)
        {
            return Open(url, AudioFilePermission.Read, fileTypeHint);
        }

        public static AudioFile? OpenRead(string url, out AudioFileError error, AudioFileType fileTypeHint = 0)
        {
            return Open(url, AudioFilePermission.Read, out error, fileTypeHint);
        }

        public static AudioFile? OpenRead(CFUrl url, AudioFileType fileTypeHint = 0)
        {
            return Open(url, AudioFilePermission.Read, fileTypeHint);
        }

        public static AudioFile? OpenRead(CFUrl url, out AudioFileError error, AudioFileType fileTypeHint = 0)
        {
            return Open(url, AudioFilePermission.Read, out error, fileTypeHint);
        }

        //
        // public static AudioFile? OpenRead (NSUrl url, AudioFileType fileTypeHint = 0)
        // {
        // 	return Open (url, AudioFilePermission.Read, fileTypeHint);
        // }
        //
        // public static AudioFile? OpenRead (NSUrl url, out AudioFileError error, AudioFileType fileTypeHint = 0)
        // {
        // 	return Open (url, AudioFilePermission.Read, out error, fileTypeHint);
        // }
        //
        public static AudioFile? Open(string url, AudioFilePermission permissions, AudioFileType fileTypeHint = 0)
        {
            AudioFileError error;
            return Open(url, permissions, out error, fileTypeHint);
        }

        public static AudioFile? Open(string url, AudioFilePermission permissions, out AudioFileError error,
            AudioFileType fileTypeHint = 0)
        {
            if (url is null)
                ThrowHelper.ThrowArgumentNullException(nameof(url));

            using (var cfurl = CFUrl.FromUrlString(url, null)!)
            {
                return Open(cfurl, permissions, out error, fileTypeHint);
            }
        }

        public static AudioFile? Open(CFUrl url, AudioFilePermission permissions, AudioFileType fileTypeHint = 0)
        {
            AudioFileError error;
            return Open(url, permissions, out error, fileTypeHint);
        }

        public static AudioFile? Open(CFUrl url, AudioFilePermission permissions, out AudioFileError error,
            AudioFileType fileTypeHint = 0)
        {
            if (url is null)
                ThrowHelper.ThrowArgumentNullException(nameof(url));

            return Open(url.Handle, permissions, fileTypeHint, out error);
        }

        // public static AudioFile? Open (NSUrl url, AudioFilePermission permissions, AudioFileType fileTypeHint = 0)
        // {
        // 	AudioFileError error;
        // 	return Open (url, permissions, out error, fileTypeHint);
        // }

        // public static AudioFile? Open (NSUrl url, AudioFilePermission permissions, out AudioFileError error, AudioFileType fileTypeHint = 0)
        // {
        // 	if (url is null)
        // 		ObjCRuntime.ThrowHelper.ThrowArgumentNullException (nameof (url));
        //
        // 	return Open (url.Handle, permissions, fileTypeHint, out error);
        // }

        private static AudioFile? Open(IntPtr urlHandle, AudioFilePermission permissions, AudioFileType fileTypeHint,
            out AudioFileError error)
        {
            IntPtr file;
            error = AudioFileOpenURL(urlHandle, (byte) permissions, fileTypeHint, out file);
            if (error == AudioFileError.Success)
                return new AudioFile(file, true);
            return null;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileOptimize(AudioFileID handle);

        public bool Optimize()
        {
            return AudioFileOptimize(Handle) == 0;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileReadBytes(AudioFileID inAudioFile,
            [MarshalAs(UnmanagedType.I1)] bool useCache, long startingByte, ref int numBytes, IntPtr outBuffer);

        public int Read(long startingByte, byte[] buffer, int offset, int count, bool useCache)
        {
            if (offset < 0)
                throw new ArgumentException(nameof(offset), "<0");
            if (count < 0)
                throw new ArgumentException(nameof(count), "<0");
            if (startingByte < 0)
                throw new ArgumentException(nameof(startingByte), "<0");
            var len = buffer.Length;
            if (offset > len)
                throw new ArgumentException("destination offset is beyond array size");
            // reordered to avoid possible integer overflow
            if (offset > len - count)
                throw new ArgumentException("Reading would overrun buffer");

            unsafe
            {
                fixed (byte* p = &buffer[offset])
                {
                    var res = AudioFileReadBytes(Handle, useCache, startingByte, ref count, (IntPtr) p);

                    if (res == (int) AudioFileError.EndOfFile)
                        return count <= 0 ? -1 : count;

                    if (res == 0)
                        return count;

                    return -1;
                }
            }
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileWriteBytes(AudioFileID audioFile,
            [MarshalAs(UnmanagedType.I1)] bool useCache, long startingByte, ref int numBytes, IntPtr buffer);

        public int Write(long startingByte, byte[] buffer, int offset, int count, bool useCache)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "< 0");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "< 0");
            if (offset > buffer.Length - count)
                throw new ArgumentException("Reading would overrun buffer");

            unsafe
            {
                fixed (byte* p = &buffer[offset])
                {
                    if (AudioFileWriteBytes(Handle, useCache, startingByte, ref count, (IntPtr) p) == 0)
                        return count;
                    else
                        return -1;
                }
            }
        }

        public int Write(long startingByte, byte[] buffer, int offset, int count, bool useCache, out int errorCode)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "< 0");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "< 0");
            if (offset > buffer.Length - count)
                throw new ArgumentException("Reading would overrun buffer");

            unsafe
            {
                fixed (byte* p = &buffer[offset])
                {
                    errorCode = AudioFileWriteBytes(Handle, useCache, startingByte, ref count, (IntPtr) p);
                    if (errorCode == 0)
                        return count;
                    else
                        return -1;
                }
            }
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern unsafe int AudioFileReadPacketData(
            AudioFileID audioFile, [MarshalAs(UnmanagedType.I1)] bool useCache, ref int numBytes,
            AudioStreamPacketDescription* packetDescriptions, long inStartingPacket, ref int numPackets,
            IntPtr outBuffer);

        public AudioStreamPacketDescription[]? ReadPacketData(long inStartingPacket, int nPackets, byte[] buffer)
        {
            AudioFileError error;
            return ReadPacketData(inStartingPacket, nPackets, buffer, out error);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(long inStartingPacket, int nPackets, byte[] buffer,
            out AudioFileError error)
        {
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            var count = buffer.Length;
            return RealReadPacketData(false, inStartingPacket, ref nPackets, buffer, 0, ref count, out error);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, int nPackets,
            byte[] buffer, int offset, int count)
        {
            return ReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, offset, ref count);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, int nPackets,
            byte[] buffer, int offset, int count, out AudioFileError error)
        {
            return ReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, offset, ref count, out error);
        }

        internal static AudioStreamPacketDescription[]? PacketDescriptionFrom(int nPackets, IntPtr b)
        {
            if (b == IntPtr.Zero)
                return new AudioStreamPacketDescription [0];

            var ret = new AudioStreamPacketDescription [nPackets];
            var p = 0;
            for (var i = 0; i < nPackets; i++)
            {
                ret[i].StartOffset = Marshal.ReadInt64(b, p);
                ret[i].VariableFramesInPacket = Marshal.ReadInt32(b, p + 8);
                ret[i].DataByteSize = Marshal.ReadInt32(b, p + 12);
                p += 16;
            }

            return ret;
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, ref int nPackets,
            byte[] buffer, int offset, ref int count)
        {
            AudioFileError error;
            return ReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, offset, ref count, out error);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, ref int nPackets,
            byte[] buffer, int offset, ref int count, out AudioFileError error)
        {
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentException(nameof(offset), "<0");
            if (count < 0)
                throw new ArgumentException(nameof(count), "<0");
            var len = buffer.Length;
            if (offset > len)
                throw new ArgumentException("destination offset is beyond array size");
            // reordered to avoid possible integer overflow
            if (offset > len - count)
                throw new ArgumentException("Reading would overrun buffer");
            return RealReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, offset, ref count, out error);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, ref int nPackets,
            IntPtr buffer, ref int count)
        {
            AudioFileError error;
            return ReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, ref count, out error);
        }

        public AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket, ref int nPackets,
            IntPtr buffer, ref int count, out AudioFileError error)
        {
            var descriptions = new AudioStreamPacketDescription [nPackets];
            return ReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, ref count, out error, descriptions);
        }

        public unsafe AudioStreamPacketDescription[]? ReadPacketData(bool useCache, long inStartingPacket,
            ref int nPackets, IntPtr buffer, ref int count, out AudioFileError error,
            AudioStreamPacketDescription[] descriptions)
        {
            if (buffer == IntPtr.Zero)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            if (count < 0)
                throw new ArgumentException(nameof(count), "<0");
            if (descriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(descriptions));

            fixed (AudioStreamPacketDescription* p = descriptions)
            {
                return RealReadPacketData(useCache, inStartingPacket, ref nPackets, buffer, ref count, out error,
                    descriptions);
            }
        }

        private unsafe AudioStreamPacketDescription[]? RealReadPacketData(bool useCache, long inStartingPacket,
            ref int nPackets, byte[] buffer, int offset, ref int count, out AudioFileError error)
        {
            var descriptions = new AudioStreamPacketDescription [nPackets];
            fixed (byte* bop = &buffer[offset])
            {
                fixed (AudioStreamPacketDescription* p = descriptions)
                {
                    return RealReadPacketData(useCache, inStartingPacket, ref nPackets, (IntPtr) bop, ref count,
                        out error, descriptions);
                }
            }
        }

        private unsafe AudioStreamPacketDescription[]? RealReadPacketData(bool useCache, long inStartingPacket,
            ref int nPackets, IntPtr buffer, ref int count, out AudioFileError error,
            AudioStreamPacketDescription[] descriptions)
        {
            int r;
            fixed (AudioStreamPacketDescription* pdesc = &descriptions[0])
            {
                r = AudioFileReadPacketData(Handle, useCache, ref count, pdesc, inStartingPacket, ref nPackets, buffer);
            }

            error = (AudioFileError) r;

            if (r == (int) AudioFileError.EndOfFile)
            {
                if (count == 0)
                    return null;
            }
            else if (r != 0)
            {
                return null;
            }

            if (descriptions.Length > nPackets) // Didn't read as many descriptions as we requested.
                Array.Resize(ref descriptions, nPackets);

            return descriptions;
        }

        public AudioStreamPacketDescription[]? ReadFixedPackets(long inStartingPacket, int nPackets, byte[] buffer)
        {
            AudioFileError error;
            return ReadFixedPackets(inStartingPacket, nPackets, buffer, out error);
        }

        public AudioStreamPacketDescription[]? ReadFixedPackets(long inStartingPacket, int nPackets, byte[] buffer,
            out AudioFileError error)
        {
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            return RealReadFixedPackets(false, inStartingPacket, nPackets, buffer, 0, buffer.Length, out error);
        }

        public AudioStreamPacketDescription[]? ReadFixedPackets(bool useCache, long inStartingPacket, int nPackets,
            byte[] buffer, int offset, int count)
        {
            AudioFileError error;
            return ReadFixedPackets(useCache, inStartingPacket, nPackets, buffer, offset, count, out error);
        }

        public AudioStreamPacketDescription[]? ReadFixedPackets(bool useCache, long inStartingPacket, int nPackets,
            byte[] buffer, int offset, int count, out AudioFileError error)
        {
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentException(nameof(offset), "<0");
            if (count < 0)
                throw new ArgumentException(nameof(count), "<0");
            var len = buffer.Length;
            if (offset > len)
                throw new ArgumentException("destination offset is beyond array size");
            // reordered to avoid possible integer overflow
            if (offset > len - count)
                throw new ArgumentException("Reading would overrun buffer");
            return RealReadFixedPackets(useCache, inStartingPacket, nPackets, buffer, offset, count, out error);
        }

        private unsafe AudioStreamPacketDescription[]? RealReadFixedPackets(bool useCache, long inStartingPacket,
            int nPackets, byte[] buffer, int offset, int count, out AudioFileError error)
        {
            var descriptions = new AudioStreamPacketDescription [nPackets];
            fixed (byte* bop = &buffer[offset])
            {
                int r;
                fixed (AudioStreamPacketDescription* pdesc = &descriptions[0])
                {
                    r = AudioFileReadPacketData(Handle, useCache, ref count, pdesc, inStartingPacket, ref nPackets,
                        (IntPtr) bop);
                }

                error = (AudioFileError) r;
                if (r == (int) AudioFileError.EndOfFile)
                {
                    if (count == 0)
                        return null;
                }
                else if (r != 0)
                {
                    return null;
                }
            }

            return descriptions;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioFileError AudioFileWritePackets(
            AudioFileID audioFile, [MarshalAs(UnmanagedType.I1)] bool useCache, int inNumBytes,
            AudioStreamPacketDescription[]? inPacketDescriptions,
            long inStartingPacket, ref int numPackets, IntPtr buffer);

        public int WritePackets(bool useCache, long startingPacket, int numPackets, IntPtr buffer, int byteCount)
        {
            if (buffer == IntPtr.Zero)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));

            if (AudioFileWritePackets(Handle, useCache, byteCount, null, startingPacket, ref numPackets, buffer) == 0)
                return numPackets;

            return -1;
        }

        public int WritePackets(bool useCache, long startingPacket, AudioStreamPacketDescription[] packetDescriptions,
            IntPtr buffer, int byteCount)
        {
            if (packetDescriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(packetDescriptions));
            if (buffer == IntPtr.Zero)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            var nPackets = packetDescriptions.Length;
            if (AudioFileWritePackets(Handle, useCache, byteCount, packetDescriptions, startingPacket, ref nPackets,
                    buffer) == 0)
                return nPackets;
            return -1;
        }

        public unsafe int WritePackets(bool useCache, long startingPacket,
            AudioStreamPacketDescription[] packetDescriptions, byte[] buffer, int offset, int byteCount)
        {
            if (packetDescriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(packetDescriptions));
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "< 0");
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount), "< 0");
            if (offset > buffer.Length - byteCount)
                throw new ArgumentException("Reading would overrun buffer");

            var nPackets = packetDescriptions.Length;
            fixed (byte* bop = &buffer[offset])
            {
                if (AudioFileWritePackets(Handle, useCache, byteCount, packetDescriptions, startingPacket, ref nPackets,
                        (IntPtr) bop) == 0)
                    return nPackets;
                return -1;
            }
        }

        public int WritePackets(bool useCache, long startingPacket, AudioStreamPacketDescription[] packetDescriptions,
            IntPtr buffer, int byteCount, out int errorCode)
        {
            if (packetDescriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(packetDescriptions));
            if (buffer == IntPtr.Zero)
                throw new ArgumentException(nameof(buffer));
            var nPackets = packetDescriptions.Length;

            errorCode = (int) AudioFileWritePackets(Handle, useCache, byteCount, packetDescriptions, startingPacket,
                ref nPackets, buffer);
            if (errorCode == 0)
                return nPackets;
            return -1;
        }

        public unsafe int WritePackets(bool useCache, long startingPacket,
            AudioStreamPacketDescription[] packetDescriptions, byte[] buffer, int offset, int byteCount,
            out int errorCode)
        {
            if (packetDescriptions is null)
                ThrowHelper.ThrowArgumentNullException(nameof(packetDescriptions));
            if (buffer is null)
                ThrowHelper.ThrowArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), "< 0");
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount), "< 0");
            if (offset > buffer.Length - byteCount)
                throw new ArgumentException("Reading would overrun buffer");

            var nPackets = packetDescriptions.Length;
            fixed (byte* bop = &buffer[offset])
            {
                errorCode = (int) AudioFileWritePackets(Handle, useCache, byteCount, packetDescriptions, startingPacket,
                    ref nPackets, (IntPtr) bop);
                if (errorCode == 0)
                    return nPackets;
                return -1;
            }
        }

        public AudioFileError WritePackets(bool useCache, int numBytes,
            AudioStreamPacketDescription[] packetDescriptions, long startingPacket, ref int numPackets, IntPtr buffer)
        {
            if (buffer == IntPtr.Zero)
                throw new ArgumentException("buffer");

            return AudioFileWritePackets(Handle, useCache, numBytes, packetDescriptions, startingPacket, ref numPackets,
                buffer);
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileCountUserData(AudioFileID handle, uint userData, out int count);

        public int CountUserData(uint userData)
        {
            int count;
            if (AudioFileCountUserData(Handle, userData, out count) == 0)
                return count;
            return -1;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileGetUserDataSize(AudioFileID audioFile, uint userDataID, int index,
            out int userDataSize);

        public int GetUserDataSize(uint userDataId, int index)
        {
            int ds;

            if (AudioFileGetUserDataSize(Handle, userDataId, index, out ds) == 0)
                return -1;
            return ds;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileGetUserData(AudioFileID audioFile, int userDataID, int index,
            ref int userDataSize, IntPtr userData);

        public int GetUserData(int userDataID, int index, ref int size, IntPtr userData)
        {
            return AudioFileGetUserData(Handle, userDataID, index, ref size, userData);
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileSetUserData(AudioFileID inAudioFile, int userDataID, int index,
            int userDataSize, IntPtr userData);

        public int SetUserData(int userDataId, int index, int userDataSize, IntPtr userData)
        {
            if (userData == IntPtr.Zero)
                ThrowHelper.ThrowArgumentNullException(nameof(userData));
            return AudioFileSetUserData(Handle, userDataId, index, userDataSize, userData);
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileRemoveUserData(AudioFileID audioFile, int userDataID, int index);

        public int RemoveUserData(int userDataId, int index)
        {
            return AudioFileRemoveUserData(Handle, userDataId, index);
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileGetPropertyInfo(AudioFileID audioFile, AudioFileProperty propertyID,
            out int outDataSize, out int isWritable);

        public bool GetPropertyInfo(AudioFileProperty property, out int size, out int writable)
        {
            return AudioFileGetPropertyInfo(Handle, property, out size, out writable) == 0;
        }

        public bool IsPropertyWritable(AudioFileProperty property)
        {
            int writable;
            int size;
            return AudioFileGetPropertyInfo(Handle, property, out size, out writable) == 0 && writable != 0;
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern int AudioFileGetProperty(AudioFileID audioFile, AudioFileProperty property,
            ref int dataSize, IntPtr outdata);

        public bool GetProperty(AudioFileProperty property, ref int dataSize, IntPtr outdata)
        {
            return AudioFileGetProperty(Handle, property, ref dataSize, outdata) == 0;
        }

        public IntPtr GetProperty(AudioFileProperty property, out int size)
        {
            int writable;

            var r = AudioFileGetPropertyInfo(Handle, property, out size, out writable);
            if (r != 0)
                return IntPtr.Zero;

            var buffer = Marshal.AllocHGlobal(size);
            if (buffer == IntPtr.Zero)
                return IntPtr.Zero;

            r = AudioFileGetProperty(Handle, property, ref size, buffer);
            if (r == 0)
                return buffer;
            Marshal.FreeHGlobal(buffer);
            return IntPtr.Zero;
        }

        private unsafe T? GetProperty<T>(AudioFileProperty property) where T : struct
        {
            int size, writable;

            if (AudioFileGetPropertyInfo(Handle, property, out size, out writable) != 0)
                return null;
            var buffer = Marshal.AllocHGlobal(size);
            if (buffer == IntPtr.Zero)
                return null;
            try
            {
                var ptype = typeof(T);
                var r = AudioFileGetProperty(Handle, property, ref size, buffer);
                switch (ptype.Name)
                {
                    case nameof(AudioFilePacketTableInfo):
                        PacketTableInfoStatus = (AudioFileError) r;
                        break;
                    case nameof(AudioStreamBasicDescription):
                        StreamBasicDescriptionStatus = (AudioFileError) r;
                        break;
                }

                if (r == 0) return Marshal.PtrToStructure<T>(buffer)!;

                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        private int GetInt(AudioFileProperty property)
        {
            unsafe
            {
                var val = 0;
                var size = 4;
                if (AudioFileGetProperty(Handle, property, ref size, (IntPtr) (&val)) == 0)
                    return val;
                return 0;
            }
        }

        private IntPtr GetIntPtr(AudioFileProperty property)
        {
            unsafe
            {
                var val = IntPtr.Zero;
                var size = sizeof(IntPtr);
                if (AudioFileGetProperty(Handle, property, ref size, (IntPtr) (&val)) == 0)
                    return val;
                return IntPtr.Zero;
            }
        }

        private double GetDouble(AudioFileProperty property)
        {
            unsafe
            {
                double val = 0;
                var size = 8;
                if (AudioFileGetProperty(Handle, property, ref size, (IntPtr) (&val)) == 0)
                    return val;
                return 0;
            }
        }

        private long GetLong(AudioFileProperty property)
        {
            unsafe
            {
                long val = 0;
                var size = 8;
                if (AudioFileGetProperty(Handle, property, ref size, (IntPtr) (&val)) == 0)
                    return val;
                return 0;
            }
        }

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioFileError AudioFileSetProperty(AudioFileID audioFile, AudioFileProperty property,
            int dataSize, IntPtr propertyData);

        [DllImport(Constants.AudioToolboxLibrary)]
        private static extern AudioFileError AudioFileSetProperty(AudioFileID audioFile, AudioFileProperty property,
            int dataSize, ref AudioFilePacketTableInfo propertyData);

        public bool SetProperty(AudioFileProperty property, int dataSize, IntPtr propertyData)
        {
            if (propertyData == IntPtr.Zero)
                ThrowHelper.ThrowArgumentNullException(nameof(propertyData));
            return AudioFileSetProperty(Handle, property, dataSize, propertyData) == 0;
        }

        private void SetInt(AudioFileProperty property, int value)
        {
            unsafe
            {
                AudioFileSetProperty(Handle, property, 4, (IntPtr) (&value));
            }
        }

        private unsafe AudioFileError SetDouble(AudioFileProperty property, double value)
        {
            return AudioFileSetProperty(Handle, property, sizeof(double), (IntPtr) (&value));
        }

        public AudioFileType FileType => (AudioFileType) GetInt(AudioFileProperty.FileFormat);

        // //[Advice ("Use 'DataFormat' instead.")]
        public AudioStreamBasicDescription StreamBasicDescription =>
            GetProperty<AudioStreamBasicDescription>(AudioFileProperty.DataFormat) ??
            default(AudioStreamBasicDescription);

        public AudioFileError StreamBasicDescriptionStatus { get; private set; }

        public AudioStreamBasicDescription? DataFormat =>
            GetProperty<AudioStreamBasicDescription>(AudioFileProperty.DataFormat);

        public AudioFormat[]? AudioFormats
        {
            get
            {
                unsafe
                {
                    int size;
                    var r = GetProperty(AudioFileProperty.FormatList, out size);
                    var records = (AudioFormat*) r;
                    if (r == IntPtr.Zero)
                        return null;
                    var itemSize = sizeof(AudioFormat);
                    var items = size / itemSize;
                    var ret = new AudioFormat [items];

                    for (var i = 0; i < items; i++)
                        ret[i] = records[i];

                    Marshal.FreeHGlobal(r);
                    return ret;
                }
            }
        }

        public bool IsOptimized => GetInt(AudioFileProperty.IsOptimized) == 1;

        public byte[] MagicCookie
        {
            get
            {
                int size;
                var h = GetProperty(AudioFileProperty.MagicCookieData, out size);
                if (h == IntPtr.Zero)
                    return Array.Empty<byte>();

                var cookie = new byte [size];
                Marshal.Copy(h, cookie, 0, size);
                Marshal.FreeHGlobal(h);

                return cookie;
            }

            set
            {
                if (value is null)
                    ThrowHelper.ThrowArgumentNullException(nameof(value));

                unsafe
                {
                    fixed (byte* bp = &value[0])
                    {
                        SetProperty(AudioFileProperty.MagicCookieData, value.Length, (IntPtr) bp);
                    }
                }
            }
        }

        public long DataPacketCount => GetLong(AudioFileProperty.AudioDataPacketCount);

        public int MaximumPacketSize => GetInt(AudioFileProperty.MaximumPacketSize);

        public long DataOffset => GetLong(AudioFileProperty.DataOffset);

        // public NSData? AlbumArtwork {
        // 	get {
        // 		return Runtime.GetNSObject<NSData> (GetIntPtr (AudioFileProperty.AlbumArtwork));
        // 	}
        // }

        public AudioChannelLayout? ChannelLayout
        {
            get
            {
                int size;
                var h = GetProperty(AudioFileProperty.ChannelLayout, out size);
                if (h == IntPtr.Zero)
                    return null;

                var layout = AudioChannelLayout.FromHandle(h);
                Marshal.FreeHGlobal(h);

                return layout;
            }
        }

        public bool DeferSizeUpdates
        {
            get => GetInt(AudioFileProperty.DeferSizeUpdates) == 1;
            set => SetInt(AudioFileProperty.DeferSizeUpdates, value ? 1 : 0);
        }

        public int BitRate => GetInt(AudioFileProperty.BitRate);

        public double EstimatedDuration => GetDouble(AudioFileProperty.EstimatedDuration);

        public int PacketSizeUpperBound => GetInt(AudioFileProperty.PacketSizeUpperBound);

        public double ReserveDuration => GetDouble(AudioFileProperty.ReserveDuration);

        public AudioFileMarkerList? MarkerList
        {
            get
            {
                int size;
                int writable;
                var res = GetPropertyInfo(AudioFileProperty.MarkerList, out size, out writable);
                if (size == 0)
                    return null;

                var ptr = Marshal.AllocHGlobal(size);
                if (AudioFileGetProperty(Handle, AudioFileProperty.MarkerList, ref size, (IntPtr) ptr) != 0)
                {
                    Marshal.FreeHGlobal(ptr);
                    return null;
                }

                return new AudioFileMarkerList(ptr, true);
            }
        }

        public AudioFileRegionList? RegionList
        {
            get
            {
                int size;
                int writable;
                var res = GetPropertyInfo(AudioFileProperty.RegionList, out size, out writable);
                if (size == 0)
                    return null;

                var ptr = Marshal.AllocHGlobal(size);
                if (AudioFileGetProperty(Handle, AudioFileProperty.RegionList, ref size, (IntPtr) ptr) != 0)
                {
                    Marshal.FreeHGlobal(ptr);
                    return null;
                }

                return new AudioFileRegionList(ptr, true);
            }
        }

        public AudioFileError PacketTableInfoStatus { get; private set; }

        public unsafe AudioFilePacketTableInfo? PacketTableInfo
        {
            get => GetProperty<AudioFilePacketTableInfo>(AudioFileProperty.PacketTableInfo);
            set
            {
                if (value is null)
                    ThrowHelper.ThrowArgumentNullException(nameof(value));

                var afpti = value.Value;
                var res = AudioFileSetProperty(Handle, AudioFileProperty.PacketTableInfo,
                    sizeof(AudioFilePacketTableInfo), ref afpti);
                if (res != 0)
                    throw new ArgumentException(res.ToString());
            }
        }

        public unsafe AudioFileChunkType[]? ChunkIDs
        {
            get
            {
                int size;
                int writable;
                var res = GetPropertyInfo(AudioFileProperty.ChunkIDs, out size, out writable);
                if (size == 0)
                    return null;

                var data = new AudioFileChunkType[size / sizeof(AudioFileChunkType)];
                fixed (AudioFileChunkType* ptr = data)
                {
                    if (AudioFileGetProperty(Handle, AudioFileProperty.ChunkIDs, ref size, (IntPtr) ptr) != 0)
                        return null;

                    return data;
                }
            }
        }

        public unsafe byte[]? ID3Tag
        {
            get
            {
                int size;
                int writable;
                var res = GetPropertyInfo(AudioFileProperty.ID3Tag, out size, out writable);
                if (size == 0)
                    return null;

                var data = new byte[size];
                fixed (byte* ptr = data)
                {
                    if (AudioFileGetProperty(Handle, AudioFileProperty.ID3Tag, ref size, (IntPtr) ptr) != 0)
                        return null;

                    return data;
                }
            }
        }

        // public AudioFileInfoDictionary? InfoDictionary {
        // 	get {
        // 		var ptr = GetIntPtr (AudioFileProperty.InfoDictionary);
        // 		if (ptr == IntPtr.Zero)
        // 			return null;
        //
        // 		return new AudioFileInfoDictionary(new NSMutableDictionary (ptr, true));
        // 	}
        // }		

        public long PacketToFrame(long packet)
        {
            AudioFramePacketTranslation buffer;
            buffer.Packet = packet;

            unsafe
            {
                var p = &buffer;
                var size = sizeof(AudioFramePacketTranslation);
                if (AudioFileGetProperty(Handle, AudioFileProperty.PacketToFrame, ref size, (IntPtr) p) == 0)
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
                if (AudioFileGetProperty(Handle, AudioFileProperty.FrameToPacket, ref size, (IntPtr) p) == 0)
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
                if (AudioFileGetProperty(Handle, AudioFileProperty.PacketToByte, ref size, (IntPtr) p) == 0)
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
                if (AudioFileGetProperty(Handle, AudioFileProperty.ByteToPacket, ref size, (IntPtr) p) == 0)
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
    }
//
// #if NETXXX
// 	[SupportedOSPlatform ("ios")]
// 	[SupportedOSPlatform ("maccatalyst")]
// 	[SupportedOSPlatform ("macos")]
// 	[SupportedOSPlatform ("tvos")]
// #endif
// 	public class AudioFileInfoDictionary : DictionaryContainer
// 	{
// 		internal AudioFileInfoDictionary (NSDictionary dict)
// 			: base (dict)
// 		{
// 		}
//
// 		public string? Album {
// 			get {
// 				return GetStringValue ("album");
// 			}
// 		}
//
// 		public string? ApproximateDurationInSeconds {
// 			get {
// 				return GetStringValue ("approximate duration in seconds");
// 			}
// 		}
//
// 		public string? Artist {
// 			get {
// 				return GetStringValue ("artist");
// 			}
// 		}
//
// 		public string? ChannelLayout	 {
// 			get {
// 				return GetStringValue ("channel layout");				
// 			}
// 		}
//
// 		public string? Composer {
// 			get {
// 				return GetStringValue ("composer");
// 			}
// 		}
//
// 		public string? Comments {
// 			get {
// 				return GetStringValue ("comments");
// 			}
// 		}
//
// 		public string? Copyright {
// 			get {
// 				return GetStringValue ("copyright");
// 			}
// 		}
//
// 		public string? EncodingApplication {
// 			get {
// 				return GetStringValue ("encoding application");
// 			}
// 		}
//
// 		public string? Genre {
// 			get {
// 				return GetStringValue ("genre");
// 			}
// 		}
//
// 		public string? ISRC {
// 			get {
// 				return GetStringValue ("ISRC");
// 			}
// 		}
//
// 		public string? KeySignature {
// 			get {
// 				return GetStringValue ("key signature");
// 			}
// 		}
//
// 		public string? Lyricist {
// 			get {
// 				return GetStringValue ("lyricist");
// 			}
// 		}
//
// 		public string? NominalBitRate {
// 			get {
// 				return GetStringValue ("nominal bit rate");				
// 			}
// 		}
//
// 		public string? RecordedDate {
// 			get {
// 				return GetStringValue ("recorded date");
// 			}
// 		}
//
// 		public string? SourceBitDepth {
// 			get {
// 				return GetStringValue ("source bit depth");
// 			}
// 		}
//
// 		public string? SourceEncoder {
// 			get {
// 				return GetStringValue ("source encoder");
// 			}
// 		}
//
// 		public string? SubTitle {
// 			get {
// 				return GetStringValue ("subtitle");
// 			}
// 		}
//
// 		public string? Tempo {
// 			get {
// 				return GetStringValue ("tempo");
// 			}
// 		}
//
// 		public string? TimeSignature {
// 			get {
// 				return GetStringValue ("time signature");
// 			}
// 		}
//
// 		public string? Title {
// 			get {
// 				return GetStringValue ("title");
// 			}
// 		}
//
// 		public string? TrackNumber {
// 			get {
// 				return GetStringValue ("track number");
// 			}
// 		}
//
// 		public string? Year {
// 			get {
// 				return GetStringValue ("year");
// 			}
// 		}
// 	}

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
}
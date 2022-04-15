using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioFileRegion
{
    private readonly IntPtr ptr;
    //
    // Wraps
    //
    // struct AudioFileRegion
    // {
    //	UInt32				mRegionID;
    //	CFStringRef			mName;
    //	UInt32				mFlags;
    //	UInt32				mNumberMarkers;
    //	AudioFileMarker		mMarkers[1]; // this is a variable length array of mNumberMarkers elements
    // }

    public AudioFileRegion(IntPtr ptr)
    {
        this.ptr = ptr;
    }

    public uint RegionID => (uint) Marshal.ReadInt32(ptr);

    public string? Name => CfString.FromHandle(NameWeak);

    internal IntPtr NameWeak => Marshal.ReadIntPtr(ptr, sizeof(uint));

    public unsafe AudioFileRegionFlags Flags =>
        (AudioFileRegionFlags) Marshal.ReadInt32(ptr, sizeof(uint) + sizeof(IntPtr));

    public unsafe int Count => Marshal.ReadInt32(ptr, 2 * sizeof(uint) + sizeof(IntPtr));

    public AudioFileMarker this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            unsafe
            {
                var ptr = (AudioFileMarker*) this.ptr + 3 * sizeof(int) + sizeof(IntPtr) +
                          index * sizeof(AudioFileMarker);
                return *ptr;
            }
        }
    }

    internal unsafe int TotalSize => Count * sizeof(AudioFileMarker);
}
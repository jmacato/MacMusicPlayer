using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;

namespace MacMusicPlayer.AudioToolbox;

public class AudioFileRegionList : IDisposable
{
    private IntPtr ptr;
    private readonly bool owns;

    public AudioFileRegionList(IntPtr ptr, bool owns)
    {
        this.ptr = ptr;
        this.owns = owns;
    }

    ~AudioFileRegionList()
    {
        Dispose(false);
    }

    public SmpteTimeType SmpteTimeType => (SmpteTimeType) Marshal.ReadInt32(ptr);

    public uint Count => (uint) Marshal.ReadInt32(ptr, sizeof(uint));

    public AudioFileRegion this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            //
            // Decodes
            //
            // struct AudioFileRegionList
            // {
            //	UInt32				mSMPTE_TimeType;
            //	UInt32				mNumberRegions;
            //	AudioFileRegion		mRegions[1]; // this is a variable length array of mNumberRegions elements
            // }
            //
            unsafe
            {
                var ptr = (byte*) this.ptr + 2 * sizeof(uint);
                for (var i = 0; i < index; ++i)
                {
                    var region = new AudioFileRegion((IntPtr) ptr);
                    ptr += region.TotalSize;
                }

                return new AudioFileRegion((IntPtr) ptr);
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!owns || ptr == IntPtr.Zero)
            return;

        for (var i = 0; i < Count; ++i) CfObject.CFRelease(this[i].NameWeak);

        Marshal.FreeHGlobal(ptr);
        ptr = IntPtr.Zero;
        GC.SuppressFinalize(this);
    }
}
using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;

namespace MacMusicPlayer.AudioToolbox;

public class AudioFileMarkerList : IDisposable
{
    private IntPtr ptr;
    private readonly bool owns;

    public AudioFileMarkerList(IntPtr ptr, bool owns)
    {
        this.ptr = ptr;
        this.owns = owns;
    }

    ~AudioFileMarkerList()
    {
        Dispose(false);
    }

    public SmpteTimeType SmpteTimeType => (SmpteTimeType) Marshal.ReadInt32(ptr);

    public uint Count => (uint) Marshal.ReadInt32(ptr, 4);

    public AudioFileMarker this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            //
            // Decodes
            //
            // struct AudioFileMarkerList
            // {
            //	UInt32				mSMPTE_TimeType;
            //	UInt32				mNumberMarkers;
            //	AudioFileMarker		mMarkers[1]; // this is a variable length array of mNumberMarkers elements
            // }
            //
            unsafe
            {
                var ptr = (AudioFileMarker*) this.ptr + 2 * sizeof(int) + index * sizeof(AudioFileMarker);
                return *ptr;
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

        for (var i = 0; i < Count; ++i) CfObject.CFRelease(this[i].Name_cfstringref);

        Marshal.FreeHGlobal(ptr);
        ptr = IntPtr.Zero;
        GC.SuppressFinalize(this);
    }
}
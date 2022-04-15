using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioChannelDescription
{
    public AudioChannelLabel Label;
    public AudioChannelFlags Flags;
    private float Coord0, Coord1, Coord2;

    public float[] Coords
    {
        get { return new float [3] {Coord0, Coord1, Coord2}; }
        set
        {
            if (value.Length != 3)
                throw new ArgumentException("Must contain three floats");
            Coord0 = value[0];
            Coord1 = value[1];
            Coord2 = value[2];
        }
    }

    public unsafe string? Name
    {
        get
        {
            IntPtr sptr;
            var size = sizeof(IntPtr);
            var ptr_size = sizeof(AudioChannelDescription);
            var ptr = ToPointer();

            var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ChannelName, ptr_size, ptr,
                ref size, out sptr);
            Marshal.FreeHGlobal(ptr);
            if (res != 0)
                return null;

            return new CfString(sptr, true);
        }
    }

    public unsafe string? ShortName
    {
        get
        {
            IntPtr sptr;
            var size = sizeof(IntPtr);
            var ptr_size = sizeof(AudioChannelDescription);
            var ptr = ToPointer();

            var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ChannelShortName, ptr_size,
                ptr, ref size, out sptr);
            Marshal.FreeHGlobal(ptr);
            if (res != 0)
                return null;

            return new CfString(sptr, true);
        }
    }

    internal unsafe IntPtr ToPointer()
    {
        var ptr = (AudioChannelDescription*) Marshal.AllocHGlobal(sizeof(AudioChannelLabel) +
                                                                  sizeof(AudioChannelFlags) + 3 * sizeof(float));
        *ptr = this;
        return (IntPtr) ptr;
    }

    public override string ToString()
    {
        return $"[id={Label} {Flags} - {Coords[0]},{Coords[1]},{Coords[2]}";
    }
}
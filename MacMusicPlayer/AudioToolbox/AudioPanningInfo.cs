using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioToolbox;

public class AudioPanningInfo
{
#if !COREBUILD
    [StructLayout(LayoutKind.Sequential)]
    private struct Layout
    {
        public PanningMode PanningMode;
        public AudioChannelFlags CoordinateFlags;
        public float Coord0, Coord1, Coord2;
        public float GainScale;
        public IntPtr OutputChannelMapWeak;
    }

    public AudioPanningInfo(AudioChannelLayout outputChannelMap)
    {
        if (outputChannelMap is null)
            ThrowHelper.ThrowArgumentNullException(nameof(outputChannelMap));

        OutputChannelMap = outputChannelMap;
    }

    public PanningMode PanningMode { get; set; }
    public AudioChannelFlags CoordinateFlags { get; set; }
    public float[] Coordinates { get; private set; } = Array.Empty<float>();
    public float GainScale { get; set; }
    public AudioChannelLayout OutputChannelMap { get; private set; }

    public unsafe float[]? GetPanningMatrix()
    {
        var type_size = sizeof(Layout);

        var str = ToStruct();
        var ptr = Marshal.AllocHGlobal(type_size);
        *(Layout*) ptr = str;

        int size;
        if (AudioFormatPropertyNative.AudioFormatGetPropertyInfo(AudioFormatProperty.PanningMatrix, type_size, ptr,
                out size) != 0)
            return null;

        AudioFormatError res;
        var data = new float[size / sizeof(float)];
        fixed (float* data_ptr = data)
        {
            res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.PanningMatrix, type_size, ptr,
                ref size, data_ptr);
        }

        Marshal.FreeHGlobal(str.OutputChannelMapWeak);
        Marshal.FreeHGlobal(ptr);

        return res == 0 ? data : null;
    }

    private Layout ToStruct()
    {
        var l = new Layout()
        {
            PanningMode = PanningMode,
            CoordinateFlags = CoordinateFlags,
            Coord0 = Coordinates[0],
            Coord1 = Coordinates[1],
            Coord2 = Coordinates[2],
            GainScale = GainScale
        };

        if (OutputChannelMap is not null)
        {
            int temp;
            l.OutputChannelMapWeak = OutputChannelMap.ToBlock(out temp);
        }

        return l;
    }
#endif // !COREBUILD
}
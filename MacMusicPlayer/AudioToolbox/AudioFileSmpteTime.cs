using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioFileSmpteTime
{
    // AudioFile_SMPTE_Time
    public sbyte Hours;
    public byte Minutes;
    public byte Seconds;
    public byte Frames;
    public uint SubFrameSampleOffset;
}
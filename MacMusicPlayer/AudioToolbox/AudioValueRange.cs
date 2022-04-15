using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioValueRange
{
    public double Minimum;
    public double Maximum;
}
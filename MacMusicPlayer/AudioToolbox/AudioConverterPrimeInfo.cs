using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioConverterPrimeInfo
{
    public int LeadingFrames;
    public int TrailingFrames;
}
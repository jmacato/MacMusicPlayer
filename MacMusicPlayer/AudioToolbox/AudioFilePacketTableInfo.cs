using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioFilePacketTableInfo
{
    public long ValidFrames;
    public int PrimingFrames;
    public int RemainderFrames;
}
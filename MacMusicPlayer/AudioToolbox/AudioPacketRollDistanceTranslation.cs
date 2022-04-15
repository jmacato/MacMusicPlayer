using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioPacketRollDistanceTranslation
{
    public long Packet;
    public long RollDistance;
}
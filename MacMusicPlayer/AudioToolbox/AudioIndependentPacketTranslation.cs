using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioIndependentPacketTranslation
{
    public long Packet;
    public long IndependentlyDecodablePacket;
}
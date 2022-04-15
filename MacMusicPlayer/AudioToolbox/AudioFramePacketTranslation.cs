using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
internal struct AudioFramePacketTranslation
{
    public long Frame;
    public long Packet;
    public int FrameOffsetInPacket;
}
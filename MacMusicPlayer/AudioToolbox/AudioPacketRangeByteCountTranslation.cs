using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioPacketRangeByteCountTranslation
{
    public long Packet;
    public long PacketCount;
    public long ByteCountUpperBound;
}
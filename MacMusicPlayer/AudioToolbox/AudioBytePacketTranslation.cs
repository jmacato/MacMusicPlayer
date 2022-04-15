using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
internal struct AudioBytePacketTranslation
{
    public long Byte;
    public long Packet;
    public int ByteOffsetInPacket;
    public BytePacketTranslationFlags Flags;
}
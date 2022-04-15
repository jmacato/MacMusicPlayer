namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileStreamProperty
{
    // UInt32 AudioFileStreamPropertyID
    ReadyToProducePackets = 0x72656479,
    FileFormat = 0x66666d74,
    DataFormat = 0x64666d74,
    FormatList = 0x666c7374,
    MagicCookieData = 0x6d676963,
    AudioDataByteCount = 0x62636e74,
    AudioDataPacketCount = 0x70636e74,
    MaximumPacketSize = 0x70737a65,
    DataOffset = 0x646f6666,
    ChannelLayout = 0x636d6170,
    PacketToFrame = 0x706b6672,
    FrameToPacket = 0x6672706b,
    PacketToByte = 0x706b6279,
    ByteToPacket = 0x6279706b,
    PacketTableInfo = 0x706e666f,
    PacketSizeUpperBound = 0x706b7562,
    AverageBytesPerPacket = 0x61627070,
    BitRate = 0x62726174,
    InfoDictionary = 0x696e666f
}
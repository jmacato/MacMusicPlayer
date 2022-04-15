namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileProperty
{
    // typedef UInt32 AudioFilePropertyID
    FileFormat = 0x66666d74,
    DataFormat = 0x64666d74,
    IsOptimized = 0x6f70746d,
    MagicCookieData = 0x6d676963,
    AudioDataByteCount = 0x62636e74,
    AudioDataPacketCount = 0x70636e74,
    MaximumPacketSize = 0x70737a65,
    DataOffset = 0x646f6666,
    ChannelLayout = 0x636d6170,
    DeferSizeUpdates = 0x64737a75,
    DataFormatName = 0x666e6d65,
    MarkerList = 0x6d6b6c73,
    RegionList = 0x72676c73,
    PacketToFrame = 0x706b6672,
    FrameToPacket = 0x6672706b,
    PacketToByte = 0x706b6279,
    ByteToPacket = 0x6279706b,
    ChunkIDs = 0x63686964,
    InfoDictionary = 0x696e666f,
    PacketTableInfo = 0x706e666f,
    FormatList = 0x666c7374,
    PacketSizeUpperBound = 0x706b7562,
    ReserveDuration = 0x72737276,
    EstimatedDuration = 0x65647572,
    BitRate = 0x62726174,
    ID3Tag = 0x69643374,
    SourceBitDepth = 0x73627464,
    AlbumArtwork = 0x61617274,
    ReadyToProducePackets = 0x72656479,
    AverageBytesPerPacket = 0x61627070,
    AudioTrackCount = 0x61746374,
    UseAudioTrack = 0x7561746b
}
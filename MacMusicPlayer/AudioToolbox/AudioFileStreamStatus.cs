namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileStreamStatus
{
    // Implictly cast to OSType
    Ok = 0,
    UnsupportedFileType = 0x7479703f,
    UnsupportedDataFormat = 0x666d743f,
    UnsupportedProperty = 0x7074793f,
    BadPropertySize = 0x2173697a,
    NotOptimized = 0x6f70746d,
    InvalidPacketOffset = 0x70636b3f,
    InvalidFile = 0x6474613f,
    ValueUnknown = 0x756e6b3f,
    DataUnavailable = 0x6d6f7265,
    IllegalOperation = 0x6e6f7065,
    UnspecifiedError = 0x7768743f,
    DiscontinuityCantRecover = 0x64736321
}
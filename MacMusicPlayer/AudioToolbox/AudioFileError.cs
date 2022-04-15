namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileError
{
    // Implictly cast to OSType in AudioFile.h
    Success = 0, // noErr
    Unspecified = 0x7768743f, // wht?
    UnsupportedFileType = 0x7479703f, // typ?
    UnsupportedDataFormat = 0x666d743f, // fmt?
    UnsupportedProperty = 0x7074793f, // pty?
    BadPropertySize = 0x2173697a, // !siz
    Permissions = 0x70726d3f, // prm?
    NotOptimized = 0x6f70746d, // optm
    InvalidChunk = 0x63686b3f, // chk?
    DoesNotAllow64BitDataSize = 0x6f66663f, // off?
    InvalidPacketOffset = 0x70636b3f, // pck?
    InvalidFile = 0x6474613f, // dta?
    OperationNotSupported = 0x6F703F3F, // op??
    FileNotOpen = -38,
    EndOfFile = -39,
    FileNotFound = -43,
    FilePosition = -40
}
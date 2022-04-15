namespace MacMusicPlayer.AudioToolbox;

public enum AudioServicesError
{
    // Implictly cast to OSType
    None = 0,
    UnsupportedProperty = 0x7074793f, // 'pty?'
    BadPropertySize = 0x2173697a, // '!siz'
    BadSpecifierSizeError = 0x21737063, // '!spc'
    SystemSoundUnspecifiedError = -1500,
    SystemSoundClientTimedOutError = -1501,
    SystemSoundExceededMaximumDurationError = -1502
}
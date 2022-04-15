namespace MacMusicPlayer.AudioToolbox;

public enum AudioFormatError : int // Implictly cast to OSType
{
    None = 0,
    Unspecified = 0x77686174, // 'what'
    UnsupportedProperty = 0x70726f70, // 'prop'
    BadPropertySize = 0x2173697a, // '!siz'
    BadSpecifierSize = 0x21737063, // '!spc'
    UnsupportedDataFormat = 0x666d743f, // 'fmt?'
    UnknownFormat = 0x21666d74 // '!fmt'

    // TODO: Not documented
    // '!dat'
}
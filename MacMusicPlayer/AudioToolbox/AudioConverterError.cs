namespace MacMusicPlayer.AudioToolbox;

public enum AudioConverterError // Impliclty cast to OSStatus in AudioConverter.h
{
    None = 0,
    FormatNotSupported = 0x666d743f, // 'fmt?'
    OperationNotSupported = 0x6f703f3f, // 'op??'
    PropertyNotSupported = 0x70726f70, // 'prop'
    InvalidInputSize = 0x696e737a, // 'insz'
    InvalidOutputSize = 0x6f74737a, // 'otsz'
    UnspecifiedError = 0x77686174, // 'what'
    BadPropertySizeError = 0x2173697a, // '!siz'
    RequiresPacketDescriptionsError = 0x21706b64, // '!pkd'
    InputSampleRateOutOfRange = 0x21697372, // '!isr'
    OutputSampleRateOutOfRange = 0x216f7372, // '!osr'
    HardwareInUse = 0x68776975, // 'hwiu'
    NoHardwarePermission = 0x7065726d, // 'perm'

    AudioFormatUnsupported =
        0x21646174 // '!dat' From http://lists.apple.com/archives/coreaudio-api/2009/Feb/msg00082.html
}
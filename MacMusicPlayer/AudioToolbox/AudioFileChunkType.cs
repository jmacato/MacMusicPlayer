namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileChunkType : uint // CoreAudio.framework - CoreAudioTypes.h - "four char code IDs"
{
    CAFStreamDescription = 0x64657363, // 'desc'
    CAFAudioData = 0x64617461, // 'data'
    CAFChannelLayout = 0x6368616e, // 'chan'
    CAFFiller = 0x66726565, // 'free'
    CAFMarker = 0x6d61726b, // 'mark'
    CAFRegion = 0x7265676e, // 'regn'
    CAFInstrument = 0x696e7374, // 'inst'
    CAFMagicCookieID = 0x6b756b69, // 'kuki'
    CAFInfoStrings = 0x696e666f, // 'info'
    CAFEditComments = 0x65646374, // 'edct'
    CAFPacketTable = 0x70616b74, // 'pakt'
    CAFStrings = 0x73747267, // 'strg'
    CAFUUID = 0x75756964, // 'uuid'
    CAFPeak = 0x7065616b, // 'peak'
    CAFOverview = 0x6f767677, // 'ovvw'
    CAFMIDI = 0x6d696469, // 'midi'
    CAFUMID = 0x756d6964, // 'umid'
    CAFFormatListID = 0x6c647363, // 'ldsc'
    CAFiXML = 0x69584d4c // 'iXML'
}
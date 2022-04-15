namespace MacMusicPlayer.AudioToolbox;

public enum AudioCodecComponentType // Implictly cast to OSType in CoreAudio.framework - CoreAudioTypes.h
{
    Decoder = 0x61646563, // 'adec'	
    Encoder = 0x61656e63 // 'aenc'
}
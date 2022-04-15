namespace MacMusicPlayer.AudioUnit;

public enum AudioCodecManufacturer : uint // Implictly cast to OSType in CoreAudio.framework - CoreAudioTypes.h
{
    AppleSoftware = 0x6170706c, // 'appl'
    AppleHardware = 0x61706877 // 'aphw'
}
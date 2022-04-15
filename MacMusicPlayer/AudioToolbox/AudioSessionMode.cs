namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionMode
{
    // UInt32 AudioSessionPropertyID
    Default = 0x64666c74,
    VoiceChat = 0x76636374,
    VideoRecording = 0x76726364,
    Measurement = 0x6d736d74, // 'msmt'
    GameChat = 0x676d6374 // 'gmct'
}
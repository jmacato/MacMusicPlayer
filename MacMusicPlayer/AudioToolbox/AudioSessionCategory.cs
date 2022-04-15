namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionCategory
{
    // UInt32 AudioSessionPropertyID
    AmbientSound = 0x616d6269, // 'ambi'
    SoloAmbientSound = 0x736f6c6f, // 'solo'
    MediaPlayback = 0x6d656469, // 'medi'
    RecordAudio = 0x72656361, // 'reca'
    PlayAndRecord = 0x706c6172, // 'plar'
    AudioProcessing = 0x70726f63 // 'proc'
}
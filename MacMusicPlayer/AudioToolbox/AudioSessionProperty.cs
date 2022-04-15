namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionProperty
{
    // typedef UInt32 AudioSessionPropertyID
    PreferredHardwareSampleRate = 0x68777372,
    PreferredHardwareIOBufferDuration = 0x696f6264,
    AudioCategory = 0x61636174, // 'acat'

    //[Deprecated (PlatformName.iOS, 5, 0)]
    AudioRoute = 0x726f7574,
    AudioRouteChange = 0x726f6368,
    CurrentHardwareSampleRate = 0x63687372,
    CurrentHardwareInputNumberChannels = 0x63686963,
    CurrentHardwareOutputNumberChannels = 0x63686f63,
    CurrentHardwareOutputVolume = 0x63686f76,
    CurrentHardwareInputLatency = 0x63696c74,
    CurrentHardwareOutputLatency = 0x636f6c74,
    CurrentHardwareIOBufferDuration = 0x63686264,
    OtherAudioIsPlaying = 0x6f746872,
    OverrideAudioRoute = 0x6f767264,
    AudioInputAvailable = 0x61696176,
    ServerDied = 0x64696564,

    //[Deprecated (PlatformName.iOS, 7, 0)]
    OtherMixableAudioShouldDuck = 0x6475636b,
    OverrideCategoryMixWithOthers = 0x636d6978,
    OverrideCategoryDefaultToSpeaker = 0x6373706b, //'cspk'
    OverrideCategoryEnableBluetoothInput = 0x63626c75, //'cblu'
    InterruptionType = 0x74797065, // 'type'
    Mode = 0x6d6f6465,
    InputSources = 0x73726373, // 'srcs'
    OutputDestinations = 0x64737473, // 'dsts'
    InputSource = 0x69737263, // 'isrc'
    OutputDestination = 0x6f647374, // 'odst'
    InputGainAvailable = 0x69676176, // 'igav'
    InputGainScalar = 0x69677363, // 'igsc'
    AudioRouteDescription = 0x63726172 // 'crar'
}
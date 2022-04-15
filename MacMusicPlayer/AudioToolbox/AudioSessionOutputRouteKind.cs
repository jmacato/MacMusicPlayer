namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionOutputRouteKind
{
    // UInt32           (set only) in AudioSession.h
    None,
    LineOut,
    Headphones,
    BluetoothHFP,
    BluetoothA2DP,
    BuiltInReceiver,
    BuiltInSpeaker,
    USBAudio,
    HDMI,
    AirPlay
}
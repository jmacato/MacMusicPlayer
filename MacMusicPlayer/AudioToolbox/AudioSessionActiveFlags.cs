namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionActiveFlags : uint // UInt32 in AudioSessionSetActiveWithFlags
{
    NotifyOthersOnDeactivation = 1 << 0
}
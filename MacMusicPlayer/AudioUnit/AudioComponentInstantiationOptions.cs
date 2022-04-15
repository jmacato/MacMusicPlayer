namespace MacMusicPlayer.AudioUnit;

public enum AudioComponentInstantiationOptions : uint
{
    OutOfProcess = 1,

    // [NoiOS, NoTV, NoMacCatalyst]
    InProcess = 2,

    ////[iOS (14,5), TV (14,5), NoMac]
    LoadedRemotely = 1u << 31
}
namespace MacMusicPlayer.AudioToolbox;

public enum AUSpatialMixerSourceMode : uint
{
    SpatializeIfMono = 0,
    Bypass = 1,
    PointSource = 2,
    AmbienceBed = 3
}
namespace MacMusicPlayer.AudioUnit;

public enum AUSpatializationAlgorithm : uint
{
    EqualPowerPanning = 0,
    SphericalHead = 1,
    Hrtf = 2,
    SoundField = 3,
    VectorBasedPanning = 4,
    StereoPassThrough = 5,
    HrtfHQ = 6,
    UseOutputType = 7
}
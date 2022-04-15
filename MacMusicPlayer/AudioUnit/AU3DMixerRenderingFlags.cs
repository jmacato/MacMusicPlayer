namespace MacMusicPlayer.AudioUnit;

public enum AU3DMixerRenderingFlags : uint
{
    InterAuralDelay = 1 << 0,
    DopplerShift = 1 << 1,
    DistanceAttenuation = 1 << 2,
    DistanceFilter = 1 << 3,
    DistanceDiffusion = 1 << 4,
    LinearDistanceAttenuation = 1 << 5,
    ConstantReverbBlend = 1 << 6
}
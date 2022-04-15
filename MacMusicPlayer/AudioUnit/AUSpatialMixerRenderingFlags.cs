namespace MacMusicPlayer.AudioUnit;

public enum AUSpatialMixerRenderingFlags : uint
{
    InterAuralDelay = 1 << 0,
    DistanceAttenuation = 1 << 2
}
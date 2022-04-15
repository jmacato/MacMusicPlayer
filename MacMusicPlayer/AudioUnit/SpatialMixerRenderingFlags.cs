using System;

namespace MacMusicPlayer.AudioUnit;

[Flags]
////[iOS (8, 0)]
public enum SpatialMixerRenderingFlags
{
    InterAuralDelay = 1 << 0,

    ////[Deprecated (PlatformName.iOS, 9, 0)]
    DistanceAttenuation = 1 << 2
}
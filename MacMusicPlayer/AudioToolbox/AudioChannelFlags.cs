using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioChannelFlags : uint
{
    // UInt32 in AudioPanningInfo -- AudioFormat.h
    AllOff = 0,
    RectangularCoordinates = 1 << 0,
    SphericalCoordinates = 1 << 1,
    Meters = 1 << 2
}
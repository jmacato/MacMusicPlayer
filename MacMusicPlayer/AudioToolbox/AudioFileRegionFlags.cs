using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioFileRegionFlags : uint // UInt32 in AudioFileRegion
{
    LoopEnable = 1,
    PlayForward = 2,
    PlayBackward = 4
}
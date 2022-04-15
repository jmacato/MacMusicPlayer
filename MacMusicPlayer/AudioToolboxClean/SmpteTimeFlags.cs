using System;

namespace MacMusicPlayer.AudioToolboxClean;

[Flags]
public enum SmpteTimeFlags : uint
{
    // UInt32
    Unknown = 0,
    TimeValid = 1 << 0,
    TimeRunning = 1 << 1
}
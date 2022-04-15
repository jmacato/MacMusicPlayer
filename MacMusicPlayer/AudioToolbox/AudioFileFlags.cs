using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioFileFlags
{
    // UInt32 in AudioFileCreateWithURL()
    EraseFlags = 1,
    DontPageAlignAudioData = 2
}
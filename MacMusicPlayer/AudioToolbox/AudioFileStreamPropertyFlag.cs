using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioFileStreamPropertyFlag
{
    // UInt32 in AudioFileStream_PropertyListenerProc
    PropertyIsCached = 1,
    CacheProperty = 2
}
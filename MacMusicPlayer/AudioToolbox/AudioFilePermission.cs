using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioFilePermission
{
    Read = 0x01,
    Write = 0x02,
    ReadWrite = 0x03
}
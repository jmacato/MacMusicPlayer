using System;

namespace MacMusicPlayer.AudioUnit;

public enum AudioObjectPropertyElement : uint
{
#if !NETXXX
    [Obsolete("Use the 'Main' element instead.")]
    Master = 0, // 0
#endif
    Main = 0 // 0
}
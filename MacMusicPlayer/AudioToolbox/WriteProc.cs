using System;

namespace MacMusicPlayer.AudioToolbox;

internal delegate int WriteProc(IntPtr clientData, long position, int requestCount, IntPtr buffer,
    out int actualCount);
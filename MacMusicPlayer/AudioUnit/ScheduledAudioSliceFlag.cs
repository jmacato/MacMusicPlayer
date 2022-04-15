using System;

namespace MacMusicPlayer.AudioUnit;

[Flags]
public enum ScheduledAudioSliceFlag
{
    Complete = 0x01,
    BeganToRender = 0x02,
    BeganToRenderLate = 0x04,

    ////[iOS (8, 0)]
    // //[Mac (10, 10)]
    Loop = 0x08,

    ////[iOS (8, 0)]
    // //[Mac (10, 10)]
    Interrupt = 0x10,

    ////[iOS (8, 0)]
    // //[Mac (10, 10)]
    InterruptAtLoop = 0x20
}
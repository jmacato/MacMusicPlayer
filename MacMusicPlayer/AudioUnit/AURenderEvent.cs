using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Explicit)]
public struct AURenderEvent
{
    [FieldOffset(0)] public AURenderEventHeader Head;

    [FieldOffset(0)] public AUParameterEvent Parameter;
}
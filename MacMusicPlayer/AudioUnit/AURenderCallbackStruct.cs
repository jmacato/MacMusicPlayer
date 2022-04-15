using System;
using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
internal struct AURenderCallbackStruct
{
    public Delegate Proc;
    public IntPtr ProcRefCon;
}
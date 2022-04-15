using System;
using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
public struct AUParameterObserverToken
{
    public IntPtr ObserverToken;

    public AUParameterObserverToken(IntPtr observerToken)
    {
        ObserverToken = observerToken;
    }
}
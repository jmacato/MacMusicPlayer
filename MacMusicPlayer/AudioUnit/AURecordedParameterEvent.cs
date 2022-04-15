using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
public struct AURecordedParameterEvent
{
    public ulong HostTime;

    public ulong Address;

    public float Value;
}
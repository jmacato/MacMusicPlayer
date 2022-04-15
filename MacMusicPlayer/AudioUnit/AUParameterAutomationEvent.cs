using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
public struct AUParameterAutomationEvent
{
    public ulong HostTime;
    public ulong Address;
    public float Value;
    public AUParameterAutomationEventType EventType;
    private ulong Reserved;
}
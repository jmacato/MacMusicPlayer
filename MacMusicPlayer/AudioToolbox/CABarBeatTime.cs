using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct CABarBeatTime
{
    public /* SInt32 */ int Bar;
    public /* UInt16 */ ushort Beat;
    public /* UInt16 */ ushort Subbeat;
    public /* UInt16 */ ushort SubbeatDivisor;
    public /* UInt16 */ ushort Reserved;
}
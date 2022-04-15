using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioStreamPacketDescription
{
    public long StartOffset;
    public int VariableFramesInPacket;
    public int DataByteSize;

    public override string ToString()
    {
        return $"StartOffset={StartOffset} VariableFramesInPacket={VariableFramesInPacket} DataByteSize={DataByteSize}";
    }
}
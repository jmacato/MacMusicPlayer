using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioPacketDependencyInfoTranslation
{
    public long Packet;
    private uint isIndependentlyDecodable;
    public uint NumberPrerollPackets;

    public bool IsIndependentlyDecodable
    {
        get => isIndependentlyDecodable != 0;
        set => isIndependentlyDecodable = value ? 1U : 0U;
    }
}
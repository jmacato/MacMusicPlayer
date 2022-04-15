using System;

namespace MacMusicPlayer.AudioToolbox;

public class PacketReceivedEventArgs : EventArgs
{
    public PacketReceivedEventArgs(int numberOfBytes, IntPtr inputData,
        AudioStreamPacketDescription[]? packetDescriptions)
    {
        Bytes = numberOfBytes;
        InputData = inputData;
        PacketDescriptions = packetDescriptions;
    }

    public int Bytes { get; private set; }
    public IntPtr InputData { get; private set; }
    public AudioStreamPacketDescription[]? PacketDescriptions { get; private set; }

    public override string ToString()
    {
        return $"Packet (Bytes={Bytes} InputData={InputData} PacketDescriptions={PacketDescriptions?.Length ?? -1}";
    }
}
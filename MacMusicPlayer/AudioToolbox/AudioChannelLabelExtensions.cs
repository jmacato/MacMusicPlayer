namespace MacMusicPlayer.AudioToolbox;

public static class AudioChannelLabelExtensions
{
    public static bool IsReserved(this AudioChannelLabel value)
    {
        return (uint) value >= 0xF0000000 && (uint) value <= 0xFFFFFFFE;
    }
}
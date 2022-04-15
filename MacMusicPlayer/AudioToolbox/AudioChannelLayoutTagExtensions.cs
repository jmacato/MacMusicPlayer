namespace MacMusicPlayer.AudioToolbox;

public static class AudioChannelLayoutTagExtensions
{
    public static AudioChannelBit? ToAudioChannel(this AudioChannelLayoutTag layoutTag)
    {
        int value;
        var size = sizeof(uint);
        var layout = (int) layoutTag;

        if (AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.BitmapForLayoutTag,
                sizeof(AudioChannelLayoutTag), ref layout, ref size, out value) != 0)
            return null;

        return (AudioChannelBit) value;
    }

    public static uint GetNumberOfChannels(this AudioChannelLayoutTag inLayoutTag)
    {
        return (uint) inLayoutTag & 0x0000FFFF;
    }

    public static bool IsReserved(this AudioChannelLayoutTag value)
    {
        return (uint) value >= 0xF0000000 && (uint) value <= 0xFFFFFFFE;
    }
}
using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioToolbox;

public class AudioBalanceFade
{
#if !COREBUILD
    [StructLayout(LayoutKind.Sequential)]
    private struct Layout
    {
        public float LeftRightBalance;
        public float BackFrontFade;
        public AudioBalanceFadeType Type;
        public IntPtr ChannelLayoutWeak;
    }

    public AudioBalanceFade(AudioChannelLayout channelLayout)
    {
        if (channelLayout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(channelLayout));

        ChannelLayout = channelLayout;
    }

    public float LeftRightBalance { get; set; }
    public float BackFrontFade { get; set; }
    public AudioBalanceFadeType Type { get; set; }
    public AudioChannelLayout ChannelLayout { get; private set; }

    public unsafe float[]? GetBalanceFade()
    {
        var type_size = sizeof(Layout);

        var str = ToStruct();
        var ptr = Marshal.AllocHGlobal(type_size);
        (*(Layout*) ptr) = str;

        int size;
        if (AudioFormatPropertyNative.AudioFormatGetPropertyInfo(AudioFormatProperty.BalanceFade, type_size, ptr,
                out size) != 0)
            return null;

        AudioFormatError res;
        var data = new float[size / sizeof(float)];
        fixed (float* data_ptr = data)
        {
            res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.BalanceFade, type_size, ptr,
                ref size, data_ptr);
        }

        Marshal.FreeHGlobal(str.ChannelLayoutWeak);
        Marshal.FreeHGlobal(ptr);

        return res == 0 ? data : null;
    }

    private Layout ToStruct()
    {
        var l = new Layout()
        {
            LeftRightBalance = LeftRightBalance,
            BackFrontFade = BackFrontFade,
            Type = Type
        };

        if (ChannelLayout is not null)
        {
            int temp;
            l.ChannelLayoutWeak = ChannelLayout.ToBlock(out temp);
        }

        return l;
    }
#endif // !COREBUILD
}
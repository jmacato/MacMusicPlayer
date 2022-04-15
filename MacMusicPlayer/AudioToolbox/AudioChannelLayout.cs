using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioToolbox;

[DebuggerDisplay("{Name}")]
public class AudioChannelLayout
{
    public AudioChannelLayout()
    {
    }

    internal unsafe AudioChannelLayout(IntPtr h)
    {
        AudioTag = (AudioChannelLayoutTag) Marshal.ReadInt32(h, 0);
        ChannelUsage = (AudioChannelBit) Marshal.ReadInt32(h, 4);
        Channels = new AudioChannelDescription [Marshal.ReadInt32(h, 8)];
        var p = 12;
        var size = sizeof(AudioChannelDescription);
        for (var i = 0; i < Channels.Length; i++)
        {
            Channels[i] = *(AudioChannelDescription*) unchecked((byte*) h + p);
            p += size;
        }
    }

    //[Advice ("Use the strongly typed 'AudioTag' instead.")]
    public int Tag
    {
        get => (int) AudioTag;
        set => AudioTag = (AudioChannelLayoutTag) value;
    }

    //[Advice ("Use 'ChannelUsage' instead.")]
    public int Bitmap
    {
        get => (int) ChannelUsage;
        set => ChannelUsage = (AudioChannelBit) value;
    }

    public AudioChannelLayoutTag AudioTag;
    public AudioChannelBit ChannelUsage;
    public AudioChannelDescription[]? Channels;

    public unsafe string? Name
    {
        get
        {
            IntPtr sptr;
            var size = sizeof(IntPtr);
            int ptr_size;
            var ptr = ToBlock(out ptr_size);

            var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ChannelLayoutName, ptr_size,
                ptr, ref size, out sptr);
            Marshal.FreeHGlobal(ptr);
            if (res != 0)
                return null;

            return new CfString(sptr, true);
        }
    }

    public unsafe string? SimpleName
    {
        get
        {
            IntPtr sptr;
            var size = sizeof(IntPtr);
            int ptr_size;
            var ptr = ToBlock(out ptr_size);

            var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ChannelLayoutSimpleName,
                ptr_size, ptr, ref size, out sptr);
            Marshal.FreeHGlobal(ptr);
            if (res != 0)
                return null;

            return new CfString(sptr, true);
        }
    }

    public static AudioChannelLayout? FromAudioChannelBitmap(AudioChannelBit channelBitmap)
    {
        return GetChannelLayout(AudioFormatProperty.ChannelLayoutForBitmap, (int) channelBitmap);
    }

    public static AudioChannelLayout? FromAudioChannelLayoutTag(AudioChannelLayoutTag channelLayoutTag)
    {
        return GetChannelLayout(AudioFormatProperty.ChannelLayoutForTag, (int) channelLayoutTag);
    }

    private static AudioChannelLayout? GetChannelLayout(AudioFormatProperty property, int value)
    {
        int size;
        AudioFormatPropertyNative.AudioFormatGetPropertyInfo(property, sizeof(AudioFormatProperty), ref value,
            out size);

        AudioChannelLayout? layout;
        var ptr = Marshal.AllocHGlobal(size);
        if (AudioFormatPropertyNative.AudioFormatGetProperty(property, sizeof(AudioFormatProperty), ref value, ref size,
                ptr) == 0)
            layout = new AudioChannelLayout(ptr);
        else
            layout = null;

        Marshal.FreeHGlobal(ptr);
        return layout;
    }

    internal static AudioChannelLayout? FromHandle(IntPtr handle)
    {
        if (handle == IntPtr.Zero)
            return null;

        return new AudioChannelLayout(handle);
    }

    public override string ToString()
    {
        return $"AudioChannelLayout: Tag={AudioTag} Bitmap={ChannelUsage} Channels={Channels!.Length}";
    }

    // The returned block must be released with FreeHGlobal
    internal unsafe IntPtr ToBlock(out int size)
    {
        if (Channels is null)
            ThrowHelper.ThrowArgumentNullException(nameof(Channels));

        var desc_size = sizeof(AudioChannelDescription);

        size = 12 + Channels.Length * desc_size;
        var buffer = Marshal.AllocHGlobal(size);
        Marshal.WriteInt32(buffer, (int) AudioTag);
        Marshal.WriteInt32(buffer, 4, (int) ChannelUsage);
        Marshal.WriteInt32(buffer, 8, Channels.Length);

        var dest = (AudioChannelDescription*) ((byte*) buffer + 12);
        foreach (var desc in Channels)
        {
            *dest = desc;
            dest++;
        }

        return buffer;
    }

    public static AudioFormatError Validate(AudioChannelLayout layout)
    {
        if (layout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(layout));

        int ptr_size;
        var ptr = layout.ToBlock(out ptr_size);

        var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ValidateChannelLayout, ptr_size,
            ptr, IntPtr.Zero, IntPtr.Zero);
        Marshal.FreeHGlobal(ptr);
        return res;
    }

    public static unsafe int[]? GetChannelMap(AudioChannelLayout inputLayout, AudioChannelLayout outputLayout)
    {
        if (inputLayout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(inputLayout));
        if (outputLayout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(outputLayout));

        var channels_count = GetNumberOfChannels(outputLayout);
        if (channels_count is null)
            throw new ArgumentException("outputLayout");

        int ptr_size;
        var input_ptr = inputLayout.ToBlock(out ptr_size);
        var output_ptr = outputLayout.ToBlock(out ptr_size);
        var array = new IntPtr[] {input_ptr, output_ptr};
        ptr_size = sizeof(IntPtr) * array.Length;

        int[] value;
        AudioFormatError res;

        fixed (IntPtr* ptr = &array[0])
        {
            value = new int[channels_count.Value];
            var size = sizeof(int) * value.Length;
            fixed (int* value_ptr = &value[0])
            {
                res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.ChannelMap, ptr_size, ptr,
                    ref size, value_ptr);
            }
        }

        Marshal.FreeHGlobal(input_ptr);
        Marshal.FreeHGlobal(output_ptr);

        return res == 0 ? value : null;
    }

    public static unsafe float[,]? GetMatrixMixMap(AudioChannelLayout inputLayout, AudioChannelLayout outputLayout)
    {
        if (inputLayout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(inputLayout));
        if (outputLayout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(outputLayout));

        var channels_count_output = GetNumberOfChannels(outputLayout);
        if (channels_count_output is null)
            throw new ArgumentException("outputLayout");

        var channels_count_input = GetNumberOfChannels(inputLayout);
        if (channels_count_input is null)
            throw new ArgumentException("inputLayout");

        int ptr_size;
        var input_ptr = inputLayout.ToBlock(out ptr_size);
        var output_ptr = outputLayout.ToBlock(out ptr_size);
        var array = new IntPtr[] {input_ptr, output_ptr};
        ptr_size = sizeof(IntPtr) * array.Length;

        float[,] value;
        AudioFormatError res;

        fixed (IntPtr* ptr = &array[0])
        {
            value = new float[channels_count_input.Value, channels_count_output.Value];
            var size = sizeof(float) * channels_count_input.Value * channels_count_output.Value;
            fixed (float* value_ptr = &value[0, 0])
            {
                res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.MatrixMixMap, ptr_size, ptr,
                    ref size, value_ptr);
            }
        }

        Marshal.FreeHGlobal(input_ptr);
        Marshal.FreeHGlobal(output_ptr);

        return res == 0 ? value : null;
    }

    public static int? GetNumberOfChannels(AudioChannelLayout layout)
    {
        if (layout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(layout));

        int ptr_size;
        var ptr = layout.ToBlock(out ptr_size);
        var size = sizeof(int);
        int value;

        var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.NumberOfChannelsForLayout,
            ptr_size, ptr, ref size, out value);
        Marshal.FreeHGlobal(ptr);
        return res != 0 ? null : (int?) value;
    }

    public static AudioChannelLayoutTag? GetTagForChannelLayout(AudioChannelLayout layout)
    {
        if (layout is null)
            ThrowHelper.ThrowArgumentNullException(nameof(layout));

        int ptr_size;
        var ptr = layout.ToBlock(out ptr_size);
        var size = sizeof(AudioChannelLayoutTag);
        int value;

        var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.TagForChannelLayout, ptr_size,
            ptr, ref size, out value);
        Marshal.FreeHGlobal(ptr);
        return res != 0 ? null : (AudioChannelLayoutTag?) value;
    }

    public static unsafe AudioChannelLayoutTag[]? GetTagsForNumberOfChannels(int count)
    {
        const int type_size = sizeof(uint);
        int size;
        if (AudioFormatPropertyNative.AudioFormatGetPropertyInfo(AudioFormatProperty.TagsForNumberOfChannels, type_size,
                ref count, out size) != 0)
            return null;

        var data = new AudioChannelLayoutTag[size / type_size];
        fixed (AudioChannelLayoutTag* ptr = data)
        {
            var res = AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.TagsForNumberOfChannels,
                type_size, ref count, ref size, (int*) ptr);
            if (res != 0)
                return null;

            return data;
        }
    }
}
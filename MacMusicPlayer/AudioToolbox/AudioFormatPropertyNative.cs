using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioToolbox;

internal static partial class AudioFormatPropertyNative
{
    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetPropertyInfo(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioFormatType inSpecifier,
        out uint outPropertyDataSize);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetPropertyInfo(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioStreamBasicDescription inSpecifier,
        out uint outPropertyDataSize);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetPropertyInfo(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioFormatInfo inSpecifier,
        out uint outPropertyDataSize);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetPropertyInfo(AudioFormatProperty propertyID,
        int inSpecifierSize, ref int inSpecifier,
        out int outPropertyDataSize);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetPropertyInfo(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        out int outPropertyDataSize);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioFormatType inSpecifier,
        ref uint ioDataSize, IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref int inSpecifier,
        ref int ioDataSize, IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        ref int ioDataSize, IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        ref int ioDataSize, out IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        ref int ioDataSize, out int outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref int inSpecifier,
        ref int ioDataSize, out int outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        IntPtr ioDataSize, IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioFormatInfo inSpecifier,
        ref uint ioDataSize, AudioFormat* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref AudioStreamBasicDescription inSpecifier,
        ref uint ioDataSize, int* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, ref int inSpecifier,
        ref int ioDataSize, int* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr* inSpecifier,
        ref int ioDataSize, int* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr* inSpecifier,
        ref int ioDataSize, float* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty propertyID,
        int inSpecifierSize, IntPtr inSpecifier,
        ref int ioDataSize, float* outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetProperty(AudioFormatProperty inPropertyID, int inSpecifierSize,
        ref AudioStreamBasicDescription inSpecifier,
        ref int ioPropertyDataSize, out IntPtr outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetProperty(AudioFormatProperty inPropertyID, int inSpecifierSize,
        ref AudioStreamBasicDescription inSpecifier,
        ref int ioPropertyDataSize, out uint outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern AudioFormatError AudioFormatGetProperty(AudioFormatProperty inPropertyID, int inSpecifierSize,
        IntPtr inSpecifier, ref int ioPropertyDataSize,
        ref AudioStreamBasicDescription outPropertyData);

    [DllImport(Constants.AudioToolboxLibrary)]
    public static extern unsafe AudioFormatError AudioFormatGetProperty(AudioFormatProperty inPropertyID,
        int inSpecifierSize, AudioFormat* inSpecifier, ref int ioPropertyDataSize,
        out uint outPropertyData);
}
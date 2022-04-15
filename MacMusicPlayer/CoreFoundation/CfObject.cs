using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.CoreFoundation;

public static class CfObject
{
    [DllImport(Constants.CoreFoundationLibrary)]
    internal static extern void CFRelease(IntPtr obj);

    [DllImport(Constants.CoreFoundationLibrary)]
    internal static extern IntPtr CFRetain(IntPtr obj);
}
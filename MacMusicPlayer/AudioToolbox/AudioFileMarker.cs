using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.CoreFoundation;

namespace MacMusicPlayer.AudioToolbox;

[StructLayout(LayoutKind.Sequential)]
public struct AudioFileMarker
{
    public double FramePosition;
    internal IntPtr Name_cfstringref;
    public int MarkerID;
    public AudioFileSmpteTime SmpteTime;
    public AudioFileMarkerType Type;
    public ushort Reserved;
    public ushort Channel;

    public string? Name => CfString.FromHandle(Name_cfstringref);
}
#nullable enable

using NativeHandle = System.IntPtr;

namespace MacMusicPlayer.ObjCRuntime;

public interface INativeObject
{
    NativeHandle Handle { get; }
}
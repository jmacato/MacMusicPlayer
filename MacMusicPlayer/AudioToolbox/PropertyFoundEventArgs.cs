using System;

namespace MacMusicPlayer.AudioToolbox;

public class PropertyFoundEventArgs : EventArgs
{
    public PropertyFoundEventArgs(AudioFileStreamProperty propertyID, AudioFileStreamPropertyFlag ioFlags)
    {
        Property = propertyID;
        Flags = ioFlags;
    }

    public AudioFileStreamProperty Property { get; private set; }
    public AudioFileStreamPropertyFlag Flags { get; set; }

    public override string ToString()
    {
        return $"AudioFileStreamProperty ({Property})";
    }
}
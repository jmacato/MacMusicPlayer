using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
internal enum BytePacketTranslationFlags : uint // Stored in UInt32 in AudioBytePacketTranslation - AudioFile.h
{
    IsEstimate = 1
}
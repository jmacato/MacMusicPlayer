using System;

namespace MacMusicPlayer.AudioToolbox;

[Flags]
public enum AudioChannelBit : uint // UInt32 mChannelBitmap in AudioChannelLayout
{
    Left = 1 << 0,
    Right = 1 << 1,
    Center = 1 << 2,
    LFEScreen = 1 << 3,
    LeftSurround = 1 << 4,
    RightSurround = 1 << 5,
    LeftCenter = 1 << 6,
    RightCenter = 1 << 7,
    CenterSurround = 1 << 8,
    LeftSurroundDirect = 1 << 9,
    RightSurroundDirect = 1 << 10,
    TopCenterSurround = 1 << 11,
    VerticalHeightLeft = 1 << 12,
    VerticalHeightCenter = 1 << 13,
    VerticalHeightRight = 1 << 14,
    TopBackLeft = 1 << 15,
    TopBackCenter = 1 << 16,
    TopBackRight = 1 << 17,

    LeftTopFront = VerticalHeightLeft,
    CenterTopFront = VerticalHeightCenter,
    RightTopFront = VerticalHeightRight,
    LeftTopMiddle = 1 << 21,
    CenterTopMiddle = TopCenterSurround,

    RightTopMiddle = 1 << 23,
    LeftTopRear = 1 << 24,
    CenterTopRear = 1 << 25,
    RightTopRear = 1 << 26
}
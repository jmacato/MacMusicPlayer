namespace MacMusicPlayer.AudioToolbox;

public enum AudioChannelLabel : int
{
    // UInt32 AudioChannelLabel
    Unknown = -1,
    Unused = 0,
    UseCoordinates = 100,

    Left = 1,
    Right = 2,
    Center = 3,
    LFEScreen = 4,
    LeftSurround = 5,
    RightSurround = 6,
    LeftCenter = 7,
    RightCenter = 8,
    CenterSurround = 9,
    LeftSurroundDirect = 10,
    RightSurroundDirect = 11,
    TopCenterSurround = 12,
    VerticalHeightLeft = 13,
    VerticalHeightCenter = 14,
    VerticalHeightRight = 15,
    TopBackLeft = 16,
    TopBackCenter = 17,
    TopBackRight = 18,
    RearSurroundLeft = 33,
    RearSurroundRight = 34,
    LeftWide = 35,
    RightWide = 36,
    LFE2 = 37,
    LeftTotal = 38,
    RightTotal = 39,
    HearingImpaired = 40,
    Narration = 41,
    Mono = 42,
    DialogCentricMix = 43,
    CenterSurroundDirect = 44,
    Haptic = 45,

    LeftTopFront = VerticalHeightLeft,
    CenterTopFront = VerticalHeightCenter,
    RightTopFront = VerticalHeightRight,
    LeftTopMiddle = 49,
    CenterTopMiddle = TopCenterSurround,

    RightTopMiddle = 51,
    LeftTopRear = 52,
    CenterTopRear = 53,
    RightTopRear = 54,

    // first order ambisonic channels
    Ambisonic_W = 200,
    Ambisonic_X = 201,
    Ambisonic_Y = 202,
    Ambisonic_Z = 203,

    // Mid/Side Recording
    MS_Mid = 204,
    MS_Side = 205,

    // X-Y Recording
    XY_X = 206,
    XY_Y = 207,

    // Binaural Recording
    BinauralLeft = 208,
    BinauralRight = 209,

    // other
    HeadphonesLeft = 301,
    HeadphonesRight = 302,
    ClickTrack = 304,
    ForeignLanguage = 305,

    // generic discrete channel
    Discrete = 400,

    // numbered discrete channel
    Discrete_0 = (1 << 16) | 0,
    Discrete_1 = (1 << 16) | 1,
    Discrete_2 = (1 << 16) | 2,
    Discrete_3 = (1 << 16) | 3,
    Discrete_4 = (1 << 16) | 4,
    Discrete_5 = (1 << 16) | 5,
    Discrete_6 = (1 << 16) | 6,
    Discrete_7 = (1 << 16) | 7,
    Discrete_8 = (1 << 16) | 8,
    Discrete_9 = (1 << 16) | 9,
    Discrete_10 = (1 << 16) | 10,
    Discrete_11 = (1 << 16) | 11,
    Discrete_12 = (1 << 16) | 12,
    Discrete_13 = (1 << 16) | 13,
    Discrete_14 = (1 << 16) | 14,
    Discrete_15 = (1 << 16) | 15,
    Discrete_65535 = (1 << 16) | 65535,

    // HOA ACN channels

    // generic
    HoaAcn = 500,

    // numbered
    HoaAcn0 = (2 << 16) | 0,
    HoaAcn1 = (2 << 16) | 1,
    HoaAcn2 = (2 << 16) | 2,
    HoaAcn3 = (2 << 16) | 3,
    HoaAcn4 = (2 << 16) | 4,
    HoaAcn5 = (2 << 16) | 5,
    HoaAcn6 = (2 << 16) | 6,
    HoaAcn7 = (2 << 16) | 7,
    HoaAcn8 = (2 << 16) | 8,
    HoaAcn9 = (2 << 16) | 9,
    HoaAcn10 = (2 << 16) | 10,
    HoaAcn11 = (2 << 16) | 11,
    HoaAcn12 = (2 << 16) | 12,
    HoaAcn13 = (2 << 16) | 13,
    HoaAcn14 = (2 << 16) | 14,
    HoaAcn15 = (2 << 16) | 15,
    HoaAcn65024 = (2 << 16) | 65024,
    HoaSn3d = HoaAcn0,
    HoaN3d = 3 << 16
}
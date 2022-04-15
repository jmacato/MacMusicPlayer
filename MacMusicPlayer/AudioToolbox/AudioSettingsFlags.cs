using System;
// //using Foundation;

namespace MacMusicPlayer.AudioToolbox;

//[NoWatch]
//[TV (10, 0)]
//[Mac (10, 12)]
//[iOS (10, 0)]
[Flags]
public enum AudioSettingsFlags : uint
{
    ExpertParameter = 1u << 0,
    InvisibleParameter = 1u << 1,
    MetaParameter = 1u << 2,
    UserInterfaceParameter = 1u << 3
}

//[NoWatch]
//[TV (14, 0)]
//[Mac (11, 0)]
//[iOS (14, 0)]

//[NoWatch]
//[TV (14, 0)]
//[Mac (11, 0)]
//[iOS (14, 0)]

//[NoWatch]
//[TV (14, 0)]
//[Mac (11, 0)]
//[iOS (14, 0)]
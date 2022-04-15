namespace MacMusicPlayer.AudioToolbox;

internal enum AudioServicesPropertyKey : uint // UInt32 AudioServicesPropertyID
{
    IsUISound = 0x69737569, // 'isui'
    CompletePlaybackIfAppDies = 0x69666469 // 'ifdi'
}
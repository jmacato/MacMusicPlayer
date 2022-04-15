using MacMusicPlayer.AudioToolbox;

namespace MacMusicPlayer.AudioUnit;

public delegate AudioUnitStatus InputDelegate(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
    uint busNumber, uint numberFrames, AudioUnit audioUnit);
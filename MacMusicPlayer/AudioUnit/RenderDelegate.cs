using MacMusicPlayer.AudioToolbox;

namespace MacMusicPlayer.AudioUnit;

public delegate AudioUnitStatus RenderDelegate(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
    uint busNumber, uint numberFrames, AudioBuffers data);
namespace MacMusicPlayer.AudioUnit;

public enum AUScheduledAudioSliceFlags : uint
{
    Complete = 1,
    BeganToRender = 2,
    BeganToRenderLate = 4,
    Loop = 8,
    Interrupt = 16,
    InterruptAtLoop = 32
}
namespace MacMusicPlayer.AudioUnit;

public enum AudioTypeGenerator
{
    // OSType in AudioComponentDescription
#if MONOMAC
		NetReceive = 0x6e726376, // 'nrcv'
#endif
    ScheduledSoundPlayer = 0x7373706c, // 'sspl'
    AudioFilePlayer = 0x6166706c // 'afpl'
}
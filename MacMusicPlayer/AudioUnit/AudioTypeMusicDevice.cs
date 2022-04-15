namespace MacMusicPlayer.AudioUnit;

public enum AudioTypeMusicDevice
{
    // OSType in AudioComponentDescription
#if MONOMAC
		DlsSynth = 0x646c7320, // 'dls '
#endif
    Sampler = 0x73616d70, // 'samp'

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
#else
    ////[iOS (8,0)]
#endif
    MidiSynth = 0x6d73796e // 'msyn'
}
namespace MacMusicPlayer.AudioUnit;

public enum AudioTypeOutput
{
    // OSType in AudioComponentDescription
    Generic = 0x67656e72, // 'genr'
#if MONOMAC
		HAL = 0x6168616c, // 'ahal'
		Default = 0x64656620, // 'def'
		System = 0x73797320, // 'sys'
#endif
#if NETXXX
		[SupportedOSPlatform ("macos10.15")]
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
    ////[Mac (10, 15)]
#endif
    Remote = 0x72696f63, // 'rioc'
    VoiceProcessingIO = 0x7670696f // 'vpio'
}
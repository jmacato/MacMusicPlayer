namespace MacMusicPlayer.AudioUnit;

public enum AudioTypeEffect
{
    // OSType in AudioComponentDescription
    PeakLimiter = 0x6c6d7472, // 'lmtr'
    DynamicsProcessor = 0x64636d70, // 'dcmp'
    LowPassFilter = 0x6c706173, // 'lpas'
    HighPassFilter = 0x68706173, // 'hpas'
    HighShelfFilter = 0x68736866, // 'hshf'
    LowShelfFilter = 0x6c736866, // 'lshf'
#if NETXXX
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
#if IOS
		[Obsolete ("Starting with ios7.0.", DiagnosticId = "BI1234", UrlFormat =
 "https://github.com/xamarin/xamarin-macios/wiki/Obsolete")]
#endif
#else
    //[Obsoleted (PlatformName.iOS, 7, 0)]
#endif
    DCFilter = 0x6463666c, // 'dcfl'
    ParametricEQ = 0x706d6571, // 'pmeq'
    Delay = 0x64656c79, // 'dely'

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
#else
    ////[iOS (8, 0)]
#endif
    SampleDelay = 0x73646c79, // 'sdly'
    Distortion = 0x64697374, // 'dist'
    BandPassFilter = 0x62706173, // 'bpas'
#if MONOMAC
		GraphicEQ = 0x67726571, // 'greq'
		MultiBandCompressor = 0x6d636d70, // 'mcmp'
		MatrixReverb = 0x6d726576, // 'mrev'
		Pitch = 0x70697463, // 'pitc'
		AUFilter = 0x66696c74, // 'filt'
		NetSend = 0x6e736e64, // 'nsnd'
		RogerBeep = 0x726f6772, // 'rogr'
#else
#if NETXXX
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("tvos13.0")]
		[UnsupportedOSPlatform ("ios13.0")]
#if TVOS
		[Obsolete ("Starting with tvos13.0 use 'AudioTypeEffect.GraphicEQ' instead.", DiagnosticId = "BI1234", UrlFormat
 = "https://github.com/xamarin/xamarin-macios/wiki/Obsolete")]
#elif IOS
		[Obsolete ("Starting with ios13.0 use 'AudioTypeEffect.GraphicEQ' instead.", DiagnosticId = "BI1234", UrlFormat
 = "https://github.com/xamarin/xamarin-macios/wiki/Obsolete")]
#endif
		[UnsupportedOSPlatform ("maccatalyst")]
#else
    //[Unavailable (PlatformName.MacCatalyst)]
    ////[Deprecated (PlatformName.iOS, 13,0, message: "Use 'AudioTypeEffect.GraphicEQ' instead.")]
    ////[Deprecated (PlatformName.TvOS, 13,0, message: "Use 'AudioTypeEffect.GraphicEQ' instead.")]
    ////[Deprecated (PlatformName.WatchOS, 6,0, message: "Use 'AudioTypeEffect.GraphicEQ' instead.")]
#endif
    AUiPodEQ = 0x69706571, // 'ipeq'
#endif
#if NETXXX
		[SupportedOSPlatform ("macos10.15")]
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
    ////[Mac (10,15)]
    //[Unavailable (PlatformName.MacCatalyst)]
#endif
    Reverb2 = 0x72766232, // 'rvb2'
    NBandEq = 0x6e626571 // 'nbeq'
}
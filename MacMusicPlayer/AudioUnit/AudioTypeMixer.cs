namespace MacMusicPlayer.AudioUnit;

public enum AudioTypeMixer
{
    // OSType in AudioComponentDescription
    MultiChannel = 0x6d636d78, // 'mcmx'
    Matrix = 0x6d786d78, // 'mxmx'
    Spacial = 0x3364656d, // Same as Embedded3D
#if MONOMAC
		Stereo = 0x736d7872, // 'smxr'
#if NETXXX
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("macos10.10")]
#if MONOMAC
		[Obsolete ("Starting with macos10.10 use 'Spacial' instead.", DiagnosticId = "BI1234", UrlFormat =
 "https://github.com/xamarin/xamarin-macios/wiki/Obsolete")]
#endif
#else
		////[Deprecated (PlatformName.MacOSX, 10, 10, message : "Use 'Spacial' instead.")]
#endif
		ThreeD = 0x33646d78, // '3dmx'
#else
#if NETXXX
		[UnsupportedOSPlatform ("ios8.0")]
#if IOS
		[Obsolete ("Starting with ios8.0 use 'Spacial' instead.", DiagnosticId = "BI1234", UrlFormat =
 "https://github.com/xamarin/xamarin-macios/wiki/Obsolete")]
#endif
#endif
    Embedded3D = 0x3364656d, // '3dem'
#endif
}
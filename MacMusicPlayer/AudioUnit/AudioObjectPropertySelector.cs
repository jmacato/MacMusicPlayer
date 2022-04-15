using System;

namespace MacMusicPlayer.AudioUnit;

public enum AudioObjectPropertySelector : uint
{
    PropertyDevices = 1684370979, // 'dev#'
    Devices = 1684370979, // 'dev#'
    DefaultInputDevice = 1682533920, // 'dIn '
    DefaultOutputDevice = 1682929012, // 'dOut'
    DefaultSystemOutputDevice = 1934587252, // 'sOut'
    TranslateUIDToDevice = 1969841252, // 'uidd'
    MixStereoToMono = 1937010031, // 'stmo'
    PlugInList = 1886152483, // 'plg#'
    TranslateBundleIDToPlugIn = 1651074160, // 'bidp'
    TransportManagerList = 1953326883, // 'tmg#'
    TranslateBundleIDToTransportManager = 1953325673, // 'tmbi'
    BoxList = 1651472419, // 'box#'
    TranslateUIDToBox = 1969841250, // 'uidb'
    ClockDeviceList = 1668049699, //'clk#'
    TranslateUidToClockDevice = 1969841251, // 'uidc',

    ////[Deprecated (PlatformName.iOS, 15,0, message : "Use the 'ProcessIsMain' element instead.")]
    ////[Deprecated (PlatformName.MacCatalyst, 15,0, message : "Use the 'ProcessIsMain' element instead.")]
    ////[Deprecated (PlatformName.MacOSX, 12,0, message : "Use the 'ProcessIsMain' element instead.")]
    [Obsolete("Use the 'ProcessIsMain' element instead.")]
    ProcessIsMaster = 1835103092, // 'mast'

    ////[iOS (15,0), MacCatalyst (15,0), Mac (12,0), NoTV, NoWatch]
    ProcessIsMain = 1835100526, // 'main'
    IsInitingOrExiting = 1768845172, // 'inot'
    UserIDChanged = 1702193508, // 'euid'
    ProcessIsAudible = 1886221684, // 'pmut'
    SleepingIsAllowed = 1936483696, // 'slep'
    UnloadingIsAllowed = 1970170980, // 'unld'
    HogModeIsAllowed = 1752131442, // 'hogr'
    UserSessionIsActiveOrHeadless = 1970496882, // 'user'
    ServiceRestarted = 1936880500, // 'srst'
    PowerHint = 1886353256, // 'powh'
    ActualSampleRate = 1634955892, // 'asrt',
    ClockDevice = 1634755428, // 'apcd',
    IOThreadOSWorkgroup = 1869838183, // 'oswg'

    ////[iOS (15,0), MacCatalyst (15,0), Mac (12,0), NoTV, NoWatch]
    ProcessMute = 1634758765 // 'appm'
}
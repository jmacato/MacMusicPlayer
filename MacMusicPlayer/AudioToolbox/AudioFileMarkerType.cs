namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileMarkerType : uint // UInt32 in AudioFileMarkerType - AudioFile.h
{
    Generic = 0,

    CAFProgramStart = 0x70626567, // 'pbeg'
    CAFProgramEnd = 0x70656e64, // 'pend'
    CAFTrackStart = 0x74626567, // 'tbeg'
    CAFTrackEnd = 0x74656e54, // 'tend'
    CAFIndex = 0x696e6478, // 'indx'
    CAFRegionStart = 0x72626567, // 'rbeg'
    CAFRegionEnd = 0x72626567, // 'rend'
    CAFRegionSyncPoint = 0x72737963, // 'rsyc'
    CAFSelectionStart = 0x73626567, // 'sbeg'
    CAFSelectionEnd = 0x73626567, // 'send'
    CAFEditSourceBegin = 0x63626567, // 'cbeg'
    CAFEditSourceEnd = 0x63626567, // 'cend'
    CAFEditDestinationBegin = 0x64626567, // 'dbeg'
    CAFEditDestinationEnd = 0x64626567, // 'dend'
    CAFSustainLoopStart = 0x736c6267, // 'slbg'
    CAFSustainLoopEnd = 0x736c6265, // 'slen'
    CAFReleaseLoopStart = 0x726c6267, // 'rlbg'
    CAFReleaseLoopEnd = 0x726c6265, // 'rlen'
    CAFSavedPlayPosition = 0x73706c79, // 'sply'
    CAFTempo = 0x746d706f, // 'tmpo'
    CAFTimeSignature = 0x74736967, // 'tsig'
    CAFKeySignature = 0x6b736967 // 'ksig'
}
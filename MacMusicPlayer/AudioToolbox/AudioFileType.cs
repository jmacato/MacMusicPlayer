namespace MacMusicPlayer.AudioToolbox;

public enum AudioFileType
{
    // UInt32 AudioFileTypeID
    AIFF = 0x41494646, // AIFF
    AIFC = 0x41494643, // AIFC
    WAVE = 0x57415645, // WAVE 
    RF64 = 0x52463634, // RF64
    SoundDesigner2 = 0x53643266, // Sd2f
    Next = 0x4e655854, // NeXT
    MP3 = 0x4d504733, // MPG3
    MP2 = 0x4d504732, // MPG2
    MP1 = 0x4d504731, // MPG1
    AC3 = 0x61632d33, // ac-3
    AAC_ADTS = 0x61647473, // adts
    MPEG4 = 0x6d703466, // mp4f
    M4A = 0x6d346166, // m4af
    M4B = 0x6d346266, // m4bf
    CAF = 0x63616666, // caff
    ThreeGP = 0x33677070, // 3gpp
    ThreeGP2 = 0x33677032, // 3gp2
    AMR = 0x616d7266, // amrf 
    FLAC = 0x666c6163, // flac 
    LatmInLoas = 0x6c6f6173 // loas
}
namespace MacMusicPlayer.AudioUnit;

public enum InstrumentType : byte // UInt8 in AUSamplerInstrumentData
{
    DLSPreset = 1,
    SF2Preset = DLSPreset,
    AUPreset = 2,
    Audiofile = 3,
    EXS24 = 4
}
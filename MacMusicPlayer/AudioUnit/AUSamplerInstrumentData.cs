using System;
using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
internal struct AUSamplerInstrumentData
{
    public IntPtr FileUrl;
    public InstrumentType InstrumentType;
    public byte BankMSB;
    public byte BankLSB;
    public byte PresetID;
}
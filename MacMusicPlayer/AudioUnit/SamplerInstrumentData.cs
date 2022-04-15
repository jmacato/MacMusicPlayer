using MacMusicPlayer.CoreFoundation;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioUnit;

public class SamplerInstrumentData
{
    public const byte DefaultPercussionBankMSB = 0x78;
    public const byte DefaultMelodicBankMSB = 0x79;
    public const byte DefaultBankLSB = 0x00;

    public SamplerInstrumentData(CFUrl fileUrl, InstrumentType instrumentType)
    {
        if (fileUrl is null)
            ThrowHelper.ThrowArgumentNullException(nameof(fileUrl));

        FileUrl = fileUrl;
        InstrumentType = instrumentType;
    }

    public CFUrl FileUrl { get; private set; }
    public InstrumentType InstrumentType { get; private set; }
    public byte BankMSB { get; set; }
    public byte BankLSB { get; set; }
    public byte PresetID { get; set; }

    internal AUSamplerInstrumentData ToStruct()
    {
        var data = new AUSamplerInstrumentData();
        data.FileUrl = FileUrl.Handle;
        data.InstrumentType = InstrumentType;
        data.BankMSB = BankMSB;
        data.BankLSB = BankLSB;
        data.PresetID = PresetID;
        return data;
    }
}
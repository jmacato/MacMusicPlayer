namespace MacMusicPlayer.AudioToolbox;

internal enum AudioConverterPropertyID // typedef UInt32 AudioConverterPropertyID
{
    MinimumInputBufferSize = 0x6d696273, // 'mibs'
    MinimumOutputBufferSize = 0x6d6f6273, // 'mobs'

    // Deprecated
    // MaximumInputBufferSize		= 0x78696273, // 'xibs'
    MaximumInputPacketSize = 0x78697073, // 'xips'
    MaximumOutputPacketSize = 0x786f7073, // 'xops'
    CalculateInputBufferSize = 0x63696273, // 'cibs'
    CalculateOutputBufferSize = 0x636f6273, // 'cobs'

    // TODO: Format specific
    // InputCodecParameters         = 'icdp'
    // OutputCodecParameters        = 'ocdp'

    // Deprecated
    // SampleRateConverterAlgorithm = 'srci'
    SampleRateConverterComplexity = 0x73726361, // 'srca'
    SampleRateConverterQuality = 0x73726371, // 'srcq'
    SampleRateConverterInitialPhase = 0x73726370, // 'srcp'
    CodecQuality = 0x63647175, // 'cdqu'
    PrimeMethod = 0x70726d6d, // 'prmm'
    PrimeInfo = 0x7072696d, // 'prim'
    ChannelMap = 0x63686d70, // 'chmp'
    DecompressionMagicCookie = 0x646d6763, // 'dmgc'
    CompressionMagicCookie = 0x636d6763, // 'cmgc'
    EncodeBitRate = 0x62726174, // 'brat'
    EncodeAdjustableSampleRate = 0x616a7372, // 'ajsr'
    InputChannelLayout = 0x69636c20, // 'icl '
    OutputChannelLayout = 0x6f636c20, // 'ocl '
    ApplicableEncodeBitRates = 0x61656272, // 'aebr'
    AvailableEncodeBitRates = 0x76656272, // 'vebr'
    ApplicableEncodeSampleRates = 0x61657372, // 'aesr'
    AvailableEncodeSampleRates = 0x76657372, // 'vesr'
    AvailableEncodeChannelLayoutTags = 0x6165636c, // 'aecl'
    CurrentOutputStreamDescription = 0x61636f64, // 'acod'
    CurrentInputStreamDescription = 0x61636964, // 'acid'
    PropertySettings = 0x61637073, // 'acps'	// TODO
    PropertyBitDepthHint = 0x61636264, // 'acbd'
    PropertyFormatList = 0x666c7374, // 'flst'
    CanResumeFromInterruption = 0x63726669 // 'crfi'
}
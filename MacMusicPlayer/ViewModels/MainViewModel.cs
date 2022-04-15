using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MacMusicPlayer.AudioToolbox;
using MacMusicPlayer.AudioUnit;

namespace MacMusicPlayer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    private AudioStreamBasicDescription audioStreamBasicDesc;
    private AudioUnit.AudioUnit audioUnit;
    private string m_recordingFilePath;
    private readonly byte[] _soundBuffer;
    private int _sampleNum;

    public MainViewModel()
    {
        var op = new AudioComponentDescription()
        {
            ComponentFlags = 0,
            ComponentFlagsMask = 0,
            ComponentManufacturer = AudioComponentManufacturerType.Apple,
            ComponentType = AudioComponentType.Output,
            ComponentSubType = AudioUnitSubType.SystemOutput
        };
        
        var _audioComponent = AudioComponent.FindNextComponent(null, ref op);

        audioUnit = _audioComponent.CreateAudioUnit();

        audioUnit = new AudioUnit.AudioUnit(_audioComponent);

        audioUnit.SetEnableIO(true, AudioUnitScopeType.Output);


        // // setting audio format
        // audioUnit.SetFormat(audioStreamBasicDesc,
        //     AudioUnitScopeType.Output,
        //     0
        // );


        var currentAudioFormat = audioUnit.GetAudioFormat(AudioUnitScopeType.Output);
        //
        // var sampleRate = (int) currentAudioFormat.SampleRate;
        // var buffer = new float[sampleRate];
        // var amplitude = 100;
        // var frequency1 = 329.63f;
        //
        // for (var n = 0; n < buffer.Length; n++)
        // {
        //     buffer[n] = (amplitude * MathF.Sin((2f * MathF.PI * n * frequency1) / sampleRate));
        // }
        //  
        //
        // _soundBuffer = new byte[buffer.Length * sizeof(float)];
        //
        // Buffer.BlockCopy(buffer, 0, _soundBuffer, 0, _soundBuffer.Length);

        _soundBuffer = File.ReadAllBytes("/Users/jumarmacato/Documents/Development/MacMusicPlayer/output2.raw");

        audioUnit.SetRenderCallback(render_CallBack, AudioUnitScopeType.Output, 0);
        audioUnit.Initialize();
        audioUnit.Start();
    }

    private unsafe AudioUnitStatus render_CallBack(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
        uint busNumber, uint numberFrames, AudioBuffers data)
    { 
        var channelCounters = new int[data.Count];

        for (var samples = 0; samples < numberFrames; samples++)
        for (var channels = 0; channels < data.Count; channels++)
        for (var sampleByteCounter = 0; sampleByteCounter < sizeof(float); sampleByteCounter++)
        {
            var sampleByte = _soundBuffer[_sampleNum];
            var curDat = (byte*) data[channels].Data;
            curDat[channelCounters[channels]++] = sampleByte;
            _sampleNum++;

            if (_sampleNum >= _soundBuffer.Length)
                // start over from the beginning of the data, our audio simply loops
                _sampleNum = 0;
        }

        return AudioUnitStatus.NoError;
    }

    private AudioUnitStatus input_CallBack(AudioUnitRenderActionFlags actionflags, AudioTimeStamp timestamp,
        uint busnumber, uint numberframes, AudioUnit.AudioUnit audiounit)
    {
        return AudioUnitStatus.NoError;
    }
}
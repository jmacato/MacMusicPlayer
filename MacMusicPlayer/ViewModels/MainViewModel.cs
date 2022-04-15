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

        var audioComponent = AudioComponent.FindNextComponent(null, ref op);

        if (audioComponent is null)
        {
            throw new InvalidOperationException("Cannot find the AudioComponent for the macOS CoreAudio backend.");
        }

        var audioUnit = new AudioUnit.AudioUnit(audioComponent);

        audioUnit.SetEnableIO(true, AudioUnitScopeType.Output);

        var currentAudioFormat = audioUnit.GetAudioFormat(AudioUnitScopeType.Output);

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
}


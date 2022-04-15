using System;
using System.Buffers;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using AudioToolbox;
using AudioUnit;

namespace MacMusicPlayer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        AudioStreamBasicDescription audioStreamBasicDesc;
        AudioUnit.AudioUnit audioUnit;
        string m_recordingFilePath;
        ExtAudioFile extAudioFileObj;
        private readonly byte[] _soundBuffer;
        private int _sampleNum;


        public MainViewModel()
        {
            audioStreamBasicDesc.SampleRate = 44_100;
            audioStreamBasicDesc.Format = AudioFormatType.LinearPCM;
            audioStreamBasicDesc.FramesPerPacket = 1;
            audioStreamBasicDesc.ChannelsPerFrame = 2;
            audioStreamBasicDesc.BytesPerFrame = audioStreamBasicDesc.ChannelsPerFrame * sizeof(ushort);
            audioStreamBasicDesc.BytesPerPacket = audioStreamBasicDesc.ChannelsPerFrame * sizeof(ushort);
            audioStreamBasicDesc.BitsPerChannel = 16;
            audioStreamBasicDesc.Reserved = 0;
            audioStreamBasicDesc.FormatFlags = AudioFormatFlags.LinearPCMIsSignedInteger;

            var _audioComponent = AudioComponent.FindComponent(AudioTypeOutput.Remote);

            audioUnit = _audioComponent.CreateAudioUnit();

            audioUnit = new AudioUnit.AudioUnit(_audioComponent);

            audioUnit.SetEnableIO(true,
                AudioUnitScopeType.Output,
                0 // Remote Input
            );

            // setting audio format
            audioUnit.SetFormat(audioStreamBasicDesc,
                AudioUnitScopeType.Output,
                0
            );


            _soundBuffer = new byte[44_100 * 2 * 10];

            Random.Shared.NextBytes(_soundBuffer);

            // audioUnit.SetInputCallback(input_CallBack, AudioUnitScopeType.Input, 1);

            audioUnit.SetRenderCallback(render_CallBack, AudioUnitScopeType.Output, 0);


            audioUnit.Initialize();
            audioUnit.Start();
        }


        private unsafe AudioUnitStatus render_CallBack(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
            uint busNumber, uint numberFrames, AudioBuffers data)
        {
            var sndbuf = _soundBuffer[busNumber];

            var sample = _sampleNum; // frame number to start from
            var bufSamples = _soundBuffer.Length; // total number of frames in the sound buffer

            var outA = (int*) data[0].Data; // output audio buffer for L channel
            var outB = (int*) data[1].Data; // output audio buffer for R channel

            // for demonstration purposes we've configured 2 stereo input busses for the mixer unit
            // but only provide a single channel of data from each input bus when asked and silence for the other channel
            // alternating as appropriate when asked to render bus 0 or bus 1's input
            for (var i = 0; i < numberFrames; ++i)
            {
                outA[i] = _soundBuffer[sample++];
                outB[i] = _soundBuffer[sample++];
                
                if (sample >= bufSamples)
                {
                    // start over from the beginning of the data, our audio simply loops
                    Console.WriteLine("Looping data for bus {0} after {1} source frames rendered", busNumber,
                        sample - 1);
                    sample = 0;
                }
            }

            // keep track of where we are in the source data buffer
            _sampleNum = sample;

            return AudioUnitStatus.NoError;

            for (int i = 0; i < data.Count; i++)
            {
                var buffer = data[i];
                var bS = buffer.DataByteSize;
                var randomData = new byte[bS * 2];

                Random.Shared.NextBytes(randomData);

                fixed (void* p = &randomData[0])
                {
                    Buffer.MemoryCopy(p, buffer.Data.ToPointer(), bS, bS);
                }
            }

            Console.WriteLine($"PING! {actionFlags} {timeStamp}");

            return AudioUnitStatus.NoError;
        }

        private AudioUnitStatus input_CallBack(AudioUnitRenderActionFlags actionflags, AudioTimeStamp timestamp,
            uint busnumber, uint numberframes, AudioUnit.AudioUnit audiounit)
        {
            return AudioUnitStatus.NoError;
        }
    }
}
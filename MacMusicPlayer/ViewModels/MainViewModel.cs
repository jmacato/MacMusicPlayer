using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
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

            _soundBuffer = File.ReadAllBytes("/Users/jumarmacato/Documents/Development/MacMusicPlayer/output.raw");

            audioUnit.SetRenderCallback(render_CallBack, AudioUnitScopeType.Output, 0);
            audioUnit.Initialize();
            audioUnit.Start();
        }
        
        private unsafe AudioUnitStatus render_CallBack(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp,
            uint busNumber, uint numberFrames, AudioBuffers data)
        {
            var sndbuf = _soundBuffer[busNumber];

            var bufSamples = _soundBuffer.Length; // total number of frames in the sound buffer

            var outA = (byte*) data[0].Data; // output audio buffer for L channel
            // var outB = (byte*) data[1].Data; // output audio buffer for R channel

            var outAIndex = 0;
            for (var i = 0; i < numberFrames; ++i)
            {
                for (int t = 0; t < sizeof(float); t++)
                {
                    var o = _soundBuffer[_sampleNum];
                    ;
                    outA[outAIndex++] = o;
                    _sampleNum++;

                    if (_sampleNum >= _soundBuffer.Length)
                    {
                        // start over from the beginning of the data, our audio simply loops
                        // Console.WriteLine("Looping data for bus {0} after {1} source frames rendered", busNumber,
                        //     _sampleNum - 1);
                        _sampleNum = 0;
                    }
                }

                // outB[i] = (byte) (_soundBuffer[sample++]);
            }


            return AudioUnitStatus.NoError;
        }

        private AudioUnitStatus input_CallBack(AudioUnitRenderActionFlags actionflags, AudioTimeStamp timestamp,
            uint busnumber, uint numberframes, AudioUnit.AudioUnit audiounit)
        {
            return AudioUnitStatus.NoError;
        }
    }
}
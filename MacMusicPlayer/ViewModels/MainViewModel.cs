using System;
using System.Collections.Generic;
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

 
        
        public MainViewModel()
        {
           

            audioStreamBasicDesc.SampleRate = 16000;
            audioStreamBasicDesc.Format = AudioFormatType.LinearPCM;
            audioStreamBasicDesc.FramesPerPacket = 1;
            audioStreamBasicDesc.ChannelsPerFrame = 1;
            audioStreamBasicDesc.BytesPerFrame = audioStreamBasicDesc.ChannelsPerFrame * sizeof(short);
            audioStreamBasicDesc.BytesPerPacket = audioStreamBasicDesc.ChannelsPerFrame * sizeof(short);
            audioStreamBasicDesc.BitsPerChannel = 16;
            audioStreamBasicDesc.Reserved = 0;
            audioStreamBasicDesc.FormatFlags = AudioFormatFlags.IsSignedInteger | AudioFormatFlags.IsPacked;
            var _audioComponent =   AudioComponent.FindComponent(AudioTypeOutput.Remote);

            audioUnit = _audioComponent.CreateAudioUnit();

            audioUnit = new AudioUnit.AudioUnit(_audioComponent);

            audioUnit.SetEnableIO(true,
                AudioUnitScopeType.Input,
                1 // Remote Input
            );

            // setting audio format
            audioUnit.SetFormat(audioStreamBasicDesc,
                AudioUnitScopeType.Output,
                1
            );                                    

            audioUnit.SetInputCallback(input_CallBack, AudioUnitScopeType.Input, 1);

            audioUnit.SetRenderCallback(render_CallBack, AudioUnitScopeType.Global, 0);


            audioUnit.Initialize();
            audioUnit.Start();
        }

        private AudioUnitStatus render_CallBack(AudioUnitRenderActionFlags actionFlags, AudioTimeStamp timeStamp, uint busNumber, uint numberFrames, AudioBuffers data)
        {

            // getting microphone input signal
            var status = audioUnit.Render(ref actionFlags,
                timeStamp,
                1, // Remote input
                numberFrames,
                data);
            
            if (status != AudioUnitStatus.OK)
            {
                return status;
            }

            //get pointer to buffer
            var outP = data[0].Data;
            unsafe
            {
                var outPtr = (int*)outP.ToPointer();
                for (int i = 0; i < numberFrames; i++)
                {
                    var val = *outPtr;
                    outPtr++;
                    //lastestPickVal = val; //This is for ploting graph
                    Console.WriteLine(val);
                }
            }
            // extAudioFileObj.ClientDataFormat = audioStreamBasicDesc;
            // var err = extAudioFileObj.Write(numberFrames, data); //Here i am trying to write data into .wav file and file is generated also but corrupted file without actual data (create file size is approx 4kb or 100 kb )
            Console.WriteLine("OUTPUT" + busNumber);
            return AudioUnitStatus.NoError;
            
        }

        private AudioUnitStatus input_CallBack(AudioUnitRenderActionFlags actionflags, AudioTimeStamp timestamp, uint busnumber, uint numberframes, AudioUnit.AudioUnit audiounit)
        {
            return AudioUnitStatus.NoError;
            
        }
    }
}
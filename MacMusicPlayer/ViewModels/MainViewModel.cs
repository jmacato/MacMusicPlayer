using System;
using System.Collections.Generic;
using System.Text;
using AudioUnit;

namespace MacMusicPlayer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        public string Greeting => "Welcome to Avalonia!";

        public MainViewModel()
        {
            var k = new AudioComponentDescription();
            k.ComponentType = AudioComponentType.Output;
            k.ComponentSubType = AudioUnitSubType.GenericOutput;
            k.ComponentManufacturer = AudioComponentManufacturerType.Apple;

            var comp = AudioComponent.FindNextComponent(null, ref k);

            var kx = new AudioUnit.AudioUnit(comp);

        }
    }
}
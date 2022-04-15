using System;
using System.Runtime.InteropServices;

namespace MacMusicPlayer.AudioUnit;

[StructLayout(LayoutKind.Sequential)]
internal struct AudioUnitConnection
{
    public IntPtr SourceAudioUnit;

    public uint /* UInt32 */
        SourceOutputNumber;

    public uint /* UInt32 */
        DestInputNumber;
}
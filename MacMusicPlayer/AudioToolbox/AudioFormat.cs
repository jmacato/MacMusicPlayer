// 
// AudioFormat.cs:
//
// Authors:
//    Miguel de Icaza (miguel@xamarin.com)
//    Marek Safar (marek.safar@gmail.com)
//     
// Copyright 2012 Xamarin Inc
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#nullable enable

using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;
// //using Foundation;

namespace MacMusicPlayer.AudioToolbox;

// AudioFormatListItem
#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#else
// //[Watch (6,0)]
#endif
[StructLayout(LayoutKind.Sequential)]
public struct AudioFormat
{
    public AudioStreamBasicDescription AudioStreamBasicDescription;
    public AudioChannelLayoutTag AudioChannelLayoutTag;

#if !WATCH
    public static unsafe AudioFormat? GetFirstPlayableFormat(AudioFormat[] formatList)
    {
        if (formatList is null)
            ThrowHelper.ThrowArgumentNullException(nameof(formatList));
        if (formatList.Length < 2)
            ThrowHelper.ThrowArgumentNullException(nameof(formatList));

        fixed (AudioFormat* item = &formatList[0])
        {
            uint index;
            var size = sizeof(uint);
            var ptr_size = sizeof(AudioFormat) * formatList.Length;
            if (AudioFormatPropertyNative.AudioFormatGetProperty(AudioFormatProperty.FirstPlayableFormatFromList,
                    ptr_size, item, ref size, out index) != 0)
                return null;
            return formatList[index];
        }
    }
#endif

    public override string ToString()
    {
        return AudioChannelLayoutTag + ":" + AudioStreamBasicDescription.ToString();
    }
}

#if !WATCH

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif

#if NETXXX
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif

// Properties are used from various types (most suitable should be used)
#endif // !WATCH
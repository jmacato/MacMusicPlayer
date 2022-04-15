// 
// AudioSessions.cs:
//
// Authors: Mono Team
//     
// Copyright 2009 Novell, Inc
// Copyright 2011, 2012 Xamarin Inc.
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

namespace MacMusicPlayer.AudioToolbox;

public enum AudioSessionErrors
{
    // Implictly cast to OSType 
    None = 0,
    NotInitialized = 0x21696e69, // '!ini',
    AlreadyInitialized = 0x696e6974, // 'init',
    InitializationError = 0x696e693f, // 'ini?',
    UnsupportedPropertyError = 0x7074793f, // 'pty?',
    BadPropertySizeError = 0x2173697a, // '!siz',
    NotActiveError = 0x21616374, // '!act',
    NoHardwareError = 0x6e6f6877, // 'nohw'
    IncompatibleCategory = 0x21636174, // '!cat'
    NoCategorySet = 0x3f636174, // '?cat'
    UnspecifiedError = 0x77686371 // 'what'
}

// Should be internal with AudioSessionPropertyListener public

//[Deprecated (PlatformName.iOS, 6, 0)]
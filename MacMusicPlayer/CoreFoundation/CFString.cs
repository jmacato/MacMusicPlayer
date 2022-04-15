//
// CFBase.cs: Contains base types
//
// Authors:
//    Miguel de Icaza (miguel@novell.com)
//    Rolf Bjarne Kvinge (rolf@xamarin.com)
//
// Copyright 2012 Xamarin Inc
//
// The class can be either constructed from a string (from user code)
// or from a handle (from iphone-sharp.dll internal calls).  This
// delays the creation of the actual managed string until actually
// required
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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;
using NativeHandle = System.IntPtr;

namespace MacMusicPlayer.CoreFoundation
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CfRange
    {
        private readonly nint loc; // defined as 'long' in native code
        private readonly nint len; // defined as 'long' in native code

        public int Location => (int) loc;

        public int Length => (int) len;

        public long LongLocation => loc;

        public long LongLength => len;

        public CfRange(int loc, int len)
        {
            this.loc = loc;
            this.len = len;
        }

        public CfRange(long l, long len)
        {
            loc = (nint) l;
            this.len = (nint) len;
        }

        public CfRange(nint l, nint len)
        {
            loc = l;
            this.len = len;
        }

        public override string ToString()
        {
            return $"CFRange [Location: {loc} Length: {len}]";
        }
    }

    public static class CfObject
    {
        [DllImport(Constants.CoreFoundationLibrary)]
        internal static extern void CFRelease(IntPtr obj);

        [DllImport(Constants.CoreFoundationLibrary)]
        internal static extern IntPtr CFRetain(IntPtr obj);
    }

    public class CfString : NativeObject
    {
        internal string? Str;

        protected CfString()
        {
        }

        [DllImport(Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
        private static extern IntPtr CFStringCreateWithCharacters(IntPtr allocator, string? str, nint count);

        [DllImport(Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
        private static extern nint CFStringGetLength(IntPtr handle);

        [DllImport(Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
        private static extern unsafe char* CFStringGetCharactersPtr(IntPtr handle);

        [DllImport(Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
        private static extern unsafe IntPtr CFStringGetCharacters(IntPtr handle, CfRange range, char* buffer);

        public static NativeHandle CreateNative(string? value)
        {
            if (value is null)
                return NativeHandle.Zero;

            return CFStringCreateWithCharacters(IntPtr.Zero, value, value.Length);
        }

        public static void ReleaseNative(NativeHandle handle)
        {
            if (handle != NativeHandle.Zero)
                CfObject.CFRelease(handle);
        }

        public CfString(string? str)
        {
            if (str is null)
                ThrowHelper.ThrowArgumentNullException(nameof(str));

            Handle = CFStringCreateWithCharacters(IntPtr.Zero, str, str.Length);
            this.Str = str;
        }

        [DllImport(Constants.CoreFoundationLibrary, EntryPoint = "CFStringGetTypeID")]
        public static extern nint GetTypeID();

        public CfString(NativeHandle handle)
            : this(handle, false)
        {
        }

        protected internal CfString(NativeHandle handle, bool owns)
            : base(handle, owns)
        {
        }

        // to be used when an API like CF*Get* returns a CFString
        public static string? FromHandle(NativeHandle handle)
        {
            if (handle == IntPtr.Zero)
                return null;

            var l = (int) CFStringGetLength(handle);
            if (l == 0)
                return string.Empty;

            string str;
            var allocateMemory = false;
            var r = new CfRange(0, l);
            unsafe
            {
                // this returns non-null only if the string can be represented as unicode
                var u = CFStringGetCharactersPtr(handle);
                if (u == null)
                {
                    // alloc short string on the stack, otherwise use the heap
                    allocateMemory = l > 128;
                    // var m = allocate_memory ? (char*) Marshal.AllocHGlobal (l * 2) : stackalloc char [l];
                    // this ^ won't compile so...
                    if (allocateMemory)
                    {
                        u = (char*) Marshal.AllocHGlobal(l * 2);
                    }
                    else
                    {
                        // `u = stackalloc char [l];` won't compile either, even with cast
                        var u2 = stackalloc char[l];
                        u = u2;
                    }

                    CFStringGetCharacters(handle, r, u);
                }

                str = new string(u, 0, l);
                if (allocateMemory)
                    Marshal.FreeHGlobal((IntPtr) u);
            }

            return str;
        }

        // to be used when an API like CF*Copy* returns a CFString
        public static string? FromHandle(NativeHandle handle, bool releaseHandle)
        {
            var s = FromHandle(handle);
            if (releaseHandle && handle != IntPtr.Zero)
                CfObject.CFRelease(handle);
            return s;
        }

        public static implicit operator string?(CfString? x)
        {
            if (x is null)
                return null;

            return x.Str ?? (x.Str = FromHandle(x.Handle));
        }

        [return: NotNullIfNotNull("s")]
        public static implicit operator CfString?(string? s)
        {
            return s is null ? null : new CfString(s);
        }

        public int Length
        {
            get
            {
                if (Str != null)
                    return Str.Length;
                else
                    return (int) CFStringGetLength(Handle);
            }
        }

        [DllImport(Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U2)]
        private static extern char CFStringGetCharacterAtIndex(IntPtr handle, nint p);

        public char this[nint p]
        {
            get
            {
                if (Str != null)
                    return Str[(int) p];
                else
                    return CFStringGetCharacterAtIndex(Handle, p);
            }
        }

        public override string ToString()
        {
            if (Str is null)
                Str = FromHandle(Handle);
            return Str ?? base.ToString()!;
        }
    }
}
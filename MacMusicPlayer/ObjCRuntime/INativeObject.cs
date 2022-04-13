#nullable enable

using System;
using Foundation;
using NativeHandle = System.IntPtr;

namespace ObjCRuntime
{
    public interface INativeObject
    {
        NativeHandle Handle { get; }
    }

    public static class NativeObjectExtensions
    {
        // help to avoid the (too common pattern)
        // 	var p = x == null ? IntPtr.Zero : x.Handle;
        static public NativeHandle GetHandle(this INativeObject? self)
        {
            return self is null ? NativeHandle.Zero : self.Handle;
        }

        static public NativeHandle GetNonNullHandle(this INativeObject self, string argumentName)
        {
            if (self is null)
                ThrowHelper.ThrowArgumentNullException(argumentName);
            if (self.Handle == NativeHandle.Zero)
                ThrowHelper.ThrowObjectDisposedException(self);
            return self.Handle;
        }

        public static NativeHandle GetCheckedHandle(this INativeObject self)
        {
            var h = self.Handle;
            if (h == NativeHandle.Zero)
                ObjCRuntime.ThrowHelper.ThrowObjectDisposedException(self);

            return h;
        }
    }
}
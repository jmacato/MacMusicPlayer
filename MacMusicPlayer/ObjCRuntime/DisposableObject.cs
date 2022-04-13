//
// DisposableObject.cs: A base class for many native data types without assuming any particular lifecycle.

// Authors:
//   Rolf Bjarne Kvinge
//
// Copyright 2021 Microsoft Corp
//
using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using Foundation;

#nullable enable 

using NativeHandle = System.IntPtr; 

namespace ObjCRuntime {
	//
	// The DisposableObject class is intended to be a base class for many native data
	// data types, without assuming any particular lifecycle (might be reference counted,
	// might not be).
	//
	// It provides the common boilerplate for this kind of objects and the Dispose
	// pattern.
	//
	public abstract class DisposableObject : INativeObject, IDisposable {
		System.IntPtr handle;
		readonly bool owns;

		public System.IntPtr Handle {
			get => handle;
			protected set => InitializeHandle (value);
		}

		protected bool Owns { get => owns; }

		protected DisposableObject ()
		{
		}

		protected DisposableObject (NativeHandle handle, bool owns)
			: this (handle, owns, true)
		{
		}

		protected DisposableObject (NativeHandle handle, bool owns, bool verify)
		{
			InitializeHandle (handle, verify);
			this.owns = owns;
		}

		~DisposableObject ()
		{
			Dispose (false);
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			handle = NativeHandle.Zero;
		}
 
		void InitializeHandle (NativeHandle handle, bool verify)
		{ 
			if (verify && handle == NativeHandle.Zero && Class.ThrowOnInitFailure) {
				throw new Exception ($"Could not initialize an instance of the type '{GetType ().FullName}': handle is null.\n{Constants.SetThrowOnInitFailureToFalse}.");
			} 
			this.handle = handle;
		}

		protected virtual void InitializeHandle (NativeHandle handle)
		{
			InitializeHandle (handle, true);
		}

		public NativeHandle GetCheckedHandle ()
		{
			var h = handle;
			if (h == NativeHandle.Zero)
				ObjCRuntime.ThrowHelper.ThrowObjectDisposedException (this);
			return h;
		}
 
	}
}

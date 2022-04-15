// #nullable enable
//
// using System;
// using System.Runtime.InteropServices;
// using ObjCRuntime;
//
// namespace AudioUnit
// {
// #if NETXXX
// 	[SupportedOSPlatform ("ios9.0")]
// 	[SupportedOSPlatform ("macos10.11")]
// 	[SupportedOSPlatform ("maccatalyst")]
// 	[SupportedOSPlatform ("tvos")]
// #else
// 	//[iOS (9,0)]
// 	//[Mac (10,11)]
// #endif
// 	public partial class AUParameter
// 	{
// 		public string GetString (float? value)
// 		{
// 			unsafe {
// 				if (value is not null) {
// 					float f = value.Value;
// 					return this._GetString (new IntPtr (&f));
// 				}
// 				else {
// 					return this._GetString (IntPtr.Zero);
// 				}
// 			}
// 		}
// 	}
// }


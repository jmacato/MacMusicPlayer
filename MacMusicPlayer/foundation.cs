// //
// // This file describes the API that the generator will produce
// //
// // Authors:
// //   Geoff Norton
// //   Miguel de Icaza
// //   Aaron Bockover
// //
// // Copyright 2009, Novell, Inc.
// // Copyright 2010, Novell, Inc.
// // Copyright 2011-2013 Xamarin Inc.
// //
// // Permission is hereby granted, free of charge, to any person obtaining
// // a copy of this software and associated documentation files (the
// // "Software"), to deal in the Software without restriction, including
// // without limitation the rights to use, copy, modify, merge, publish,
// // distribute, sublicense, and/or sell copies of the Software, and to
// // permit persons to whom the Software is furnished to do so, subject to
// // the following conditions:
// // 
// // The above copyright notice and this permission notice shall be
// // included in all copies or substantial portions of the Software.
// // 
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// // MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// // LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// // OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// // WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// //
// //
// #define DOUBLE_BLOCKS
// using ObjCRuntime;
// using CloudKit;
// using CoreData;
// using CoreFoundation;
// using Foundation;
// using CoreGraphics;
// #if HAS_APPCLIP
// using AppClip;
// #endif
// #if IOS
// using QuickLook;
// #endif
// #if !TVOS
// using Contacts;
// #endif
// #if !WATCH
// using CoreAnimation;
// using CoreSpotlight;
// #endif
// using CoreMedia;
// using SceneKit;
// using Security;
// #if IOS || MONOMAC
// using FileProvider;
// #else
// using INSFileProviderItem = Foundation.NSObject;
// #endif
//
// #if MONOMAC
// using AppKit;
// using QuickLookUI;
// #else
// using CoreLocation;
// using UIKit;
// #endif
//
// using System;
// using System.ComponentModel;
//
// // In Apple headers, this is a typedef to a pointer to a private struct
// using NSAppleEventManagerSuspensionID = System.IntPtr;
// // These two are both four char codes i.e. defined on a uint with constant like 'xxxx'
// using AEKeyword = System.UInt32;
// using OSType = System.UInt32;
// // typedef double NSTimeInterval;
// using NSTimeInterval = System.Double;
//
// #if MONOMAC
// // dummy usings to make code compile without having the actual types available (for  to work)
// using NSDirectionalEdgeInsets = Foundation.NSObject;
// using UIEdgeInsets = Foundation.NSObject;
// using UIOffset = Foundation.NSObject;
// using UIPreferredPresentationStyle = Foundation.NSObject;
// #else
// using NSPasteboard = Foundation.NSObject;
// using NSWorkspaceAuthorization = Foundation.NSObject;
//
// using NSStringAttributes = UIKit.UIStringAttributes;
// #endif
//
// #if IOS && !__MACCATALYST__
// using NSAppleEventSendOptions = Foundation.NSObject;
// using NSBezierPath = Foundation.NSObject;
// using NSImage = Foundation.NSObject;
// #endif
//
// #if TVOS
// using NSAppleEventSendOptions = Foundation.NSObject;
// using NSBezierPath = Foundation.NSObject;
// using NSImage = Foundation.NSObject;
// #endif
//
// #if WATCH
// // dummy usings to make code compile without having the actual types available (for  to work)
// using NSAppleEventSendOptions = Foundation.NSObject;
// using NSBezierPath = Foundation.NSObject;
// using NSImage = Foundation.NSObject;
// using CSSearchableItemAttributeSet = Foundation.NSObject;
// #endif
//
// #if WATCH
// using CIBarcodeDescriptor = Foundation.NSObject;
// #else
// using CoreImage;
// #endif
//
// #if !IOS
// using APActivationPayload = Foundation.NSObject;
// #endif
//
// #if __MACCATALYST__
// using NSAppleEventSendOptions = Foundation.NSObject;
// using NSBezierPath = Foundation.NSObject;
// using NSImage = Foundation.NSObject;
// #endif
//
// #if IOS || WATCH || TVOS
// using NSNotificationSuspensionBehavior = Foundation.NSObject;
// using NSNotificationFlags = Foundation.NSObject;
// #endif
//
// #if !NETXXX
// using NativeHandle = System.IntPtr;
// #endif
//
// namespace Foundation {
// 	delegate void NSFilePresenterReacquirer ( Action reacquirer);
// }
//
// namespace Foundation
// {
// 	delegate NSComparisonResult NSComparator (NSObject obj1, NSObject obj2);
// 	delegate void NSAttributedRangeCallback (NSDictionary attrs, NSRange range, ref bool stop);
// 	delegate void NSAttributedStringCallback (NSObject value, NSRange range, ref bool stop);
//
// 	delegate bool NSEnumerateErrorHandler (NSUrl url, NSError error);
// 	delegate void NSMetadataQueryEnumerationCallback (NSObject result, nuint idx, ref bool stop);
// #if NETXXX
// 	delegate void NSItemProviderCompletionHandler (INSSecureCoding itemBeingLoaded, NSError error);
// #else
// 	delegate void NSItemProviderCompletionHandler (NSObject itemBeingLoaded, NSError error);
// #endif
// 	delegate void NSItemProviderLoadHandler ( NSItemProviderCompletionHandler completionHandler, Class expectedValueClass, NSDictionary options);
// 	delegate void EnumerateDatesCallback (NSDate date, bool exactMatch, ref bool stop);
// 	delegate void EnumerateIndexSetCallback (nuint idx, ref bool stop);
// 	delegate void CloudKitRegistrationPreparationAction ( CloudKitRegistrationPreparationHandler handler);
// 	delegate void CloudKitRegistrationPreparationHandler (CKShare share, CKContainer container, NSError error);
//
// #if NETXXX
// 	
// 	interface NSAutoreleasePool {
// 	}
// #endif
//
// 	interface NSArray<TValue> : NSArray {}
//
// 	
// 	
// 	interface NSArray : NSSecureCoding, NSMutableCopying, INSFastEnumeration, CKRecordValue {
// 		
// 		nuint Count { get; }
//
// 		
// 		NativeHandle ValueAt (nuint idx);
//
// 		
// 		
// 		
// 		IntPtr FromObjects (IntPtr array, nint count);
//
// 		
// 		
// 		NSObject ValueForKey (NSString key);
//
// 		
// 		void SetValueForKey (NSObject value, NSString key);
//
// 		
// 		
// 		
// 		
// 		
// 		bool WriteToFile (string path, bool useAuxiliaryFile);
//
// 		
// 		
// 		
// 		
// 		
// 		NSArray FromFile (string path);
// 		
// 		
// 		NSArray Sort (NSComparator cmptr);
// 		
// 		
// 		NSArray Filter (NSPredicate predicate);
//
// 		
// 		
// 		
// 		bool _Contains (NativeHandle anObject);
//
// 		
// 		bool Contains (NSObject anObject);
//
// 		
// 		
// 		
// 		nuint _IndexOf (NativeHandle anObject);
//
// 		
// 		nuint IndexOf (NSObject anObject);
//
// 		
// 		void AddObserver (NSObject observer, NSIndexSet indexes, string keyPath, NSKeyValueObservingOptions options, IntPtr context);
//
// 		
// 		void RemoveObserver (NSObject observer, NSIndexSet indexes, string keyPath, IntPtr context);
//
// 		
// 		void RemoveObserver (NSObject observer, NSIndexSet indexes, string keyPath);
//
// 		
// 		
// 		bool Write (NSUrl url, out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSArray FromUrl (NSUrl url, out NSError error);
// 	}
//
// #if MONOMAC
// 	interface NSAttributedStringDocumentAttributes { }
// #endif
//
// 	
// 	partial interface NSAttributedString : NSCoding, NSMutableCopying, NSSecureCoding
// 	#if MONOMAC
// 		, NSPasteboardReading, NSPasteboardWriting
// 	#endif
// 	#if IOS
// 		, NSItemProviderReading, NSItemProviderWriting
// 	#endif
// 	{
// #if !WATCH
// 		
// 		NSAttributedString FromAttachment (NSTextAttachment attachment);
// #endif
//
// 		
// 		IntPtr LowLevelValue { get; }
//
// 		
// #if NETXXX
// 		IntPtr LowLevelGetAttributes (nint location, IntPtr effectiveRange);
// #else
// 		IntPtr LowLevelGetAttributes (nint location, out NSRange effectiveRange);
// #endif
//
// 		
// 		nint Length { get; }
//
// 		// TODO: figure out the type, this deserves to be strongly typed if possble
// 		
// 		NSObject GetAttribute (string attribute, nint location, out NSRange effectiveRange);
//
// 		
// 		NSAttributedString Substring (NSRange range);
//
// 		
// 		NSDictionary GetAttributes (nint location, out NSRange longestEffectiveRange, NSRange rangeLimit);
//
// 		
// 		NSObject GetAttribute (string attribute, nint location, out NSRange longestEffectiveRange, NSRange rangeLimit);
//
// 		
// 		bool IsEqual (NSAttributedString other);
//
// 		
// 		NativeHandle Constructor (string str);
//
// #if !MONOMAC
//
// #if IOS
// 		// New API in iOS9 with same signature as an older alternative.
// 		// We expose only the *new* one for the new platforms as the old
// 		// one was moved to `NSDeprecatedKitAdditions (NSAttributedString)`
// 		
// 		
// 		
// 		
// 		IntPtr InitWithURL (NSUrl url,  NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
//
// 		// but we still need to allow the API to work before iOS 9.0
// 		// and to compleify matters the old one was deprecated in 9.0
// 		
// 		
// 		
// 		
// 		
// 		IntPtr InitWithFileURL (NSUrl url,  NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
// #elif TVOS || WATCH
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrl url,  NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
// #endif
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, ref NSError error);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (NSData data,  NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, ref NSError error);
//
// 		
// 		
// 		
// 		NSData GetDataFromRange (NSRange range, NSDictionary attributes, ref NSError error);
//
// 		
// 		
// 		
// 		NSData GetDataFromRange (NSRange range, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error);
//
// 		
// 		
// 		
// 		NSFileWrapper GetFileWrapperFromRange (NSRange range, NSDictionary attributes, ref NSError error);
//
// 		
// 		
// 		
// 		NSFileWrapper GetFileWrapperFromRange (NSRange range, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error);
// #endif
// 		
// 		
// 		
// 		NativeHandle Constructor (string str,  NSDictionary attributes);
//
// 		
// 		NativeHandle Constructor (NSAttributedString other);
//
// 		
// 		void EnumerateAttributes (NSRange range, NSAttributedStringEnumeration options, NSAttributedRangeCallback callback);
//
// 		
// 		void EnumerateAttribute (NSString attributeName, NSRange inRange, NSAttributedStringEnumeration options, NSAttributedStringCallback callback);
//
// #if MONOMAC
// 		
// 		
// 		NativeHandle Constructor (NSData data,  NSDictionary options, out NSDictionary docAttributes, out NSError error);
//
// 		
// 		
// 		NativeHandle Constructor(NSData wordDocFormat, out NSDictionary docAttributes);
//
// 		
// 		
// 		NativeHandle Constructor (NSData htmlData, NSUrl baseUrl, out NSDictionary docAttributes);
// 		
// 		
// 		
// 		void DrawString (CGRect rect, NSStringDrawingOptions options);	
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl url,  NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error);
//
// 		
// 		
// 		NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (string path, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		IntPtr InitWithRtf (NSData data, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		IntPtr InitWithRtfd (NSData data, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		IntPtr InitWithHTML (NSData data, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		NativeHandle Constructor (NSData data,   NSDictionary options, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		NativeHandle Constructor (NSFileWrapper wrapper, out NSDictionary resultDocumentAttributes);
//
// 		
// 		
// 		bool ContainsAttachments { get; }
//
// 		
// 		
// 		NSDictionary GetFontAttributes (NSRange range);
//
// 		
// 		
// 		NSDictionary GetRulerAttributes (NSRange range);
//
// 		
// 		
// 		nuint GetLineBreak (nuint beforeIndex, NSRange aRange);
//
// 		
// 		
// 		nuint GetLineBreakByHyphenating (nuint beforeIndex, NSRange aRange);
//
// 		
// 		
// 		NSRange DoubleClick (nuint index);
//
// 		
// 		
// 		nuint GetNextWord (nuint fromIndex, bool isForward);
//
// 		
// 		
// 		
// 		NSUrl GetUrl (nuint index, out NSRange effectiveRange);
//
// 		
// 		
// 		NSRange GetRange (NSTextBlock textBlock, nuint index);
//
// 		
// 		
// 		NSRange GetRange (NSTextTable textTable, nuint index);
//
// 		
// 		
// 		NSRange GetRange (NSTextList textList, nuint index);
//
// 		
// 		
// 		nint GetItemNumber (NSTextList textList, nuint index);
//
// 		
// 		
// 		NSData GetData (NSRange range,  NSDictionary options, out NSError error);
//
// 		
// 		
// 		NSData GetData (NSRange range, NSAttributedStringDocumentAttributes options, out NSError error);
//
// 		
// 		
// 		NSFileWrapper GetFileWrapper (NSRange range,  NSDictionary options, out NSError error);
//
// 		
// 		
// 		NSFileWrapper GetFileWrapper (NSRange range, NSAttributedStringDocumentAttributes options, out NSError error);
//
// 		
// 		
// 		NSData GetRtf (NSRange range,  NSDictionary options);
//
// 		
// 		
// 		NSData GetRtf (NSRange range, NSAttributedStringDocumentAttributes options);
//
// 		
// 		
// 		NSData GetRtfd (NSRange range,  NSDictionary options);
//
// 		
// 		
// 		NSData GetRtfd (NSRange range, NSAttributedStringDocumentAttributes options);
//
// 		
// 		
// 		NSFileWrapper GetRtfdFileWrapper (NSRange range,  NSDictionary options);
//
// 		
// 		
// 		NSFileWrapper GetRtfdFileWrapper (NSRange range, NSAttributedStringDocumentAttributes options);
//
// 		
// 		
// 		NSData GetDocFormat (NSRange range,  NSDictionary options);
//
// 		
// 		
// 		NSData GetDocFormat (NSRange range, NSAttributedStringDocumentAttributes options);
// #else
// 		
// 		
// 		void DrawString (CGRect rect, NSStringDrawingOptions options,  NSStringDrawingContext context);
//
// 		
// 		
// 		CGRect GetBoundingRect (CGSize size, NSStringDrawingOptions options,  NSStringDrawingContext context);
// #endif
//
// 		
// 		
// 		CGSize Size { get; }
//
// 		
// 		void DrawString (CGPoint point);
// 		
// 		
// 		void DrawString (CGRect rect);
//
// 		// -(BOOL)containsAttachmentsInRange:(NSRange)range __attribute__((availability(macosx, introduced=10.11)));
// 		
// 		
// 		bool ContainsAttachmentsInRange (NSRange range);
//
// 		// inlined from NSAttributedStringWebKitAdditions category (since they are all static members)
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSUrlRequest request, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSUrlRequest request, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSUrl fileUrl, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSUrl fileUrl, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (string @string, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (string @string, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSData data, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);
//
// 		 // really inside WKWebKit
// 		
// 		
// 		
// 		
// 		void LoadFromHtml (NSData data, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);
// 	}
//
// 	 // really inside WKWebKit
// 	
// 	delegate void NSAttributedStringCompletionHandler ( NSAttributedString attributedString,  NSDictionary<NSString, NSObject> attributes,  NSError error);
//
// 	 // really inside WKWebKit
// 	
// 	
// 	interface NSAttributedStringDocumentReadingOptionKeys {
// 		
// 		NSString ReadAccessUrlKey { get; }
// 	}
//
// 	[BaseType (typeof (NSObject),
// 		   Delegates=new string  { "WeakDelegate" },
// 		   Events=new Type  { typeof (NSCacheDelegate)} )]
// 	interface NSCache {
// 		
// 		NSObject ObjectForKey (NSObject key);
//
// 		
// 		void SetObjectforKey (NSObject obj, NSObject key);
//
// 		
// 		void SetCost (NSObject obj, NSObject key, nuint cost);
//
// 		
// 		void RemoveObjectForKey (NSObject key);
//
// 		
// 		void RemoveAllObjects ();
//
// 		//Detected properties
// 		
// 		string Name { get; set; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSCacheDelegate Delegate { get; set; }
//
// 		
// 		nuint TotalCostLimit { get; set; }
//
// 		
// 		nuint CountLimit { get; set; }
//
// 		
// 		bool EvictsObjectsWithDiscardedContent { get; set; }
// 	}
//
// 	
// 	
// 	
// 	interface NSCacheDelegate {
// 		
// 		void WillEvictObject (NSCache cache, NSObject obj);
// 	}
//
// 	
// 	// instance created with 'init' will crash when Dispose is called
// 	
// 	interface NSCachedUrlResponse : NSCoding, NSSecureCoding, NSCopying {
// 		
// 		NativeHandle Constructor (NSUrlResponse response, NSData data,  NSDictionary userInfo, NSUrlCacheStoragePolicy storagePolicy);
//
// 		
// 		NativeHandle Constructor (NSUrlResponse response, NSData data);
//           
// 		
// 		NSUrlResponse Response { get; }
//
// 		
// 		NSData Data { get; }
//
// 		
// 		NSDictionary UserInfo { get; }
//
// 		
// 		NSUrlCacheStoragePolicy StoragePolicy { get; }
// 	}
// 	
// 	
// 	// 'init' returns NIL - `init` now marked as NS_UNAVAILABLE
// 	
// 	interface NSCalendar : NSSecureCoding, NSCopying {
// 		
// 		
// 		NativeHandle Constructor (NSString identifier);
//
// 		
// 		string Identifier { get; }
//
// 		 
// 		NSCalendar CurrentCalendar { get; }
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		NSTimeZone TimeZone { get; set; } 
//
// 		
// 		nuint FirstWeekDay { get; set; } 
//
// 		
// 		nuint MinimumDaysInFirstWeek { get; set; }
//
// 		
// 		NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate);
//
// 		
// 		NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate, NSDate toDate, NSCalendarOptions opts);
//
// #if !NETXXX
// 		
// 		
// 		NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate, NSDate toDate, NSDateComponentsWrappingBehavior opts);
// #endif
//
// 		
// 		NSDate DateByAddingComponents (NSDateComponents comps, NSDate date, NSCalendarOptions opts);
//
// #if !NETXXX
// 		
// 		
// 		NSDate DateByAddingComponents (NSDateComponents comps, NSDate date, NSDateComponentsWrappingBehavior opts);
// #endif
//
// 		
// 		NSDate DateFromComponents (NSDateComponents comps);
//
// 		
// 		NSString NSGregorianCalendar { get; }
// 		
// 		
// 		NSString NSBuddhistCalendar { get; }
// 		
// 		
// 		NSString NSChineseCalendar { get; }
// 		
// 		
// 		NSString NSHebrewCalendar { get; }
// 		
// 		
// 		NSString NSIslamicCalendar { get; }
// 		
// 		
// 		NSString NSIslamicCivilCalendar { get; }
// 		
// 		
// 		NSString NSJapaneseCalendar { get; }
// 		
// 		
// 		NSString NSRepublicOfChinaCalendar { get; }
// 		
// 		
// 		NSString NSPersianCalendar { get; }
// 		
// 		
// 		NSString NSIndianCalendar { get; }
// 		
// 		
// 		NSString NSISO8601Calendar { get; }
//
// 		
// 		NSString CopticCalendar { get; }
//
// 		
// 		NSString EthiopicAmeteAlemCalendar { get; }
//
// 		
// 		NSString EthiopicAmeteMihretCalendar { get; }
//
// 		
// 		
// 		NSString IslamicTabularCalendar { get; }
//
// 		
// 		
// 		NSString IslamicUmmAlQuraCalendar { get; }
//
// 		
// 		string  EraSymbols { get; }
//
// 		
// 		string  LongEraSymbols { get; }
//
// 		
// 		string  MonthSymbols { get; }
//
// 		
// 		string  ShortMonthSymbols { get; }
//
// 		
// 		string  VeryShortMonthSymbols { get; }
//
// 		
// 		string  StandaloneMonthSymbols { get; }
//
// 		
// 		string  ShortStandaloneMonthSymbols { get; }
//
// 		
// 		string  VeryShortStandaloneMonthSymbols { get; }
//
// 		
// 		string  WeekdaySymbols { get; }
//
// 		
// 		string  ShortWeekdaySymbols { get; }
//
// 		
// 		string  VeryShortWeekdaySymbols { get; }
//
// 		
// 		string  StandaloneWeekdaySymbols { get; }
//
// 		
// 		string  ShortStandaloneWeekdaySymbols { get; }
//
// 		
// 		string  VeryShortStandaloneWeekdaySymbols { get; }
//
// 		
// 		string  QuarterSymbols { get; }
//
// 		
// 		string  ShortQuarterSymbols { get; }
//
// 		
// 		string  StandaloneQuarterSymbols { get; }
//
// 		
// 		string  ShortStandaloneQuarterSymbols { get; }
//
// 		
// 		string AMSymbol { get; }
//
// 		
// 		string PMSymbol { get; }
//
// 		
// 		
// 		NSComparisonResult CompareDate(NSDate date1, NSDate date2, NSCalendarUnit granularity);
//
// 		
// 		
// 		nint GetComponentFromDate (NSCalendarUnit unit, NSDate date);
//
// 		
// 		
// 		NSDateComponents ComponentsFromDateToDate (NSCalendarUnit unitFlags, NSDateComponents startingDate, NSDateComponents resultDate, NSCalendarOptions options);
//
// 		
// 		
// 		NSDateComponents ComponentsInTimeZone (NSTimeZone timezone, NSDate date);
//
// 		
// 		
// 		bool Matches (NSDate date, NSDateComponents components);
//
// 		
// 		
// 		NSDate DateByAddingUnit (NSCalendarUnit unit, nint value, NSDate date, NSCalendarOptions options);
//
// 		
// 		
// 		NSDate DateBySettingsHour (nint hour, nint minute, nint second, NSDate date, NSCalendarOptions options);
//
// 		
// 		
// 		NSDate DateBySettingUnit (NSCalendarUnit unit, nint value, NSDate date, NSCalendarOptions options);
//
// 		
// 		
// 		NSDate Date (nint era, nint year, nint month, nint date, nint hour, nint minute, nint second, nint nanosecond);
//
// 		
// 		
// 		NSDate DateForWeekOfYear (nint era, nint year, nint week, nint weekday, nint hour, nint minute, nint second, nint nanosecond);
//
// 		
// 		
// 		void EnumerateDatesStartingAfterDate (NSDate start, NSDateComponents matchingComponents, NSCalendarOptions options,  EnumerateDatesCallback callback);
//
// 		
// 		
// 		void GetComponentsFromDate (out nint era, out nint year, out nint month, out nint day, NSDate date);
//
// 		
// 		
// 		void GetComponentsFromDateForWeekOfYear (out nint era, out nint year, out nint weekOfYear, out nint weekday, NSDate date);
//
// 		
// 		
// 		void GetHourComponentsFromDate (out nint hour, out nint minute, out nint second, out nint nanosecond, NSDate date);
//
// 		
// 		
// 		bool IsEqualToUnitGranularity (NSDate date1, NSDate date2, NSCalendarUnit unit);
//
// 		
// 		
// 		bool IsInSameDay (NSDate date1, NSDate date2);
//
// 		
// 		
// 		bool IsDateInToday (NSDate date);
//
// 		
// 		
// 		bool IsDateInTomorrow (NSDate date);
//
// 		
// 		
// 		bool IsDateInWeekend (NSDate date);
//
// 		
// 		
// 		bool IsDateInYesterday (NSDate date);
//
// 		
// 		
// 		
// 		NSDate FindNextDateAfterDateMatching (NSDate date, NSDateComponents components, NSCalendarOptions options);
//
// 		
// 		
// 		
// 		NSDate FindNextDateAfterDateMatching (NSDate date, nint hour, nint minute, nint second, NSCalendarOptions options);
//
// 		
// 		
// 		
// 		NSDate FindNextDateAfterDateMatching (NSDate date, NSCalendarUnit unit, nint value, NSCalendarOptions options);
//
// 		
// 		
// 		bool FindNextWeekend (out NSDate date, out double /* NSTimeInterval */ interval, NSCalendarOptions options, NSDate afterDate);
//
// 		
// 		
// 		bool RangeOfWeekendContainingDate (out NSDate weekendStartDate, out double /* NSTimeInterval */ interval, NSDate date);
// 		
// 		// although the ideal would be to use GetRange, we already have the method
// 		// RangeOfWeekendContainingDate and for the sake of consistency we are 
// 		// going to use the same name pattern.
// 		
// 		NSRange MinimumRange (NSCalendarUnit unit);
//
// 		
// 		NSRange MaximumRange (NSCalendarUnit unit);
//
// 		
// 		NSRange Range (NSCalendarUnit smaller, NSCalendarUnit larger, NSDate date);
//
// 		
// 		nuint Ordinality (NSCalendarUnit smaller, NSCalendarUnit larger, NSDate date);
//
// 		
// 		bool Range (NSCalendarUnit unit,  out NSDate datep, out double /* NSTimeInterval */ interval, NSDate date);
//
// 		
// 		
// 		NSDate StartOfDayForDate (NSDate date);
//
// 		
// 		
// 		
// 		NSString DayChangedNotification { get; }
// 	}
//
// 	// Obsolete, but the only API surfaced by WebKit.WebHistory.
// 	
// 	
// 	
// 	interface NSCalendarDate {
// 		
// 		
// 		NativeHandle Constructor (string description, string calendarFormat, NSObject locale);
//
// 		
// 		
// 		NativeHandle Constructor (string description, string calendarFormat);
//
// 		
// 		
// 		NativeHandle Constructor (string description);
//
// 		
// 		
// 		NativeHandle Constructor (nint year, nuint month, nuint day, nuint hour, nuint minute, nuint second,  NSTimeZone aTimeZone);
//
// 		
// 		
// 		NSCalendarDate DateByAddingYears (nint year, nint month, nint day, nint hour, nint minute, nint second);
//
// 		
// 		
// 		nint DayOfCommonEra { get; }
//
// 		
// 		
// 		nint DayOfMonth { get; }
//
// 		
// 		
// 		nint DayOfWeek { get; }
//
// 		
// 		
// 		nint DayOfYear { get; }
//
// 		
// 		
// 		nint HourOfDay { get; }
//
// 		
// 		
// 		nint MinuteOfHour { get; }
//
// 		
// 		
// 		nint MonthOfYear { get; }
//
// 		
// 		
// 		nint SecondOfMinute { get; }
//
// 		
// 		
// 		nint YearOfCommonEra { get; }
//
// 		
// 		
// 		string CalendarFormat { get; set; }
//
// 		
// 		
// 		string GetDescription (string calendarFormat, NSObject locale);
//
// 		
// 		
// 		string GetDescription (string calendarFormat);
//
// 		
// 		
// 		string GetDescription (NSLocale locale);
//
// 		
// 		
// 		NSTimeZone TimeZone { get; set; }
// 	}
//
// 	
// 	interface NSCharacterSet : NSSecureCoding, NSMutableCopying {
// 		
// 		NSCharacterSet Alphanumerics {get;}
//
// 		
// 		NSCharacterSet Capitalized {get;}
//
// 		// TODO/FIXME: constructor?
// 		
// 		NSCharacterSet FromBitmap (NSData data);
//
// 		// TODO/FIXME: constructor?
// 		
// 		NSCharacterSet FromString (string aString);
//
// 		
// 		NSCharacterSet FromFile (string path);
//
// 		
// 		NSCharacterSet FromRange (NSRange aRange);
//
// 		
// 		NSCharacterSet Controls {get;}
//
// 		
// 		NSCharacterSet DecimalDigits {get;}
//
// 		
// 		NSCharacterSet Decomposables {get;}
//
// 		
// 		NSCharacterSet Illegals {get;}
//
// 		
// 		NSCharacterSet Letters {get;}
//
// 		
// 		NSCharacterSet LowercaseLetters {get;}
//
// 		
// 		NSCharacterSet Newlines {get;}
//
// 		
// 		NSCharacterSet Marks {get;}
//
// 		
// 		NSCharacterSet Punctuation {get;}
//
// 		
// 		NSCharacterSet Symbols {get;}
//
// 		
// 		NSCharacterSet UppercaseLetters {get;}
//
// 		
// 		NSCharacterSet WhitespaceAndNewlines {get;}
//
// 		
// 		NSCharacterSet Whitespaces {get;}
//
// 		
// 		NSData GetBitmapRepresentation ();
//
// 		
// 		bool Contains (char aCharacter);
//
// 		
// 		bool HasMemberInPlane (byte thePlane);
//
// 		
// 		NSCharacterSet InvertedSet {get;}
//
// 		
// 		bool IsSupersetOf (NSCharacterSet theOtherSet);
//
// 		
// 		bool Contains (uint /* UTF32Char = UInt32 */ theLongChar);
// 	}
//
// 	
// 	
// 	interface NSMassFormatter {
// 		
// 		NSNumberFormatter NumberFormatter { get; set; }
//
// 		
// 		NSFormattingUnitStyle UnitStyle { get; set; }
//
// 		
// 		bool ForPersonMassUse {  get; set; }
//
// 		
// 		string StringFromValue (double value, NSMassFormatterUnit unit);
//
// 		
// 		string StringFromKilograms (double numberInKilograms);
//
// 		
// 		string UnitStringFromValue (double value, NSMassFormatterUnit unit);
//
// 		
// 		string UnitStringFromKilograms (double numberInKilograms, ref NSMassFormatterUnit unitp);
//
// 		
// 		bool GetObjectValue (out NSObject obj, string str, out string error);
// 	}
//
// 	
// 	interface NSMutableCharacterSet {
// 		
// 		void AddCharacters (NSRange aRange);
// 		
// 		
// 		void RemoveCharacters (NSRange aRange);
// 		
// 		
// #if MONOMAC && !NET
// 		void AddCharacters (string str);
// #else
// 		void AddCharacters (NSString str);
// #endif
// 		
// 		
// #if MONOMAC && !NET
// 		void RemoveCharacters (string str);
// #else
// 		void RemoveCharacters (NSString str);
// #endif
// 		
// 		
// 		void UnionWith (NSCharacterSet otherSet);
// 		
// 		
// 		void IntersectWith (NSCharacterSet otherSet);
// 		
// 		
// 		void Invert ();
//
// 		
// 		
// 		NSCharacterSet Alphanumerics {get;}
//
// 		
// 		
// 		NSCharacterSet Capitalized {get;}
//
// 		
// 		
// 		NSCharacterSet FromBitmapRepresentation (NSData data);
//
// 		
// 		
// 		NSCharacterSet FromString (string aString);
//
// 		
// 		
// 		
// 		NSCharacterSet FromFile (string path);
//
// 		
// 		
// 		NSCharacterSet FromRange (NSRange aRange);
//
// 		
// 		
// 		NSCharacterSet Controls {get;}
//
// 		
// 		
// 		NSCharacterSet DecimalDigits {get;}
//
// 		
// 		
// 		NSCharacterSet Decomposables {get;}
//
// 		
// 		
// 		NSCharacterSet Illegals {get;}
//
// 		
// 		
// 		NSCharacterSet Letters {get;}
//
// 		
// 		
// 		NSCharacterSet LowercaseLetters {get;}
//
// 		
// 		
// 		NSCharacterSet Newlines {get;}
//
// 		
// 		
// 		NSCharacterSet Marks {get;}
//
// 		
// 		
// 		NSCharacterSet Punctuation {get;}
//
// 		
// 		
// 		NSCharacterSet Symbols {get;}
//
// 		
// 		
// 		NSCharacterSet UppercaseLetters {get;}
//
// 		
// 		
// 		NSCharacterSet WhitespaceAndNewlines {get;}
//
// 		
// 		
// 		NSCharacterSet Whitespaces {get;}
// 	}
// 	
// 	
// 	interface NSCoder {
//
// 		//
// 		// Encoding and decoding
// 		//
// 		
// 		void Encode ( NSObject obj);
// 		
// 		
// 		void EncodeRoot ( NSObject obj);
//
// 		
// 		NSObject DecodeObject ();
//
// 		//
// 		// Encoding and decoding with keys
// 		// 
// 		
// 		void EncodeConditionalObject ( NSObject val, string key);
// 		
// 		
// 		void Encode ( NSObject val, string key);
// 		
// 		
// 		void Encode (bool val, string key);
// 		
// 		
// 		void Encode (double val, string key);
// 		
// 		
// 		void Encode (float /* float, not CGFloat */ val, string key);
// 		
// 		
// 		void Encode (int /* int32 */ val, string key);
// 		
// 		
// 		void Encode (long val, string key);
//
// 		
// 		void Encode (nint val, string key);
//
// 		
// 		void EncodeBlock (IntPtr bytes, nint length, string key);
//
// 		
// 		bool ContainsKey (string key);
// 		
// 		
// 		bool DecodeBool (string key);
//
// 		
// 		double DecodeDouble (string key);
//
// 		
// 		float DecodeFloat (string key); /* float, not CGFloat */ 
//
// 		
// 		int DecodeInt (string key); /* int, not NSInteger */
//
// 		
// 		long DecodeLong (string key);
//
// 		
// 		nint DecodeNInt (string key);
//
// 		
// 		NSObject DecodeObject (string key);
//
// 		
// 		IntPtr DecodeBytes (string key, out nuint length);
//
// 		
// 		IntPtr DecodeBytes (out nuint length);
//
// 		
// 		NSSet AllowedClasses { get; }
//
// 		
// 		bool RequiresSecureCoding ();
//
// 		
// 		
// 		NSObject DecodeTopLevelObject (out NSError error);
//
// 		
// 		
// 		NSObject DecodeTopLevelObject (string key, out NSError error);
//
// 		
// 		
// 		NSObject DecodeTopLevelObject (Class klass, string key, out NSError error);
//
// 		
// 		
// 		NSObject DecodeTopLevelObject ( NSSet<Class> setOfClasses, string key, out NSError error);
//
// 		
// 		
// 		void Fail (NSError error);
//
// 		
// 		uint SystemVersion { get; }
//
// 		
// 		
// 		NSDecodingFailurePolicy DecodingFailurePolicy { get; }
//
// 		
// 		
// 		NSError Error { get; }
//
// 		
// 		
// 		
// 		NSObject DecodeArrayOfObjects (Class @class, string key);
//
// 		
// 		
// 		
// 		NSObject DecodeArrayOfObjects (NSSet<Class> classes, string key);
//
// 		
// 		
// 		
// 		NSDictionary DecodeDictionary (Class keyClass, Class objectClass, string key);
//
// 		
// 		
// 		
// 		NSDictionary DecodeDictionary (NSSet<Class> keyClasses, NSSet<Class> objectClasses, string key);
// 	}
// 	
// 	
// 	interface NSComparisonPredicate : NSSecureCoding {
// 		
// 		NSComparisonPredicate Create (NSExpression leftExpression, NSExpression rightExpression, NSComparisonPredicateModifier comparisonModifier, NSPredicateOperatorType operatorType, NSComparisonPredicateOptions comparisonOptions);
//
// 		
// 		NSComparisonPredicate FromSelector (NSExpression leftExpression, NSExpression rightExpression, Selector selector);
//
// 		
// 		
// 		NativeHandle Constructor (NSExpression leftExpression, NSExpression rightExpression, NSComparisonPredicateModifier comparisonModifier, NSPredicateOperatorType operatorType, NSComparisonPredicateOptions comparisonOptions);
// 		
// 		
// 		
// 		NativeHandle Constructor (NSExpression leftExpression, NSExpression rightExpression, Selector selector);
//
// 		
// 		NSPredicateOperatorType PredicateOperatorType { get; }
//
// 		
// 		NSComparisonPredicateModifier ComparisonPredicateModifier { get; }
//
// 		
// 		NSExpression LeftExpression { get; }
//
// 		
// 		NSExpression RightExpression { get; }
//
// 		
// 		
// 		Selector CustomSelector { get; }
//
// 		
// 		NSComparisonPredicateOptions Options { get; }
// 	}
//
// 	
// 	 // An uncaught exception was raised: Can't have a NOT predicate with no subpredicate.
// 	interface NSCompoundPredicate : NSCoding {
// 		
// 		
// 		NativeHandle Constructor (NSCompoundPredicateType type, NSPredicate subpredicates);
//
// 		
// 		NSCompoundPredicateType Type { get; }
//
// 		
// 		NSPredicate Subpredicates { get; } 
//
// 		
// 		
// 		NSCompoundPredicate CreateAndPredicate (NSPredicate subpredicates);
//
// 		
// 		
// 		NSCompoundPredicate CreateOrPredicate (NSPredicate  subpredicates);
//
// 		
// 		
// 		NSCompoundPredicate CreateNotPredicate (NSPredicate predicate);
//
// 	}
//
// 	delegate void NSDataByteRangeEnumerator (IntPtr bytes, NSRange range, ref bool stop);
// 	
// 	
// 	interface NSData : NSSecureCoding, NSMutableCopying, CKRecordValue {
// 		
// 		
// 		NSData FromUrl (NSUrl url);
//
// 		
// 		
// 		NSData FromUrl (NSUrl url, NSDataReadingOptions mask, out NSError error);
//
// 		
// 		NSData FromFile (string path);
// 		
// 		
// 		
// 		NSData FromFile (string path, NSDataReadingOptions mask, out NSError error);
//
// 		
// 		
// 		NSData FromData (NSData source);
//
// 		
// 		NSData FromBytes (IntPtr bytes, nuint size);
//
// 		
// 		NSData FromBytesNoCopy (IntPtr bytes, nuint size);
//
// 		
// 		NSData FromBytesNoCopy (IntPtr bytes, nuint size, bool freeWhenDone);
//
// 		
// 		IntPtr Bytes { get; }
//
// 		
// 		nuint Length { get;  set; }
//
// 		
// 		
// 		bool _Save (string file, nint options, IntPtr addr);
// 		
// 		
// 		
// 		bool _Save (NSUrl url, nint options, IntPtr addr);
//
// 		
// 		
// 		
// 		
// 		
// 		bool Save (string path, bool atomically);
//
// 		
// 		bool Save (NSUrl url, bool atomically);
//
// 		
// 		NSData Subdata (NSRange range);
//
// 		
// 		void GetBytes (IntPtr buffer, nuint length);
//
// 		
// 		void GetBytes (IntPtr buffer, NSRange range);
//
// 		
// 		NSRange Find (NSData dataToFind, NSDataSearchOptions searchOptions, NSRange searchRange);
//
// 		 // 10.9
// 		
// 		NativeHandle Constructor (string base64String, NSDataBase64DecodingOptions options);
//
// 		 // 10.9
// 		
// 		NativeHandle Constructor (NSData base64Data, NSDataBase64DecodingOptions options);
//
// 		 // 10.9
// 		
// 		NSData GetBase64EncodedData (NSDataBase64EncodingOptions options);
//
// 		 // 10.9
// 		
// 		string GetBase64EncodedString (NSDataBase64EncodingOptions options);
//
// 		
// 		
// 		void EnumerateByteRange (NSDataByteRangeEnumerator enumerator);
//
// 		
// 		
// 		NativeHandle Constructor (IntPtr bytes, nuint length,  Action<IntPtr,nuint> deallocator);
//
// 		// NSDataCompression (NSData)
//
// 		
// 		
// 		
// 		NSData Decompress (NSDataCompressionAlgorithm algorithm,  out NSError error);
//
// 		
// 		
// 		
// 		NSData Compress (NSDataCompressionAlgorithm algorithm,  out NSError error);
// 	}
//
// 	
// 	interface NSDataDetector : NSCopying, NSCoding {
// 		
// 		
// 		NativeHandle Constructor (NSTextCheckingTypes options, out NSError error);
//
// 		
// 		NativeHandle Constructor (NSTextCheckingType options, out NSError error);
//
// 		
// 		NSDataDetector Create (NSTextCheckingTypes checkingTypes, out NSError error);
//
// 		
// 		
// 		NSDataDetector Create (NSTextCheckingType checkingTypes, out NSError error);
//
// 		
// 		NSTextCheckingTypes CheckingTypes { get; }
// 	}
//
// 	
// 	interface NSDateComponents : NSSecureCoding, NSCopying, INSCopying, INSSecureCoding, INativeObject {
// 		 // by default this property is null
// 		
// 		NSTimeZone TimeZone { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSCalendar Calendar { get; set; }
//
// 		
// 		nint Quarter { get; set; }
//
// 		
// 		NSDate Date { get; }
//
// 		//Detected properties
// 		
// 		nint Era { get; set; }
//
// 		
// 		nint Year { get; set; }
//
// 		
// 		nint Month { get; set; }
//
// 		
// 		nint Day { get; set; }
//
// 		
// 		nint Hour { get; set; }
//
// 		
// 		nint Minute { get; set; }
//
// 		
// 		nint Second { get; set; }
//
// 		
// 		nint Nanosecond { get; set; }
//
// 		
// 		
// 		
// 		nint Week { get; set; }
//
// 		
// 		nint Weekday { get; set; }
//
// 		
// 		nint WeekdayOrdinal { get; set; }
//
// 		
// 		nint WeekOfMonth { get; set; }
//
// 		
// 		nint WeekOfYear { get; set; }
// 		
// 		
// 		nint YearForWeekOfYear { get; set; }
//
// 		
// 		bool IsLeapMonth {  get; set; }
//
// 		
// 		
// 		bool IsValidDate { get; }
//
// 		
// 		
// 		bool IsValidDateInCalendar (NSCalendar calendar);
//
// 		
// 		
// 		void SetValueForComponent (nint value, NSCalendarUnit unit);
//
// 		
// 		
// 		nint GetValueForComponent (NSCalendarUnit unit);
// 	}
// 	
// 	
// 	interface NSByteCountFormatter {
// 		
// 		bool AllowsNonnumericFormatting { get; set; }
//
// 		
// 		bool IncludesUnit { get; set; }
//
// 		
// 		bool IncludesCount { get; set; }
//
// 		
// 		bool IncludesActualByteCount { get; set; }
// 		
// 		
// 		bool Adaptive {  get; set;  }
//
// 		
// 		bool ZeroPadsFractionDigits { get; set;  }
//
// 		
// 		
// 		string Format (long byteCount, NSByteCountFormatterCountStyle countStyle);
//
// 		
// 		string Format (long byteCount);
//
// 		
// 		NSByteCountFormatterUnits AllowedUnits { get; set; }
//
// 		
// 		NSByteCountFormatterCountStyle CountStyle { get; set; }
//
// 		
// 		
// 		NSFormattingContext FormattingContext { get; set; }
//
// 		
// 		
// 		
// 		string GetString ( NSObject obj);
// 	}
//
// 	
// 	interface NSDateFormatter {
// 		
// 		string ToString (NSDate date);
//
// 		
// 		NSDate Parse (string date);
//
// 		
// 		string DateFormat { get; set; }
//
// 		
// 		NSDateFormatterStyle DateStyle { get; set; }
//
// 		
// 		NSDateFormatterStyle TimeStyle { get; set; }
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		bool GeneratesCalendarDates { get; set; }
//
// 		
// 		NSDateFormatterBehavior Behavior { get; set; }
//
// 		
// 		NSDateFormatterBehavior DefaultBehavior { get; set; }
//
// 		
// 		NSTimeZone TimeZone { get; set; }
//
// 		
// 		NSCalendar Calendar { get; set; }
//
// 		// not exposed as a property in documentation
// 		
// 		bool IsLenient { get;  set; } 
//
// 		
// 		NSDate TwoDigitStartDate { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDate DefaultDate { get; set; }
//
// 		
// 		string  EraSymbols { get; set; }
//
// 		
// 		string  MonthSymbols { get; set; }
//
// 		
// 		string  ShortMonthSymbols { get; set; }
//
// 		
// 		string  WeekdaySymbols { get; set; }
//
// 		
// 		string  ShortWeekdaySymbols { get; set; } 
//
// 		
// 		string AMSymbol { get; set; }
//
// 		
// 		string PMSymbol { get; set; }
//
// 		
// 		string  LongEraSymbols { get; set; }
//
// 		
// 		string  VeryShortMonthSymbols { get; set; }
// 		
// 		
// 		string  StandaloneMonthSymbols { get; set; }
//
// 		
// 		string  ShortStandaloneMonthSymbols { get; set; }
//
// 		
// 		string  VeryShortStandaloneMonthSymbols { get; set; }
// 		
// 		
// 		string  VeryShortWeekdaySymbols { get; set; }
//
// 		
// 		string  StandaloneWeekdaySymbols { get; set; }
//
// 		
// 		string  ShortStandaloneWeekdaySymbols { get; set; }
// 		
// 		
// 		string  VeryShortStandaloneWeekdaySymbols { get; set; }
// 		
// 		
// 		string  QuarterSymbols { get; set; }
//
// 		
// 		string  ShortQuarterSymbols { get; set; }
// 		
// 		
// 		string  StandaloneQuarterSymbols { get; set; }
//
// 		
// 		string  ShortStandaloneQuarterSymbols { get; set; }
//
// 		
// 		NSDate GregorianStartDate { get; set; }
//
// 		
// 		
// 		string ToLocalizedString (NSDate date, NSDateFormatterStyle dateStyle, NSDateFormatterStyle timeStyle);
//
// 		
// 		
// 		string GetDateFormatFromTemplate (string template, nuint options,  NSLocale locale);
//
// 		
// 		bool DoesRelativeDateFormatting { get; set; }
//
// 		
// 		
// 		void SetLocalizedDateFormatFromTemplate (string dateFormatTemplate);
//
// 		
// 		
// 		NSFormattingContext FormattingContext { get; set; }
// 	}
//
// 	
// 	
// 	interface NSDateComponentsFormatter {
// 		
// 		NSDateComponentsFormatterUnitsStyle UnitsStyle { get; set; }
//
// 		
// 		NSCalendarUnit AllowedUnits { get; set; }
//
// 		
// 		NSDateComponentsFormatterZeroFormattingBehavior ZeroFormattingBehavior { get; set; }
//
// 		
// 		NSCalendar Calendar { get; set; }
//
// 		
// 		bool AllowsFractionalUnits { get; set; }
//
// 		
// 		nint MaximumUnitCount { get; set; }
//
// 		
// 		bool CollapsesLargestUnit { get; set; }
//
// 		
// 		bool IncludesApproximationPhrase { get; set; }
//
// 		
// 		bool IncludesTimeRemainingPhrase { get; set; }
//
// 		
// 		NSFormattingContext FormattingContext { get; set; }
//
// 		
// 		string StringForObjectValue ( NSObject obj);
//
// 		
// 		string StringFromDateComponents (NSDateComponents components);
//
// 		
// 		string StringFromDate (NSDate startDate, NSDate endDate);
//
// 		
// 		string StringFromTimeInterval (double ti);
//
// 		
// 		string LocalizedStringFromDateComponents (NSDateComponents components, NSDateComponentsFormatterUnitsStyle unitsStyle);
//
// 		
// 		bool GetObjectValue (out NSObject obj, string str, out string error);
//
// 		
// 		
// 		NSDate ReferenceDate { get; set; }
// 	}
//
// 	
// 	
// 	interface NSDateIntervalFormatter {
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		NSCalendar Calendar { get; set; }
//
// 		
// 		NSTimeZone TimeZone { get; set; }
//
// 		
// 		string DateTemplate { get; set; }
//
// 		
// 		NSDateIntervalFormatterStyle DateStyle { get; set; }
//
// 		
// 		NSDateIntervalFormatterStyle TimeStyle { get; set; }
//
// 		
// 		string StringFromDate (NSDate fromDate, NSDate toDate);
//
// 		
// 		
// 		
// 		string ToString (NSDateInterval dateInterval);
// 	}
//
// 	
// 	
// 	interface NSEnergyFormatter {
// 		
// 		NSNumberFormatter NumberFormatter { get; set; }
//
// 		
// 		NSFormattingUnitStyle UnitStyle { get; set; }
//
// 		
// 		bool ForFoodEnergyUse {  get; set; }
//
// 		
// 		string StringFromValue (double value, NSEnergyFormatterUnit unit);
//
// 		
// 		string StringFromJoules (double numberInJoules);
//
// 		
// 		string UnitStringFromValue (double value, NSEnergyFormatterUnit unit);
//
// 		
// 		string UnitStringFromJoules (double numberInJoules, out NSEnergyFormatterUnit unitp);
//
// 		
// 		bool GetObjectValue (out NSObject obj, string str, out string error);
// 	}
//
// 	interface NSFileHandleReadEventArgs {
// 		
// 		NSData AvailableData { get; }
//
// 		
// 		nint UnixErrorCode { get; }
// 	}
//
// 	interface NSFileHandleConnectionAcceptedEventArgs {
// 		
// 		NSFileHandle NearSocketConnection { get; }
// 		
// 		
// 		nint UnixErrorCode { get; }
// 	}
// 	
// 	
// 	 // return invalid handle
// 	interface NSFileHandle : NSSecureCoding {
// 		
// 		NSData AvailableData ();
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSData ReadDataToEndOfFile ();
//
// 		
// 		
// 		
// 		NSData ReadToEnd ( out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		NSData ReadDataOfLength (nuint length);
//
// 		
// 		
// 		
// 		NSData Read (nuint length,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		void WriteData (NSData data);
//
// 		
// 		
// 		bool Write (NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		ulong OffsetInFile ();
//
// 		
// 		
// 		bool GetOffset (out ulong offsetInFile,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		ulong SeekToEndOfFile ();
//
// 		
// 		
// 		bool SeekToEnd ( out ulong offsetInFile,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		void SeekToFileOffset (ulong offset);
//
// 		
// 		
// 		bool Seek (ulong offset,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		void TruncateFileAtOffset (ulong offset);
//
// 		
// 		
// 		bool Truncate (ulong offset,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		void SynchronizeFile ();
//
// 		
// 		
// 		bool Synchronize ( out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		void CloseFile ();
//
// 		
// 		
// 		bool Close ( out NSError error);
// 		
// 		
// 		
// 		NSFileHandle FromStandardInput ();
// 		
// 		
// 		
// 		NSFileHandle FromStandardOutput ();
//
// 		
// 		
// 		NSFileHandle FromStandardError ();
//
// 		
// 		
// 		NSFileHandle FromNullDevice ();
//
// 		
// 		
// 		NSFileHandle OpenRead (string path);
//
// 		
// 		
// 		NSFileHandle OpenWrite (string path);
//
// 		
// 		
// 		NSFileHandle OpenUpdate (string path);
//
// 		
// 		
// 		NSFileHandle OpenReadUrl (NSUrl url, out NSError error);
//
// 		
// 		
// 		NSFileHandle OpenWriteUrl (NSUrl url, out NSError error);
//
// 		
// 		
// 		NSFileHandle OpenUpdateUrl (NSUrl url, out NSError error);
// 		
// 		
// 		void ReadInBackground (NSString  notifyRunLoopModes);
//
// 		
// 		void ReadInBackground (NSRunLoopMode  notifyRunLoopModes);
//
// 		
// 		void ReadInBackground ();
//
// 		
// 		void ReadToEndOfFileInBackground (NSString  notifyRunLoopModes);
//
// 		
// 		void ReadToEndOfFileInBackground (NSRunLoopMode  notifyRunLoopModes);
//
// 		
// 		void ReadToEndOfFileInBackground ();
//
// 		
// 		void AcceptConnectionInBackground (NSString  notifyRunLoopModes);
//
// 		
// 		void AcceptConnectionInBackground (NSRunLoopMode  notifyRunLoopModes);
//
// 		
// 		void AcceptConnectionInBackground ();
//
// 		
// 		void WaitForDataInBackground (NSString  notifyRunLoopModes);
//
// 		
// 		void WaitForDataInBackground (NSRunLoopMode  notifyRunLoopModes);
//
// 		
// 		void WaitForDataInBackground ();
// 		
// 		
// 		
// 		NativeHandle Constructor (int /* int, not NSInteger */ fd, bool closeOnDealloc);
// 		
// 		
// 		NativeHandle Constructor (int /* int, not NSInteger */ fd);
//
// 		
// 		int FileDescriptor { get; } /* int, not NSInteger */
//
// 		
// 		void SetReadabilityHandler ( Action<NSFileHandle> readCallback);
//
// 		
// 		void SetWriteabilityHandle ( Action<NSFileHandle> writeCallback);
//
// 		
// 		NSString OperationException { get; }
//
// 		
// 		
// 		NSString ReadCompletionNotification { get; }
// 		
// 		
// 		
// 		NSString ReadToEndOfFileCompletionNotification { get; }
// 		
// 		
// 		
// 		NSString ConnectionAcceptedNotification { get; }
//
// 		
// 		
// 		NSString DataAvailableNotification { get; }
// 	}
//
// 	
// 	
// 	interface NSPersonNameComponent {
// 		
// 		NSString ComponentKey { get; }
// 		
// 		
// 		NSString GivenName { get; }
// 		
// 		
// 		NSString FamilyName { get; }
// 		
// 		
// 		NSString MiddleName { get; }
// 		
// 		
// 		NSString Prefix { get; }
// 		
// 		
// 		NSString Suffix { get; }
// 		
// 		
// 		NSString Nickname { get; }
// 		
// 		
// 		NSString Delimiter { get; }
// 	}
// 	
//
// 	
// 	
// 	interface NSPersonNameComponents : NSCopying, NSSecureCoding {
//
// 		
// 		string NamePrefix { get; set; }
//
// 		
// 		string GivenName { get; set; }
//
// 		
// 		string MiddleName { get; set; }
//
// 		
// 		string FamilyName { get; set; }
// 	
// 		
// 		string NameSuffix { get; set; }
// 	
// 		
// 		string Nickname { get; set; }
// 	
// 		
// 		NSPersonNameComponents PhoneticRepresentation { get; set; }
// 	}
//
// 	
// 	
// 	interface NSPersonNameComponentsFormatter
// 	{
// 		
// 		NSPersonNameComponentsFormatterStyle Style { get; set; }
// 	
// 		
// 		bool Phonetic {  get; set; }
// 	
// 		
// 		
// 		string GetLocalizedString (NSPersonNameComponents components, NSPersonNameComponentsFormatterStyle nameFormatStyle, NSPersonNameComponentsFormatterOptions nameOptions);
// 	
// 		
// 		string GetString (NSPersonNameComponents components);
// 	
// 		
// 		NSAttributedString GetAnnotatedString (NSPersonNameComponents components);
// 	
// 		
// 		bool GetObjectValue (out NSObject result, string str, out string errorDescription);
//
// 		
// 		
// 		
// 		NSPersonNameComponents GetComponents (string @string);
// 	}
// 	
// 	
// 	
// 	interface NSPipe {
// 		
// 		
// 		NSFileHandle ReadHandle { get; }
// 		
// 		
// 		NSFileHandle WriteHandle { get; }
//
// 		
// 		
// 		NSPipe Create ();
// 	}
//
// 	
// 	interface NSFormatter : NSCoding, NSCopying {
// 		
// 		string StringFor ( NSObject value);
//
// 		// - (NSAttributedString *)attributedStringForObjectValue:(id)obj withDefaultAttributes:(NSDictionary *)attrs;
//
// 		
// 		string EditingStringFor (NSObject value);
//
// 		
// 		
// 		
// 		NSAttributedString GetAttributedString (NSObject obj, NSDictionary defaultAttributes);
//
// 		// -(NSAttributedString *)attributedStringForObjectValue:(id)obj withDefaultAttributes:(NSDictionary *)attrs;
// 		
// 		NSAttributedString GetAttributedString (NSObject obj, NSDictionary<NSString, NSObject> defaultAttributes);
//
// 		
// #if MONOMAC
// 		NSAttributedString GetAttributedString (NSObject obj, NSStringAttributes defaultAttributes);
// #else
// 		NSAttributedString GetAttributedString (NSObject obj, UIStringAttributes defaultAttributes);
// #endif
//
// 		
// 		bool GetObjectValue (out NSObject obj, string str, out NSString error);
//
// 		
// 		bool IsPartialStringValid (string partialString, out string newString, out NSString error);
//
// 		
// 		bool IsPartialStringValid (ref string partialString, out NSRange proposedSelRange, string origString, NSRange origSelRange, out string error);
// 	}
//
// 	
// 	
// 	
// 	interface NSCoding {
// 		// 
// 		
// 		NativeHandle Constructor (NSCoder decoder);
//
// 		
// 		
// 		void EncodeTo (NSCoder encoder);
// 	}
//
// 	
// 	interface NSSecureCoding : NSCoding {
// 		// note: +supportsSecureCoding being static it is not a good "generated" binding candidate
// 	}
//
// 	
// 	
// 	
// 	interface NSCopying {
// 		
// 		
// 		
// 		NSObject Copy ( NSZone zone);
// 	}
//
// 	
// 	
// 	
// 	interface NSMutableCopying : NSCopying {
// 		
// 		
// 		
// 		NSObject MutableCopy ( NSZone zone);
// 	}
//
// 	interface INSMutableCopying {}
//
// 	
// 	
// 	
// 	interface NSKeyedArchiverDelegate {
// 		
// 		void EncodedObject (NSKeyedArchiver archiver, NSObject obj);
// 		
// 		
// 		void Finished (NSKeyedArchiver archiver);
// 		
// 		
// 		NSObject WillEncode (NSKeyedArchiver archiver, NSObject obj);
// 		
// 		
// 		void Finishing (NSKeyedArchiver archiver);
// 		
// 		
// 		void ReplacingObject (NSKeyedArchiver archiver, NSObject oldObject, NSObject newObject);
// 	}
//
// 	
// 	
// 	
// 	interface NSKeyedUnarchiverDelegate {
// 		
// 		NSObject DecodedObject (NSKeyedUnarchiver unarchiver, NSObject obj);
// 		
// 		
// 		void Finished (NSKeyedUnarchiver unarchiver);
// 		
// 		
// 		Class CannotDecodeClass (NSKeyedUnarchiver unarchiver, string klass, string  classes);
// 		
// 		
// 		void Finishing (NSKeyedUnarchiver unarchiver);
// 		
// 		
// 		void ReplacingObject (NSKeyedUnarchiver unarchiver, NSObject oldObject, NSObject newObject);
// 	}
//
// 	[BaseType (typeof (NSCoder),
// 		   Delegates=new string  {"WeakDelegate"},
// 		   Events=new Type  { typeof (NSKeyedArchiverDelegate) })]
// 	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -: cannot use -init for initialization
// 	
// 	interface NSKeyedArchiver {
//
// 		
// 		
// 		NativeHandle Constructor (bool requiresSecureCoding);
//
// 		// hack so we can decorate the default .ctor with availability attributes
// 		
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (NSMutableData data);
// 	
// 		
// 		
// 		
// 		
// #if NETXXX
// 		NSData GetArchivedData (NSObject @object, bool requiresSecureCoding,  out NSError error);
// #else
// 		NSData ArchivedDataWithRootObject (NSObject @object, bool requiresSecureCoding,  out NSError error);
// #endif
//
// 		
// 		
// 		
// 		
// 		
// 		
// #if NETXXX
// 		NSData GetArchivedData (NSObject root);
// #else
// 		NSData ArchivedDataWithRootObject (NSObject root);
// #endif
// 		
// 		
// 		
// 		
// 		
// 		
// 		
// 		bool ArchiveRootObjectToFile (NSObject root, string file);
//
// 		
// 		void FinishEncoding ();
//
// 		
// 		NSPropertyListFormat PropertyListFormat { get; set; }
//
// 		
// 		
// 		NSKeyedArchiverDelegate Delegate { get; set; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		void SetClassName (string name, Class kls);
//
// 		
// 		string GetClassName (Class kls);
//
// 		
// 		
// 		NSString RootObjectKey { get; }
//
// #if NETXXX
// 		
// 		bool RequiresSecureCoding { get; set; }
// #else
// 		
// 		void SetRequiresSecureCoding (bool requireSecureEncoding);
//
// 		
// 		bool GetRequiresSecureCoding ();
// #endif
//
// 		
// 		
// 		NSData EncodedData { get; }
// 	}
// 	
// 	[BaseType (typeof (NSCoder),
// 		   Delegates=new string  {"WeakDelegate"},
// 		   Events=new Type  { typeof (NSKeyedUnarchiverDelegate) })]
// 	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -: cannot use -init for initialization
// 	
// 	interface NSKeyedUnarchiver {
// 		
// 		
// 		NativeHandle Constructor (NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedObject (Class cls, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedObject (Type type, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedObject (NSSet<Class> classes, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedObject (Type  types, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (NSData data);
// 	
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSObject UnarchiveObject (NSData data);
//
// 		
// 		
// 		
// 		
// 		
// 		
// 		// FIXME: 
// 		NSObject UnarchiveTopLevelObject (NSData data, out NSError error);
// 		
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSObject UnarchiveFile (string file);
//
// 		
// 		void FinishDecoding ();
//
// 		
// 		
// 		NSKeyedUnarchiverDelegate Delegate { get; set; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		void SetClass (Class kls, string codedName);
//
// 		
// 		
// 		Class GetClass (string codedName);
//
// #if NETXXX
// 		
// 		bool RequiresSecureCoding { get; set; }
// #else
// 		
// 		void SetRequiresSecureCoding (bool requireSecureEncoding);
//
// 		
// 		bool GetRequiresSecureCoding ();
// #endif
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedArray (Class @class, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSObject GetUnarchivedArray (NSSet<Class> classes, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSDictionary GetUnarchivedDictionary (Class keyClass, Class valueClass, NSData data,  out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSDictionary GetUnarchivedDictionary (NSSet<Class> keyClasses, NSSet<Class> valueClasses, NSData data,  out NSError error);
// 	}
//
// 	 { "Delegate" }, Events=new Type  { typeof (NSMetadataQueryDelegate)})]
// 	interface NSMetadataQuery {
// 		
// 		bool StartQuery ();
//
// 		
// 		void StopQuery ();
//
// 		
// 		bool IsStarted { get; }
//
// 		
// 		bool IsGathering { get; }
//
// 		
// 		bool IsStopped { get; }
//
// 		
// 		void DisableUpdates ();
//
// 		
// 		void EnableUpdates ();
//
// 		
// 		nint ResultCount { get; }
//
// 		
// 		NSObject ResultAtIndex (nint idx);
//
// 		
// 		NSMetadataItem Results { get; }
//
// 		
// 		nint IndexOfResult (NSObject result);
//
// 		
// 		NSDictionary ValueLists { get; }
//
// 		
// 		NSObject  GroupedResults { get; }
//
// 		
// 		NSObject ValueOfAttribute (string attribyteName, nint atIndex);
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSMetadataQueryDelegate Delegate { get; set; }
// 		
// 		
// 		 // by default this property is null
// 		NSPredicate Predicate { get; set; }
//
// 		
// 		NSSortDescriptor SortDescriptors { get; set; }
//
// 		
// 		NSObject ValueListAttributes { get; set; }
//
// 		
// 		NSArray GroupingAttributes { get; set; }
//
// 		
// 		double NotificationBatchingInterval { get; set; }
//
// 		
// 		NSObject  SearchScopes { get; set; }
// 		
// 		// There is no info associated with these notifications
// 		
// 		
// 		NSString DidStartGatheringNotification { get; }
// 	
// 		
// 		
// 		NSString GatheringProgressNotification { get; }
// 		
// 		
// 		
// 		NSString DidFinishGatheringNotification { get; }
// 		
// 		
// 		
// 		NSString DidUpdateNotification { get; }
// 		
// 		
// 		NSString ResultContentRelevanceAttribute { get; }
// 		
// 		// Scope constants for defined search locations
// 		
// 		
// 		NSString UserHomeScope { get; }
// 		
// 		
// 		
// 		NSString LocalComputerScope { get; }
//
// 		
// 		
// 		NSString LocalDocumentsScope { get; }
//
// 		
// 		
// 		NSString NetworkScope { get; }
//
// 		
// 		NSString UbiquitousDocumentsScope { get; }
//
// 		
// 		NSString UbiquitousDataScope { get; }
//
//
// 		
// 		
// 		NSString AccessibleUbiquitousExternalDocumentsScope { get; }
//
// 		
// 		NSString ItemFSNameKey { get; }
//
// 		
// 		NSString ItemDisplayNameKey { get; }
//
// 		
// 		NSString ItemURLKey { get; }
//
// 		
// 		NSString ItemPathKey { get; }
//
// 		
// 		NSString ItemFSSizeKey { get; }
//
// 		
// 		NSString ItemFSCreationDateKey { get; }
//
// 		
// 		NSString ItemFSContentChangeDateKey { get; }
//
// 		
// 		
// 		NSString ContentTypeKey { get; }
//
// 		
// 		
// 		NSString ContentTypeTreeKey { get; }
// 		
//
// 		
// 		NSString ItemIsUbiquitousKey { get; }
//
// 		
// 		NSString UbiquitousItemHasUnresolvedConflictsKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemIsDownloadedKey { get; }
//
// 		
// 		NSString UbiquitousItemIsDownloadingKey { get; }
//
// 		
// 		NSString UbiquitousItemIsUploadedKey { get; }
//
// 		
// 		NSString UbiquitousItemIsUploadingKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemDownloadingStatusKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemDownloadingErrorKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemUploadingErrorKey { get; }
//
// 		
// 		NSString UbiquitousItemPercentDownloadedKey { get; }
//
// 		
// 		NSString UbiquitousItemPercentUploadedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadRequestedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemIsExternalDocumentKey { get; }
// 		
// 		
// 		
// 		NSString UbiquitousItemContainerDisplayNameKey { get; }
// 		
// 		
// 		
// 		NSString UbiquitousItemURLInLocalContainerKey { get; }
//
// 		
// 		
// 		NSString KeywordsKey { get; }
//
// 		
// 		
// 		NSString TitleKey { get; }
//
// 		
// 		
// 		NSString AuthorsKey { get; }
//
// 		
// 		
// 		NSString EditorsKey { get; }
//
// 		
// 		
// 		NSString ParticipantsKey { get; }
//
// 		
// 		
// 		NSString ProjectsKey { get; }
//
// 		
// 		
// 		NSString DownloadedDateKey { get; }
//
// 		
// 		
// 		NSString WhereFromsKey { get; }
//
// 		
// 		
// 		NSString CommentKey { get; }
//
// 		
// 		
// 		NSString CopyrightKey { get; }
//
// 		
// 		
// 		NSString LastUsedDateKey { get; }
//
// 		
// 		
// 		NSString ContentCreationDateKey { get; }
//
// 		
// 		
// 		NSString ContentModificationDateKey { get; }
//
// 		
// 		
// 		NSString DateAddedKey { get; }
//
// 		
// 		
// 		NSString DurationSecondsKey { get; }
//
// 		
// 		
// 		NSString ContactKeywordsKey { get; }
//
// 		
// 		
// 		NSString VersionKey { get; }
//
// 		
// 		
// 		NSString PixelHeightKey { get; }
//
// 		
// 		
// 		NSString PixelWidthKey { get; }
//
// 		
// 		
// 		NSString PixelCountKey { get; }
//
// 		
// 		
// 		NSString ColorSpaceKey { get; }
//
// 		
// 		
// 		NSString BitsPerSampleKey { get; }
//
// 		
// 		
// 		NSString FlashOnOffKey { get; }
//
// 		
// 		
// 		NSString FocalLengthKey { get; }
//
// 		
// 		
// 		NSString AcquisitionMakeKey { get; }
//
// 		
// 		
// 		NSString AcquisitionModelKey { get; }
//
// 		
// 		
// 		NSString IsoSpeedKey { get; }
//
// 		
// 		
// 		NSString OrientationKey { get; }
//
// 		
// 		
// 		NSString LayerNamesKey { get; }
//
// 		
// 		
// 		NSString WhiteBalanceKey { get; }
//
// 		
// 		
// 		NSString ApertureKey { get; }
//
// 		
// 		
// 		NSString ProfileNameKey { get; }
//
// 		
// 		
// 		NSString ResolutionWidthDpiKey { get; }
//
// 		
// 		
// 		NSString ResolutionHeightDpiKey { get; }
//
// 		
// 		
// 		NSString ExposureModeKey { get; }
//
// 		
// 		
// 		NSString ExposureTimeSecondsKey { get; }
//
// 		
// 		
// 		NSString ExifVersionKey { get; }
//
// 		
// 		
// 		NSString CameraOwnerKey { get; }
//
// 		
// 		
// 		NSString FocalLength35mmKey { get; }
//
// 		
// 		
// 		NSString LensModelKey { get; }
//
// 		
// 		
// 		NSString ExifGpsVersionKey { get; }
//
// 		
// 		
// 		NSString AltitudeKey { get; }
//
// 		
// 		
// 		NSString LatitudeKey { get; }
//
// 		
// 		
// 		NSString LongitudeKey { get; }
//
// 		
// 		
// 		NSString SpeedKey { get; }
//
// 		
// 		
// 		NSString TimestampKey { get; }
//
// 		
// 		
// 		NSString GpsTrackKey { get; }
//
// 		
// 		
// 		NSString ImageDirectionKey { get; }
//
// 		
// 		
// 		NSString NamedLocationKey { get; }
//
// 		
// 		
// 		NSString GpsStatusKey { get; }
//
// 		
// 		
// 		NSString GpsMeasureModeKey { get; }
//
// 		
// 		
// 		NSString GpsDopKey { get; }
//
// 		
// 		
// 		NSString GpsMapDatumKey { get; }
//
// 		
// 		
// 		NSString GpsDestLatitudeKey { get; }
//
// 		
// 		
// 		NSString GpsDestLongitudeKey { get; }
//
// 		
// 		
// 		NSString GpsDestBearingKey { get; }
//
// 		
// 		
// 		NSString GpsDestDistanceKey { get; }
//
// 		
// 		
// 		NSString GpsProcessingMethodKey { get; }
//
// 		
// 		
// 		NSString GpsAreaInformationKey { get; }
//
// 		
// 		
// 		NSString GpsDateStampKey { get; }
//
// 		
// 		
// 		NSString GpsDifferentalKey { get; }
//
// 		
// 		
// 		NSString CodecsKey { get; }
//
// 		
// 		
// 		NSString MediaTypesKey { get; }
//
// 		
// 		
// 		NSString StreamableKey { get; }
//
// 		
// 		
// 		NSString TotalBitRateKey { get; }
//
// 		
// 		
// 		NSString VideoBitRateKey { get; }
//
// 		
// 		
// 		NSString AudioBitRateKey { get; }
//
// 		
// 		
// 		NSString DeliveryTypeKey { get; }
//
// 		
// 		
// 		NSString AlbumKey { get; }
//
// 		
// 		
// 		NSString HasAlphaChannelKey { get; }
//
// 		
// 		
// 		NSString RedEyeOnOffKey { get; }
//
// 		
// 		
// 		NSString MeteringModeKey { get; }
//
// 		
// 		
// 		NSString MaxApertureKey { get; }
//
// 		
// 		
// 		NSString FNumberKey { get; }
//
// 		
// 		
// 		NSString ExposureProgramKey { get; }
//
// 		
// 		
// 		NSString ExposureTimeStringKey { get; }
//
// 		
// 		
// 		NSString HeadlineKey { get; }
//
// 		
// 		
// 		NSString InstructionsKey { get; }
//
// 		
// 		
// 		NSString CityKey { get; }
//
// 		
// 		
// 		NSString StateOrProvinceKey { get; }
//
// 		
// 		
// 		NSString CountryKey { get; }
//
// 		
// 		
// 		NSString TextContentKey { get; }
//
// 		
// 		
// 		NSString AudioSampleRateKey { get; }
//
// 		
// 		
// 		NSString AudioChannelCountKey { get; }
//
// 		
// 		
// 		NSString TempoKey { get; }
//
// 		
// 		
// 		NSString KeySignatureKey { get; }
//
// 		
// 		
// 		NSString TimeSignatureKey { get; }
//
// 		
// 		
// 		NSString AudioEncodingApplicationKey { get; }
//
// 		
// 		
// 		NSString ComposerKey { get; }
//
// 		
// 		
// 		NSString LyricistKey { get; }
//
// 		
// 		
// 		NSString AudioTrackNumberKey { get; }
//
// 		
// 		
// 		NSString RecordingDateKey { get; }
//
// 		
// 		
// 		NSString MusicalGenreKey { get; }
//
// 		
// 		
// 		NSString IsGeneralMidiSequenceKey { get; }
//
// 		
// 		
// 		NSString RecordingYearKey { get; }
//
// 		
// 		
// 		NSString OrganizationsKey { get; }
//
// 		
// 		
// 		NSString LanguagesKey { get; }
//
// 		
// 		
// 		NSString RightsKey { get; }
//
// 		
// 		
// 		NSString PublishersKey { get; }
//
// 		
// 		
// 		NSString ContributorsKey { get; }
//
// 		
// 		
// 		NSString CoverageKey { get; }
//
// 		
// 		
// 		NSString SubjectKey { get; }
//
// 		
// 		
// 		NSString ThemeKey { get; }
//
// 		
// 		
// 		NSString DescriptionKey { get; }
//
// 		
// 		
// 		NSString IdentifierKey { get; }
//
// 		
// 		
// 		NSString AudiencesKey { get; }
//
// 		
// 		
// 		NSString NumberOfPagesKey { get; }
//
// 		
// 		
// 		NSString PageWidthKey { get; }
//
// 		
// 		
// 		NSString PageHeightKey { get; }
//
// 		
// 		
// 		NSString SecurityMethodKey { get; }
//
// 		
// 		
// 		NSString CreatorKey { get; }
//
// 		
// 		
// 		NSString EncodingApplicationsKey { get; }
//
// 		
// 		
// 		NSString DueDateKey { get; }
//
// 		
// 		
// 		NSString StarRatingKey { get; }
//
// 		
// 		
// 		NSString PhoneNumbersKey { get; }
//
// 		
// 		
// 		NSString EmailAddressesKey { get; }
//
// 		
// 		
// 		NSString InstantMessageAddressesKey { get; }
//
// 		
// 		
// 		NSString KindKey { get; }
//
// 		
// 		
// 		NSString RecipientsKey { get; }
//
// 		
// 		
// 		NSString FinderCommentKey { get; }
//
// 		
// 		
// 		NSString FontsKey { get; }
//
// 		
// 		
// 		NSString AppleLoopsRootKeyKey { get; }
//
// 		
// 		
// 		NSString AppleLoopsKeyFilterTypeKey { get; }
//
// 		
// 		
// 		NSString AppleLoopsLoopModeKey { get; }
//
// 		
// 		
// 		NSString AppleLoopDescriptorsKey { get; }
//
// 		
// 		
// 		NSString MusicalInstrumentCategoryKey { get; }
//
// 		
// 		
// 		NSString MusicalInstrumentNameKey { get; }
//
// 		
// 		
// 		NSString CFBundleIdentifierKey { get; }
//
// 		
// 		
// 		NSString InformationKey { get; }
//
// 		
// 		
// 		NSString DirectorKey { get; }
//
// 		
// 		
// 		NSString ProducerKey { get; }
//
// 		
// 		
// 		NSString GenreKey { get; }
//
// 		
// 		
// 		NSString PerformersKey { get; }
//
// 		
// 		
// 		NSString OriginalFormatKey { get; }
//
// 		
// 		
// 		NSString OriginalSourceKey { get; }
//
// 		
// 		
// 		NSString AuthorEmailAddressesKey { get; }
//
// 		
// 		
// 		NSString RecipientEmailAddressesKey { get; }
//
// 		
// 		
// 		NSString AuthorAddressesKey { get; }
//
// 		
// 		
// 		NSString RecipientAddressesKey { get; }
//
// 		
// 		
// 		NSString IsLikelyJunkKey { get; }
//
// 		
// 		
// 		NSString ExecutableArchitecturesKey { get; }
//
// 		
// 		
// 		NSString ExecutablePlatformKey { get; }
//
// 		
// 		
// 		NSString ApplicationCategoriesKey { get; }
//
// 		
// 		
// 		NSString IsApplicationManagedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemIsSharedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemCurrentUserRoleKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemCurrentUserPermissionsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemOwnerNameComponentsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemMostRecentEditorNameComponentsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemRoleOwner { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemRoleParticipant { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemPermissionsReadOnly { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemPermissionsReadWrite { get; }
// 		
// 		
// 		 // by default this property is null
// 		
// 		// DOC: object is a mixture of NSString, NSMetadataItem, NSUrl
// 		NSObject  SearchItems { get; set; }
//
// 		
// 		 // by default this property is null
// 		
// 		NSOperationQueue OperationQueue { get; set; }
// 		
// 		
// 		
// 		void EnumerateResultsUsingBlock (NSMetadataQueryEnumerationCallback callback);
//
// 		
// 		void EnumerateResultsWithOptions (NSEnumerationOptions opts, NSMetadataQueryEnumerationCallback block);
//
// 		//
// 		// These are for NSMetadataQueryDidUpdateNotification 
// 		//
// 		
// 		
// 		NSString QueryUpdateAddedItemsKey { get; }
//
// 		
// 		
// 		NSString QueryUpdateChangedItemsKey { get; }
// 		
// 		
// 		
// 		NSString QueryUpdateRemovedItemsKey { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSMetadataQueryDelegate {
// 		
// 		NSObject ReplacementObjectForResultObject (NSMetadataQuery query, NSMetadataItem result);
//
// 		
// 		NSObject ReplacementValueForAttributevalue (NSMetadataQuery query, string attributeName, NSObject value);
// 	}
//
// 	
// #if NETXXX
// 	 // points to nothing so access properties crash the apps
// #endif
// 	interface NSMetadataItem {
//
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		NSObject ValueForAttribute (string key);
//
// 		
// 		
// 		
// 		IntPtr GetHandle (NSString key);
// 		
// 		NSDictionary ValuesForAttributes (NSArray keys);
//
// 		
// 		NSObject  Attributes { get; }
// 	}
//
// 	
// 	interface NSMetadataQueryAttributeValueTuple {
// 		
// 		string Attribute { get; }
//
// 		
// 		NSObject Value { get; }
//
// 		
// 		nint Count { get; }
// 	}
//
// 	
// 	interface NSMetadataQueryResultGroup {
// 		
// 		string Attribute { get; }
//
// 		
// 		NSObject Value { get; }
//
// 		
// 		NSObject  Subgroups { get; }
//
// 		
// 		nint ResultCount { get; }
//
// 		
// 		NSObject ResultAtIndex (nuint idx);
//
// 		
// 		NSObject  Results { get; }
//
// 	}
//
// 	// Sadly, while this API is a poor API and we should in general not use it
// 	// Apple has now surfaced it on a few methods.   So we need to take the Obsolete
// 	// out, and we will have to fully support it.
// 	
// 	
// 	interface NSMutableArray {
// 		
// 		
// 		NativeHandle Constructor (nuint capacity);
//
// 		
// 		
// 		
// 		void _Add (IntPtr obj);
//
// 		
// 		void Add (NSObject obj);
//
// 		
// 		
// 		
// 		void _Insert (IntPtr obj, nint index);
//
// 		
// 		void Insert (NSObject obj, nint index);
//
// 		
// 		void RemoveLastObject ();
//
// 		
// 		void RemoveObject (nint index);
//
// 		
// 		
// 		
// 		void _ReplaceObject (nint index, IntPtr withObject);
//
// 		
// 		void ReplaceObject (nint index, NSObject withObject);
//
// 		
// 		void RemoveAllObjects ();
//
// 		
// 		void AddObjects (NSObject  source);
//
// 		
// 		
// 		
// 		void _InsertObjects (IntPtr objects, NSIndexSet atIndexes);
//
// 		
// 		void InsertObjects (NSObject  objects, NSIndexSet atIndexes);
//
// 		
// 		void RemoveObjectsAtIndexes (NSIndexSet indexSet);
//
// 		
// 		
// 		NSMutableArray FromFile (string path);
//
// 		
// 		
// 		NSMutableArray FromUrl (NSUrl url);
// 		
// 	}
// 	
// 	interface NSMutableArray<TValue> : NSMutableArray {}
//
// 	
// 	interface NSMutableAttributedString {
// 		
// 		NativeHandle Constructor (string str);
// 		
// 		
// 		NativeHandle Constructor (string str,  NSDictionary attributes);
//
// 		
// 		NativeHandle Constructor (NSAttributedString other);
//
// 		
// 		void Replace (NSRange range, string newValue);
//
// 		
// 		void LowLevelSetAttributes (IntPtr dictionaryAttrsHandle, NSRange range);
//
// 		
// 		NSMutableString MutableString { get; }
//
// 		
// 		void AddAttribute (NSString attributeName, NSObject value, NSRange range);
//
// 		
// 		void AddAttributes (NSDictionary attrs, NSRange range);
//
// 		
// 		
// 		void AddAttributes (NSStringAttributes attributes, NSRange range);
//
// 		
// 		void RemoveAttribute (string name, NSRange range);
// 		
// 		
// 		void Replace (NSRange range, NSAttributedString value);
// 		
// 		
// 		void Insert (NSAttributedString attrString, nint location);
//
// 		
// 		void Append (NSAttributedString attrString);
//
// 		
// 		void DeleteRange (NSRange range);
//
// 		
// 		void SetString (NSAttributedString attrString);
//
// 		
// 		void BeginEditing ();
//
// 		
// 		void EndEditing ();
//
// 		
// 		
// 		
// 		
// 		
// 		bool ReadFromFile (NSUrl url, NSDictionary options, ref NSDictionary returnOptions, ref NSError error);
//
// 		
// 		
// 		
// 		
// 		bool ReadFromFile (NSUrl url, NSAttributedStringDocumentAttributes options, ref NSDictionary returnOptions, ref NSError error);
//
// 		
// 		
// 		
// 		bool ReadFromData (NSData data, NSDictionary options, ref NSDictionary returnOptions, ref NSError error);
// 		
// 		
// 		
// 		bool ReadFromData (NSData data, NSAttributedStringDocumentAttributes options, ref NSDictionary returnOptions, ref NSError error);
//
// 		
// 		
// 		
// 		
// 		bool ReadFromUrl (NSUrl url, NSDictionary options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);
//
// 		
// 		
// 		bool ReadFromUrl (NSUrl url, NSDictionary<NSString, NSObject> options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);
//
// 		
// 		
// 		bool ReadFromUrl (NSUrl url, NSAttributedStringDocumentAttributes options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);
// 	}
//
// 	
// 	interface NSMutableData {
// 		 
// 		
// 		NSMutableData FromCapacity (nint capacity);
//
// 		 
// 		
// 		NSMutableData FromLength (nint length);
// 		
// 		 
// 		NSMutableData Create ();
//
// 		
// 		IntPtr MutableBytes { get; }
//
// 		
// 		
// 		NativeHandle Constructor (nuint capacity);
//
// 		
// 		void AppendData (NSData other);
//
// 		
// 		void AppendBytes (IntPtr bytes, nuint len);
//
// 		
// 		void SetData (NSData data);
//
// 		
// 		
// 		nuint Length { get; set; }
//
// 		
// 		void ReplaceBytes (NSRange range, IntPtr buffer);
//
// 		
// 		void ResetBytes (NSRange range);
//
// 		
// 		void ReplaceBytes (NSRange range, IntPtr buffer, nuint length);
// 		
// 		// NSMutableDataCompression (NSMutableData)
//
// 		
// 		
// 		bool Decompress (NSDataCompressionAlgorithm algorithm,  out NSError error);
//
// 		
// 		
// 		bool Compress (NSDataCompressionAlgorithm algorithm,  out NSError error);
// 	}
//
// 	
// 	
// 	enum NSDataCompressionAlgorithm : long {
// 		Lzfse = 0,
// 		Lz4,
// 		Lzma,
// 		Zlib,
// 	}
//
// 	
// 	
// 	interface NSDate : NSSecureCoding, NSCopying, CKRecordValue {
// 		
// 		double SecondsSinceReferenceDate { get; }
//
// 		
// 		double GetSecondsSince (NSDate anotherDate);
//
// 		
// 		double SecondsSinceNow { get; } 
//
// 		
// 		double SecondsSince1970 { get; } 
//
// 		
// 		
// 		NSDate FromTimeIntervalSinceReferenceDate (double secs);
//
// 		
// 		NSDate FromTimeIntervalSince1970 (double secs);
//
// 		
// 		
// 		NSDate Now { get; }
// 		
// 		
// 		
// 		NSDate DistantPast { get; }
// 		
// 		
// 		
// 		NSDate DistantFuture { get; }
//
// 		
// 		NSDate AddSeconds (double seconds);
//
// 		
// 		
// 		NSDate FromTimeIntervalSinceNow (double secs);
//
// 		
// 		string DescriptionWithLocale (NSLocale locale);
//
// 		
// 		NSDate EarlierDate (NSDate anotherDate);
//
// 		
// 		NSDate LaterDate (NSDate anotherDate);
//
// 		
// 		NSComparisonResult Compare (NSDate other);
//
// 		
// 		bool IsEqualToDate (NSDate other);
//
// 		// NSDate_SensorKit
//
// 		
// 		
// 		
// 		
// 		NSDate CreateFromSRAbsoluteTime (double time);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (double srAbsoluteTime);
//
// 		
// 		
// 		
// 		double SrAbsoluteTime { get; }
// 	}
// 	
// 	
// 	
// 	interface NSDictionary : NSSecureCoding, NSMutableCopying, NSFetchRequestResult, INSFastEnumeration {
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSDictionary FromFile (string path);
//
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSDictionary FromUrl (NSUrl url);
//
// 		
// 		
// 		NSDictionary FromObjectAndKey (NSObject obj, NSObject key);
//
// 		
// 		
// 		NSDictionary FromDictionary (NSDictionary source);
//
// 		
// 		
// 		IntPtr _FromObjectsAndKeysInternal (IntPtr objects, IntPtr keys, nint count);
//
// 		
// 		
// 		NSDictionary FromObjectsAndKeysInternal ( NSArray objects,  NSArray keys, nint count);
//
// 		
// 		
// 		IntPtr _FromObjectsAndKeysInternal (IntPtr objects, IntPtr keys);
//
// 		
// 		
// 		NSDictionary FromObjectsAndKeysInternal ( NSArray objects,  NSArray keys);
//
// 		
// 		NativeHandle Constructor (NSDictionary other);
//
// 		
// 		NativeHandle Constructor (NSDictionary other, bool copyItems);
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (string fileName);
//
// 		
// 		NativeHandle Constructor (NSArray objects, NSArray keys);
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSDictionary<NSString, NSObject> FromUrl (NSUrl url, out NSError error);
// 		
// 		
// 		nuint Count { get; }
//
// 		
// 		
// 		
// 		IntPtr _ObjectForKey (IntPtr key);
//
// 		
// 		NSObject ObjectForKey (NSObject key);
//
// 		
// 		
// 		
// 		IntPtr _AllKeys ();
//
// 		
// 		NSObject  Keys { get; }
//
// 		
// 		
// 		
// 		IntPtr _AllKeysForObject (IntPtr obj);
//
// 		
// 		NSObject  KeysForObject (NSObject obj);
//
// 		
// 		
// 		
// 		IntPtr _AllValues ();
//
// 		
// 		NSObject  Values { get; }
//
// 		
// 		string DescriptionInStringsFileFormat { get; }
//
// 		
// 		bool IsEqualToDictionary (NSDictionary other);
// 		
// 		
// 		NSEnumerator ObjectEnumerator { get; }
//
// 		
// 		
// 		
// 		IntPtr _ObjectsForKeys (IntPtr keys, IntPtr marker);
//
// 		
// 		NSObject  ObjectsForKeys (NSArray keys, NSObject marker);
// 		
// 		
// 		
// 		
// 		
// 		
// 		bool WriteToFile (string path, bool useAuxiliaryFile);
//
// 		
// 		
// 		
// 		
// 		
// 		bool WriteToUrl (NSUrl url, bool atomically);
//
// 		
// 		
// 		NSObject GetSharedKeySetForKeys (NSObject  keys);
//
// 	}
//
// 	interface NSDictionary<K,V> : NSDictionary {}
//
// 	
// 	interface NSEnumerator {
// 		
// 		NSObject NextObject (); 
// 	}
//
// 	interface NSEnumerator<T> : NSEnumerator {}
//
// 	
// 	
// 	interface NSError : NSSecureCoding, NSCopying {
// 		
// 		NSError FromDomain (NSString domain, nint code,  NSDictionary userInfo);
//
// 		
// 		
// 		NativeHandle Constructor (NSString domain, nint code,  NSDictionary userInfo);
// 		
// 		
// 		string Domain { get; }
//
// 		
// 		nint Code { get; }
//
// 		
// 		NSDictionary UserInfo { get; }
//
// 		
// 		string LocalizedDescription { get; }
//
// 		
// 		string LocalizedFailureReason { get; }
//
// 		
// 		string LocalizedRecoverySuggestion { get; }
//
// 		
// 		string  LocalizedRecoveryOptions { get; }
//
// 		
// 		string HelpAnchor { get; }
//
// 		
// 		
// 		
// 		NSError  UnderlyingErrors { get; }
//
// 		
// 		NSString CocoaErrorDomain { get;}
//
// 		
// 		NSString PosixErrorDomain { get; }
//
// 		
// 		NSString OsStatusErrorDomain { get; }
//
// 		
// 		NSString MachErrorDomain { get; }
//
// 		
// 		NSString NSUrlErrorDomain { get; }
//
// #if NETXXX
// 		
// #else
// 		
// #endif
// 		
// 		NSString NSNetServicesErrorDomain { get; }
//
// 		
// 		NSString NSStreamSocketSSLErrorDomain { get; }
//
// 		
// 		NSString NSStreamSOCKSErrorDomain { get; }
//
// 		
// 		NSString CoreLocationErrorDomain { get; }
//
// #if !WATCH
// 		
// 		NSString CFNetworkErrorDomain { get; }
// #endif
//
// 		
// 		
// 		NSString CoreMotionErrorDomain { get; }
//
// #if !XAMCORE_3_0
// 		// now exposed with the corresponding EABluetoothAccessoryPickerError enum
// 		
// 		
// 		NSString EABluetoothAccessoryPickerErrorDomain { get; }
//
// 		// now exposed with the corresponding MKErrorCode enum
// 		
// 		
// 		
// 		NSString MapKitErrorDomain { get; }
//
// 		// now exposed with the corresponding WKErrorCode enum
// 		
// 		
// 		
// 		
// 		NSString WatchKitErrorDomain { get; }
// #endif
// 		
// 		
// 		NSString UnderlyingErrorKey { get; }
//
// 		
// 		
// 		
// 		NSString MultipleUnderlyingErrorsKey { get; }
//
// 		
// 		NSString LocalizedDescriptionKey { get; }
//
// 		
// 		NSString LocalizedFailureReasonErrorKey { get; }
//
// 		
// 		NSString LocalizedRecoverySuggestionErrorKey { get; }
//
// 		
// 		NSString LocalizedRecoveryOptionsErrorKey { get; }
//
// 		
// 		NSString RecoveryAttempterErrorKey { get; }
//
// 		
// 		NSString HelpAnchorErrorKey { get; }
//
// 		
// 		NSString StringEncodingErrorKey { get; }
//
// 		
// 		NSString UrlErrorKey { get; }
//
// 		
// 		NSString FilePathErrorKey { get; }
//
// 		
// 		
// 		NSString DebugDescriptionErrorKey { get; }
//
// 		
// 		
// 		NSString LocalizedFailureErrorKey { get; }
//
// 		
// 		
// 		
// 		void SetUserInfoValueProvider (string errorDomain,  NSErrorUserInfoValueProvider provider);
//
// 		
// 		
// 		
// 		
// 		NSErrorUserInfoValueProvider GetUserInfoValueProvider (string errorDomain);
//
// 		// From NSError (NSFileProviderError) Category to avoid static category uglyness
//
// 		
// 		
// 		
// 		
// 		
// 		NSError GetFileProviderError (INSFileProviderItem existingItem);
//
// 		
// 		
// 		
// 		
// 		
// 		NSError GetFileProviderError (string nonExistentItemIdentifier);
//
// 		
// 		
// 		
// 		
// 		
// 		NSError GetFileProviderErrorForRejectedDeletion (INSFileProviderItem updatedVersion);
// 		
// #if false
// 		// FIXME that value is present in the header (7.0 DP 6) files but returns NULL (i.e. unusable)
// 		// we're also missing other NSURLError* fields (which we should add)
// 		
// 		
// 		NSString NSUrlErrorBackgroundTaskCancelledReasonKey { get; }
// #endif
// 	}
//
// 	delegate NSObject NSErrorUserInfoValueProvider (NSError error, NSString userInfoKey);	
//
// 	
// 	// 'init' returns NIL
// 	
// 	interface NSException : NSSecureCoding, NSCopying {
// 		
// 		
// 		NativeHandle Constructor (string name, string reason,  NSDictionary userInfo);
//
// 		
// 		string Name { get; }
// 	
// 		
// 		string Reason { get; }
// 		
// 		
// 		NSObject UserInfo { get; }
//
// 		
// 		NSNumber CallStackReturnAddresses { get; }
//
// 		
// 		string CallStackSymbols { get; }
// 	}
//
// #if !NETXXX && !WATCH
// 	) instead.")]
// 	delegate void NSExpressionHandler (NSObject evaluatedObject, NSExpression  expressions, NSMutableDictionary context);
// #endif
// 	delegate NSObject NSExpressionCallbackHandler (NSObject evaluatedObject, NSExpression  expressions, NSMutableDictionary context);
// 	
// 	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -predicateFormat cannot be sent to an abstract object of class NSExpression: Create a concrete instance!
// 	
// 	interface NSExpression : NSSecureCoding, NSCopying {
// 		
// 		NSExpression FromConstant ( NSObject obj);
//
// 		
// 		NSExpression ExpressionForEvaluatedObject { get; }
//
// 		
// 		NSExpression FromVariable (string string1);
//
// 		
// 		NSExpression FromKeyPath (string keyPath);
//
// 		
// 		NSExpression FromFunction (string name, NSExpression parameters);
//
// 		
// 		NSExpression FromFormat (string expressionFormat);
//
// #if !NETXXX && !WATCH
// 		)' instead.")]
// 		
// 		NSExpression FromFormat (string format, NSExpression  parameters);
// #endif
//
// 		
// 		NSExpression FromFormat (string format, NSObject  parameters);
//
// 		//+ (NSExpression *)expressionForAggregate:(NSArray *)subexpressions; 
// 		
// 		NSExpression FromAggregate (NSExpression  subexpressions);
//
// 		
// 		NSExpression FromUnionSet (NSExpression left, NSExpression right);
//
// 		
// 		NSExpression FromIntersectSet (NSExpression left, NSExpression right);
//
// 		
// 		NSExpression FromMinusSet (NSExpression left, NSExpression right);
//
// 		//+ (NSExpression *)expressionForSubquery:(NSExpression *)expression usingIteratorVariable:(NSString *)variable predicate:(id)predicate; 
// 		
// 		NSExpression FromSubquery (NSExpression expression, string variable, NSObject predicate);
//
// 		
// 		NSExpression FromFunction (NSExpression target, string name, NSExpression parameters);
//
// #if !NETXXX && !WATCH
// 		)' instead.")]
// 		
// 		NSExpression FromFunction (NSExpressionHandler target, NSExpression parameters);
// #endif
//
// 		
// 		NSExpression FromFunction (NSExpressionCallbackHandler target, NSExpression parameters);
//
// 		
// 		
// 		
// 		NSExpression FromAnyKey ();
//
// 		
// 		
// 		
// 		NSExpression FromConditional (NSPredicate predicate, NSExpression trueExpression, NSExpression falseExpression);
// 			
// 		
// 		
// 		void AllowEvaluation ();
// 		
// 		
// 		
// 		NativeHandle Constructor (NSExpressionType type);
//
// 		
// 		NSExpressionType ExpressionType { get; }
//
// 		
// 		NSExpressionCallbackHandler _Block { get; }
//
// 		
// 		NSObject _ConstantValue { get; }
//
// 		
// 		string _KeyPath { get; }
//
// 		
// 		string _Function { get; }
//
// 		
// 		string _Variable { get; }
//
// 		
// 		NSExpression _Operand { get; }
//
// 		
// 		NSExpression _Arguments { get; }
//
// 		
// 		NSObject _Collection { get; }
//
// 		
// 		NSPredicate _Predicate { get; }
//
// 		
// 		NSExpression _LeftExpression { get; }
//
// 		
// 		NSExpression _RightExpression { get; }
//
// 		
// 		
// 		NSExpression _TrueExpression { get; }
//
// 		
// 		
// 		NSExpression _FalseExpression { get; }
// 		
// 		
// 		
// 		NSObject EvaluateWith ( NSObject obj,  NSMutableDictionary context);
// 	}
//
// 	 // Not defined in 32-bit
// 	
// 	partial interface NSExtensionContext {
//
// 		
// 		NSExtensionItem  InputItems { get; }
//
// 		
// 		
// 		void CompleteRequest (NSExtensionItem  returningItems,  Action<bool> completionHandler);
//
// 		
// 		void CancelRequest (NSError error);
//
// 		
// 		
// 		void OpenUrl (NSUrl url,  Action<bool> completionHandler);
//
// 		
// 		NSString ItemsAndErrorsKey { get; }
//
// 		
// 		
// 		
// 		
// 		NSString HostWillEnterForegroundNotification { get; }
//
// 		
// 		
// 		
// 		
// 		NSString HostDidEnterBackgroundNotification { get; }
//
// 		
// 		
// 		
// 		
// 		NSString HostWillResignActiveNotification { get; }
//
// 		
// 		
// 		
// 		
// 		NSString HostDidBecomeActiveNotification { get; }
// 	}
//
// 	 // Not defined in 32-bit
// 	
// 	partial interface NSExtensionItem : NSCopying, NSSecureCoding {
//
// 		 // by default this property is null
// 		
// 		NSAttributedString AttributedTitle { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSAttributedString AttributedContentText { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSItemProvider  Attachments { get; set; }
//
// 		
// 		NSDictionary UserInfo { get; set; }
//
// 		
// 		NSString AttributedTitleKey { get; }
//
// 		
// 		NSString AttributedContentTextKey { get; }
//
// 		
// 		NSString AttachmentsKey { get; }
// 	}
//
// 	
// 	interface NSNull : NSSecureCoding, NSCopying
// #if !WATCH
// 	, CAAction
// #endif
// 	{
// 		
// 		
// 		NSNull _Null { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSLengthFormatter {
// 		
// 		NSNumberFormatter NumberFormatter { get; set; }
//
// 		
// 		NSFormattingUnitStyle UnitStyle { get; set; }
//
// 		
// 		string StringFromValue (double value, NSLengthFormatterUnit unit);
//
// 		
// 		string StringFromMeters (double numberInMeters);
//
// 		
// 		string UnitStringFromValue (double value, NSLengthFormatterUnit unit);
//
// 		
// 		string UnitStringFromMeters (double numberInMeters, ref NSLengthFormatterUnit unitp);
//
// 		
// 		bool GetObjectValue (out NSObject obj, string str, out string error);
//
// 		
// 		bool ForPersonHeightUse {  get; set; }
// 	}
//
// 	delegate void NSLingusticEnumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop);
//
// 	
// 	
// 	
// 	
// 	
// 	interface NSLinguisticTagger {
// 		
// 		
// 		NativeHandle Constructor (NSString  tagSchemes, NSLinguisticTaggerOptions opts);
//
// 		
// 		NSString  TagSchemes { get; }
//
// 		
// 		
// 		NSString  GetAvailableTagSchemesForLanguage (string language);
//
// 		
// 		void SetOrthographyrange (NSOrthography orthography, NSRange range);
//
// 		
// 		NSOrthography GetOrthography (nint charIndex, ref NSRange effectiveRange);
//
// 		
// 		void StringEditedInRange (NSRange newRange, nint delta);
//
// 		
// 		void EnumerateTagsInRange (NSRange range, NSString tagScheme, NSLinguisticTaggerOptions opts, NSLingusticEnumerator enumerator);
//
// 		
// 		NSRange GetSentenceRangeForRange (NSRange range);
//
// 		
// 		string GetTag (nint charIndex, NSString tagScheme, ref NSRange tokenRange, ref NSRange sentenceRange);
//
// 		
// 		NSString  GetTagsInRange (NSRange range, NSString tagScheme, NSLinguisticTaggerOptions opts, ref NSArray tokenRanges);
//
// 		
// 		NSString  GetPossibleTags (nint charIndex, NSString tagScheme, ref NSRange tokenRange, ref NSRange sentenceRange, ref NSArray scores);
//
// 		//Detected properties
// 		 // by default this property is null
// 		
// 		string AnalysisString { get; set; }
//
// 		
// 		
// 		string GetTags (NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options,  out NSValue tokenRanges);
//
// 		
// 		
// 		void EnumerateTags (NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options, LinguisticTagEnumerator enumerator);
//
// 		
// 		
// 		
// 		string GetTag (nuint charIndex, NSLinguisticTaggerUnit unit, string scheme,  ref NSRange tokenRange);
//
// 		
// 		
// 		NSRange GetTokenRange (nuint charIndex, NSLinguisticTaggerUnit unit);
//
// 		
// 		
// 		
// 		string GetAvailableTagSchemes (NSLinguisticTaggerUnit unit, string language);
//
// 		
// 		
// 		string DominantLanguage { get; }
//
// 		
// 		
// 		
// 		
// 		string GetDominantLanguage (string str);
//
// 		
// 		
// 		
// 		
// 		string GetTag (string str, nuint charIndex, NSLinguisticTaggerUnit unit, string scheme,  NSOrthography orthography,  ref NSRange tokenRange);
//
// 		
// 		
// 		
// 		string GetTags (string str, NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography,  out NSValue tokenRanges);
//
// 		
// 		
// 		
// 		void EnumerateTags (string str, NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography, LinguisticTagEnumerator enumerator);
// 	}
//
// 	delegate void LinguisticTagEnumerator (string tag, NSRange tokenRange, bool stop);
//
// #if !NETXXX
// 	
// 	
// 	interface NSLinguisticTag {
// 		
// 		NSString SchemeTokenType { get; }
//
// 		
// 		NSString SchemeLexicalClass { get; }
//
// 		
// 		NSString SchemeNameType { get; }
//
// 		
// 		NSString SchemeNameTypeOrLexicalClass { get; }
//
// 		
// 		NSString SchemeLemma { get; }
//
// 		
// 		NSString SchemeLanguage { get; }
//
// 		
// 		NSString SchemeScript { get; }
//
// 		
// 		NSString Word { get; }
//
// 		
// 		NSString Punctuation { get; }
//
// 		
// 		NSString Whitespace { get; }
//
// 		
// 		NSString Other { get; }
//
// 		
// 		NSString Noun { get; }
//
// 		
// 		NSString Verb { get; }
//
// 		
// 		NSString Adjective { get; }
//
// 		
// 		NSString Adverb { get; }
//
// 		
// 		NSString Pronoun { get; }
//
// 		
// 		NSString Determiner { get; }
//
// 		
// 		NSString Particle { get; }
//
// 		
// 		NSString Preposition { get; }
//
// 		
// 		NSString Number { get; }
//
// 		
// 		NSString Conjunction { get; }
//
// 		
// 		NSString Interjection { get; }
//
// 		
// 		NSString Classifier { get; }
//
// 		
// 		NSString Idiom { get; }
//
// 		
// 		NSString OtherWord { get; }
//
// 		
// 		NSString SentenceTerminator { get; }
//
// 		
// 		NSString OpenQuote { get; }
//
// 		
// 		NSString CloseQuote { get; }
//
// 		
// 		NSString OpenParenthesis { get; }
//
// 		
// 		NSString CloseParenthesis { get; }
//
// 		
// 		NSString WordJoiner { get; }
//
// 		
// 		NSString Dash { get; }
//
// 		
// 		NSString OtherPunctuation { get; }
//
// 		
// 		NSString ParagraphBreak { get; }
//
// 		
// 		NSString OtherWhitespace { get; }
//
// 		
// 		NSString PersonalName { get; }
//
// 		
// 		NSString PlaceName { get; }
//
// 		
// 		NSString OrganizationName { get; }
// 	}
// #endif
//
// 	
// 	// 'init' returns NIL so it's not usable evenif it does not throw an ObjC exception
// 	// funnily it was "added" in iOS 7 and header files says "do not invoke; not a valid initializer for this class"
// 	
// 	interface NSLocale : NSSecureCoding, NSCopying {
// 		
// 		
// 		NSLocale SystemLocale { get; }
//
// 		
// 		
// 		NSLocale CurrentLocale { get; }
//
// 		
// 		
// 		NSLocale AutoUpdatingCurrentLocale { get; }
// 		
// 		
// 		
// 		NativeHandle Constructor (string identifier);
//
// 		
// 		string LocaleIdentifier { get; }
//
// 		
// 		string  AvailableLocaleIdentifiers { get; }
//
// 		
// 		string  ISOLanguageCodes { get; }
//
// 		
// 		string  ISOCurrencyCodes { get; }
//
// 		
// 		string  ISOCountryCodes { get; }
//
// 		
// 		string  CommonISOCurrencyCodes { get; }
//
// 		
// 		string  PreferredLanguages { get; }
//
// 		
// 		NSDictionary ComponentsFromLocaleIdentifier (string identifier);
//
// 		
// 		string LocaleIdentifierFromComponents (NSDictionary dict);
//
// 		
// 		string CanonicalLanguageIdentifierFromString (string str);
//
// 		
// 		string CanonicalLocaleIdentifierFromString (string str);
//
// 		
// 		NSLocaleLanguageDirection GetCharacterDirection (string isoLanguageCode);
//
// 		
// 		NSLocaleLanguageDirection GetLineDirection (string isoLanguageCode);
//
// 		 // already in OSX 10.6
// 		
// 		
// 		NSLocale FromLocaleIdentifier (string ident);
//
// 		
// 		
// 		NSString CurrentLocaleDidChangeNotification { get; }
//
// 		
// 		NSObject ObjectForKey (NSString key);
//
// 		
// 		NSString DisplayNameForKey (NSString key, string value);
//
// 		
// 		NSString _Identifier { get; }
// 		
// 		
// 		NSString _LanguageCode { get; }
// 		
// 		
// 		NSString _CountryCode { get; }
// 		
// 		
// 		NSString _ScriptCode { get; }
// 		
// 		
// 		NSString _VariantCode { get; }
// 		
// 		
// 		NSString _ExemplarCharacterSet { get; }
// 		
// 		
// 		NSString _Calendar { get; }
// 		
// 		
// 		NSString _CollationIdentifier { get; }
// 		
// 		
// 		NSString _UsesMetricSystem { get; }
// 		
// 		
// 		NSString _MeasurementSystem { get; }
// 		
// 		
// 		NSString _DecimalSeparator { get; }
// 		
// 		
// 		NSString _GroupingSeparator { get; }
// 		
// 		
// 		NSString _CurrencySymbol { get; }
// 		
// 		
// 		NSString _CurrencyCode { get; }
// 		
// 		
// 		NSString _CollatorIdentifier { get; }
// 		
// 		
// 		NSString _QuotationBeginDelimiterKey { get; }
// 		
// 		
// 		NSString _QuotationEndDelimiterKey { get; }
// 		
// 		
// 		NSString _AlternateQuotationBeginDelimiterKey { get; }
// 		
// 		
// 		NSString _AlternateQuotationEndDelimiterKey { get; }
//
// 		// follow the pattern of NSLocale.cs which included managed helpers that did the same
//
// 		
// 		
// 		string CalendarIdentifier { get; }
//
// 		
// 		
// 		
// 		string GetLocalizedCalendarIdentifier (string calendarIdentifier);
// 	}
//
// 	delegate void NSMatchEnumerator (NSTextCheckingResult result, NSMatchingFlags flags, ref bool stop);
//
// 	// This API surfaces NSString instead of strings, because we already have the .NET version that uses
// 	// strings, so it makes sense to use NSString here (and also, the replacing functionality operates on
// 	// NSMutableStrings)
// 	
// 	interface NSRegularExpression : NSCopying, NSSecureCoding {
// 		
// 		
// 		NativeHandle Constructor (NSString pattern, NSRegularExpressionOptions options, out NSError error);
//
// 		
// 		
// 		NSRegularExpression Create (NSString pattern, NSRegularExpressionOptions options, out NSError error);
//
// 		
// 		NSString Pattern { get; }
//
// 		
// 		NSRegularExpressionOptions Options { get; }
//
// 		
// 		nuint NumberOfCaptureGroups { get; }
//
// 		
// 		
// 		NSString GetEscapedPattern (NSString str);
//
// 		/* From the NSMatching category */
//
// 		
// 		void EnumerateMatches (NSString str, NSMatchingOptions options, NSRange range, NSMatchEnumerator enumerator);
//
// #if !NETXXX
// 		
// 		
// 		NSString  GetMatches (NSString str, NSMatchingOptions options, NSRange range);
// #endif
//
// 		
// #if NETXXX
// 		NSTextCheckingResult  GetMatches (NSString str, NSMatchingOptions options, NSRange range);
// #else
// 		
// 		NSTextCheckingResult  GetMatches2 (NSString str, NSMatchingOptions options, NSRange range);
// #endif
//
// 		
// 		nuint GetNumberOfMatches (NSString str, NSMatchingOptions options, NSRange range);
// 		
// 		
// 		
// 		NSTextCheckingResult FindFirstMatch (string str, NSMatchingOptions options, NSRange range);
// 		
// 		
// 		NSRange GetRangeOfFirstMatch (string str, NSMatchingOptions options, NSRange range);
// 		
// 		/* From the NSReplacement category */
//
// 		
// 		string ReplaceMatches (string sourceString, NSMatchingOptions options, NSRange range, string template);
// 		
// 		
// 		nuint ReplaceMatches (NSMutableString mutableString, NSMatchingOptions options, NSRange range,  NSString template);
//
// 		
// 		NSString GetReplacementString (NSTextCheckingResult result, NSString str, nint offset, NSString template);
//
// 		
// 		NSString GetEscapedTemplate (NSString str);
// 		
// 	}
// 	
// 	
// 	// init returns NIL
// 	
// 	interface NSRunLoop {
// 		
// 		NSRunLoop Current { get; }
//
// 		
// 		NSRunLoop Main { get; }
//
// 		
// 		NSString CurrentMode { get; }
//
// 		
// 		NSRunLoopMode CurrentRunLoopMode { get; }
//
// 		
// 		CFRunLoop GetCFRunLoop ();
//
// 		
// 		void AddTimer (NSTimer timer, NSString forMode);
//
// 		
// 		void AddTimer (NSTimer timer, NSRunLoopMode forMode);
//
// 		
// 		NSDate LimitDateForMode (NSString mode);
//
// 		
// 		NSDate LimitDateForMode (NSRunLoopMode mode);
//
// 		
// 		void AcceptInputForMode (NSString mode, NSDate limitDate);
//
// 		
// 		void AcceptInputForMode (NSRunLoopMode mode, NSDate limitDate);
//
// 		
// 		void Run ();
//
// 		
// 		void RunUntil (NSDate date);
//
// 		
// 		bool RunUntil (NSString runLoopMode, NSDate limitdate);
//
// 		
// 		bool RunUntil (NSRunLoopMode runLoopMode, NSDate limitDate);
//
// 		
// 		
// 		void Perform (Action block);
//
// 		
// 		
// 		void Perform (NSString modes, Action block);
//
// 		
// 		
// 		void Perform (NSRunLoopMode modes, Action block);
//
// #if !NETXXX
// 		
// 		
// 		NSString NSDefaultRunLoopMode { get; }
//
// 		
// 		
// 		NSString NSRunLoopCommonModes { get; }
//
// 		
// 		
// 		
// 		
// 		NSString NSRunLoopConnectionReplyMode { get; }
//
// 		
// 		
// 		
// 		NSString NSRunLoopModalPanelMode { get; }
//
// 		
// 		
// 		
// 		NSString NSRunLoopEventTracking { get; }
//
// 		
// 		
// 		
// 		NSString UITrackingRunLoopMode { get; }
// #endif
// 	}
//
// 	
// 	
// 	interface NSSet : NSSecureCoding, NSMutableCopying {
// 		
// 		NSSet CreateSet ();
//
// 		
// 		NativeHandle Constructor (NSSet other);
// 		
// 		
// 		NativeHandle Constructor (NSArray other);
// 		
// 		
// 		nuint Count { get; }
//
// 		
// 		
// 		
// 		IntPtr _LookupMember (IntPtr probe);
//
// 		
// 		NSObject LookupMember (NSObject probe);
//
// 		
// 		
// 		
// 		IntPtr _AnyObject { get; }
//
// 		
// 		NSObject AnyObject { get; }
//
// 		
// 		
// 		
// 		bool _Contains (NativeHandle id);
//
// 		
// 		bool Contains (NSObject id);
//
// 		
// 		IntPtr _AllObjects ();
//
// 		
// 		bool IsEqualToSet (NSSet other);
//
// 		
// 		NSEnumerator _GetEnumerator ();
// 		
// 		
// 		bool IsSubsetOf (NSSet other);
// 		
// 		
// 		void Enumerate (NSSetEnumerator enumerator);
//
// 		
// 		
// 		
// 		NativeHandle _SetByAddingObjectsFromSet (NativeHandle other);
//
// 		
// 		NSSet SetByAddingObjectsFromSet (NSSet other);
//
// 		
// 		bool IntersectsSet (NSSet other);
//
// 		
// 		
// 		
// 		NativeHandle _SetWithArray (NativeHandle array);
// 	}
//
// 	interface NSSet<TKey> : NSSet {}
//
// 	
// 	interface NSSortDescriptor : NSSecureCoding, NSCopying {
// 		
// 		NativeHandle Constructor (string key, bool ascending);
//
// 		
// 		NativeHandle Constructor (string key, bool ascending,  Selector selector);
//
// 		
// 		NativeHandle Constructor (string key, bool ascending, NSComparator comparator);
//
// 		
// 		string Key { get; }
//
// 		
// 		bool Ascending { get; }
//
// 		
// 		
// 		Selector Selector { get; }
//
// 		
// 		NSComparisonResult Compare (NSObject object1, NSObject object2);
//
// 		
// 		NSObject ReversedSortDescriptor { get; }
//
// 		
// 		
// 		void AllowEvaluation ();
// 	}
// 	
// 	
// 	partial interface NSKeyValueSorting_NSOrderedSet {
// 		
// 		NSObject  GetSortedArray (NSSortDescriptor  sortDescriptors);
// 	}
// 	
// #pragma warning disable 618
// 	
// #pragma warning restore 618
// 	partial interface NSSortDescriptorSorting_NSMutableArray {
// 		
// 		void SortUsingDescriptors (NSSortDescriptor  sortDescriptors);
// 	}
//
// 	
// 	partial interface NSKeyValueSorting_NSMutableOrderedSet {
// 		
// 		void SortUsingDescriptors (NSSortDescriptor  sortDescriptors);
// 	}
// 	
// 	
// 	
// 	// init returns NIL
// 	
// 	interface NSTimer {
//
// 		
// 		NSTimer CreateScheduledTimer (double seconds, NSObject target, Selector selector,  NSObject userInfo, bool repeats);
//
// 		
// 		
// 		
// 		NSTimer CreateScheduledTimer (double interval, bool repeats, Action<NSTimer> block);
//
// 		
// 		NSTimer CreateTimer (double seconds, NSObject target, Selector selector,  NSObject userInfo, bool repeats);
//
// 		
// 		
// 		
// 		NSTimer CreateTimer (double interval, bool repeats, Action<NSTimer> block);
//
// 		
// 		
// 		NativeHandle Constructor (NSDate date, double seconds, NSObject target, Selector selector,  NSObject userInfo, bool repeats);
//
// 		
// 		
// 		NativeHandle Constructor (NSDate date, double seconds, bool repeats, Action<NSTimer> block);
//
// 		
// 		void Fire ();
//
// 		 // by default this property is null
// 		
// 		NSDate FireDate { get; set; }
//
// 		// Note: preserving this member allows us to re-enable the `Optimizable` binding flag
// 		
// 		
// 		void Invalidate ();
//
// 		
// 		bool IsValid { get; }
//
// 		
// 		double TimeInterval { get; }
//
// 		
// 		NSObject UserInfo { get; }
//
// 		
// 		
// 		double Tolerance { get; set; }
// 	}
//
// 	
// 	// NSTimeZone is an abstract class that defines the behavior of time zone objects. -> http://developer.apple.com/library/ios/#documentation/Cocoa/Reference/Foundation/Classes/NSTimeZone_Class/Reference/Reference.html
// 	// calling 'init' returns a NIL pointer, i.e. an unusable instance
// 	
// 	interface NSTimeZone : NSSecureCoding, NSCopying {
// 		
// 		NativeHandle Constructor (string name);
// 		
// 		
// 		NativeHandle Constructor (string name, NSData data);
//
// 		
// 		string Name { get; } 
//
// 		
// 		NSData Data { get; }
//
// 		
// 		nint SecondsFromGMT (NSDate date);
//
// 		
// 		
// 		NSDictionary Abbreviations { get; }
//
// 		
// 		string Abbreviation ();
//
// 		
// 		string Abbreviation (NSDate date);
//
// 		
// 		bool IsDaylightSavingsTime (NSDate date);
//
// 		
// 		double DaylightSavingTimeOffset (NSDate date);
//
// 		
// 		NSDate NextDaylightSavingTimeTransitionAfter (NSDate date);
//
// 		
// 		NSTimeZone FromName (string tzName);
//
// 		
// 		NSTimeZone FromName (string tzName, NSData data);
// 		
// 		
// 		
// 		NSTimeZone FromGMT (nint seconds);
//
// 		
// 		NSTimeZone LocalTimeZone { get; }
//
// 		
// 		nint GetSecondsFromGMT { get; }
//
// 		
// 		NSTimeZone DefaultTimeZone { get; set; }
//
// 		
// 		void ResetSystemTimeZone ();
//
// 		
// 		NSTimeZone SystemTimeZone { get; }
// 		
// 		
// 		NSTimeZone FromAbbreviation (string abbreviation);
//
// 		
// 		string _KnownTimeZoneNames { get; }
//
// 		
// 		string DataVersion { get; }
//
// 		
// 		string GetLocalizedName (NSTimeZoneNameStyle style,  NSLocale locale);
// 	}
//
// 	interface NSUbiquitousKeyValueStoreChangeEventArgs {
// 		
// 		string  ChangedKeys { get; }
// 	
// 		
// 		NSUbiquitousKeyValueStoreChangeReason ChangeReason { get; }
// 	}
//
// 	
// #if WATCH
// 	
// 	 // "NSUbiquitousKeyValueStore is unavailable" is printed to the log.
// #endif
// 	interface NSUbiquitousKeyValueStore {
// 		
// 		
// 		NSUbiquitousKeyValueStore DefaultStore { get; }
//
// 		
// 		NSObject ObjectForKey (string aKey);
//
// 		
// 		void SetObjectForKey (NSObject anObject, string aKey);
//
// 		
// 		void Remove (string aKey);
//
// 		
// 		string GetString (string aKey);
//
// 		
// 		NSObject  GetArray (string aKey);
//
// 		
// 		NSDictionary GetDictionary (string aKey);
//
// 		
// 		NSData GetData (string aKey);
//
// 		
// 		long GetLong (string aKey);
//
// 		
// 		double GetDouble (string aKey);
//
// 		
// 		bool GetBool (string aKey);
//
// 		
// 		void _SetString (string aString, string aKey);
//
// 		
// 		void _SetData (NSData data, string key);
//
// 		
// 		void _SetArray (NSObject  array, string key);
//
// 		
// 		void _SetDictionary (NSDictionary aDictionary, string aKey);
//
// 		
// 		void _SetLong (long value, string aKey);
//
// 		
// 		void _SetDouble (double value, string aKey);
//
// 		
// 		void _SetBool (bool value, string aKey);
//
// 		
// 		NSDictionary ToDictionary ();
//
// 		
// 		bool Synchronize ();
//
// 		
// 		
// 		NSString DidChangeExternallyNotification { get; }
//
// 		
// 		NSString ChangeReasonKey { get; }
//
// 		
// 		NSString ChangedKeysKey { get; }
// 	}
//
// 	
// 	
// 	interface NSUuid : NSSecureCoding, NSCopying {
// 		
// 		NativeHandle Constructor (string str);
//
// 		// bound manually to keep the managed/native signatures identical
// 		//
// 		//NativeHandle Constructor (IntPtr bytes, bool unused);
//
// 		
// 		void GetUuidBytes (IntPtr uuid);
//
// 		
// 		string AsString ();
// 	}
//
// 	 // .objc_class_name_NSUserActivity", referenced from '' not found
// 	
// 	 // xcode 8 beta 4 marks it as API_DEPRECATED
// 	partial interface NSUserActivity
// #if IOS // iOS only.
// 	: NSItemProviderReading, NSItemProviderWriting
// #endif
// 	{
// 		
// 		
// 		NativeHandle Constructor (string activityType);
//
// 		
// 		string ActivityType { get; }
// 	
// 		 // by default this property is null
// 		
// 		string Title { get; set; }
// 	
// 		
// 		NSDictionary UserInfo { get; set; }
// 	
// 		
// 		bool NeedsSave { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		NSUrl WebPageUrl { get; set; }
// 	
// 		
// 		bool SupportsContinuationStreams { get; set; }
// 	
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSUserActivityDelegate Delegate { get; set; }
// 	
// 		
// 		void AddUserInfoEntries (NSDictionary otherDictionary);
// 	
// 		
// 		void BecomeCurrent ();
// 	
// 		
// 		void Invalidate ();
// 	
// 		
// 		
// 		void GetContinuationStreams (Action<NSInputStream,NSOutputStream,NSError> completionHandler);
//
// 		
// 		
// 		NSSet<NSString> RequiredUserInfoKeys { get; set; }
//
// 		
// 		
// 		NSDate ExpirationDate { get; set; }
//
// 		
// 		
// 		NSSet<NSString> Keywords { get; set; }
//
// 		
// 		
// 		void ResignCurrent ();
//
// 		
// 		
// 		bool EligibleForHandoff {  get; set; }
//
// 		
// 		
// 		bool EligibleForSearch {  get; set; }
//
// 		
// 		
// 		bool EligibleForPublicIndexing {  get; set; }
// 		
// 		
// 		
// 		
// 		
// 		 // From CSSearchableItemAttributeSet.h
// 		CSSearchableItemAttributeSet ContentAttributeSet { get; set; }
//
// 		
// 		
// 		NSUrl ReferrerUrl { get; set; }
//
// 		// From NSUserActivity (CIBarcodeDescriptor)
//
// 		
// 		
// 		CIBarcodeDescriptor DetectedBarcodeDescriptor { get; }
//
// 		// From NSUserActivity (CLSDeepLinks)
//
// 		
// 		
// 		
// 		bool IsClassKitDeepLink { get; }
//
// 		
// 		
// 		
// 		string ContextIdentifierPath { get; }
//
// 		// From NSUserActivity (IntentsAdditions)
//
// 		
// 		
// 		string SuggestedInvocationPhrase {
// 			// This _simply_ ensure that the Intents namespace (via the enum) will be present which,
// 			// in turns, means that the Intents.framework is loaded into memory and this makes the
// 			// selectors (getter and setter) work at runtime. Other selectors do not need it.
// 			// reference: https://github.com/xamarin/xamarin-macios/issues/4894
// 			
// 			get;
// 			
// 			set;
// 		}
//
// 		
// 		
// 		bool EligibleForPrediction {  get; set; }
//
// 		
// 		
// 		
// 		string PersistentIdentifier { get; set; }
//
// 		
// 		
// 		
// 		
// 		
// 		void DeleteSavedUserActivities (string persistentIdentifiers, Action handler);
//
// 		
// 		
// 		
// 		
// 		
// 		void DeleteAllSavedUserActivities (Action handler);
//
// 		// Inlined from NSUserActivity (UISceneActivationConditions)
//
// 		
// 		
// 		string TargetContentIdentifier { get; set; }
//
// #if HAS_APPCLIP
// 		// Inlined from NSUserActivity (AppClip)
// 		
// 		
// 		
// 		APActivationPayload AppClipActivationPayload { get; }
// #endif
// 	}
//
// 	 // same as NSUserActivity
// 	
// 	partial interface NSUserActivityType {
// 		
// 		NSString BrowsingWeb { get; }
// 	}
//
// 	 // same as NSUserActivity
// 	
// 	
// 	partial interface NSUserActivityDelegate {
// 		
// 		void UserActivityWillSave (NSUserActivity userActivity);
// 	
// 		
// 		void UserActivityWasContinued (NSUserActivity userActivity);
// 	
// 		
// 		void UserActivityReceivedData (NSUserActivity userActivity, NSInputStream inputStream, NSOutputStream outputStream);
// 	}
// 		
// 	
// 	interface NSUserDefaults {
// 		
// 		
// 		NSUrl URLForKey (string defaultName);
//
// 		
// 		void SetURL ( NSUrl url, string defaultName);
//
// 		
// 		
// 		NSUserDefaults StandardUserDefaults { get; }
// 	
// 		
// 		
// 		void ResetStandardUserDefaults ();
// 	
// 		
// 		
// 		IntPtr InitWithUserName (string username);
//
// 		
// 		
// 		
// 		IntPtr InitWithSuiteName (string suiteName);
//
// 		
// 		NSObject ObjectForKey (string defaultName);
// 	
// 		
// 		void SetObjectForKey (NSObject value, string defaultName);
// 	
// 		
// 		void RemoveObject (string defaultName);
// 	
// 		
// 		string StringForKey (string defaultName);
// 	
// 		
// 		NSObject  ArrayForKey (string defaultName);
// 	
// 		
// 		NSDictionary DictionaryForKey (string defaultName);
// 	
// 		
// 		NSData DataForKey (string defaultName);
// 	
// 		
// 		string  StringArrayForKey (string defaultName);
// 	
// 		
// 		nint IntForKey (string defaultName);
// 	
// 		
// 		float FloatForKey (string defaultName); // this is defined as float, not CGFloat.
// 	
// 		
// 		double DoubleForKey (string defaultName);
// 	
// 		
// 		bool BoolForKey (string defaultName);
// 	
// 		
// 		void SetInt (nint value, string defaultName);
// 	
// 		
// 		void SetFloat (float value /* this is defined as float, not CGFloat */, string defaultName);
// 	
// 		
// 		void SetDouble (double value, string defaultName);
// 	
// 		
// 		void SetBool (bool value, string  defaultName);
// 	
// 		
// 		void RegisterDefaults (NSDictionary registrationDictionary);
// 	
// 		
// 		void AddSuite (string suiteName);
// 	
// 		
// 		void RemoveSuite (string suiteName);
// 	
// 		
// 		NSDictionary ToDictionary ();
// 	
// 		
// 		string  VolatileDomainNames ();
// 	
// 		
// 		NSDictionary GetVolatileDomain (string domainName);
// 	
// 		
// 		void SetVolatileDomain (NSDictionary domain, string domainName);
// 	
// 		
// 		void RemoveVolatileDomain (string domainName);
// 	
// 		
// 		
// 		
// 		string  PersistentDomainNames ();
// 	
// 		
// 		NSDictionary PersistentDomainForName (string domainName);
// 	
// 		
// 		void SetPersistentDomain (NSDictionary domain, string domainName);
// 	
// 		
// 		void RemovePersistentDomain (string domainName);
// 	
// 		
// 		bool Synchronize ();
// 	
// 		
// 		bool ObjectIsForced (string key);
// 	
// 		
// 		bool ObjectIsForced (string key, string domain);
//
// 		
// 		NSString GlobalDomain { get; }
//
// 		
// 		NSString ArgumentDomain { get; }
//
// 		
// 		NSString RegistrationDomain { get; }
//
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString SizeLimitExceededNotification { get; }
//
// 		
// 		
// 		
// 		NSString NoCloudAccountNotification { get; }
//
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString DidChangeAccountsNotification { get; }
//
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString CompletedInitialSyncNotification { get; }
//
// 		
// 		
// 		NSString DidChangeNotification { get; }
// 	}
// 	
// 	
// 	// init returns NIL
// 	
// 	partial interface NSUrl : NSSecureCoding, NSCopying
// #if MONOMAC
// 	, NSPasteboardReading, NSPasteboardWriting
// #endif
// 	, NSItemProviderWriting, NSItemProviderReading
// #if IOS || MONOMAC
// 	, QLPreviewItem
// #endif
// 	{
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (string scheme, string host, string path);
//
// 		
// 		
// 		NativeHandle Constructor (string path, bool isDir);
//
// 		
// 		NativeHandle Constructor (string urlString);
//
// 		
// 		
// 		NativeHandle Constructor (string urlString, NSUrl relativeToUrl);
//
// 		
// 		
// 		NSUrl FromString ( string s);
//
// 		
// 		NSUrl _FromStringRelative (string url, NSUrl relative);
// 		
// 		
// 		string AbsoluteString { get; }
//
// 		
// 		NSUrl AbsoluteUrl { get; }
//
// 		
// 		NSUrl BaseUrl { get; }
//
// 		
// 		string Fragment { get; }
//
// 		
// 		string Host { get; }
//
// 		
// 		
// 		bool IsEqual ( NSUrl other);
//
// 		
// 		bool IsFileUrl { get; }
// 		
// 		
// 		bool IsFileReferenceUrl { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		string ParameterString { get;}
//
// 		
// 		string Password { get;}
//
// 		
// 		string Path { get;}
//
// 		
// 		string Query { get;}
//
// 		
// 		string RelativePath { get;}
//
// 		
// 		string  PathComponents { get; }
//
// 		
// 		string LastPathComponent { get; }
//
// 		
// 		string PathExtension { get; }
//
// 		
// 		string RelativeString { get;}
//
// 		
// 		string ResourceSpecifier { get;}
//
// 		
// 		string Scheme { get;}
//
// 		
// 		string User { get;}
//
// 		
// 		NSUrl StandardizedUrl { get; }
//
// 		
// 		NSUrl Append (string pathComponent, bool isDirectory);
//
// 		
// 		NSUrl AppendPathExtension (string extension);
//
// 		
// 		NSUrl RemoveLastPathComponent ();
//
// 		
// 		NSUrl RemovePathExtension ();
//
// 		
// 		
// 		bool GetFileSystemRepresentation (IntPtr buffer, nint maxBufferLength);
//
// 		
// 		
// 		IntPtr GetFileSystemRepresentationAsUtf8Ptr { get; }
//
// 		
// 		
// 		void RemoveCachedResourceValueForKey (NSString key);
//
// 		
// 		
// 		void RemoveAllCachedResourceValues ();
//
// 		
// 		
// 		void SetTemporaryResourceValue (NSObject value, NSString key);
//
// 		
// 		
// 		
// 		NativeHandle Constructor (IntPtr ptrUtf8path, bool isDir,  NSUrl baseURL);
//
// 		
// 		NSUrl FromUTF8Pointer (IntPtr ptrUtf8path, bool isDir,  NSUrl baseURL);
//
// 		/* These methods come from NURL_AppKitAdditions */
// 		
// 		
// 		
// 		NSUrl FromPasteboard (NSPasteboard pasteboard);
//
// 		
// 		
// 		void WriteToPasteboard (NSPasteboard pasteboard);
//
// 		
// 		
// 		NSData GetBookmarkData (NSUrl bookmarkFileUrl, out NSError error);
//
// 		
// 		
// 		NSUrl FromBookmarkData (NSData data, NSUrlBookmarkResolutionOptions options,  NSUrl relativeToUrl, out bool isStale, out NSError error);
//
// 		
// 		
// 		bool WriteBookmarkData (NSData data, NSUrl bookmarkFileUrl, NSUrlBookmarkCreationOptions options, out NSError error);
//
// 		
// 		NSUrl FilePathUrl { get; }
//
// 		
// 		NSUrl FileReferenceUrl { get; }		
//
// 		
// 		bool GetResourceValue (out NSObject value, NSString key, out NSError error);
//
// 		
// 		NSDictionary GetResourceValues (NSString  keys, out NSError error);
//
// 		
// 		bool SetResourceValue (NSObject value, NSString key, out NSError error);
// 		
// 		
// 		
// 		NSNumber PortNumber { get; }
//
// 		
// 		NSString NameKey { get; }
//
// 		
// 		NSString LocalizedNameKey { get; }
//
// 		
// 		NSString IsRegularFileKey { get; }
//
// 		
// 		NSString IsDirectoryKey { get; }
//
// 		
// 		NSString IsSymbolicLinkKey { get; }
//
// 		
// 		NSString IsVolumeKey { get; }
//
// 		
// 		NSString IsPackageKey { get; }
//
// 		
// 		NSString IsSystemImmutableKey { get; }
//
// 		
// 		NSString IsUserImmutableKey { get; }
//
// 		
// 		NSString IsHiddenKey { get; }
//
// 		
// 		NSString HasHiddenExtensionKey { get; }
//
// 		
// 		NSString CreationDateKey { get; }
//
// 		
// 		NSString ContentAccessDateKey { get; }
//
// 		
// 		NSString ContentModificationDateKey { get; }
//
// 		
// 		NSString AttributeModificationDateKey { get; }
//
// 		
// 		NSString LinkCountKey { get; }
//
// 		
// 		NSString ParentDirectoryURLKey { get; }
//
// 		
// 		NSString VolumeURLKey { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		NSString TypeIdentifierKey { get; }
//
// 		
// 		NSString LocalizedTypeDescriptionKey { get; }
//
// 		
// 		NSString LabelNumberKey { get; }
//
// 		
// 		NSString LabelColorKey { get; }
//
// 		
// 		NSString LocalizedLabelKey { get; }
//
// 		
// 		NSString EffectiveIconKey { get; }
//
// 		
// 		NSString CustomIconKey { get; }
//
// 		
// 		NSString FileSizeKey { get; }
//
// 		
// 		NSString FileAllocatedSizeKey { get; }
//
// 		
// 		NSString IsAliasFileKey	{ get; }
//
// 		
// 		NSString VolumeLocalizedFormatDescriptionKey { get; }
//
// 		
// 		NSString VolumeTotalCapacityKey { get; }
//
// 		
// 		NSString VolumeAvailableCapacityKey { get; }
//
// 		
// 		NSString VolumeResourceCountKey { get; }
//
// 		
// 		NSString VolumeSupportsPersistentIDsKey { get; }
//
// 		
// 		NSString VolumeSupportsSymbolicLinksKey { get; }
//
// 		
// 		NSString VolumeSupportsHardLinksKey { get; }
//
// 		
// 		NSString VolumeSupportsJournalingKey { get; }
//
// 		
// 		NSString VolumeIsJournalingKey { get; }
//
// 		
// 		NSString VolumeSupportsSparseFilesKey { get; }
//
// 		
// 		NSString VolumeSupportsZeroRunsKey { get; }
//
// 		
// 		NSString VolumeSupportsCaseSensitiveNamesKey { get; }
//
// 		
// 		NSString VolumeSupportsCasePreservedNamesKey { get; }
//
// 		// 5.0 Additions
// 		
// 		NSString KeysOfUnsetValuesKey { get; }
//
// 		
// 		NSString FileResourceIdentifierKey { get; }
//
// 		
// 		NSString VolumeIdentifierKey { get; }
//
// 		
// 		NSString PreferredIOBlockSizeKey { get; }
//
// 		
// 		NSString IsReadableKey { get; }
//
// 		
// 		NSString IsWritableKey { get; }
//
// 		
// 		NSString IsExecutableKey { get; }
//
// 		
// 		NSString IsMountTriggerKey { get; }
//
// 		
// 		NSString FileSecurityKey { get; }
//
// 		
// 		NSString FileResourceTypeKey { get; }
//
// 		
// 		NSString FileResourceTypeNamedPipe { get; }
//
// 		
// 		NSString FileResourceTypeCharacterSpecial { get; }
//
// 		
// 		NSString FileResourceTypeDirectory { get; }
//
// 		
// 		NSString FileResourceTypeBlockSpecial { get; }
//
// 		
// 		NSString FileResourceTypeRegular { get; }
//
// 		
// 		NSString FileResourceTypeSymbolicLink { get; }
//
// 		
// 		NSString FileResourceTypeSocket { get; }
//
// 		
// 		NSString FileResourceTypeUnknown { get; }
//
// 		
// 		NSString TotalFileSizeKey { get; }
//
// 		
// 		NSString TotalFileAllocatedSizeKey { get; }
//
// 		
// 		NSString VolumeSupportsRootDirectoryDatesKey { get; }
//
// 		
// 		NSString VolumeSupportsVolumeSizesKey { get; }
//
// 		
// 		NSString VolumeSupportsRenamingKey { get; }
//
// 		
// 		NSString VolumeSupportsAdvisoryFileLockingKey { get; }
//
// 		
// 		NSString VolumeSupportsExtendedSecurityKey { get; }
//
// 		
// 		NSString VolumeIsBrowsableKey { get; }
//
// 		
// 		NSString VolumeMaximumFileSizeKey { get; }
//
// 		
// 		NSString VolumeIsEjectableKey { get; }
//
// 		
// 		NSString VolumeIsRemovableKey { get; }
//
// 		
// 		NSString VolumeIsInternalKey { get; }
//
// 		
// 		NSString VolumeIsAutomountedKey { get; }
//
// 		
// 		NSString VolumeIsLocalKey { get; }
//
// 		
// 		NSString VolumeIsReadOnlyKey { get; }
//
// 		
// 		NSString VolumeCreationDateKey { get; }
//
// 		
// 		NSString VolumeURLForRemountingKey { get; }
//
// 		
// 		NSString VolumeUUIDStringKey { get; }
//
// 		
// 		NSString VolumeNameKey { get; }
//
// 		
// 		NSString VolumeLocalizedNameKey { get; }
//
// 		
// 		
// 		NSString VolumeIsEncryptedKey { get; }
//
// 		
// 		
// 		NSString VolumeIsRootFileSystemKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsCompressionKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsFileCloningKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsSwapRenamingKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsExclusiveRenamingKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsImmutableFilesKey { get; }
//
// 		
// 		
// 		NSString VolumeSupportsAccessPermissionsKey { get; }
//
// 		
// 		
// 		
// 		NSString VolumeSupportsFileProtectionKey { get; }
//
// 		
// 		
// 		NSString VolumeAvailableCapacityForImportantUsageKey { get; }
//
// 		
// 		
// 		NSString VolumeAvailableCapacityForOpportunisticUsageKey { get; }
//
// 		
// 		NSString IsUbiquitousItemKey { get; }
//
// 		
// 		NSString UbiquitousItemHasUnresolvedConflictsKey { get; }
//
// 		
// 		NSString UbiquitousItemIsDownloadedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemIsDownloadingKey { get; }
//
// 		
// 		NSString UbiquitousItemIsUploadedKey { get; }
//
// 		
// 		NSString UbiquitousItemIsUploadingKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemPercentDownloadedKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemPercentUploadedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemIsSharedKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemCurrentUserRoleKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemCurrentUserPermissionsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemOwnerNameComponentsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemMostRecentEditorNameComponentsKey { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemRoleOwner { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemRoleParticipant { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemPermissionsReadOnly { get; }
//
// 		
// 		
// 		NSString UbiquitousSharedItemPermissionsReadWrite { get; }
//
// 		
// 		NSString IsExcludedFromBackupKey { get; }
//
// 		
// 		NSData CreateBookmarkData (NSUrlBookmarkCreationOptions options,  string  resourceValues,  NSUrl relativeUrl, out NSError error);
//
// 		
// 		NativeHandle Constructor (NSData bookmarkData, NSUrlBookmarkResolutionOptions resolutionOptions,  NSUrl relativeUrl, out bool bookmarkIsStale, out NSError error);
//
// 		
// 		NSString PathKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadingStatusKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadingErrorKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemUploadingErrorKey { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadingStatusNotDownloaded { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadingStatusDownloaded { get; }
//
// 		
// 		
// 		NSString UbiquitousItemDownloadingStatusCurrent { get; }
//
// 		
// 		
// 		bool StartAccessingSecurityScopedResource ();
//
// 		
// 		
// 		void StopAccessingSecurityScopedResource ();
//
// 		
// 		
// 		NSUrl ResolveAlias  (NSUrl aliasFileUrl, NSUrlBookmarkResolutionOptions options, out NSError error);
//
// 		
// 		NSUrl CreateFileUrl (string  pathComponents);
//
// 		
// 		
// 		NSString AddedToDirectoryDateKey { get; }
// 		
// 		
// 		
// 		NSString DocumentIdentifierKey { get; }
// 		
// 		
// 		
// 		NSString GenerationIdentifierKey { get; }
// 		
// 		
// 		
// 		NSString ThumbnailDictionaryKey { get; }
// 		
// 		
// 		
// 		NSString UbiquitousItemContainerDisplayNameKey { get; }
//
// 		
// 		
// 		
// 		NSString UbiquitousItemIsExcludedFromSyncKey { get; }
// 		
// 		
// 		
// 		NSString UbiquitousItemDownloadRequestedKey { get; }
//
// 		//
// 		// iOS 9.0/osx 10.11 additions
// 		//
// 		
// 		
// 		
// 		NativeHandle Constructor (string path, bool isDir,  NSUrl relativeToUrl);
//
// 		
// 		
// 		
// 		NSUrl CreateFileUrl (string path, bool isDir,  NSUrl relativeToUrl);
//
// 		
// 		
// 		
// 		NSUrl CreateFileUrl (string path,  NSUrl relativeToUrl);
//
// 		
// 		
// 		
// 		NSUrl CreateWithDataRepresentation (NSData data,  NSUrl relativeToUrl);
//
// 		
// 		
// 		
// 		NSUrl CreateAbsoluteUrlWithDataRepresentation (NSData data,  NSUrl relativeToUrl);
//
// 		
// 		
// 		NSData DataRepresentation { get; }
//
// 		
// 		
// 		bool HasDirectoryPath { get; }
//
// 		
// 		
// 		NSString IsApplicationKey { get; }
//
// 		
// 		
// 		NSString FileProtectionKey { get; }
//
// 		
// 		
// 		NSString FileProtectionNone { get; }
// 		
// 		
// 		
// 		NSString FileProtectionComplete { get; }
// 		
// 		
// 		
// 		NSString FileProtectionCompleteUnlessOpen { get; }
//
// 		
// 		
// 		NSString FileProtectionCompleteUntilFirstUserAuthentication { get; }
//
// 		
// 		
// 		
// 		NSString ContentTypeKey { get; }
//
// 		
// 		
// 		
// 		NSString FileContentIdentifierKey { get; }
//
// 		
// 		
// 		
// 		NSString IsPurgeableKey { get; }
//
// 		
// 		
// 		
// 		NSString IsSparseKey { get; }
//
// 		
// 		
// 		
// 		NSString MayHaveExtendedAttributesKey { get; }
//
// 		
// 		
// 		
// 		NSString MayShareFileContentKey { get; }
//
// 		// From the NSItemProviderReading protocol
// 		
// 		
// 		
// 		new string ReadableTypeIdentifiers { get; }
//
// 		// From the NSItemProviderReading protocol
// 		
// 		
// 		
// 		
// 		new NSUrl GetObject (NSData data, string typeIdentifier,  out NSError outError);
//
// 		// From the NSItemProviderWriting protocol
// 		
// 		
// 		
// 		new	string WritableTypeIdentifiers { get; }
// 	}
//
// 	
// 	//
// 	// Just a category so we can document the three methods together
// 	//
// 	
// 	partial interface NSUrl_PromisedItems {
// 		
// 		
// 		bool CheckPromisedItemIsReachable (out NSError error);
//
// 		
// 		
// 		bool GetPromisedItemResourceValue (out NSObject value, NSString key, out NSError error);
//
// 		
// 		
// 		
// 		NSDictionary GetPromisedItemResourceValues (NSString  keys, out NSError error);
// 		
// 	}
//
// 	
// 	
// 	interface NSUrlQueryItem : NSSecureCoding, NSCopying {
// 		
// 		
// 		NativeHandle Constructor (string name, string value);
//
// 		
// 		string Name { get; }
//
// 		
// 		string Value { get; }
// 	}
//
// 	
// 	partial interface NSUrlUtilities_NSCharacterSet {
// 		
// 		NSCharacterSet UrlUserAllowedCharacterSet { get; }
// 	
// 		
// 		NSCharacterSet UrlPasswordAllowedCharacterSet { get; }
// 	
// 		
// 		NSCharacterSet UrlHostAllowedCharacterSet { get; }
// 	
// 		
// 		NSCharacterSet UrlPathAllowedCharacterSet { get; }
// 	
// 		
// 		NSCharacterSet UrlQueryAllowedCharacterSet { get; }
// 	
// 		
// 		NSCharacterSet UrlFragmentAllowedCharacterSet { get; }
// 	}
// 		
// 	
// 	interface NSUrlCache {
// 		
// 		NSUrlCache SharedCache { get; set; }
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor (nuint memoryCapacity, nuint diskCapacity,  string diskPath);
//
// 		
// 		
// 		NativeHandle Constructor (nuint memoryCapacity, nuint diskCapacity,  NSUrl directoryUrl);
//
// 		
// 		NSCachedUrlResponse CachedResponseForRequest (NSUrlRequest request);
//
// 		
// 		void StoreCachedResponse (NSCachedUrlResponse cachedResponse, NSUrlRequest forRequest);
//
// 		
// 		void RemoveCachedResponse (NSUrlRequest request);
//
// 		
// 		void RemoveAllCachedResponses ();
//
// 		
// 		nuint MemoryCapacity { get; set; }
//
// 		
// 		nuint DiskCapacity { get; set; }
//
// 		
// 		nuint CurrentMemoryUsage { get; }
//
// 		
// 		nuint CurrentDiskUsage { get; }
//
// 		
// 		
// 		void RemoveCachedResponsesSinceDate (NSDate date);
//
// 		
// 		
// 		void StoreCachedResponse (NSCachedUrlResponse cachedResponse, NSUrlSessionDataTask dataTask);
//
// 		
// 		
// 		
// 		void GetCachedResponse (NSUrlSessionDataTask dataTask, Action<NSCachedUrlResponse> completionHandler);
//
// 		
// 		
// 		void RemoveCachedResponse (NSUrlSessionDataTask dataTask);
// 	}
// 	
// 	
// 	
// 	partial interface NSUrlComponents : NSCopying {
// 		
// 		NativeHandle Constructor (NSUrl url, bool resolveAgainstBaseUrl);
// 	
// 		
// 		NSUrlComponents FromUrl (NSUrl url, bool resolvingAgainstBaseUrl);
// 	
// 		
// 		NativeHandle Constructor (string urlString);
// 	
// 		
// 		NSUrlComponents FromString (string urlString);
// 	
// 		
// 		NSUrl Url { get; }
// 	
// 		
// 		NSUrl GetRelativeUrl (NSUrl baseUrl);
// 	
// 		 // by default this property is null
// 		
// 		string Scheme { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string User { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string Password { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string Host { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		NSNumber Port { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string Path { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string Query { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string Fragment { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedUser { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedPassword { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedHost { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedPath { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedQuery { get; set; }
// 	
// 		 // by default this property is null
// 		
// 		string PercentEncodedFragment { get; set; }
//
// 		
// 		 // by default this property is null
// 		
// 		NSUrlQueryItem  QueryItems { get; set; }
//
// 		
// 		
// 		string AsString ();
//
// 		
// 		
// 		NSRange RangeOfScheme { get; }
//
// 		
// 		
// 		NSRange RangeOfUser { get; }
//
// 		
// 		
// 		NSRange RangeOfPassword { get; }
//
// 		
// 		
// 		NSRange RangeOfHost { get; }
//
// 		
// 		
// 		NSRange RangeOfPort { get; }
//
// 		
// 		
// 		NSRange RangeOfPath { get; }
//
// 		
// 		
// 		NSRange RangeOfQuery { get; }
//
// 		
// 		
// 		NSRange RangeOfFragment { get; }
//
// 		
// 		
// 		NSUrlQueryItem PercentEncodedQueryItems { get; set; }
// 	}
// 	
// 	
// 	// 'init' returns NIL
// 	
// 	interface NSUrlAuthenticationChallenge : NSSecureCoding {
// 		
// 		NativeHandle Constructor (NSUrlProtectionSpace space, NSUrlCredential credential, nint previousFailureCount,  NSUrlResponse response,  NSError error, NSUrlConnection sender);
// 		
// 		
// 		NativeHandle Constructor (NSUrlAuthenticationChallenge  challenge, NSUrlConnection sender);
// 	
// 		
// 		NSUrlProtectionSpace ProtectionSpace { get; }
// 	
// 		
// 		NSUrlCredential ProposedCredential { get; }
// 	
// 		
// 		nint PreviousFailureCount { get; }
// 	
// 		
// 		NSUrlResponse FailureResponse { get; }
// 	
// 		
// 		NSError Error { get; }
// 	
// 		
// 		NSUrlConnection Sender { get; }
// 	}
//
// 	
// #if NETXXX
// 	interface NSUrlAuthenticationChallengeSender {
// #else
// 	
// 	
// 	interface NSURLAuthenticationChallengeSender {
// #endif
// 		
// 		
// 		void UseCredential (NSUrlCredential credential, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		
// 		void ContinueWithoutCredential (NSUrlAuthenticationChallenge challenge);
//
// 		
// 		
// 		void CancelAuthenticationChallenge (NSUrlAuthenticationChallenge challenge);
//
// 		
// 		void PerformDefaultHandling (NSUrlAuthenticationChallenge challenge);
//
// 		
// 		void RejectProtectionSpaceAndContinue (NSUrlAuthenticationChallenge challenge);
// 	}
//
//
// 	delegate void NSUrlConnectionDataResponse (NSUrlResponse response, NSData data, NSError error);
// 	
// 	
// 	interface NSUrlConnection : 
// #if NETXXX
// 		NSUrlAuthenticationChallengeSender
// #else
// 		NSURLAuthenticationChallengeSender
// #endif
// 	{
// 		
// 		bool CanHandleRequest (NSUrlRequest request);
// 	
// 		
// 		
// 		
// 		
// 		NSUrlConnection FromRequest (NSUrlRequest request,  NSUrlConnectionDelegate connectionDelegate);
// 	
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrlRequest request,  NSUrlConnectionDelegate connectionDelegate);
// 	
// 		
// 		
// 		
// 		NativeHandle Constructor (NSUrlRequest request,  NSUrlConnectionDelegate connectionDelegate, bool startImmediately);
// 	
// 		
// 		void Start ();
// 	
// 		
// 		void Cancel ();
// 	
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSString forMode);
//
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
// 	
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSString forMode);
//
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
//
// 		
// 		
// 		NSUrlRequest OriginalRequest { get; }
//
// 		
// 		
// 		NSUrlRequest CurrentRequest { get; }
//
// 		
// 		void SetDelegateQueue (NSOperationQueue queue);
//
// 		
// 		
// 		
// 		
// 		
// 		
// 		
// 		void SendAsynchronousRequest (NSUrlRequest request, NSOperationQueue queue, NSUrlConnectionDataResponse completionHandler);
// 		
// #if HAS_NEWSSTANDKIT
// 		// Extension from iOS5, NewsstandKit
// 		
// 		
// 		
// 		NewsstandKit.NKAssetDownload NewsstandAssetDownload { get; }
// #endif
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlConnectionDelegate {
// 		
// 		
// 		
// 		bool CanAuthenticateAgainstProtectionSpace (NSUrlConnection connection, NSUrlProtectionSpace protectionSpace);
//
// 		
// 		
// 		
// 		void ReceivedAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		
// 		
// 		void CanceledAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		bool ConnectionShouldUseCredentialStorage (NSUrlConnection connection);
//
// 		
// 		void FailedWithError (NSUrlConnection connection, NSError error);
//
// 		
// 		void WillSendRequestForAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);
// 	}
//
// 	
// 	
// 	interface NSUrlConnectionDataDelegate {
//
// 		
// 		NSUrlRequest WillSendRequest (NSUrlConnection connection, NSUrlRequest request, NSUrlResponse response);
//
// 		
// 		void ReceivedResponse (NSUrlConnection connection, NSUrlResponse response);
//
// 		
// 		void ReceivedData (NSUrlConnection connection, NSData data);
//
// 		
// 		NSInputStream NeedNewBodyStream (NSUrlConnection connection, NSUrlRequest request);
//
// 		
// 		void SentBodyData (NSUrlConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
//
// 		
// 		NSCachedUrlResponse WillCacheResponse (NSUrlConnection connection, NSCachedUrlResponse cachedResponse);
//
// 		
// 		void FinishedLoading (NSUrlConnection connection);
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlConnectionDownloadDelegate {
// 		
// 		void WroteData (NSUrlConnection connection, long bytesWritten, long totalBytesWritten, long expectedTotalBytes);
// 		
// 		
// 		void ResumedDownloading (NSUrlConnection connection, long totalBytesWritten, long expectedTotalBytes);
// 		
// 		
// 		
// 		void FinishedDownloading (NSUrlConnection connection, NSUrl destinationUrl);
// 	}
// 		
// 	
// 	// crash when calling NSObjecg.get_Description (and likely other selectors)
// 	
// 	interface NSUrlCredential : NSSecureCoding, NSCopying {
//
// 		
// 		NativeHandle Constructor (SecTrust trust);
//
// 		
// 		NSUrlCredentialPersistence Persistence { get; }
//
// 		
// 		NativeHandle Constructor (string user, string password, NSUrlCredentialPersistence persistence);
// 	
// 		
// 		
// 		NSUrlCredential FromUserPasswordPersistance (string user, string password, NSUrlCredentialPersistence persistence);
//
// 		
// 		string User { get; }
// 	
// 		
// 		string Password { get; }
// 	
// 		
// 		bool HasPassword {get; }
// 	
// 		
// 		
// 		NativeHandle Constructor (IntPtr identity, IntPtr certificates, NSUrlCredentialPersistence persistance);
// 	
// 		
// 		
// 		
// 		NSUrlCredential FromIdentityCertificatesPersistanceInternal (IntPtr identity, IntPtr certificates, NSUrlCredentialPersistence persistence);
// 	
// 		
// 		
// 		IntPtr Identity { get; }
// 	
// 		
// 		SecCertificate  Certificates { get; }
// 	
// 		// bound manually to keep the managed/native signatures identical
// 		//
// 		//NativeHandle Constructor (IntPtr SecTrustRef_trust, bool ignored);
// 	
// 		
// 		
// 		
// 		NSUrlCredential FromTrust (IntPtr trust);
// 	}
//
// 	
// 	// init returns NIL -> SharedCredentialStorage
// 	
// 	interface NSUrlCredentialStorage {
// 		
// 		
// 		NSUrlCredentialStorage SharedCredentialStorage { get; }
//
// 		
// 		NSDictionary GetCredentials (NSUrlProtectionSpace forProtectionSpace);
//
// 		
// 		NSDictionary AllCredentials { get; }
//
// 		
// 		void SetCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);
//
// 		
// 		void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);
//
// 		
// 		NSUrlCredential GetDefaultCredential (NSUrlProtectionSpace forProtectionSpace);
//
// 		
// 		void SetDefaultCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);
//
// 		
// 		
// 		void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace, NSDictionary options);
//
// 		
// 		
// 		NSString RemoveSynchronizableCredentials { get; }
//
// 		
// 		
// 		NSString ChangedNotification { get; }
//
// 		
// 		
// 		
// 		void GetCredentials (NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task,  Action<NSDictionary> completionHandler);
//
// 		
// 		
// 		void SetCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task);
//
// 		
// 		
// 		void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSDictionary options, NSUrlSessionTask task);
//
// 		
// 		
// 		
// 		void GetDefaultCredential (NSUrlProtectionSpace space, NSUrlSessionTask task,  Action<NSUrlCredential> completionHandler);
//
// 		
// 		
// 		void SetDefaultCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task);
// 		
// 	}
//
// #if NETXXX
// 	delegate void NSUrlSessionPendingTasks (NSUrlSessionTask  dataTasks, NSUrlSessionTask  uploadTasks, NSUrlSessionTask downloadTasks);
// #elif XAMCORE_3_0
// 	delegate void NSUrlSessionPendingTasks2 (NSUrlSessionTask  dataTasks, NSUrlSessionTask  uploadTasks, NSUrlSessionTask downloadTasks);
// #else
// 	delegate void NSUrlSessionPendingTasks (NSUrlSessionDataTask  dataTasks, NSUrlSessionUploadTask  uploadTasks, NSUrlSessionDownloadTask downloadTasks);
// 	delegate void NSUrlSessionPendingTasks2 (NSUrlSessionTask  dataTasks, NSUrlSessionTask  uploadTasks, NSUrlSessionTask downloadTasks);
// #endif
// 	delegate void NSUrlSessionAllPendingTasks (NSUrlSessionTask  tasks);
// 	delegate void NSUrlSessionResponse (NSData data, NSUrlResponse response, NSError error);
// 	delegate void NSUrlSessionDownloadResponse (NSUrl data, NSUrlResponse response, NSError error);
//
// 	delegate void NSUrlDownloadSessionResponse (NSUrl location, NSUrlResponse response, NSError error);
//
// 	interface INSUrlSessionDelegate {}
//
// 	//
// 	// Some of the XxxTaskWith methods that take a completion were flagged as allowing a null in
// 	// 083d9cba1eb997eac5c5ded77db32180c3eef566 with comment:
// 	//
// 	// "Add missing  on NSUrlSession since the
// 	// delegate is optional and the handler can be null when one
// 	// is provided (but requiring a delegate along with handlers
// 	// only duplicates code)"
// 	//
// 	// but Apple has flagged these as not allowing null.
// 	//
// 	// Leaving the null allowed for now.
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSession {
// 	
// 		
// 		NSUrlSession SharedSession { get; }
// 	
// 		
// 		NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration);
// 	
// 		
// 		NSUrlSession FromWeakConfiguration (NSUrlSessionConfiguration configuration,  NSObject weakDelegate,  NSOperationQueue delegateQueue);
// 	
// #if !NETXXX
// 		
// 		
// 		NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration, NSUrlSessionDelegate sessionDelegate,  NSOperationQueue delegateQueue);
// #endif
// 		
// 		NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration, INSUrlSessionDelegate sessionDelegate,  NSOperationQueue delegateQueue);
//
// 		
// 		NSOperationQueue DelegateQueue { get; }
// 	
// 		
// 		NSObject WeakDelegate { get; }
// 	
// 		
// 		
// 		NSUrlSessionDelegate Delegate { get; }
// 	
// 		
// 		NSUrlSessionConfiguration Configuration { get; }
//
// 		
// 		
// 		string SessionDescription { get; set; }
// 	
// 		
// 		void FinishTasksAndInvalidate ();
// 	
// 		
// 		void InvalidateAndCancel ();
// 	
// 		
// 		
// 		void Reset (Action completionHandler);
// 	
// 		
// 		
// 		void Flush (Action completionHandler);
// 	
// #if !XAMCORE_3_0
// 		// broken version that we must keep for XAMCORE_3_0 binary compatibility
// 		// but that we do not have to expose on tvOS and watchOS, forcing people to use the correct API
// 		
// 		
// 		
// 		void GetTasks (NSUrlSessionPendingTasks completionHandler);
// #elif NET
// 		// Fixed version (breaking change) only for NET
// 		
// 		
// 		void GetTasks (NSUrlSessionPendingTasks completionHandler);
// #endif
//
// #if !NETXXX
// 		// Workaround, not needed for NET+
// 		
// 		
// 		
// 		void GetTasks2 (NSUrlSessionPendingTasks2 completionHandler);
// #endif
//
// 		
// 		
// 		NSUrlSessionDataTask CreateDataTask (NSUrlRequest request);
// 	
// 		
// 		
// 		NSUrlSessionDataTask CreateDataTask (NSUrl url);
// 	
// 		
// 		
// 		NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSUrl fileURL);
// 	
// 		
// 		
// 		NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSData bodyData);
// 	
// 		
// 		
// 		NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request);
// 	
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTask (NSUrlRequest request);
// 	
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTask (NSUrl url);
// 	
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTask (NSData resumeData);
//
// 		
// 		
// 		
// 		NSUrlSessionDataTask CreateDataTask (NSUrlRequest request,  NSUrlSessionResponse completionHandler);
// 	
// 		
// 		
// 		
// 		NSUrlSessionDataTask CreateDataTask (NSUrl url,  NSUrlSessionResponse completionHandler);
// 	
// 		
// 		
// 		
// 		NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSUrl fileURL, NSUrlSessionResponse completionHandler);
// 	
// 		
// 		
// 		
// 		NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSData bodyData, NSUrlSessionResponse completionHandler);
// 	
// 		
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTask (NSUrlRequest request,  NSUrlDownloadSessionResponse completionHandler);
// 	
// 		
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTask (NSUrl url,  NSUrlDownloadSessionResponse completionHandler);
//
// 		
// 		
// 		
// 		NSUrlSessionDownloadTask CreateDownloadTaskFromResumeData (NSData resumeData,  NSUrlDownloadSessionResponse completionHandler);
//
//         
// 		
// 		
// 		
// 		void GetAllTasks (NSUrlSessionAllPendingTasks completionHandler);
//
// 		
// 		
// 		NSUrlSessionStreamTask CreateBidirectionalStream (string hostname, nint port);
//
// 		
// 		
// 		
// 		NSUrlSessionStreamTask CreateBidirectionalStream (NSNetService service);
//
// 		
// 		
// 		NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrl url);
//
// 		
// 		
// 		NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrl url, string protocols);
//
// 		
// 		
// 		NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrlRequest request);
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlSessionStreamDelegate
// 	{
// 		
// 		void ReadClosed (NSUrlSession session, NSUrlSessionStreamTask streamTask);
// 	
// 		
// 		void WriteClosed (NSUrlSession session, NSUrlSessionStreamTask streamTask);
// 	
// 		
// 		void BetterRouteDiscovered (NSUrlSession session, NSUrlSessionStreamTask streamTask);
// 	
// 		//
// 		// Note: the names of this methods do not exactly match the Objective-C name
// 		// because it was a bad name, and does not describe what this does, so the name
// 		// was picked from the documentation and what it does.
// 		//
// 		
// 		void CompletedTaskCaptureStreams (NSUrlSession session, NSUrlSessionStreamTask streamTask, NSInputStream inputStream, NSOutputStream outputStream);
// 	}
// 	
// 	delegate void NSUrlSessionDataRead (NSData data, bool atEof, NSError error);
// 	
// 	
// 	 // now (xcode11) marked as deprecated
// 	interface NSUrlSessionStreamTask
// 	{
// 		
// 		
// 		void ReadData (nuint minBytes, nuint maxBytes, double timeout, NSUrlSessionDataRead completionHandler);
// 	
// 		
// 		
// 		void WriteData (NSData data, double timeout, Action<NSError> completionHandler);
// 	
// 		
// 		void CaptureStreams ();
// 	
// 		
// 		void CloseWrite ();
// 	
// 		
// 		void CloseRead ();
// 	
// 		
// 		void StartSecureConnection ();
// 	
// 		
// 		
// 		
// 		
// 		
// 		void StopSecureConnection ();
// 	}
// 	
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionTask : NSCopying, NSProgressReporting
// 	{
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		nuint TaskIdentifier { get; }
// 	
// 		
// 		NSUrlRequest OriginalRequest { get; }
// 	
// 		
// 		NSUrlRequest CurrentRequest { get; }
// 	
// 		
// 		NSUrlResponse Response { get; }
// 	
// 		
// 		long BytesReceived { get; }
// 	
// 		
// 		long BytesSent { get; }
// 	
// 		
// 		long BytesExpectedToSend { get; }
// 	
// 		
// 		long BytesExpectedToReceive { get; }
// 	
// 		 // by default this property is null
// 		
// 		string TaskDescription { get; set; }
// 	
// 		
// 		void Cancel ();
// 	
// 		
// 		NSUrlSessionTaskState State { get; }
// 	
// 		
// 		NSError Error { get; }
// 	
// 		
// 		void Suspend ();
// 	
// 		
// 		void Resume ();
//
// 		
// 		long TransferSizeUnknown { get; }
//
// 		
// 		
// 		float Priority { get; set; } /* float, not CGFloat */
//
// 		
// 		
// 		bool PrefersIncrementalDelivery { get; set; }
//
// 		
// 		
// 		NSDate EarliestBeginDate { get; set; }
//
// 		
// 		
// 		long CountOfBytesClientExpectsToSend { get; set; }
//
// 		
// 		
// 		long CountOfBytesClientExpectsToReceive { get; set; }
//
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlSessionTaskPriority {
// 		
// 		float Default { get; } /* float, not CGFloat */
// 		
// 		
// 		float Low { get; } /* float, not CGFloat */
// 		
// 		
// 		float High { get; } /* float, not CGFloat */
// 	}
// 	
// 	// All of the NSUrlSession APIs are either 10.10, or 10.9 and 64-bit only
// 	// "NSURLSession is not available for i386 targets before Mac OS X 10.10."
//
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionDataTask {
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
// 	}
//
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionUploadTask {
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
// 	}
//
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionDownloadTask {
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		void Cancel (Action<NSData> resumeCallback);
// 	}
// 	
// 	
// 	
// 	
// 	interface ProxyConfigurationDictionaryKeys {
// 		
// 		NSString HttpEnableKey { get; }
//
// 		
// 		NSString HttpProxyHostKey { get; }
//
// 		
// 		NSString HttpProxyPortKey { get; }
//
// 		
// 		
// 		NSString HttpsEnableKey { get; }
//
// 		
// 		NSString HttpsProxyHostKey { get; }
//
// 		
// 		NSString HttpsProxyPortKey { get; }
// 	}
//
// 	
// 	
// 	interface ProxyConfigurationDictionary {
// 		bool HttpEnable { get; set; }
// 		string HttpProxyHost { get; set; }
// 		int HttpProxyPort { get; set;}
// 		
// 		bool HttpsEnable { get; set; }
// 		string HttpsProxyHost { get; set;}
// 		int HttpsProxyPort { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionConfiguration : NSCopying {
// 	
// 		
// 		
// 		NSUrlSessionConfiguration _DefaultSessionConfiguration { get; }
//
// 		
// 		
// 		NSUrlSessionConfiguration _EphemeralSessionConfiguration { get; }
// 	
// 		
// 		
// 		NSUrlSessionConfiguration _BackgroundSessionConfiguration (string identifier);
// 	
// 		
// 		string Identifier { get; }
// 	
// 		
// 		NSUrlRequestCachePolicy RequestCachePolicy { get; set; }
// 	
// 		
// 		double TimeoutIntervalForRequest { get; set; }
// 	
// 		
// 		double TimeoutIntervalForResource { get; set; }
// 	
// 		
// 		NSUrlRequestNetworkServiceType NetworkServiceType { get; set; }
// 	
// 		
// 		bool AllowsCellularAccess { get; set; }
// 	
// 		
// 		bool Discretionary {  get; set; }
// 	
// 		
// 		
// 		bool SessionSendsLaunchEvents { get; set; }
//
// 		
// 		
// 		NSDictionary ConnectionProxyDictionary { get; set; }
//
// 		
// 		ProxyConfigurationDictionary StrongConnectionProxyDictionary {
// 			
// 			get;
// 			
// 			set;
// 		}
// 	
// 		
// 		
// 		
// 		
// 		
// 		SslProtocol TLSMinimumSupportedProtocol { get; set; }
// 	
// 		
// 		
// 		TlsProtocolVersion TlsMinimumSupportedProtocolVersion { get; set; }
//
// 		
// 		
// 		
// 		
// 		
// 		SslProtocol TLSMaximumSupportedProtocol { get; set; }
//
// 		
// 		
// 		TlsProtocolVersion TlsMaximumSupportedProtocolVersion { get; set; }
//
// 		
// 		bool HttpShouldUsePipelining { get; set; }
// 	
// 		
// 		bool HttpShouldSetCookies { get; set; }
// 	
// 		
// 		NSHttpCookieAcceptPolicy HttpCookieAcceptPolicy { get; set; }
// 	
// 		
// 		
// 		NSDictionary HttpAdditionalHeaders { get; set; }
// 	
// 		
// 		nint HttpMaximumConnectionsPerHost { get; set; }
// 	
// 		
// 		
// 		NSHttpCookieStorage HttpCookieStorage { get; set; }
// 	
// 		
// 		
// 		NSUrlCredentialStorage URLCredentialStorage { get; set; }
//
// 		
// 		
// 		NSUrlCache URLCache { get; set; }
// 	
// 		
// 		
// 		NSArray WeakProtocolClasses { get; set; }
//
// 		
// 		
// 		
// 		string SharedContainerIdentifier { get; set; }
//
// 		
// 		
// 		
// 		NSUrlSessionConfiguration _CreateBackgroundSessionConfiguration (string identifier);
//
// 		
// 		
// 		bool ShouldUseExtendedBackgroundIdleMode { get; set; }
//
// 		
// 		
// 		NSUrlSessionMultipathServiceType MultipathServiceType { get; set; }
//
// 		
// 		
// 		bool WaitsForConnectivity { get; set; }
//
// 		
// 		
// 		bool AllowsExpensiveNetworkAccess { get; set; }
//
// 		
// 		
// 		bool AllowsConstrainedNetworkAccess { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionDelegate {
// 		
// 		void DidBecomeInvalid (NSUrlSession session, NSError error);
// 	
// 		
// 		void DidReceiveChallenge (NSUrlSession session, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition,NSUrlCredential> completionHandler);
// 	
// 		
// 		
// 		void DidFinishEventsForBackgroundSession (NSUrlSession session);
// 	}
//
// 	
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionTaskDelegate {
// 	
// 		
// 		void WillPerformHttpRedirection (NSUrlSession session, NSUrlSessionTask task, NSHttpUrlResponse response, NSUrlRequest newRequest, Action<NSUrlRequest> completionHandler);
// 	
// 		
// 		void DidReceiveChallenge (NSUrlSession session, NSUrlSessionTask task, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition,NSUrlCredential> completionHandler);
// 	
// 		
// 		void NeedNewBodyStream (NSUrlSession session, NSUrlSessionTask task, Action<NSInputStream> completionHandler);
// 	
// 		
// 		void DidSendBodyData (NSUrlSession session, NSUrlSessionTask task, long bytesSent, long totalBytesSent, long totalBytesExpectedToSend);
// 	
// 		
// 		void DidCompleteWithError (NSUrlSession session, NSUrlSessionTask task,  NSError error);
//
// 		
// 		
// 		void DidFinishCollectingMetrics (NSUrlSession session, NSUrlSessionTask task, NSUrlSessionTaskMetrics metrics);
//
// 		
// 		
// 		void WillBeginDelayedRequest (NSUrlSession session, NSUrlSessionTask task, NSUrlRequest request, Action<NSUrlSessionDelayedRequestDisposition, NSUrlRequest> completionHandler);
//
// 		
// 		
// 		void TaskIsWaitingForConnectivity (NSUrlSession session, NSUrlSessionTask task);
// 	}
// 	
// 	
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionDataDelegate {
// 		
// 		void DidReceiveResponse (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlResponse response, Action<NSUrlSessionResponseDisposition> completionHandler);
// 	
// 		
// 		void DidBecomeDownloadTask (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlSessionDownloadTask downloadTask);
// 	
// 		
// 		void DidReceiveData (NSUrlSession session, NSUrlSessionDataTask dataTask, NSData data);
// 	
// 		
// 		void WillCacheResponse (NSUrlSession session, NSUrlSessionDataTask dataTask, NSCachedUrlResponse proposedResponse, Action<NSCachedUrlResponse> completionHandler);
//
// 		
// 		
// 		void DidBecomeStreamTask (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlSessionStreamTask streamTask);
// 	}
// 	
// 	
// 	
// 	
// 	
// 	
// 	partial interface NSUrlSessionDownloadDelegate {
// 	
// 		
// 		
// 		void DidFinishDownloading (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, NSUrl location);
// 	
// 		
// 		void DidWriteData (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long bytesWritten, long totalBytesWritten, long totalBytesExpectedToWrite);
// 	
// 		
// 		void DidResume (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long resumeFileOffset, long expectedTotalBytes);
// 	
// 		
// 		NSString TaskResumeDataKey { get; }
// 	}
//
// 	interface NSUndoManagerCloseUndoGroupEventArgs {
// 		// Bug in docs, see header file
// 		
// 		
// 		bool Discardable { get; }
// 	}
// 	
// 	
// 	interface NSUndoManager {
// 		
// 		void BeginUndoGrouping ();
// 		
// 		
// 		void EndUndoGrouping ();
// 		
// 		
// 		nint GroupingLevel { get; }
// 		
// 		
// 		void DisableUndoRegistration ();
//
// 		
// 		void EnableUndoRegistration ();
//
// 		
// 		bool IsUndoRegistrationEnabled { get; }
// 		
// 		
// 		bool GroupsByEvent { get; set; }
// 		
// 		
// 		nint LevelsOfUndo { get; set; }
// 		
// #if NETXXX
// 		
// 		NSString  WeakRunLoopModes { get; set; }
// #else
// 		
// 		string  RunLoopModes { get; set; } 
// #endif
// 		
// 		
// 		void Undo ();
// 		
// 		
// 		void Redo ();
// 		
// 		
// 		void UndoNestedGroup ();
// 		
// 		
// 		bool CanUndo { get; }
// 		
// 		
// 		bool CanRedo { get; }
//
// 		
// 		bool IsUndoing { get; }
//
// 		
// 		bool IsRedoing { get; }
//
// 		
// 		void RemoveAllActions ();
//
// 		
// 		void RemoveAllActions (NSObject target);
//
// 		
// 		void RegisterUndoWithTarget (NSObject target, Selector selector,  NSObject anObject);
//
// 		
// 		NSObject PrepareWithInvocationTarget (NSObject target);
//
// 		
// 		string UndoActionName { get; }
//
// 		
// 		string RedoActionName { get; }
//
// #if NETXXX
// 		
// 		void SetActionName (string actionName);
// #else
// 		
// 		
// 		void SetActionname (string actionName); 
// #endif
//
// 		
// 		string UndoMenuItemTitle { get; }
//
// 		
// 		string RedoMenuItemTitle { get; }
//
// 		
// 		string UndoMenuTitleForUndoActionName (string name);
//
// 		
// 		string RedoMenuTitleForUndoActionName (string name);
//
// 		
// 		
// 		NSString CheckpointNotification { get; }
//
// 		
// 		
// 		NSString DidOpenUndoGroupNotification { get; }
//
// 		
// 		
// 		NSString DidRedoChangeNotification { get; }
//
// 		
// 		
// 		NSString DidUndoChangeNotification { get; }
//
// 		
// 		
// 		NSString WillCloseUndoGroupNotification { get; }
//
// 		
// 		
// 		NSString WillRedoChangeNotification { get; }
//
// 		
// 		
// 		NSString WillUndoChangeNotification { get; }
//
// 		
// 		void SetActionIsDiscardable (bool discardable);
//
// 		
// 		bool UndoActionIsDiscardable { get; }
//
// 		
// 		bool RedoActionIsDiscardable { get; }
//
// 		
// 		NSString GroupIsDiscardableKey { get; }
//
// 		
// 		
// 		NSString DidCloseUndoGroupNotification { get; }
//
// 	    
// 		
// 		void RegisterUndo (NSObject target, Action<NSObject> undoHandler);
//
// 	}
// 	
// 	
// 	// 'init' returns NIL
// 	
// 	interface NSUrlProtectionSpace : NSSecureCoding, NSCopying {
// 		
// 		
// 		
// 		IntPtr Init (string host, nint port,  string protocol,  string realm,  string authenticationMethod);
// 	
// 		
// 		
// 		IntPtr InitWithProxy (string host, nint port,  string type,  string realm,  string authenticationMethod);
// 	
// 		
// 		string Realm { get; }
// 	
// 		
// 		bool ReceivesCredentialSecurely { get; }
// 	
// 		
// 		bool IsProxy { get; }
// 	
// 		
// 		string Host { get; }
// 	
// 		
// 		nint  Port { get; }
// 	
// 		
// 		string ProxyType { get; }
// 	
// 		
// 		string Protocol { get; }
// 	
// 		
// 		string AuthenticationMethod { get; }
//
// 		// NSURLProtectionSpace(NSClientCertificateSpace)
//
// 		
// 		NSData  DistinguishedNames { get; }
// 		
// 		// NSURLProtectionSpace(NSServerTrustValidationSpace)
// 		
// 		
// 		IntPtr ServerTrust { get ; }
//
// 		
// 		NSString HTTP { get; }
//
// 		
// 		NSString HTTPS { get; }
//
// 		
// 		NSString FTP { get; }
//
// 		
// 		NSString HTTPProxy { get; }
//
// 		
// 		NSString HTTPSProxy { get; }
//
// 		
// 		NSString FTPProxy { get; }
//
// 		
// 		NSString SOCKSProxy { get; }
//
// 		
// 		NSString AuthenticationMethodDefault { get; }
//
// 		
// 		NSString AuthenticationMethodHTTPBasic { get; }
//
// 		
// 		NSString AuthenticationMethodHTTPDigest { get; }
//
// 		
// 		NSString AuthenticationMethodHTMLForm { get; }
//
// 		
// 		NSString AuthenticationMethodNTLM { get; }
//
// 		
// 		NSString AuthenticationMethodNegotiate { get; }
//
// 		
// 		NSString AuthenticationMethodClientCertificate { get; }
//
// 		
// 		NSString AuthenticationMethodServerTrust { get; }
// 	}
// 	
// 	
// 	interface NSUrlRequest : NSSecureCoding, NSMutableCopying {
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, NSUrlRequestCachePolicy cachePolicy, double timeoutInterval);
//
// 		
// 		NSUrlRequest FromUrl (NSUrl url);
//
// 		
// 		NSUrl Url { get; }
//
// 		
// 		NSUrlRequestCachePolicy CachePolicy { get; }
//
// 		
// 		double TimeoutInterval { get; }
//
// 		
// 		NSUrl MainDocumentURL { get; }
//
// 		
// 		NSUrlRequestNetworkServiceType NetworkServiceType { get; }
//
// 		
// 		bool AllowsCellularAccess { get; }
//
// 		
// 		
// 		bool AllowsExpensiveNetworkAccess { get;  set; }
//
// 		
// 		
// 		bool AllowsConstrainedNetworkAccess { get;  set; }
// 		
// 		
// 		string HttpMethod { get; }
//
// 		
// 		NSDictionary Headers { get; }
//
// 		
// 		string Header (string field);
//
// 		
// 		NSData Body { get; }
//
// 		
// 		NSInputStream BodyStream { get; }
//
// 		
// 		bool ShouldHandleCookies { get; }
//
// 		
// 		
// 		
// 		bool AssumesHttp3Capable { get;  set; }
// 	}
//
// 	
// 	
// 	interface NSMutableDictionary {
// 		
// 		
// 		NSMutableDictionary FromFile (string path);
//
// 		
// 		
// 		NSMutableDictionary FromUrl (NSUrl url);
//
// 		
// 		
// 		NSMutableDictionary FromObjectAndKey (NSObject obj, NSObject key);
//
// 		
// 		
// 		NSMutableDictionary FromDictionary (NSDictionary source);
//
// 		
// 		
// 		NSMutableDictionary FromObjectsAndKeysInternalCount (NSArray objects, NSArray keys, nint count);
//
// 		
// 		
// 		NSMutableDictionary FromObjectsAndKeysInternal (NSArray objects, NSArray Keys);
// 		
// 		
// 		NativeHandle Constructor (NSDictionary other);
//
// 		
// 		NativeHandle Constructor (NSDictionary other, bool copyItems);
//
// 		
// 		NativeHandle Constructor (string fileName);
//
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		
// 		NativeHandle Constructor (NSArray objects, NSArray keys);
//
// 		
// 		void RemoveAllObjects ();
//
// 		
// 		
// 		
// 		void _RemoveObjectForKey (IntPtr key);
//
// 		
// 		void RemoveObjectForKey (NSObject key);
//
// 		
// 		
// 		
// 		void _SetObject (IntPtr obj, IntPtr key);
//
// 		
// 		void SetObject (NSObject obj, NSObject key);
//
// 		
// 		
// 		NSDictionary FromSharedKeySet (NSObject sharedKeyToken);
//
// 		
// 		void AddEntries (NSDictionary other);
// 	}
//
// 	interface NSMutableDictionary<K,V> : NSDictionary {}
//
// 	
// 	
// 	interface NSMutableSet {
// 		
// 		NativeHandle Constructor (NSArray other);
//
// 		
// 		NativeHandle Constructor (NSSet other);
// 		
// 		
// 		
// 		NativeHandle Constructor (nint capacity);
//
// 		
// 		
// 		
// 		void _Add (IntPtr obj);
//
// 		
// 		void Add (NSObject nso);
//
// 		
// 		
// 		
// 		void _Remove (IntPtr nso);
//
// 		
// 		void Remove (NSObject nso);
//
// 		
// 		void RemoveAll ();
//
// 		
// 		
// 		
// 		void _AddObjects (IntPtr objects);
//
// 		
// 		void AddObjects (NSObject  objects);
//
// 		
// 		void MinusSet (NSSet other);
//
// 		
// 		void UnionSet (NSSet other);
// 	}
// 	
// 	
// 	interface NSMutableUrlRequest {
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		NativeHandle Constructor (NSUrl url, NSUrlRequestCachePolicy cachePolicy, double timeoutInterval);
//
// 		 // by default this property is null
// 		
// 		NSUrl Url { get; set; }
//
// 		
// 		NSUrlRequestCachePolicy CachePolicy { get; set; }
//
// 		
// 		double TimeoutInterval { set; get; }
//
// 		 // by default this property is null
// 		
// 		NSUrl MainDocumentURL { get; set; }
//
// 		
// 		string HttpMethod { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary Headers { get; set; }
//
// 		
// 		void _SetValue (string value, string field);
//
// 		 // by default this property is null
// 		
// 		NSData Body { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSInputStream BodyStream { get; set; }
//
// 		
// 		bool ShouldHandleCookies { get; set; }
//
// 		
// 		NSUrlRequestNetworkServiceType NetworkServiceType { set; get; }
//
// 		 
// 		bool AllowsCellularAccess { get; set; }
//
// 		
// 		
// 		bool AllowsExpensiveNetworkAccess { get; set; }
//
// 		
// 		
// 		bool AllowsConstrainedNetworkAccess { get; set; }
//
// 		
// 		
// 		
// 		bool AssumesHttp3Capable { get; set; }
// 	}
// 	
// 	
// 	interface NSUrlResponse : NSSecureCoding, NSCopying {
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, string mimetype, nint expectedContentLength,  string textEncodingName);
//
// 		
// 		NSUrl Url { get; }
//
// 		
// 		string MimeType { get; }
//
// 		
// 		long ExpectedContentLength { get; }
//
// 		
// 		string TextEncodingName { get; }
//
// 		
// 		string SuggestedFilename { get; }
// 	}
//
// 	 { "WeakDelegate" }, Events=new Type  { typeof (NSStreamDelegate)} )]
// 	interface NSStream {
// 		
// 		void Open ();
//
// 		
// 		void Close ();
// 	
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSStreamDelegate Delegate { get; set; }
//
// #if NETXXX
// 		
// #endif
// 		
// 		
// 		
// 		NSObject GetProperty (NSString key);
// 	
// #if NETXXX
// 		
// #endif
// 		
// 		
// 		bool SetProperty ( NSObject property, NSString key);
// 	
// #if NETXXX
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSString mode);
//
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSString mode);
// #else
// 		
// 		void Schedule (NSRunLoop aRunLoop, string mode);
// 	
// 		
// 		void Unschedule (NSRunLoop aRunLoop, string mode);
// #endif
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSRunLoopMode mode);
//
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode mode);
//
// 		
// 		NSStreamStatus Status { get; }
// 	
// 		
// 		NSError Error { get; }
//
// 		
// 		NSString SocketSecurityLevelKey { get; }
//
// 		
// 		NSString SocketSecurityLevelNone { get; }
//
// 		
// 		NSString SocketSecurityLevelSslV2 { get; }
//
// 		
// 		NSString SocketSecurityLevelSslV3 { get; }
//
// 		
// 		NSString SocketSecurityLevelTlsV1 { get; }
//
// 		
// 		NSString SocketSecurityLevelNegotiatedSsl { get; }
//
// 		
// 		NSString SocksProxyConfigurationKey { get; }
//
// 		
// 		NSString SocksProxyHostKey { get; }
//
// 		
// 		NSString SocksProxyPortKey { get; }
//
// 		
// 		NSString SocksProxyVersionKey { get; }
//
// 		
// 		NSString SocksProxyUserKey { get; }
//
// 		
// 		NSString SocksProxyPasswordKey { get; }
//
// 		
// 		NSString SocksProxyVersion4 { get; }
//
// 		
// 		NSString SocksProxyVersion5 { get; }
//
// 		
// 		NSString DataWrittenToMemoryStreamKey { get; }
//
// 		
// 		NSString FileCurrentOffsetKey { get; }
//
// 		
// 		NSString SocketSslErrorDomain { get; }
//
// 		
// 		NSString SocksErrorDomain { get; }
//
// 		
// 		NSString NetworkServiceType { get; }
//
// 		
// 		NSString NetworkServiceTypeVoIP { get; }
//
// 		
// 		NSString NetworkServiceTypeVideo { get; }
//
// 		
// 		NSString NetworkServiceTypeBackground { get; }
//
// 		
// 		NSString NetworkServiceTypeVoice { get; }
//
// 		
// 		
// 		
// 		NSString NetworkServiceTypeCallSignaling { get; }
//
// 		
// 		
// 		void GetBoundStreams (nuint bufferSize, out NSInputStream inputStream, out NSOutputStream outputStream);
//
// 		
// 		
// 		
// 		void GetStreamsToHost (string hostname, nint port, out NSInputStream inputStream, out NSOutputStream outputStream);		
// 	}
//
// 	
// 	
// 	
// 	interface NSStreamDelegate {
// 		
// 		void HandleEvent (NSStream theStream, NSStreamEvent streamEvent);
// 	}
//
// 	
// 	
// 	interface NSString2 : NSSecureCoding, NSMutableCopying, CKRecordValue
// 	#if MONOMAC
// 		, NSPasteboardReading, NSPasteboardWriting // Documented that it implements NSPasteboard protocols even if header doesn't show it
// 	#endif
// 		, NSItemProviderReading, NSItemProviderWriting
// 	{
// 		
// 		NativeHandle Constructor (NSData data, NSStringEncoding encoding);
//
// 		
// 		
// 		CGSize StringSize ( NSDictionary attributedStringAttributes);
// 		
// 		
// 		
// 		CGRect BoundingRectWithSize (CGSize size, NSStringDrawingOptions options, NSDictionary attributes);
// 		
// 		
// 		
// 		void DrawString (CGPoint point, NSDictionary attributes);
// 		
// 		
// 		
// 		void DrawString (CGRect rect, NSDictionary attributes);
// 		
// 		
// 		
// 		void DrawString (CGRect rect, NSStringDrawingOptions options, NSDictionary attributes);
//
// 		
// 		
// 		char _characterAtIndex (nint index);
//
// 		
// 		nint Length {get;}
//
// 		
// 		
// 		bool IsEqualTo (IntPtr handle);
// 		
// 		
// 		NSComparisonResult Compare (NSString aString);
//
// 		
// 		NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask);
//
// 		
// 		NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask, NSRange range);
//
// 		
// 		NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask, NSRange range,  NSLocale locale);
// 		
// 		
// 		NSString Replace (NSRange range, NSString replacement);
//
// 		
// 		NSString CommonPrefix (NSString aString, NSStringCompareOptions options);
// 		
// 		// start methods from NSStringPathExtensions category
//
// 		
// 		
// 		string PathWithComponents( string components );
//
// 		
// 		string PathComponents { get; }
//
// 		
// 		bool IsAbsolutePath { get; }
//
// 		
// 		NSString LastPathComponent { get; }
//
// 		
// 		NSString DeleteLastPathComponent();
//  
//  		
//  		NSString AppendPathComponent( NSString str );
//
//  		
//  		NSString PathExtension { get; }
//
//  		
//  		NSString DeletePathExtension();
//
//  		
//  		NSString AppendPathExtension( NSString str );
//  
//  		
//  		NSString AbbreviateTildeInPath();
//
//  		
//  		NSString ExpandTildeInPath();
//  
//  		
//  		NSString StandarizePath();
//
//  		
//  		NSString ResolveSymlinksInPath();
//
// 		
//  		string AppendPaths( string paths );
//
// 		// end methods from NSStringPathExtensions category
//
// 		
// 		string Capitalize ( NSLocale locale);
// 		
// 		
// 		string ToLower (NSLocale locale);
// 		
// 		
// 		string ToUpper (NSLocale locale);
//
// 		
// 		
// 		bool Contains (NSString str);
//
// 		
// 		
// 		bool LocalizedCaseInsensitiveContains (NSString str);
//
// 		
// 		
// 		
// 		nuint DetectStringEncoding (NSData rawData, NSDictionary options, out string convertedString, out bool usedLossyConversion);
//
// 		
// 		
// 		nuint DetectStringEncoding (NSData rawData, EncodingDetectionOptions options, out string convertedString, out bool usedLossyConversion);
//
// 		
// 		
// 		NSString EncodingDetectionSuggestedEncodingsKey { get; }
//
// 		
// 		
// 		NSString EncodingDetectionDisallowedEncodingsKey { get; }
// 		
// 		
// 		
// 		NSString EncodingDetectionUseOnlySuggestedEncodingsKey { get; }
// 		
// 		
// 		
// 		NSString EncodingDetectionAllowLossyKey { get; }
//
// 		
// 		
// 		NSString EncodingDetectionFromWindowsKey { get; }
//
// 		
// 		
// 		NSString EncodingDetectionLossySubstitutionKey { get; }
//
// 		
// 		
// 		NSString EncodingDetectionLikelyLanguageKey { get; }
//
// 		
// 		NSRange LineRangeForRange (NSRange range);
//
// 		
// 		void GetLineStart (out nuint startPtr, out nuint lineEndPtr, out nuint contentsEndPtr, NSRange range);
//
// 		
// 		
// 		NSString GetVariantFittingPresentationWidth (nint width);
//
// 		
// 		
// 		bool LocalizedStandardContainsString (NSString str);
//
// 		
// 		
// 		NSRange LocalizedStandardRangeOfString (NSString str);
//
// 		
// 		
// 		NSString LocalizedUppercaseString { get; }
//
// 		
// 		
// 		NSString LocalizedLowercaseString { get; }
//
// 		
// 		
// 		NSString LocalizedCapitalizedString { get; }
//
// 		
// 		
// 		
// 		NSString TransliterateString (NSString transform, bool reverse);
//
// 		
// 		bool HasPrefix (NSString prefix);
//
// 		
// 		bool HasSuffix (NSString suffix);
//
// 		// UNUserNotificationCenterSupport category
// 		
// 		
// 		
// 		NSString GetLocalizedUserNotificationString (NSString key,   NSObject  arguments);
//
// 		
// 		void GetParagraphPositions (out nuint paragraphStartPosition, out nuint paragraphEndPosition, out nuint contentsEndPosition, NSRange range);
//
// 		
// 		NSRange GetParagraphRange (NSRange range);
//
// 		
// 		NSString SeparateComponents (NSString separator);
//
// 		
// 		NSString SeparateComponents (NSCharacterSet separator);
//
// 		// From the NSItemProviderReading protocol
//
// 		
// 		
// 		
// 		new string ReadableTypeIdentifiers { get; }
//
// 		
// 		
// 		
// 		
// 		new NSString GetObject (NSData data, string typeIdentifier,  out NSError outError);
//
// 		// From the NSItemProviderWriting protocol
// 		
// 		
// 		
// 		new string WritableTypeIdentifiers { get; }
// 	}
//
// 	
// 	interface EncodingDetectionOptions {
// 		NSStringEncoding  EncodingDetectionSuggestedEncodings { get; set; }
// 		NSStringEncoding  EncodingDetectionDisallowedEncodings { get; set; }
// 		bool EncodingDetectionUseOnlySuggestedEncodings { get; set; }
// 		bool EncodingDetectionAllowLossy { get; set; }
// 		bool EncodingDetectionFromWindows { get; set; }
// 		NSString EncodingDetectionLossySubstitution { get; set; }
// 		NSString EncodingDetectionLikelyLanguage { get; set; }
// 	}
//
// 	
// 	// hack: it seems that generator.cs can't track NSCoding correctly ? maybe because the type is named NSString2 at that time
// 	interface NSMutableString : NSCoding {
// 		
// 		NativeHandle Constructor (nint capacity);
//
// 		
// 		
// 		void Insert (NSString str, nint index);
//
// 		
// 		
// 		void DeleteCharacters (NSRange range);
//
// 		
// 		void Append (NSString str);
//
// 		
// 		void SetString (NSString str);
//
// 		
// 		
// 		nuint ReplaceOcurrences (NSString target, NSString replacement, NSStringCompareOptions options, NSRange range);
//
// 		
// 		
// 		
// 		bool ApplyTransform (NSString transform, bool reverse, NSRange range, out NSRange resultingRange);
//
// 		
// 		
// 		bool ApplyTransform (NSStringTransform transform, bool reverse, NSRange range, out NSRange resultingRange);
//
// 		
// 		void ReplaceCharactersInRange (NSRange range, NSString aString);
// 	}
// 	
// 	
// 	partial interface NSUrlUtilities_NSString {
// 		
// 		
// 		NSString CreateStringByAddingPercentEncoding (NSCharacterSet allowedCharacters);
// 	
// 		
// 		
// 		NSString CreateStringByRemovingPercentEncoding ();
// 	
// 		
// 		NSString CreateStringByAddingPercentEscapes (NSStringEncoding enc);
// 	
// 		
// 		NSString CreateStringByReplacingPercentEscapes (NSStringEncoding enc);
// 	}
//
// 	// This comes from UIKit.framework/Headers/NSStringDrawing.h
// 	
// 	
// 	interface NSStringDrawingContext {
// 		
// 		nfloat MinimumScaleFactor { get; set;  }
//
// 		
// 		
// 		
// 		
// 		nfloat MinimumTrackingAdjustment { get; set;  }
//
// 		
// 		nfloat ActualScaleFactor { get;  }
//
// 		
// 		
// 		
// 		nfloat ActualTrackingAdjustment { get;  }
//
// 		
// 		CGRect TotalBounds { get;  }
// 	}
//
// 	
// 	
// 	interface NSInputStream {
// 		
// 		bool HasBytesAvailable ();
// 	
// 		
// 		NativeHandle Constructor (string path);
//
// 		
// 		
// 		NativeHandle Constructor (NSData data);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl url);
//
// 		
// 		
// 		NSInputStream FromData (NSData data);
// 	
// 		
// 		
// 		NSInputStream FromFile (string  path);
//
// 		
// 		
// 		NSInputStream FromUrl (NSUrl url);
//
// #if NETXXX
// 		
// 		
// 		
// 		NSObject GetProperty (NSString key);
//
// 		
// 		
// 		bool SetProperty ( NSObject property, NSString key);
//
// #endif
//
// 	}
//
// 	delegate bool NSEnumerateLinguisticTagsEnumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop);
//
// 	
// 	
// 	interface NSLinguisticAnalysis {
// #if NETXXX
// 		))]
// #else
// 		))]
// #endif
// 		
// 		
// 		NSString GetLinguisticTags (NSRange range, NSString scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography,  out NSValue tokenRanges);
//
// 		
// #if NETXXX
// 		NSLinguisticTag GetLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography,  out NSValue tokenRanges);
// #else
// 		NSLinguisticTagUnit GetLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography,  out NSValue tokenRanges);
// #endif
//
// 		
// 		
// 		void EnumerateLinguisticTags (NSRange range, NSString scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography, NSEnumerateLinguisticTagsEnumerator handler);
//
// 		
// 		void EnumerateLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options,  NSOrthography orthography, NSEnumerateLinguisticTagsEnumerator handler);
// 	}
//
// 	//
// 	// We expose NSString versions of these methods because it could
// 	// avoid an extra lookup in cases where there is a large volume of
// 	// calls being made and the keys are mostly tokens
// 	//
// 	
// 	interface NSObject2 : NSObjectProtocol {
//
// 		// those are to please the compiler while creating the definition .dll
// 		// but, for the final binary, we'll be using manually bounds alternatives
// 		// not the generated code
// #pragma warning disable 108
// 		
// 		
// 		bool ConformsToProtocol (NativeHandle /* Protocol */ aProtocol);
//
// 		
// 		
// 		NSObject DangerousRetain ();
//
// 		
// 		
// 		void DangerousRelease ();
//
// 		
// 		
// 		NSObject DangerousAutorelease ();
// #pragma warning restore 108
//
// 		
// 		void DoesNotRecognizeSelector (Selector sel);
//
// 		
// 		void ObserveValue (NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context);
//
// 		
// 		void AddObserver (NSObject observer, NSString keyPath, NSKeyValueObservingOptions options, IntPtr context);
//
// 		
// 		void AddObserver (NSObject observer, string keyPath, NSKeyValueObservingOptions options, IntPtr context);
// 		
// 		
// 		void RemoveObserver (NSObject observer, NSString keyPath, IntPtr context);
//
// 		
// 		void RemoveObserver (NSObject observer, string keyPath, IntPtr context);
// 		
// 		
// 		void RemoveObserver (NSObject observer, NSString keyPath);
//
// 		
// 		void RemoveObserver (NSObject observer, string keyPath);
//
// 		
// 		void WillChangeValue (string forKey);
//
// 		
// 		void DidChangeValue (string forKey);
//
// 		
// 		void WillChange (NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey);
//
// 		
// 		void DidChange (NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey);
//
// 		
// 		void WillChange (NSString forKey, NSKeyValueSetMutationKind mutationKind, NSSet objects);
//
// 		
// 		void DidChange (NSString forKey, NSKeyValueSetMutationKind mutationKind, NSSet objects);
//
// 		
// 		NSSet GetKeyPathsForValuesAffecting (NSString key);
//
// 		
// 		bool AutomaticallyNotifiesObserversForKey (string key);
//
// 		
// 		
// 		NSObject ValueForKey (NSString key);
//
// 		
// 		void SetValueForKey (NSObject value, NSString key);
//
// 		
// 		NSObject ValueForKeyPath (NSString keyPath);
//
// 		
// 		void SetValueForKeyPath (NSObject value, NSString keyPath);
//
// 		
// 		NSObject ValueForUndefinedKey (NSString key);
//
// 		
// 		void SetValueForUndefinedKey (NSObject value, NSString undefinedKey);
//
// 		
// 		void SetNilValueForKey (NSString key);
//
// 		
// 		NSDictionary GetDictionaryOfValuesFromKeys (NSString  keys);
//
// 		
// 		void SetValuesForKeysWithDictionary (NSDictionary keyedValues);
// 		
// 		
// 		NSString ChangeKindKey { get; }
//
// 		
// 		NSString ChangeNewKey { get; }
//
// 		
// 		NSString ChangeOldKey { get; }
//
// 		
// 		NSString ChangeIndexesKey { get; }
//
// 		
// 		NSString ChangeNotificationIsPriorKey { get; }
//
// 		// Cocoa Bindings added by Kenneth J. Pouncey 2010/11/17
// #if !NETXXX
// 		
// #endif
// 		
// 		
// 		Class GetBindingValueClass (NSString binding);
//
// #if !NETXXX
// 		
// 		 NSDictionary options)' instead.")]
// 		
// 		void Bind (string binding, NSObject observable, string keyPath,  NSDictionary options);
//
// 		
// 		
// 		
// 		void Unbind (string binding);
//
// 		
// 		
// 		
// 		Class BindingValueClass (string binding);
//
// 		
// 		
// 		
// 		NSDictionary BindingInfo (string binding);
//
// 		
// 		
// 		
// 		NSObject BindingOptionDescriptions (string aBinding);
//
// 		
// 		
// 		
// 		NSObject GetDefaultPlaceholder (NSObject marker, string binding);
//
// 		
// 		
// 		
// 		
// 		void SetDefaultPlaceholder (NSObject placeholder, NSObject marker, string binding);
//
// 		
// 		
// 		NSString ExposedBindings ();
// #else
// 		
// 		
// 		NSString ExposedBindings { get; }
// #endif
//
// #if !NETXXX
// 		
// #endif
// 		
// 		
// 		void Bind (NSString binding, NSObject observable, string keyPath,  NSDictionary options);
//
// #if !NETXXX
// 		
// #endif
// 		
// 		
// 		void Unbind (NSString binding);
//
// #if !NETXXX
// 		
// #endif
// 		
// 		
// 		NSDictionary GetBindingInfo (NSString binding);
//
// #if !NETXXX
// 		
// #endif
// 		
// 		
// 		NSObject GetBindingOptionDescriptions (NSString aBinding);
//
// 		// NSPlaceholders (informal) protocol
// 		
// 		
// 		
// 		
// 		NSObject GetDefaultPlaceholder (NSObject marker, NSString binding);
//
// 		
// 		
// 		
// 		
// 		void SetDefaultPlaceholder (NSObject placeholder, NSObject marker, NSString binding);
//
// 		
// 		
// 		
// 		void ObjectDidEndEditing (NSObject editor);
//
// 		
// 		
// 		
// 		bool CommitEditing ();
//
// 		
// 		
// 		
// 		void CommitEditing (NSObject objDelegate, Selector didCommitSelector, IntPtr contextInfo);
//
// 		
// 		IntPtr GetMethodForSelector (Selector sel);
//
// 		
// 		
// 		
// 		NSObject Copy ();
//
// 		
// 		
// 		
// 		NSObject MutableCopy ();
//
// 		//
// 		// Extra Perform methods, with selectors
// 		//
// 		
// 		void PerformSelector (Selector selector,  NSObject withObject, double afterDelay, NSString  nsRunLoopModes);
//
// 		
// 		void PerformSelector (Selector selector,  NSObject withObject, double delay);
// 		
// 		
// 		void PerformSelector (Selector selector, NSThread onThread,  NSObject withObject, bool waitUntilDone);
// 		
// 		
// 		void PerformSelector (Selector selector, NSThread onThread,  NSObject withObject, bool waitUntilDone,  NSString  nsRunLoopModes);
// 		
// 		
// 		void CancelPreviousPerformRequest (NSObject aTarget);
//
// 		
// 		void CancelPreviousPerformRequest (NSObject aTarget, Selector selector,  NSObject argument);
//
// 		
// 		
// 		
// 		void PrepareForInterfaceBuilder ();
//
// 		
// #if MONOMAC
// 		// comes from NSNibAwaking category and does not requires calling super
// #else
// 		 // comes from UINibLoadingAdditions category - which is decorated
// #endif
// 		
// 		void AwakeFromNib ();
//
// 		
// 		
// 		bool AccessibilityRespondsToUserInteraction { get; set; }
//
// 		
// 		
// 		string  AccessibilityUserInputLabels { get; set; }
//
// 		
// 		
// 		NSAttributedString AccessibilityAttributedUserInputLabels { get; set; }
//
// 		
// 		
// 		string AccessibilityTextualContext { get; set; }
// 	}
//
// 	
// 	
// 	
// 	interface NSBindingSelectionMarker : NSCopying {
// 		
// 		
// 		NSBindingSelectionMarker MultipleValuesSelectionMarker { get; }
//
// 		
// 		
// 		NSBindingSelectionMarker NoSelectionMarker { get; }
//
// 		
// 		
// 		NSBindingSelectionMarker NotApplicableSelectionMarker { get; }
//
// 		
// 		
// 		
// 		void SetDefaultPlaceholder ( NSObject placeholder,  NSBindingSelectionMarker marker, Class objectClass, string binding);
//
// 		
// 		
// 		
// 		
// 		NSObject GetDefaultPlaceholder ( NSBindingSelectionMarker marker, Class objectClass, string binding);
// 	}
//
// 	 // exists both as a type and a protocol in ObjC, Swift uses NSObjectProtocol
// 	interface NSObjectProtocol {
//
// 		
// 		
// 		string Description { get; }
//
// 		
// 		string DebugDescription { get; }
//
// 		
// 		
// 		
// 		Class Superclass { get; }
//
// 		// defined multiple times (method, property and even static), one (not static) is required
// 		// and that match Apple's documentation
// 		
// 		
// 		
// 		nuint GetNativeHash ();
//
// 		
// 		
// 		
// 		bool IsEqual ( NSObject anObject);
//
// 		
// 		
// 		
// 		Class Class { get; }
//
// 		
// 		
// 		
// 		NSObject Self { get; }
//
// 		
// 		
// 		NSObject PerformSelector (Selector aSelector);
//
// 		
// 		
// 		NSObject PerformSelector (Selector aSelector,  NSObject anObject);
//
// 		
// 		
// 		NSObject PerformSelector (Selector aSelector,  NSObject object1,  NSObject object2);
//
// 		
// 		
// 		
// 		bool IsProxy { get; }
//
// 		
// 		
// 		
// 		bool IsKindOfClass ( Class aClass);
//
// 		
// 		
// 		
// 		bool IsMemberOfClass ( Class aClass);
//
// 		
// 		
// 		
// 		bool ConformsToProtocol ( NativeHandle /* Protocol */ aProtocol);
//
// 		
// 		
// 		
// 		bool RespondsToSelector ( Selector sel);
//
// 		
// 		
// 		
// 		NSObject DangerousRetain ();
//
// 		
// 		
// 		
// 		void DangerousRelease ();
//
// 		
// 		
// 		
// 		NSObject DangerousAutorelease ();
//
// 		
// 		
// 		nuint RetainCount { get; }
//
// 		
// 		
// 		
// 		NSZone Zone { get; }
// 	}
//
// 	
// 	interface NSOperation {
// 		
// 		void Start ();
//
// 		
// 		void Main ();
//
// 		
// 		bool IsCancelled { get; }
//
// 		
// 		void Cancel ();
//
// 		
// 		bool IsExecuting { get; }
//
// 		
// 		bool IsFinished { get; }
//
// 		
// 		bool IsConcurrent { get; }
//
// 		
// 		bool IsReady { get; }
//
// 		
// 		void AddDependency (NSOperation op);
//
// 		
// 		void RemoveDependency (NSOperation op);
//
// 		
// 		NSOperation  Dependencies { get; }
//
// 		
// 		
// 		Action CompletionBlock { get; set; }
//
// 		
// 		void WaitUntilFinished ();
//
// 		
// 		
// 		
// 		
// 		
// 		double ThreadPriority { get; set; }
//
// 		//Detected properties
// 		
// 		NSOperationQueuePriority QueuePriority { get; set; }
//
// 		
// 		
// 		bool Asynchronous {  get; }
//
// 		
// 		
// 		NSQualityOfService QualityOfService { get; set; }
//
// 		
// 		 // by default this property is null
// 		
// 		string Name { get; set; }
// 	}
//
// 	
// 	interface NSBlockOperation {
// 		
// 		
// 		NSBlockOperation Create (/* non null */ Action method);
//
// 		
// 		void AddExecutionBlock (/* non null */ Action method);
//
// 		
// 		NSObject  ExecutionBlocks { get; }
// 	}
//
// 	
// 	interface NSOperationQueue : NSProgressReporting {
// 		
// 		void AddOperation ( NSOperation op);
//
// 		
// 		void AddOperations ( NSOperation  operations, bool waitUntilFinished);
//
// 		
// 		void AddOperation (/* non null */ Action operation);
//
// 		
// 		
// 		
// 		
// 		
// 		NSOperation  Operations { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		nint OperationCount { get; }
//
// 		
// 		
// 		void AddBarrier (Action barrier);
//
// 		
// 		string Name { get; set; }
//
// 		
// 		void CancelAllOperations ();
//
// 		
// 		void WaitUntilAllOperationsAreFinished ();
//
// 		
// 		
// 		NSOperationQueue CurrentQueue { get; }
//
// 		
// 		
// 		NSOperationQueue MainQueue { get; }
//
// 		//Detected properties
// 		
// 		nint MaxConcurrentOperationCount { get; set; }
//
// 		
// 		bool Suspended { get; set; }
//
// 		
// 		
// 		NSQualityOfService QualityOfService { get; set; }
//
// 		
// 		
// 		
// 		DispatchQueue UnderlyingQueue { get; set; }
// 		
// 	}
//
// 	interface NSOrderedSet<TKey> : NSOrderedSet {}
//
// 	
// 	
// 	interface NSOrderedSet : NSSecureCoding, NSMutableCopying {
// 		
// 		NativeHandle Constructor (NSObject start);
//
// 		
// 		NativeHandle Constructor (NSArray array);
//
// 		
// 		NativeHandle Constructor (NSSet source);
//
// 		
// 		NativeHandle Constructor (NSOrderedSet source);
//
// 		
// 		nint Count { get; }
//
// 		
// 		
// 		
// 		IntPtr _GetObject (nint idx);
//
// 		
// 		NSObject GetObject (nint idx);
//
// 		
// 		IntPtr _ToArray ();
//
// 		
// 		
// 		
// 		nint _IndexOf (IntPtr obj);
//
// 		
// 		nint IndexOf (NSObject obj);
//
// 		
// 		NSEnumerator _GetEnumerator ();
//
// 		
// 		
// 		
// 		IntPtr _AsSet ();
//
// 		
// 		NSSet AsSet ();
//
// 		
// 		
// 		
// 		bool _Contains (IntPtr obj);
//
// 		
// 		bool Contains (NSObject obj);
//
// 		
// 		
// 		
// 		IntPtr _FirstObject ();
//
// 		
// 		NSObject FirstObject ();
//
// 		
// 		
// 		
// 		IntPtr _LastObject ();
//
// 		
// 		NSObject LastObject ();
//
// 		
// 		bool IsEqualToOrderedSet (NSOrderedSet other);
//
// 		
// 		bool Intersects (NSOrderedSet other);
//
// 		
// 		bool Intersects (NSSet other);
//
// 		
// 		bool IsSubset (NSOrderedSet other);
//
// 		
// 		bool IsSubset (NSSet other);
//
// 		
// 		NSOrderedSet GetReverseOrderedSet ();
// 	}
//
// 	interface NSMutableOrderedSet<TKey> : NSMutableOrderedSet {}
//
// 	
// 	
// 	interface NSMutableOrderedSet {
// 		
// 		NativeHandle Constructor (NSObject start);
//
// 		
// 		NativeHandle Constructor (NSSet source);
//
// 		
// 		NativeHandle Constructor (NSOrderedSet source);
//
// 		
// 		
// 		NativeHandle Constructor (nint capacity);
//
// 		
// 		NativeHandle Constructor (NSArray array);
//
// 		
// 		void UnionSet (NSSet other);
//
// 		
// 		void MinusSet (NSSet other);
//
// 		
// 		void UnionSet (NSOrderedSet other);
//
// 		
// 		void MinusSet (NSOrderedSet other);
//
// 		
// 		
// 		
// 		void _Insert (IntPtr obj, nint atIndex);
//
// 		
// 		void Insert (NSObject obj, nint atIndex);
//
// 		
// 		void Remove (nint index);
//
// 		
// 		
// 		
// 		void _Replace (nint objectAtIndex, IntPtr newObject);
//
// 		
// 		void Replace (nint objectAtIndex, NSObject newObject);
//
// 		
// 		
// 		
// 		void _Add (IntPtr obj);
//
// 		
// 		void Add (NSObject obj);
//
// 		
// 		
// 		
// 		void _AddObjects (NSArray source);
//
// 		
// 		void AddObjects (NSObject  source);
//
// 		
// 		
// 		
// 		void _InsertObjects (NSArray objects, NSIndexSet atIndexes);
//
// 		
// 		void InsertObjects (NSObject  objects, NSIndexSet atIndexes);
//
// 		
// 		void RemoveObjects (NSIndexSet indexSet);
//
// 		
// 		void ExchangeObject (nint first, nint second);
//
// 		
// 		void MoveObjects (NSIndexSet indexSet, nint destination);
//
// 		
// 		
// 		
// 		void _SetObject (IntPtr obj, nint index);
//
// 		
// 		void SetObject (NSObject obj, nint index);
//
// 		
// 		
// 		
// 		void _ReplaceObjects (NSIndexSet indexSet, NSArray replacementObjects);
//
// 		
// 		void ReplaceObjects (NSIndexSet indexSet, NSObject  replacementObjects);
//
// 		
// 		void RemoveObjects (NSRange range);
//
// 		
// 		void RemoveAllObjects ();
//
// 		
// 		
// 		
// 		void _RemoveObject (IntPtr obj);
//
// 		
// 		void RemoveObject (NSObject obj);
//
// 		
// 		
// 		
// 		void _RemoveObjects (NSArray objects);
//
// 		
// 		void RemoveObjects (NSObject  objects);
//
// 		
// 		void Intersect (NSOrderedSet intersectWith);
//
// 		
// 		void Intersect (NSSet intersectWith);
//
// 		
// 		void Sort (NSComparator comparator);
//
// 		
// 		void Sort (NSSortOptions sortOptions, NSComparator comparator);
//
// 		
// 		void SortRange (NSRange range, NSSortOptions sortOptions, NSComparator comparator);
// 	}
// 	
// 	
// 	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -: object cannot be nil
// 	
// 	interface NSOrthography : NSSecureCoding, NSCopying {
// 		
// 		string DominantScript { get;  }
//
// 		
// 		NSDictionary LanguageMap { get;  }
//
// 		
// 		string DominantLanguage { get;  }
//
// 		
// 		string  AllScripts { get;  }
//
// 		
// 		string  AllLanguages { get;  }
//
// 		
// 		string  LanguagesForScript (string script);
//
// 		
// 		string DominantLanguageForScript (string script);
//
// 		
// 		
// 		NativeHandle Constructor (string dominantScript,  NSDictionary languageMap);
// 	}
// 	
// 	
// 	 // crash when used
// 	interface NSOutputStream {
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		bool HasSpaceAvailable ();
// 	
// 		//
// 		//NativeHandle Constructor (uint8_t  buffer, NSUInteger capacity);
//
// 		
// 		NativeHandle Constructor (string path, bool shouldAppend);
//
// 		
// 		
// 		NSObject OutputStreamToMemory ();
//
// 		//
// 		//
// 		//NSObject OutputStreamToBuffer (uint8_t  buffer, NSUInteger capacity);
//
// 		
// 		
// 		NSOutputStream CreateFile (string path, bool shouldAppend);
//
// #if NETXXX
// 		
// 		
// 		
// 		NSObject GetProperty (NSString key);
//
// 		
// 		
// 		bool SetProperty ( NSObject property, NSString key);
//
// #endif
// 	}
//
// 	
// 	// default 'init' crash both simulator and devices
// 	
// 	interface NSHttpCookie {
// 		
// 		NativeHandle Constructor (NSDictionary properties);
//
// 		
// 		NSHttpCookie CookieFromProperties (NSDictionary properties);
//
// 		
// 		NSDictionary RequestHeaderFieldsWithCookies (NSHttpCookie  cookies);
//
// 		
// 		NSHttpCookie  CookiesWithResponseHeaderFields (NSDictionary headerFields, NSUrl url);
//
// 		
// 		NSDictionary Properties { get; }
//
// 		
// 		nuint Version { get; }
//
// 		
// 		string Value { get; }
//
// 		
// 		NSDate ExpiresDate { get; }
//
// 		
// 		bool IsSessionOnly { get; }
//
// 		
// 		string Domain { get; }
//
// 		
// 		string Name { get; }
//
// 		
// 		string Path { get; }
//
// 		
// 		bool IsSecure { get; }
//
// 		
// 		bool IsHttpOnly { get; }
//
// 		
// 		string Comment { get; }
//
// 		
// 		NSUrl CommentUrl { get; }
//
// 		
// 		NSNumber  PortList { get; }
//
// 		
// 		NSString KeyName { get; }
//
// 		
// 		NSString KeyValue { get; }
//
// 		
// 		NSString KeyOriginUrl { get; }
//
// 		
// 		NSString KeyVersion { get; }
//
// 		
// 		NSString KeyDomain { get; }
//
// 		
// 		NSString KeyPath { get; }
//
// 		
// 		NSString KeySecure { get; }
//
// 		
// 		NSString KeyExpires { get; }
//
// 		
// 		NSString KeyComment { get; }
//
// 		
// 		NSString KeyCommentUrl { get; }
//
// 		
// 		NSString KeyDiscard { get; }
//
// 		
// 		NSString KeyMaximumAge { get; }
//
// 		
// 		NSString KeyPort { get; }
//
// 		
// 		
// 		NSString KeySameSitePolicy { get; }
//
// 		
// 		
// 		NSString KeySameSiteLax { get; }
//
// 		
// 		
// 		NSString KeySameSiteStrict { get; }
//
// 		
// 		
// 		NSString SameSitePolicy { get; }
// 	}
//
// 	
// 	// NSHTTPCookieStorage implements a singleton object -> use SharedStorage since 'init' returns NIL
// 	
// 	interface NSHttpCookieStorage {
// 		
// 		NSHttpCookieStorage SharedStorage { get; }
//
// 		
// 		NSHttpCookie  Cookies { get; }
//
// 		
// 		void SetCookie (NSHttpCookie cookie);
//
// 		
// 		void DeleteCookie (NSHttpCookie cookie);
//
// 		
// 		NSHttpCookie  CookiesForUrl (NSUrl url);
//
// 		
// 		void SetCookies (NSHttpCookie  cookies, NSUrl forUrl, NSUrl mainDocumentUrl);
//
// 		
// 		NSHttpCookieAcceptPolicy AcceptPolicy { get; set; }
//
// 		
// 		NSHttpCookie  GetSortedCookies (NSSortDescriptor  sortDescriptors);
//
// 		// @required - (void)removeCookiesSinceDate:(NSDate *)date;
// 		
// 		
// 		void RemoveCookiesSinceDate (NSDate date);
//
// 		
// 		
// 		
// 		NSHttpCookieStorage GetSharedCookieStorage (string groupContainerIdentifier);
// 		
// 		
// 		
// 		
// 		void GetCookiesForTask (NSUrlSessionTask task, Action<NSHttpCookie > completionHandler);
//
// 		
// 		
// 		void StoreCookies (NSHttpCookie  cookies, NSUrlSessionTask task);
//
// 		
// 		
// 		NSString CookiesChangedNotification { get; }
//
// 		
// 		
// 		NSString AcceptPolicyChangedNotification { get; }
// 	}
// 	
// 	
// 	interface NSHttpUrlResponse {
// 		
// 		NativeHandle Constructor (NSUrl url, string mimetype, nint expectedContentLength,  string textEncodingName);
//
// 		
// 		NativeHandle Constructor (NSUrl url, nint statusCode,  string httpVersion,  NSDictionary headerFields);
// 		
// 		
// 		nint StatusCode { get; }
//
// 		
// 		NSDictionary AllHeaderFields { get; }
//
// 		
// 		string LocalizedStringForStatusCode (nint statusCode);
//
// 		
// 		
// 		
// 		string GetHttpHeaderValue (string headerField);
// 	}
// 	
// 	
// #if MONOMAC
// 	 // An uncaught exception was raised: -: attempt to remove nil key
// #endif
// 	partial interface NSBundle {
// 		
// 		NSBundle MainBundle { get; }
//
// 		
// 		NSBundle FromPath (string path);
//
// 		
// 		
// 		NativeHandle Constructor (string path);
//
// 		
// 		NSBundle FromClass (Class c);
//
// 		
// 		NSBundle FromIdentifier (string str);
//
// 		
// 		NSBundle  _AllBundles { get; }
//
// 		
// 		NSBundle  AllFrameworks { get; }
//
// 		
// 		bool Load ();
//
// 		
// 		bool IsLoaded { get; }
//
// 		
// 		bool Unload ();
//
// 		
// 		string BundlePath { get; }
// 		
// 		
// 		string  ResourcePath { get; }
// 		
// 		
// 		string ExecutablePath { get; }
// 		
// 		
// 		string PathForAuxiliaryExecutable (string s);
// 		
//
// 		
// 		string PrivateFrameworksPath { get; }
// 		
// 		
// 		string SharedFrameworksPath { get; }
// 		
// 		
// 		string SharedSupportPath { get; }
// 		
// 		
// 		string BuiltinPluginsPath { get; }
// 		
// 		
// 		string BundleIdentifier { get; }
//
// 		
// 		Class ClassNamed (string className);
// 		
// 		
// 		Class PrincipalClass { get; }
//
// 		
// 		string PathForResourceAbsolute (string name,  string ofType, string bundleDirectory);
// 		
// 		
// 		string PathForResource (string name,  string ofType);
//
// 		
// 		string PathForResource (string name,  string ofType,  string subpath);
// 		
// 		
// 		string PathForResource (string name,  string ofType, string subpath, string localizationName);
//
// 		
// 		NSString GetLocalizedString ( NSString key,  NSString value,  NSString table);
//
// 		
// 		NSObject ObjectForInfoDictionary (string key);
//
// 		
// 		string DevelopmentLocalization { get; }
// 		
// 		
// 		NSDictionary InfoDictionary{ get; }
//
// 		// Additions from AppKit
// 		
// 		
// 		bool LoadNibNamed (string nibName,  NSObject owner, out NSArray topLevelObjects);
//
// 		// https://developer.apple.com/library/mac/#documentation/Cocoa/Reference/ApplicationKit/Classes/NSBundle_AppKitAdditions/Reference/Reference.html
// 		
// 		
// 		
// 		
// 		bool LoadNib (string nibName, NSObject owner);
//
// 		
// 		
// 		string PathForImageResource (string resource);
//
// 		
// 		
// 		string PathForSoundResource (string resource);
//
// 		
// 		
// 		NSUrl GetUrlForImageResource (string resource);
//
// 		
// 		
// 		NSAttributedString GetContextHelp (string key);
//
// 		// http://developer.apple.com/library/ios/#documentation/uikit/reference/NSBundle_UIKitAdditions/Introduction/Introduction.html
// 		
// 		
// 		
// 		NSArray LoadNib (string nibName,  NSObject owner,  NSDictionary options);
//
// 		
// 		NSUrl BundleUrl { get; }
// 		
// 		
// 		NSUrl ResourceUrl { get; }
//
// 		
// 		NSUrl ExecutableUrl { get; }
//
// 		
// 		NSUrl UrlForAuxiliaryExecutable (string executable);
//
// 		
// 		NSUrl PrivateFrameworksUrl { get; }
//
// 		
// 		NSUrl SharedFrameworksUrl { get; }
//
// 		
// 		NSUrl SharedSupportUrl { get; }
//
// 		
// 		NSUrl BuiltInPluginsUrl { get; }
//
// 		
// 		NativeHandle Constructor (NSUrl url);
// 		
// 		
// 		NSBundle FromUrl (NSUrl url);
//
// 		
// 		string  PreferredLocalizations { get; }
//
// 		
// 		string  Localizations { get; }
//
// 		
// 		
// 		NSUrl AppStoreReceiptUrl { get; }
//
// 		
// 		string  PathsForResources (string fileExtension,  string subDirectory);
//
// 		
// 		string  PathsForResources (string fileExtension,  string subDirectory,  string localizationName);
//
// 		
// 		string  GetPathsForResources (string fileExtension, string bundlePath);
//
// 		
// 		NSUrl GetUrlForResource (string name, string fileExtension,  string subdirectory, NSUrl bundleURL);
//
// 		
// 		NSUrl  GetUrlsForResourcesWithExtension (string fileExtension,  string subdirectory, NSUrl bundleURL);
//
// 		
// 		NSUrl GetUrlForResource (string name, string fileExtension);
//
// 		
// 		NSUrl GetUrlForResource (string name, string fileExtension,  string subdirectory);
//
// 		
// 		NSUrl GetUrlForResource (string name, string fileExtension,  string subdirectory,  string localizationName);
//
// 		
// 		NSUrl  GetUrlsForResourcesWithExtension (string fileExtension,  string subdirectory);
//
// 		
// 		NSUrl  GetUrlsForResourcesWithExtension (string fileExtension,  string subdirectory,   string localizationName);
//
// 		
// 		
// 		
// 		double GetPreservationPriority (NSString tag);
//
// 		
// 		
// 		
// 		void SetPreservationPriority (double priority, NSSet<NSString> tags);
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSBundleResourceRequest : NSProgressReporting
// 	{
// 		
// 		NativeHandle Constructor (NSSet<NSString> tags);
// 	
// 		
// 		
// 		NativeHandle Constructor (NSSet<NSString> tags, NSBundle bundle);
// 	
// 		
// 		double LoadingPriority { get; set; }
// 	
// 		
// 		NSSet<NSString> Tags { get; }
// 	
// 		
// 		NSBundle Bundle { get; }
// 	
// 		
// 		
// 		void BeginAccessingResources (Action<NSError> completionHandler);
// 	
// 		
// 		
// 		void ConditionallyBeginAccessingResources (Action<bool> completionHandler);
// 	
// 		
// 		void EndAccessingResources ();
// 	
// 		
// 		
// 		NSString LowDiskSpaceNotification { get; }
// 		
// 		
// 		double LoadingPriorityUrgent { get; }
// 	}
// 		
// 	
// 	interface NSIndexPath : NSCoding, NSSecureCoding, NSCopying {
// 		
// 		NSIndexPath FromIndex (nuint index);
//
// 		
// 		NSIndexPath _FromIndex (IntPtr indexes, nint len);
//
// 		
// 		NSIndexPath IndexPathByAddingIndex (nuint index);
// 		
// 		
// 		NSIndexPath IndexPathByRemovingLastIndex ();
//
// 		
// 		nuint IndexAtPosition (nint position);
//
// 		
// 		nint Length { get; } 
//
// 		
// 		void _GetIndexes (IntPtr target);
//
// 		
// 		
// 		void _GetIndexes (IntPtr target, NSRange positionRange);
//
// 		
// 		nint Compare (NSIndexPath other);
//
// 		// NSIndexPath UIKit Additions Reference
// 		// https://developer.apple.com/library/ios/#documentation/UIKit/Reference/NSIndexPath_UIKitAdditions/Reference/Reference.html
//
// 		// see monotouch/src/UIKit/Addition.cs for int-returning Row/Section properties
// 		
// 		
// 		
// 		nint LongRow { get; }
//
// 		
// 		
// 		
// 		nint LongSection { get; }
//
// 		
// 		
// 		
// 		
// 		NSIndexPath FromRowSection (nint row, nint section);
//
// 		
// 		
// 		
// 		nint Section { get; }
//
// 		
// 		
// 		
// 		
// 		NSIndexPath FromItemSection (nint item, nint section);
//
// 		
// 		
// 		
// 		nint Item { get; }
// 	}
//
// 	delegate void NSRangeIterator (NSRange range, ref bool stop);
// 	
// 	
// 	interface NSIndexSet : NSCoding, NSSecureCoding, NSMutableCopying {
// 		
// 		NSIndexSet FromIndex (nint idx);
//
// 		
// 		NSIndexSet FromNSRange (NSRange indexRange);
// 		
// 		
// 		NativeHandle Constructor (nuint index);
//
// 		
// 		
// 		NativeHandle Constructor (NSIndexSet other);
//
// 		
// 		nint Count { get; }
//
// 		
// 		bool IsEqual (NSIndexSet other);
//
// 		
// 		nuint FirstIndex { get; }
//
// 		
// 		nuint LastIndex { get; }
//
// 		
// 		nuint IndexGreaterThan (nuint index);
//
// 		
// 		nuint IndexLessThan (nuint index);
//
// 		
// 		nuint IndexGreaterThanOrEqual (nuint index);
//
// 		
// 		nuint IndexLessThanOrEqual (nuint index);
//
// 		
// 		bool Contains (nuint index);
//
// 		
// 		bool Contains (NSIndexSet indexes);
//
// 		
// 		void EnumerateRanges (NSRangeIterator iterator);
//
// 		
// 		void EnumerateRanges (NSEnumerationOptions opts, NSRangeIterator iterator);
//
// 		
// 		void EnumerateRanges (NSRange range, NSEnumerationOptions opts, NSRangeIterator iterator);
//
// 		
// 		void EnumerateIndexes (EnumerateIndexSetCallback enumeratorCallback);
//
// 		
// 		void EnumerateIndexes (NSEnumerationOptions opts, EnumerateIndexSetCallback enumeratorCallback);
//
// 		
// 		void EnumerateIndexes (NSRange range, NSEnumerationOptions opts, EnumerateIndexSetCallback enumeratorCallback);
// 	}
//
// 	
// 	 // from the docs: " you should not create these objects using alloc and init."
// 	interface NSInvocation {
//
// 		
// 		Selector Selector { get; set; }
//
// 		
// 		NSObject Target { get; set; }
//
// 		// FIXME: We need some special marshaling support to handle these buffers...
// 		
// 		void _SetArgument (IntPtr buffer, nint index);
//
// 		
// 		void _GetArgument (IntPtr buffer, nint index);
//
// 		
// 		void _SetReturnValue (IntPtr buffer);
//
// 		
// 		void _GetReturnValue (IntPtr buffer);
//
// 		
// 		void Invoke ();
//
// 		
// 		void Invoke (NSObject target);
//
// 		
// 		NSMethodSignature MethodSignature { get; }
// 	}
//
//
// 	 // Not defined in 32-bit
// 	
// 	
// 	partial interface NSItemProvider : NSCopying {
// 		
// 		
// 		NativeHandle Constructor ( NSObject item, string typeIdentifier);
//
// 		
// 		NativeHandle Constructor (NSUrl fileUrl);
//
// 		
// 		string  RegisteredTypeIdentifiers { get; }
//
// 		
// 		void RegisterItemForTypeIdentifier (string typeIdentifier, NSItemProviderLoadHandler loadHandler);
//
// 		
// 		bool HasItemConformingTo (string typeIdentifier);
//
// 		
// 		
// 		void LoadItem (string typeIdentifier,  NSDictionary options,  Action<NSObject,NSError> completionHandler);
//
// 		
// 		NSString PreferredImageSizeKey { get; }		
//
// 		
// 		void SetPreviewImageHandler (NSItemProviderLoadHandler handler);
//
// 		
// 		
// 		void LoadPreviewImage (NSDictionary options, Action<NSObject,NSError> completionHandler);
//
// 		
// 		NSString ErrorDomain { get; }
//
// 		
// 		
// 		CGRect SourceFrame { get; }
//
// 		
// 		
// 		CGRect ContainerFrame { get; }
//
// 		
// 		
// 		
// 		
// 		CGSize PreferredPresentationSize {
// 			get;
// #if !MONOMAC
// 			set;
// #endif
// 		}
//
// 		
// 		 //  handled by NSItemProvider.cs for backwards compat reasons
// 		
// 		void RegisterCloudKitShare (CloudKitRegistrationPreparationAction preparationHandler);
//
// 		
// 		
// 		
// 		void RegisterCloudKitShare (CKShare share, CKContainer container);
//
// 		
// 		
// 		void RegisterDataRepresentation (string typeIdentifier, NSItemProviderRepresentationVisibility visibility, RegisterDataRepresentationLoadHandler loadHandler);
//
// 		
// 		
// 		void RegisterFileRepresentation (string typeIdentifier, NSItemProviderFileOptions fileOptions, NSItemProviderRepresentationVisibility visibility, RegisterFileRepresentationLoadHandler loadHandler);
//
// 		
// 		
// 		string GetRegisteredTypeIdentifiers (NSItemProviderFileOptions fileOptions);
//
// 		
// 		
// 		bool HasConformingRepresentation (string typeIdentifier, NSItemProviderFileOptions fileOptions);
//
// 		
// 		
// 		NSProgress LoadDataRepresentation (string typeIdentifier, Action <NSData, NSError> completionHandler);
//
// 		
// 		
// 		NSProgress LoadFileRepresentation (string typeIdentifier, Action <NSUrl, NSError> completionHandler);
//
// 		
// 		
// 		NSProgress LoadInPlaceFileRepresentation (string typeIdentifier, LoadInPlaceFileRepresentationHandler completionHandler);
//
// 		
// 		
// 		
// 		string SuggestedName { get; set; }
//
// 		
// 		
// 		NativeHandle Constructor (INSItemProviderWriting @object);
//
// 		
// 		
// 		void RegisterObject (INSItemProviderWriting @object, NSItemProviderRepresentationVisibility visibility);
//
// 		
// 		
// 		void RegisterObject (Class aClass, NSItemProviderRepresentationVisibility visibility, RegisterObjectRepresentationLoadHandler loadHandler);
//
// 		
// 		
// 		void RegisterObject (Type type, NSItemProviderRepresentationVisibility visibility, RegisterObjectRepresentationLoadHandler loadHandler);
//
// 		
// 		
// 		bool CanLoadObject (Class aClass);
//
// 		
// 		
// 		bool CanLoadObject (Type type);
//
// 		
// 		
// 		NSProgress LoadObject (Class aClass, Action<INSItemProviderReading, NSError> completionHandler);
//
// 		// NSItemProvider_UIKitAdditions category
//
// 		
// 		
// 		
// 		
// 		
// 		NSData TeamData { get; set; }
//
// 		
// 		
// 		
// 		
// 		
// 		UIPreferredPresentationStyle PreferredPresentationStyle { get; set; }
// 	}
//     
// 	delegate NSProgress RegisterFileRepresentationLoadHandler ( RegisterFileRepresentationCompletionHandler completionHandler);
// 	delegate void RegisterFileRepresentationCompletionHandler (NSUrl fileUrl, bool coordinated, NSError error);
// 	delegate void ItemProviderDataCompletionHandler (NSData data, NSError error);
// 	delegate NSProgress RegisterDataRepresentationLoadHandler ( ItemProviderDataCompletionHandler completionHandler);
// 	delegate void LoadInPlaceFileRepresentationHandler (NSUrl fileUrl, bool isInPlace, NSError error);
// 	delegate NSProgress RegisterObjectRepresentationLoadHandler ( RegisterObjectRepresentationCompletionHandler completionHandler);
// 	delegate void RegisterObjectRepresentationCompletionHandler (INSItemProviderWriting @object, NSError error);
//
// 	interface INSItemProviderReading {}
// 	
// 	
// 	
// 	interface NSItemProviderReading
// 	{
// 		// This static method has to be implemented on each class that implements
// 		// this, this is not a capability that exists in C#.
// 		// We are inlining these on each class that implements NSItemProviderReading
// 		// for the sake of the method being callable from C#, for user code, the
// 		// user needs to manually  the selector on a static method, like
// 		// they do for the "layer" property on CALayer subclasses.
// 		//
// 		
// 		
// 		string ReadableTypeIdentifiers { get; }
//
// 		
// 		
// 		
// 		INSItemProviderReading GetObject (NSData data, string typeIdentifier,  out NSError outError);
// 	}
//
// 	interface INSItemProviderWriting {}
//
// 	
// 	
// 	interface NSItemProviderWriting
// 	{
// 		//
// 		// This static method has to be implemented on each class that implements
// 		// this, this is not a capability that exists in C#.
// 		// We are inlining these on each class that implements NSItemProviderWriting
// 		// for the sake of the method being callable from C#, for user code, the
// 		// user needs to manually  the selector on a static method, like
// 		// they do for the "layer" property on CALayer subclasses.
// 		//
// 		
// 		
// 		string WritableTypeIdentifiers { get; }
//
// 		// This is an optional method, which means the generator will inline it in any classes
// 		// that implements this interface. Unfortunately none of the native classes that implements
// 		// the protocol actually implements this method, which means that inlining the method will cause
// 		// introspection to complain (rightly). So comment out this method to avoid generator a lot of unusable API.
// 		// See also https://bugzilla.xamarin.com/show_bug.cgi?id=59308.
// 		//
// 		// 
// 		// 
// 		// NSItemProviderRepresentationVisibility GetItemProviderVisibility (string typeIdentifier);
//
// 		
// 		// 'WritableTypeIdentifiers' is a nicer name, but there's a static property with that name.
// 		string WritableTypeIdentifiersForItemProvider { get; }
//
// 		
// 		// 'GetItemProviderVisibility' is a nicer name, but there's a static method with that name.
// 		NSItemProviderRepresentationVisibility GetItemProviderVisibilityForTypeIdentifier (string typeIdentifier);
//
// 		
// 		
// 		
// 		NSProgress LoadData (string typeIdentifier, Action<NSData, NSError> completionHandler);
// 	}
//
// 	
// 	
// 	partial interface NSJavaScriptExtension {
// 		
// 		NSString PreprocessingResultsKey { get; }
//
// 		
// 		NSString FinalizeArgumentKey { get; }
// 	}
//
// 	
// 	interface NSTypeIdentifier {
// 		
// 		NSString DateText { get; }
//
// 		
// 		NSString AddressText { get; }
//
// 		
// 		NSString PhoneNumberText { get; }
//
// 		
// 		NSString TransitInformationText { get; }
// 	}
// 		
// 	
// 	 // `init` returns a null handle
// 	interface NSMethodSignature {
// 		
// 		
// 		NSMethodSignature FromObjcTypes (IntPtr utf8objctypes);
// 		
// 		
// 		nuint NumberOfArguments { get; }
//
// 		
// 		nuint FrameLength { get; }
//
// 		
// 		nuint MethodReturnLength { get; }
//
// 		
// 		bool IsOneway { get; }
//
// 		
// 		IntPtr GetArgumentType (nuint index);
//
// 		
// 		IntPtr MethodReturnType { get; }
// 	}
//
// 	
// 	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** +: Do not create instances of NSJSONSerialization in this release
// 	
// 	interface NSJsonSerialization {
// 		
// 		
// 		bool IsValidJSONObject (NSObject obj);
//
// 		
// 		
// 		NSData Serialize (NSObject obj, NSJsonWritingOptions opt, out NSError error);
//
// 		
// 		
// 		NSObject Deserialize (NSData data, NSJsonReadingOptions opt, out NSError error);
//
// 		
// 		
// 		nint Serialize (NSObject obj, NSOutputStream stream, NSJsonWritingOptions opt, out NSError error);
//
// 		
// 		
// 		NSObject Deserialize (NSInputStream stream, NSJsonReadingOptions opt, out NSError error);
//
// 	}
// 	
// 	
// 	interface NSMutableIndexSet : NSSecureCoding {
// 		
// 		NativeHandle Constructor (nuint index);
//
// 		
// 		NativeHandle Constructor (NSIndexSet other);
//
// 		
// 		void Add (NSIndexSet other);
//
// 		
// 		void Remove (NSIndexSet other);
//
// 		
// 		void Clear ();
//
// 		
// 		void Add (nuint index);
//
// 		
// 		void Remove (nuint index);
//
// 		
// 		void ShiftIndexes (nuint startIndex, nint delta);
//
// 		
// 		void AddIndexesInRange (NSRange range);
//
// 		
// 		void RemoveIndexesInRange (NSRange range);
// 	}
//
// 	
// 	 // the instance just crash when trying to call selectors
// 	 { "WeakDelegate" }, Events=new Type  { typeof (NSNetServiceDelegate)})]
// 	interface NSNetService {
// 		
// 		
// 		NativeHandle Constructor (string domain, string type, string name, int /* int, not NSInteger */ port);
//
// 		
// 		NativeHandle Constructor (string domain, string type, string name);
// 		
// 		
// 		NSObject WeakDelegate { get; set; }
// 		
// 		
// 		
// 		NSNetServiceDelegate Delegate { get; set; }
//
// #if NETXXX
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSString forMode);
//
// 		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSString forMode);
// #else
// 		
// 		void Schedule (NSRunLoop aRunLoop, string forMode);
//
// 		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
// 		
// 		void Unschedule (NSRunLoop aRunLoop, string forMode);
// #endif
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
//
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
//
// 		
// 		string Domain { get; }
//
// 		
// 		string Type { get; }
//
// 		
// 		string Name { get; }
//
// 		
// 		NSData  Addresses { get; }
//
// 		
// 		nint Port { get; }
//
// 		
// 		void Publish ();
//
// 		
// 		void Publish (NSNetServiceOptions options);
//
// 		
// 		
// 		
// 		
// 		void Resolve ();
//
// 		
// 		void Resolve (double timeOut);
//
// 		
// 		void Stop ();
//
// 		
// 		NSDictionary DictionaryFromTxtRecord (NSData data);
// 		
// 		
// 		NSData DataFromTxtRecord (NSDictionary dictionary);
// 		
// 		
// 		string HostName { get; }
//
// 		
// 		bool GetStreams (out NSInputStream inputStream, out NSOutputStream outputStream);
// 		
// 		
// 		NSData GetTxtRecordData ();
//
// 		
// 		bool SetTxtRecordData (NSData data);
//
// 		//NSData TxtRecordData { get; set; }
//
// 		
// 		void StartMonitoring ();
//
// 		
// 		void StopMonitoring ();
//
// 		
// 		
// 		bool IncludesPeerToPeer { get; set; }
// 	}
//
// 	
// 	
// 	
// 	interface NSNetServiceDelegate {
// 		
// 		void WillPublish (NSNetService sender);
//
// 		
// 		void Published (NSNetService sender);
//
// 		
// 		void PublishFailure (NSNetService sender, NSDictionary errors);
//
// 		
// 		void WillResolve (NSNetService sender);
//
// 		
// 		void AddressResolved (NSNetService sender);
//
// 		
// 		void ResolveFailure (NSNetService sender, NSDictionary errors);
//
// 		
// 		void Stopped (NSNetService sender);
//
// 		
// 		void UpdatedTxtRecordData (NSNetService sender, NSData data);
//
// 		
// 		
// 		void DidAcceptConnection (NSNetService sender, NSInputStream inputStream, NSOutputStream outputStream);
// 	}
//
// 	
// 	[BaseType (typeof (NSObject),
// 		   Delegates=new string  {"WeakDelegate"},
// 		   Events=new Type  {typeof (NSNetServiceBrowserDelegate)})]
// 	interface NSNetServiceBrowser {
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSNetServiceBrowserDelegate Delegate { get; set; }
//
// #if NETXXX
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSString forMode);
//
// 		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSString forMode);
// #else
// 		
// 		void Schedule (NSRunLoop aRunLoop, string forMode);
//
// 		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
// 		
// 		void Unschedule (NSRunLoop aRunLoop, string forMode);
// #endif
//
// 		
// 		void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
//
// 		
// 		void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);
//
// 		
// 		void SearchForBrowsableDomains ();
//
// 		
// 		void SearchForRegistrationDomains ();
//
// 		
// 		void SearchForServices (string type, string domain);
//
// 		
// 		void Stop ();
//
// 		
// 		
// 		bool IncludesPeerToPeer { get; set; }
// 	}
//
// 	
// 	
// 	
// 	interface NSNetServiceBrowserDelegate {
// 		
// 		void SearchStarted (NSNetServiceBrowser sender);
// 		
// 		
// 		void SearchStopped (NSNetServiceBrowser sender);
// 		
// 		
// 		void NotSearched (NSNetServiceBrowser sender, NSDictionary errors);
// 		
// 		
// 		void FoundDomain (NSNetServiceBrowser sender, string domain, bool moreComing);
// 		
// 		
// 		void FoundService (NSNetServiceBrowser sender, NSNetService service, bool moreComing);
// 		
// 		
// 		void DomainRemoved (NSNetServiceBrowser sender, string domain, bool moreComing);
// 		
// 		
// 		void ServiceRemoved (NSNetServiceBrowser sender, NSNetService service, bool moreComing);
// 	}
//
// 	
// 	// Objective-C exception thrown.  Name: NSGenericException Reason: *** -: should never be used
// 	 // added in iOS7 but header files says "do not invoke; not a valid initializer for this class"
// 	interface NSNotification : NSCoding, NSCopying {
// 		
// 		// Null not allowed
// 		string Name { get; }
//
// 		
// 		
// 		NSObject Object { get; }
//
// 		
// 		
// 		NSDictionary UserInfo { get; }
//
// 		
// 		NSNotification FromName (string name,  NSObject obj);
//
// 		
// 		NSNotification FromName (string name,  NSObject obj,  NSDictionary userInfo);
// 		
// 	}
//
// 	
// 	interface NSNotificationCenter {
// 		
// 		NSNotificationCenter DefaultCenter { get; }
// 	
// 		
// 		
// 		void AddObserver (NSObject observer, Selector aSelector,  NSString aName,  NSObject anObject);
// 	
// 		
// 		void PostNotification (NSNotification notification);
// 	
// 		
// 		void PostNotificationName (string aName,  NSObject anObject);
// 	
// 		
// 		void PostNotificationName (string aName,  NSObject anObject,  NSDictionary aUserInfo);
// 	
// 		
// 		
// 		void RemoveObserver (NSObject observer);
// 	
// 		
// 		
// 		void RemoveObserver (NSObject observer,  string aName,  NSObject anObject);
//
// 		
// 		NSObject AddObserver ( string name,  NSObject obj,  NSOperationQueue queue, Action<NSNotification> handler);
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSDistributedLock
// 	{
// 		
// 		
// 		
// 		NSDistributedLock FromPath (string path);
//
// 		
// 		
// 		NativeHandle Constructor (string path);
//
// 		
// 		bool TryLock ();
//
// 		
// 		void Unlock ();
//
// 		
// 		void BreakLock ();
//
// 		
// 		NSDate LockDate { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSDistributedNotificationCenter {
// 		
// 		
// #if NETXXX
// 		NSDistributedNotificationCenter DefaultCenter { get; }
// #else
// 		NSDistributedNotificationCenter GetDefaultCenter ();
//
// 		
// 		
// 		
// 		NSObject DefaultCenter { get; }
// #endif
//
// 		
// 		void AddObserver (NSObject observer, Selector selector,  string notificationName,  string notificationSenderc, NSNotificationSuspensionBehavior suspensionBehavior);
//
// 		
// 		void PostNotificationName (string name,  string anObject,  NSDictionary userInfo, bool deliverImmediately);
// 		
// 		
// 		void PostNotificationName (string name,  string anObjecb,  NSDictionary userInfo, NSNotificationFlags options);
//
// 		
// 		void AddObserver (NSObject observer, Selector aSelector,  string aName,  NSObject anObject);
//
// 		
// 		void PostNotificationName (string aName,  string anObject);
//
// 		
// 		void PostNotificationName (string aName,  string anObject,  NSDictionary aUserInfo);
//
// 		
// 		void RemoveObserver (NSObject observer,  string aName,  NSObject anObject);
//
// 		//Detected properties
// 		
// 		bool Suspended { get; set; }
// 		
// 		
// 		NSString NSLocalNotificationCenterType {get;}
// 	}
// 	
// 	
// 	interface NSNotificationQueue {
// 		
// 		
// 		NSNotificationQueue DefaultQueue { get; }
//
// 		
// 		
// 		NativeHandle Constructor (NSNotificationCenter notificationCenter);
//
// 		
// 		void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle);
//
// 		
// #if !NETXXX
// 		void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask,  string  modes);
// #else
// 		void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask,  NSString  modes);
//
// 		
// 		void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask,  NSRunLoopMode  modes);
// #endif
//
// 		
// 		void DequeueNotificationsMatchingcoalesceMask (NSNotification notification, NSNotificationCoalescing coalesceMask);
// 	}
//
// 	
// 	// init returns NIL
// 	
// 	partial interface NSValue : NSSecureCoding, NSCopying {
// 		
// 		
// 		
// 		
// 		
// 		void StoreValueAtAddress (IntPtr value);
//
// 		
// 		
// 		void StoreValueAtAddress (IntPtr value, nuint size);
//
// 		
// 		IntPtr ObjCTypePtr ();
// 		
// 		//
// 		//NSValue InitFromBytes (IntPtr byte_ptr, IntPtr char_ptr_type);
//
// 		
// 		
// 		NSValue Create (IntPtr bytes, IntPtr objCType);
//
// 		
// 		
// 		NSValue ValueFromNonretainedObject (NSObject anObject);
// 	
// 		
// 		NSObject NonretainedObjectValue { get; }
// 	
// 		
// 		
// 		NSValue ValueFromPointer (IntPtr pointer);
// 	
// 		
// 		IntPtr PointerValue { get; }
// 	
// 		
// 		bool IsEqualTo (NSValue value);
// 		
// 		
// 		NSValue FromRange(NSRange range);
//
// 		
// 		NSRange RangeValue { get; }
//
// 		
// 		
// 		NSValue FromCMTime (CMTime time);
//
// 		
// 		
// 		CMTime CMTimeValue { get; }
//
// 		
// 		
// 		NSValue FromCMTimeMapping (CMTimeMapping timeMapping);
//
// 		
// 		
// 		CMTimeMapping CMTimeMappingValue { get; }
//
// 		
// 		
// 		NSValue FromCMTimeRange (CMTimeRange timeRange);
//
// 		
// 		
// 		CMTimeRange CMTimeRangeValue { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSValue FromCGRect (CGRect rect);
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSValue FromCGSize (CGSize size);
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSValue FromCGPoint (CGPoint point);
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		CGRect CGRectValue { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		CGSize CGSizeValue { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		CGPoint CGPointValue { get; }
//
// 		
// 		
// 		CoreGraphics.CGAffineTransform CGAffineTransformValue { get; }
// 		
// 		
// 		
// 		UIEdgeInsets UIEdgeInsetsValue { get; }
//
// 		
// 		
// 		
// 		NSDirectionalEdgeInsets DirectionalEdgeInsetsValue { get; }
//
// 		
// 		
// 		NSValue FromCGAffineTransform (CoreGraphics.CGAffineTransform tran);
//
// 		
// 		
// 		NSValue FromUIEdgeInsets (UIEdgeInsets insets);
//
// 		
// 		
// 		
// 		
// 		NSValue FromDirectionalEdgeInsets (NSDirectionalEdgeInsets insets);
//
// 		
// 		
// 		NSValue FromUIOffset (UIOffset insets);
//
// 		
// 		
// 		UIOffset UIOffsetValue { get; }
// 		// from UIGeometry.h - those are in iOS8 only (even if the header is silent about them)
// 		// and not in OSX 10.10
//
// 		
// 		
// 		
// 		CGVector CGVectorValue { get; }
//
// 		
// 		
// 		
// 		NSValue FromCGVector (CGVector vector);
//
// 		// Maybe we should include this inside mapkit.cs instead (it's a partial interface, so that's trivial)?
// 		
// 		 // The header doesn't say, but the rest of the API from the same file (MKGeometry.h) was introduced in 10.9
// 		
// 		NSValue FromMKCoordinate (CoreLocation.CLLocationCoordinate2D coordinate);
//
// 		
// 		 // The header doesn't say, but the rest of the API from the same file (MKGeometry.h) was introduced in 10.9
// 		
// 		NSValue FromMKCoordinateSpan (MapKit.MKCoordinateSpan coordinateSpan);
//
// 		
// 		
// 		
// 		CoreLocation.CLLocationCoordinate2D CoordinateValue { get; }
//
// 		
// 		
// 		
// 		MapKit.MKCoordinateSpan CoordinateSpanValue { get; }
//
// #if !WATCH
// 		
// 		NSValue FromCATransform3D (CoreAnimation.CATransform3D transform);
//
// 		
// 		CoreAnimation.CATransform3D CATransform3DValue { get; }
// #endif
//
// 		#region SceneKit Additions
//
// 		
// 		
// 		NSValue FromVector (SCNVector3 vector);
//
// 		
// 		
// 		SCNVector3 Vector3Value { get; }
//
// 		
// 		
// 		NSValue FromVector (SCNVector4 vector);
//
// 		
// 		
// 		SCNVector4 Vector4Value { get; }
//
// 		
// 		
// 		NSValue FromSCNMatrix4 (SCNMatrix4 matrix);
//
// 		
// 		
// 		SCNMatrix4 SCNMatrix4Value { get; }
//
// 		#endregion
// 	}
//
// 	
// 	 // Apple docs: NSValueTransformer is an abstract class...
// 	interface NSValueTransformer {
// 		
// 		
// 		void SetValueTransformer ( NSValueTransformer transformer, string name);
//
// 		
// 		
// 		
// 		NSValueTransformer GetValueTransformer (string name);
//
// 		
// 		
// 		string ValueTransformerNames { get; }
//
// 		
// 		
// 		Class TransformedValueClass { get; }
//
// 		
// 		
// 		bool AllowsReverseTransformation { get; }
//
// 		
// 		
// 		NSObject TransformedValue ( NSObject value);
//
// 		
// 		
// 		NSObject ReverseTransformedValue ( NSObject value);
//
// #if IOS && !NET
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString SizeLimitExceededNotification { get; }
//
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString DidChangeAccountsNotification { get; }
//
// 		
// 		 // Headers say watchOS 2.0, but they're lying.
// 		
// 		
// 		
// 		NSString CompletedInitialSyncNotification { get; }
//
// 		
// 		
// 		
// 		NSString UserDefaultsDidChangeNotification { get; }
// #endif
//
// 		
// 		NSString BooleanTransformerName { get; }
//
// 		
// 		NSString IsNilTransformerName { get; }
//
// 		
// 		NSString IsNotNilTransformerName { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		NSString UnarchiveFromDataTransformerName { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		NSString KeyedUnarchiveFromDataTransformerName { get; }
//
// 		
// 		
// 		NSString SecureUnarchiveFromDataTransformerName { get; }
// 	}
//
// 	
// 	
// 	interface NSSecureUnarchiveFromDataTransformer {
// 		
// 		
// 		Class  AllowedTopLevelClasses { get; }
//
// 		
// 		
// 		Type  AllowedTopLevelTypes { get; }
// 	}
// 	
// 	
// 	// init returns NIL
// 	
// 	interface NSNumber : CKRecordValue, NSFetchRequestResult {
// 		
// 		sbyte SByteValue { get; }
// 	
// 		
// 		byte ByteValue { get; }
// 	
// 		
// 		short Int16Value { get; }
// 	
// 		
// 		ushort UInt16Value { get; }
// 	
// 		
// 		int Int32Value { get; }
// 	
// 		
// 		uint UInt32Value { get; } 
// 	
// 		
// 		nint LongValue { get; }
// 		
// 		
// 		nuint UnsignedLongValue { get; }
// 	
// 		
// 		long Int64Value { get; }
// 	
// 		
// 		ulong UInt64Value { get; }
// 	
// 		
// 		float FloatValue { get; } /* float, not CGFloat */
// 	
// 		
// 		double DoubleValue { get; }
//
// 		
// 		NSDecimal NSDecimalValue { get; }
// 	
// 		
// 		bool BoolValue { get; }
//
// 		
// 		nint NIntValue { get; }
//
// 		
// 		nuint NUIntValue { get; }
//
// 		
// 		string StringValue { get; }
//
// 		
// 		nint Compare (NSNumber otherNumber);
// 	
// 		 // Equals(object) or IEquatable<T>'s Equals(NSNumber)
// 		
// 		bool IsEqualToNumber (NSNumber number);
// 	
// 		
// 		string DescriptionWithLocale (NSLocale locale);
//
// 		
// 		
// 		NativeHandle Constructor (sbyte value);
// 	
// 		
// 		
// 		NativeHandle Constructor (byte value);
// 	
// 		
// 		
// 		NativeHandle Constructor (short value);
// 	
// 		
// 		
// 		NativeHandle Constructor (ushort value);
// 	
// 		
// 		
// 		NativeHandle Constructor (int /* int, not NSInteger */ value);
// 	
// 		
// 		
// 		NativeHandle Constructor (uint /* unsigned int, not NSUInteger */value);
// 	
// 		//
// 		//NativeHandle Constructor (long value);
// 		//
// 		//
// 		//NativeHandle Constructor (ulong value);
// 	
// 		
// 		
// 		NativeHandle Constructor (long value);
// 	
// 		
// 		
// 		NativeHandle Constructor (ulong value);
// 	
// 		
// 		
// 		NativeHandle Constructor (float /* float, not CGFloat */ value);
// 	
// 		
// 		
// 		NativeHandle Constructor (double value);
// 	
// 		
// 		
// 		NativeHandle Constructor (bool value);
//
// 		
// 		
// 		NativeHandle Constructor (nint value);
//
// 		
// 		
// 		NativeHandle Constructor (nuint value);
// 	
// 		
// 		NSNumber FromSByte (sbyte value);
// 	
// 		
// 		
// 		NSNumber FromByte (byte value);
// 	
// 		
// 		
// 		NSNumber FromInt16 (short value);
// 	
// 		
// 		
// 		NSNumber FromUInt16 (ushort value);
// 	
// 		
// 		
// 		NSNumber FromInt32 (int /* int, not NSInteger */ value);
// 	
// 		
// 		
// 		NSNumber FromUInt32 (uint /* unsigned int, not NSUInteger */ value);
//
// 		
// 		
// 		NSNumber FromLong (nint value);
// 		//
// 		
// 		
// 		NSNumber FromUnsignedLong (nuint value);
// 	
// 		
// 		
// 		NSNumber FromInt64 (long value);
// 	
// 		
// 		
// 		NSNumber FromUInt64 (ulong value);
// 	
// 		
// 		
// 		NSNumber FromFloat (float /* float, not CGFloat */ value);
// 	
// 		
// 		
// 		NSNumber FromDouble (double value);
// 	
// 		
// 		
// 		NSNumber FromBoolean (bool value);
//
// 		
// 		
// 		NSNumber FromNInt (nint value);
//
// 		
// 		
// 		NSNumber FromNUInt (nuint value);
// 	}
//
//
// 	
// 	interface NSNumberFormatter {
// 		
// 		string StringFromNumber (NSNumber number);
//
// 		
// 		NSNumber NumberFromString (string text);
//
// 		
// 		
// 		string LocalizedStringFromNumbernumberStyle (NSNumber num, NSNumberFormatterStyle nstyle);
//
// 		//Detected properties
// 		
// 		NSNumberFormatterStyle NumberStyle { get; set; }
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		bool GeneratesDecimalNumbers { get; set; }
//
// 		
// 		NSNumberFormatterBehavior FormatterBehavior { get; set; }
//
// 		
// 		
// 		NSNumberFormatterBehavior DefaultFormatterBehavior { get; set; }
//
// 		
// 		string NegativeFormat { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForNegativeValues { get; set; }
//
// 		
// 		string PositiveFormat { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForPositiveValues { get; set; }
//
// 		
// 		bool AllowsFloats { get; set; }
//
// 		
// 		string DecimalSeparator { get; set; }
//
// 		
// 		bool AlwaysShowsDecimalSeparator { get; set; }
//
// 		
// 		string CurrencyDecimalSeparator { get; set; }
//
// 		
// 		bool UsesGroupingSeparator { get; set; }
//
// 		
// 		string GroupingSeparator { get; set; }
//
// 		 // by default this property is null
// 		
// 		string ZeroSymbol { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForZero { get; set; }
//
// 		
// 		string NilSymbol { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForNil { get; set; }
//
// 		
// 		string NotANumberSymbol { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForNotANumber { get; set; }
//
// 		
// 		string PositiveInfinitySymbol { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForPositiveInfinity { get; set; }
//
// 		
// 		string NegativeInfinitySymbol { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSDictionary TextAttributesForNegativeInfinity { get; set; }
//
// 		
// 		string PositivePrefix { get; set; }
//
// 		
// 		string PositiveSuffix { get; set; }
//
// 		
// 		string NegativePrefix { get; set; }
//
// 		
// 		string NegativeSuffix { get; set; }
//
// 		
// 		string CurrencyCode { get; set; }
//
// 		
// 		string CurrencySymbol { get; set; }
//
// 		
// 		string InternationalCurrencySymbol { get; set; }
//
// 		
// 		string PercentSymbol { get; set; }
//
// 		
// 		string PerMillSymbol { get; set; }
//
// 		
// 		string MinusSign { get; set; }
//
// 		
// 		string PlusSign { get; set; }
//
// 		
// 		string ExponentSymbol { get; set; }
//
// 		
// 		nuint GroupingSize { get; set; }
//
// 		
// 		nuint SecondaryGroupingSize { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSNumber Multiplier { get; set; }
//
// 		
// 		nuint FormatWidth { get; set; }
//
// 		
// 		string PaddingCharacter { get; set; }
//
// 		
// 		NSNumberFormatterPadPosition PaddingPosition { get; set; }
//
// 		
// 		NSNumberFormatterRoundingMode RoundingMode { get; set; }
//
// 		
// 		NSNumber RoundingIncrement { get; set; }
//
// 		
// 		nint MinimumIntegerDigits { get; set; }
//
// 		
// 		nint MaximumIntegerDigits { get; set; }
//
// 		
// 		nint MinimumFractionDigits { get; set; }
//
// 		
// 		nint MaximumFractionDigits { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSNumber Minimum { get; set; }
//
// 		 // by default this property is null
// 		
// 		NSNumber Maximum { get; set; }
//
// 		
// 		string CurrencyGroupingSeparator { get; set; }
//
// 		
// 		bool Lenient { get; set; }
//
// 		
// 		bool UsesSignificantDigits { get; set; }
//
// 		
// 		nuint MinimumSignificantDigits { get; set; }
//
// 		
// 		nuint MaximumSignificantDigits { get; set; }
//
// 		
// 		bool PartialStringValidationEnabled { get; set; }
// 	}
//
// 	
// 	interface NSDecimalNumber : NSSecureCoding {
// 		
// 		NativeHandle Constructor (long mantissa, short exponent, bool isNegative);
// 		
// 		
// 		
// 		NativeHandle Constructor (NSDecimal dec);
//
// 		
// 		NativeHandle Constructor (string numberValue);
//
// 		
// 		NativeHandle Constructor (string numberValue, NSObject locale);
//
// 		
// 		
// 		string DescriptionWithLocale (NSLocale locale);
//
// 		
// 		NSDecimal NSDecimalValue { get; }
//
// 		
// 		NSDecimalNumber Zero { get; }
//
// 		
// 		NSDecimalNumber One { get; }
// 		
// 		
// 		NSDecimalNumber MinValue { get; }
// 		
// 		
// 		NSDecimalNumber MaxValue { get; }
//
// 		
// 		NSDecimalNumber NaN { get; }
//
// 		//
// 		// All the behavior ones require:
// 		// id <NSDecimalNumberBehaviors>)behavior;
//
// 		
// 		NSDecimalNumber Add (NSDecimalNumber d);
//
// 		
// 		NSDecimalNumber Add (NSDecimalNumber d, NSObject Behavior);
//
// 		
// 		NSDecimalNumber Subtract (NSDecimalNumber d);
//
// 		
// 		NSDecimalNumber Subtract (NSDecimalNumber d, NSObject Behavior);
// 		
// 		
// 		NSDecimalNumber Multiply (NSDecimalNumber d);
//
// 		
// 		NSDecimalNumber Multiply (NSDecimalNumber d, NSObject Behavior);
// 		
// 		
// 		NSDecimalNumber Divide (NSDecimalNumber d);
//
// 		
// 		NSDecimalNumber Divide (NSDecimalNumber d, NSObject Behavior);
//
// 		
// 		NSDecimalNumber RaiseTo (nuint power);
//
// 		
// 		NSDecimalNumber RaiseTo (nuint power,  NSObject Behavior);
// 		
// 		
// 		NSDecimalNumber MultiplyPowerOf10 (short power);
//
// 		
// 		NSDecimalNumber MultiplyPowerOf10 (short power,  NSObject Behavior);
//
// 		
// 		NSDecimalNumber Rounding (NSObject behavior);
//
// 		
// 		
// 		nint Compare (NSNumber other);
//
// 		
// 		NSObject DefaultBehavior { get; set; }
//
// 		
// 		
// 		double DoubleValue { get; }
// 	}
//
// 	
// 	
// 	interface NSThread {
// 		
// 		NSThread Current { get; }
//
// 		
// 		string  NativeCallStack { get; }
//
// 		//+ (void)detachNewThreadSelector:(SEL)selector toTarget:(id)target withObject:(id)argument;
//
// 		
// 		bool IsMultiThreaded { get; }
//
// 		//- (NSMutableDictionary *)threadDictionary;
//
// 		
// 		void SleepUntil (NSDate date);
// 		
// 		
// 		void SleepFor (double timeInterval);
//
// 		
// 		void Exit ();
//
// 		
// 		double _GetPriority ();
//
// 		
// 		bool _SetPriority (double priority);
//
// 		//+ (NSArray *)callStackReturnAddresses;
//
// 		 // by default this property is null
// 		
// 		string Name { get; set; }
//
// 		
// 		nuint StackSize { get; set; }
//
// 		
// 		bool IsMainThread { get; }
//
// 		// MainThread is already used for the instance selector and we can't reuse the same name
// 		
// 		
// 		bool IsMain { get; }
//
// 		
// 		
// 		NSThread MainThread { get; }
//
// 		
// 		bool IsExecuting { get; }
//
// 		
// 		bool IsFinished { get; }
//
// 		
// 		bool IsCancelled { get; }
//
// 		
// 		void Cancel ();
//
// 		
// 		void Start ();
//
// 		
// 		void Main ();
//
// 		
// 		
// 		NSQualityOfService QualityOfService { get; set; }
// 			
// 	}
//
// 	
// 	
// 	interface NSPort : NSCoding, NSCopying {
// 		
// 		NSPort Create ();
//
// 		
// 		void Invalidate ();
//
// 		
// 		bool IsValid { get; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSPortDelegate Delegate { get; set; }
//
// 		
// 		void ScheduleInRunLoop (NSRunLoop runLoop, NSString runLoopMode);
//
// 		
// 		void ScheduleInRunLoop (NSRunLoop runLoop, NSRunLoopMode runLoopMode);
//
// 		
// 		void RemoveFromRunLoop (NSRunLoop runLoop, NSString runLoopMode);
//
// 		
// 		void RemoveFromRunLoop (NSRunLoop runLoop, NSRunLoopMode runLoopMode);
//
// 		// Disable warning for NSMutableArray
// #pragma warning disable 618
// 		
// 		bool SendBeforeDate (NSDate limitDate,  NSMutableArray components,  NSPort receivePort, nuint headerSpaceReserved);
//
// 		
// 		bool SendBeforeDate (NSDate limitDate, nuint msgID,  NSMutableArray components,  NSPort receivePort, nuint headerSpaceReserved);
// #pragma warning restore 618
// 	}
//
// 	
// 	
// 	interface NSPortDelegate {
// 		
// 		
// 		void MessageReceived (NSPortMessage message);
// 	}
//
// 	
// 	
// 	interface NSPortMessage {
// 		
// 		
// 		
// 		NativeHandle Constructor (NSPort sendPort, NSPort recvPort, NSArray components);
//
// 		
// 		
// 		NSArray Components { get; }
//
// 		// Apple started refusing applications that use those selectors (desk #63237)
// 		// The situation is a bit confusing since NSPortMessage.h is not part of iOS SDK - 
// 		// but the type is used (from NSPort) but not _itself_ documented
// 		// The selectors Apple *currently* dislike are removed from the iOS build
// 		
// 		
// 		bool SendBefore (NSDate date);
//
// 		
// 		
// 		NSPort ReceivePort { get; }
//
// 		
// 		
// 		NSPort SendPort { get; }
//
// 		
// 		
// 		uint MsgId { get; set; } /* uint32_t */
// 	}
//
// 	
// 	interface NSMachPort {
// 		
// 		
// 		NativeHandle Constructor (uint /* uint32_t */ machPort);
//
// 		
// 		
// 		NativeHandle Constructor (uint /* uint32_t */ machPort, NSMachPortRights options);
// 		
// 		
// 		NSPort FromMachPort (uint /* uint32_t */ port);
//
// 		
// 		NSPort FromMachPort (uint /* uint32_t */ port, NSMachPortRights options);
//
// 		
// 		uint MachPort { get; } /* uint32_t */
//
// 		
// 		
// 		void RemoveFromRunLoop (NSRunLoop runLoop, NSString mode);
//
// 		// note: wrap'ed version using NSRunLoopMode will call the override
//
// 		
// 		
// 		void ScheduleInRunLoop (NSRunLoop runLoop, NSString mode);
//
// 		// note: wrap'ed version using NSRunLoopMode will call the override
//
// 		
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSMachPortDelegate Delegate { get; set; }
// 	}
//
// 	
// 	
// 	interface NSMachPortDelegate {
// 		
// 		void MachMessageReceived (IntPtr msgHeader);
// 	}
//
// 	
// 	interface NSProcessInfo {
// 		
// 		NSProcessInfo ProcessInfo { get; }
//
// 		
// 		string  Arguments { get; }
//
// 		
// 		NSDictionary Environment { get; }
//
// 		
// 		int ProcessIdentifier { get; } /* int, not NSInteger */
//
// 		
// 		string GloballyUniqueString { get; }
//
// 		
// 		string ProcessName { get; set; }
//
// 		
// 		string HostName { get; }
//
// 		
// 		
// 		
// 		nint OperatingSystem { get; }
//
// 		
// 		
// 		
// 		string OperatingSystemName { get; }
//
// 		
// 		string OperatingSystemVersionString { get; }
//
// 		
// 		ulong PhysicalMemory { get; }
// 		
// 		
// 		nint ProcessorCount { get; }
// 		
// 		
// 		nint ActiveProcessorCount { get; }
//
// 		
// 		double SystemUptime { get; }
//
// 		
// 		
// 		NSObject BeginActivity (NSActivityOptions options, string reason);
//
// 		
// 		
// 		void EndActivity (NSObject activity);
//
// 		
// 		
// 		void PerformActivity (NSActivityOptions options, string reason, Action runCode);
//
// 		
// 		
// 		
// 		bool IsOperatingSystemAtLeastVersion (NSOperatingSystemVersion version);
//
// 		
// 		
// 		
// 		NSOperatingSystemVersion OperatingSystemVersion { get; }
// 		
// 		
// 		
// 		void EnableSuddenTermination  ();
//
// 		
// 		
// 		void DisableSuddenTermination ();
//
// 		
// 		
// 		void EnableAutomaticTermination (string reason);
//
// 		
// 		
// 		void DisableAutomaticTermination (string reason);
//
// 		
// 		
// 		bool AutomaticTerminationSupportEnabled { get; set; }
//
// 		
// 		
// 		
// 		void PerformExpiringActivity (string reason, Action<bool> block);
//
// 		
// 		
// 		
// 		bool LowPowerModeEnabled {  get; }
//
// 		
// 		
// 		
// 		
// 		NSString PowerStateDidChangeNotification { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		NSProcessInfoThermalState ThermalState { get; }
//
// 		
// 		
// 		
// 		
// 		
// 		
// 		NSString ThermalStateDidChangeNotification { get; }
//
// #region NSProcessInfoPlatform (NSProcessInfo)
// 		
// 		
// 		bool IsMacCatalystApplication {  get; }
//
// 		
// 		
// 		bool IsiOSApplicationOnMac {  get; }
// #endregion
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSProcessInfo_NSUserInformation {
// 		
// 		string GetUserName ();
//
// 		
// 		string GetFullUserName ();
// 	}
//
// 	
// 	
// 	partial interface NSProgress {
// 	
// 		
// 		NSProgress CurrentProgress { get; }
// 	
// 		
// 		NSProgress FromTotalUnitCount (long unitCount);
//
// 		
// 		
// 		NSProgress GetDiscreteProgress (long unitCount);
//
// 		
// 		
// 		NSProgress FromTotalUnitCount (long unitCount, NSProgress parent, long portionOfParentTotalUnitCount);
// 	
// 		
// 		
// 		NativeHandle Constructor ( NSProgress parentProgress,  NSDictionary userInfo);
// 	
// 		
// 		void BecomeCurrent (long pendingUnitCount);
// 	
// 		
// 		void ResignCurrent ();
// 	
// 		
// 		
// 		void AddChild (NSProgress child, long pendingUnitCount);
//
// 		
// 		long TotalUnitCount { get; set; }
// 	
// 		
// 		long CompletedUnitCount { get; set; }
// 	
// 		
// 		string LocalizedDescription { get; set; }
// 	
// 		
// 		string LocalizedAdditionalDescription { get; set; }
// 	
// 		
// 		bool Cancellable {  get; set; }
// 	
// 		
// 		bool Pausable {  get; set; }
// 	
// 		
// 		bool Cancelled {  get; }
// 	
// 		
// 		bool Paused {  get; }
// 	
// 		
// 		void SetCancellationHandler (Action handler);
// 	
// 		
// 		void SetPauseHandler (Action handler);
//
// 		
// 		
// 		void SetResumingHandler (Action handler);
// 	
// 		
// 		void SetUserInfo ( NSObject obj, NSString key);
// 	
// 		
// 		bool Indeterminate {  get; }
// 	
// 		
// 		double FractionCompleted { get; }
// 	
// 		
// 		void Cancel ();
// 	
// 		
// 		void Pause ();
//
// 		
// 		
// 		void Resume ();
// 	
// 		
// 		NSDictionary UserInfo { get; }
// 	
// 		 // by default this property is null
// 		
// 		NSString Kind { get; set; }
//
// 		
// 		
// 		void Publish ();
// 	
// 		
// 		
// 		void Unpublish ();
// 	
// 		
// 		
// 		void SetAcknowledgementHandler (Action<bool> acknowledgementHandler, string appBundleIdentifier);
// 		
// 		
// 		
// 		NSObject AddSubscriberForFile (NSUrl url, Action<NSProgress> publishingHandler);
// 		
// 		
// 		
// 		void RemoveSubscriber (NSObject subscriber);
//
// 		
// 		
// 		void AcknowledgeWithSuccess (bool success);
//
// 		
// 		
// 		bool Old {  get; }
//
// 		
// 		NSString KindFile { get; }
// 	
// 		
// 		NSString EstimatedTimeRemainingKey { get; }
// 	
// 		
// 		NSString ThroughputKey { get; }
// 	
// 		
// 		NSString FileOperationKindKey { get; }
// 	
// 		
// 		NSString FileOperationKindDownloading { get; }
// 	
// 		
// 		NSString FileOperationKindDecompressingAfterDownloading { get; }
// 	
// 		
// 		NSString FileOperationKindReceiving { get; }
// 	
// 		
// 		NSString FileOperationKindCopying { get; }
//
// 		
// 		
// 		NSString FileOperationKindUploading { get; }
// 	
// 		
// 		NSString FileURLKey { get; }
// 	
// 		
// 		NSString FileTotalCountKey { get; }
// 	
// 		
// 		NSString FileCompletedCountKey { get; }
//
// 		
// 		
// 		NSString FileAnimationImageKey { get; }
// 	
// 		
// 		
// 		NSString FileAnimationImageOriginalRectKey { get; }
// 	
// 		
// 		
// 		NSString FileIconKey { get; }
//
// 		
// 		
// 		void PerformAsCurrent (long unitCount, Action work);
//
// 		
// 		bool Finished {  get; }
//
// 		
// 		
// 		
// 		//
// 		NSNumber _EstimatedTimeRemaining { get; set; }
//
// 		
// 		
// 		
// 		//
// 		NSNumber _Throughput { get; set; }
//
// 		
// 		
// 		string FileOperationKind { get; set; }
//
// 		
// 		
// 		NSUrl FileUrl { get; set; }
//
// 		
// 		
// 		
// 		//
// 		NSNumber _FileTotalCount { get; set; }
//
// 		
// 		
// 		
// 		//
// 		NSNumber _FileCompletedCount { get; set; }
// 	}
//
// 	interface INSProgressReporting {}
//
// 	
// 	
// 	interface NSProgressReporting {
// #if NETXXX
// 		
// #endif
// 		
// 		NSProgress Progress { get; }
// 	}
// 	
// 	
// 	interface NSPurgeableData : NSSecureCoding, NSMutableCopying, NSDiscardableContent {
// 	}
//
// 	
// 	interface NSDiscardableContent {
// 		
// 		
// 		bool BeginContentAccess ();
//
// 		
// 		
// 		void EndContentAccess ();
//
// 		
// 		
// 		void DiscardContentIfPossible ();
//
// 		
// 		
// 		bool IsContentDiscarded { get; }
// 	}
//
// 	delegate void NSFileCoordinatorWorkerRW (NSUrl newReadingUrl, NSUrl newWritingUrl);
//
// 	interface INSFilePresenter {}
//
// 	
// 	interface NSFileCoordinator {
// 		
// 		void AddFilePresenter ( NSFilePresenter filePresenter);
//
// 		
// 		
// 		void RemoveFilePresenter ( NSFilePresenter filePresenter);
//
// 		
// 		
// 		
// 		NSFilePresenter  FilePresenters { get; }
//
// 		
// 		
// 		NativeHandle Constructor ( INSFilePresenter filePresenterOrNil);
//
// #if !NETXXX
// 		
// 		
// 		NativeHandle Constructor ( NSFilePresenter filePresenterOrNil);
// #endif
//
// 		
// 		void CoordinateRead (NSUrl itemUrl, NSFileCoordinatorReadingOptions options, out NSError error, /* non null */ Action<NSUrl> worker);
//
// 		
// 		void CoordinateWrite (NSUrl url, NSFileCoordinatorWritingOptions options, out NSError error, /* non null */ Action<NSUrl> worker);
//
// 		
// 		void CoordinateReadWrite (NSUrl readingURL, NSFileCoordinatorReadingOptions readingOptions, NSUrl writingURL, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ NSFileCoordinatorWorkerRW readWriteWorker);
// 		
// 		
// 		void CoordinateWriteWrite (NSUrl writingURL, NSFileCoordinatorWritingOptions writingOptions, NSUrl writingURL2, NSFileCoordinatorWritingOptions writingOptions2, out NSError error, /* non null */ NSFileCoordinatorWorkerRW writeWriteWorker);
//
// #if !NETXXX
// 		
// 		
// 		void CoordinateBatc (NSUrl  readingURLs, NSFileCoordinatorReadingOptions readingOptions, NSUrl  writingURLs, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ Action batchHandler);
// #endif
//
// 		
// 		void CoordinateBatch (NSUrl  readingURLs, NSFileCoordinatorReadingOptions readingOptions, NSUrl  writingURLs, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ Action batchHandler);
//
// 		
// 		
// 		void CoordinateAccess (NSFileAccessIntent  intents, NSOperationQueue executionQueue, Action<NSError> accessor);
//
// 		
// 		void ItemMoved (NSUrl fromUrl, NSUrl toUrl);
//
// 		
// 		void Cancel ();
//
// 		
// 		void WillMove (NSUrl oldUrl, NSUrl newUrl);
//
// 		
// 		string PurposeIdentifier { get; set; }
//
// 		
// 		
// 		void ItemUbiquityAttributesChanged (NSUrl url, NSSet<NSString> attributes);
// 	}
//
// 	
// 	
// 	
// 	interface NSFileAccessIntent {
// 		
// 		NSUrl Url { get; }
//
// 		
// 		NSFileAccessIntent CreateReadingIntent (NSUrl url, NSFileCoordinatorReadingOptions options);
//
// 		
// 		NSFileAccessIntent CreateWritingIntent (NSUrl url, NSFileCoordinatorWritingOptions options);
// 	}
// 	
// 	
// 	partial interface NSFileManager {
// 		
// 		NSString NSFileType { get; }
//
// 		
// 		NSString TypeDirectory { get; }
//
// 		
// 		NSString TypeRegular { get; }
//
// 		
// 		NSString TypeSymbolicLink { get; }
//
// 		
// 		NSString TypeSocket { get; }
//
// 		
// 		NSString TypeCharacterSpecial { get; }
//
// 		
// 		NSString TypeBlockSpecial { get; }
//
// 		
// 		NSString TypeUnknown { get; }
//
// 		
// 		NSString Size { get; }
//
// 		
// 		NSString ModificationDate { get; }
//
// 		
// 		NSString ReferenceCount { get; }
//
// 		
// 		NSString DeviceIdentifier { get; }
//
// 		
// 		NSString OwnerAccountName { get; }
//
// 		
// 		NSString GroupOwnerAccountName { get; }
//
// 		
// 		NSString PosixPermissions { get; }
//
// 		
// 		NSString SystemNumber { get; }
//
// 		
// 		NSString SystemFileNumber { get; }
//
// 		
// 		NSString ExtensionHidden { get; }
//
// 		
// 		NSString HfsCreatorCode { get; }
//
// 		
// 		NSString HfsTypeCode { get; }
//
// 		
// 		NSString Immutable { get; }
//
// 		
// 		NSString AppendOnly { get; }
//
// 		
// 		NSString CreationDate { get; }
//
// 		
// 		NSString OwnerAccountID { get; }
//
// 		
// 		NSString GroupOwnerAccountID { get; }
//
// 		
// 		NSString Busy { get; }
//
// 		
// 		
// 		NSString FileProtectionKey { get; }
//
// 		
// 		
// 		NSString FileProtectionNone { get; }
//
// 		
// 		
// 		NSString FileProtectionComplete { get; }
//
// 		
// 		
// 		NSString FileProtectionCompleteUnlessOpen { get; }
//
// 		
// 		
// 		NSString FileProtectionCompleteUntilFirstUserAuthentication  { get; }
//
// 		
// 		NSString SystemSize { get; }
//
// 		
// 		NSString SystemFreeSize { get; }
//
// 		
// 		NSString SystemNodes { get; }
//
// 		
// 		NSString SystemFreeNodes { get; }
//
// 		
// 		NSFileManager DefaultManager { get; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		
// 		NSFileManagerDelegate Delegate { get; set; }
//
// 		
// 		bool SetAttributes (NSDictionary attributes, string path, out NSError error);
//
// 		
// 		bool CreateDirectory (string path, bool createIntermediates,  NSDictionary attributes, out NSError error);
//
// 		
// 		string GetDirectoryContent (string path, out NSError error);
//
// 		
// 		string GetDirectoryContentRecursive (string path, out NSError error);
//
// 		
// 		NSDictionary _GetAttributes (string path, out NSError error);
//
// 		
// 		NSDictionary _GetFileSystemAttributes (String path, out NSError error);
//
// 		
// 		bool CreateSymbolicLink (string path, string destPath, out NSError error);
//
// 		
// 		string GetSymbolicLinkDestination (string path, out NSError error);
//
// 		
// 		bool Copy (string srcPath, string dstPath, out NSError error);
//
// 		
// 		bool Move (string srcPath, string dstPath, out NSError error);
//
// 		
// 		bool Link (string srcPath, string dstPath, out NSError error);
//
// 		
// 		bool Remove ( string path, out NSError error);
//
// #if DEPRECATED
// 		// These are not available on iOS, and deprecated on OSX.
// 		
// 		bool LinkPath (string src, string dest, IntPtr handler);
//
// 		
// 		bool CopyPath (string src, string dest, IntPtr handler);
//
// 		
// 		bool MovePath (string src, string dest, IntPtr handler);
//
// 		
// 		bool RemoveFileAtPath (string path, IntPtr handler);
// #endif
// 		
// 		string GetCurrentDirectory ();
//
// 		
// 		bool ChangeCurrentDirectory (string path);
//
// 		
// 		bool FileExists (string path);
//
// 		
// 		bool FileExists (string path, ref bool isDirectory);
//
// 		
// 		bool IsReadableFile (string path);
//
// 		
// 		bool IsWritableFile (string path);
//
// 		
// 		bool IsExecutableFile (string path);
//
// 		
// 		bool IsDeletableFile (string path);
//
// 		
// 		bool ContentsEqual (string path1, string path2);
//
// 		
// 		string DisplayName (string path);
//
// 		
// 		string ComponentsToDisplay (string path);
//
// 		
// 		NSDirectoryEnumerator GetEnumerator (string path);
//
// 		
// 		string Subpaths (string path);
//
// 		
// 		NSData Contents (string path);
//
// 		
// 		bool CreateFile (string path, NSData data,  NSDictionary attr);
//
// 		
// 		NSUrl GetDirectoryContent (NSUrl url,  NSArray properties, NSDirectoryEnumerationOptions options, out NSError error);
//
// 		
// 		bool Copy (NSUrl srcUrl, NSUrl dstUrl, out NSError error);
//
// 		
// 		bool Move (NSUrl srcUrl, NSUrl dstUrl, out NSError error);
//
// 		
// 		bool Link (NSUrl srcUrl, NSUrl dstUrl, out NSError error);
//
// 		
// 		bool Remove ( NSUrl url, out NSError error);
//
// 		
// 		NSDirectoryEnumerator GetEnumerator (NSUrl url,  NSString keys, NSDirectoryEnumerationOptions options,  NSEnumerateErrorHandler handler);
//
// 		
// 		NSUrl GetUrl (NSSearchPathDirectory directory, NSSearchPathDomain domain,  NSUrl url, bool shouldCreate, out NSError error);
//
// 		
// 		NSUrl GetUrls (NSSearchPathDirectory directory, NSSearchPathDomain domains);
//
// 		
// 		bool Replace (NSUrl originalItem, NSUrl newItem,  string backupItemName, NSFileManagerItemReplacementOptions options, out NSUrl resultingURL, out NSError error);
//
// 		
// 		NSUrl GetMountedVolumes ( NSArray properties, NSVolumeEnumerationOptions options);
//
// 		// Methods to convert paths to/from C strings for passing to system calls - Not implemented
// 		////- (const char *)fileSystemRepresentationWithPath:(NSString *)path;
// 		//
// 		//const char FileSystemRepresentationWithPath (string path);
//
// 		////- (NSString *)stringWithFileSystemRepresentation:(const char *)str length:(NSUInteger)len;
// 		//
// 		//string StringWithFileSystemRepresentation (const char str, uint len);
//
// 		
// 		bool CreateDirectory (NSUrl url, bool createIntermediates,  NSDictionary attributes, out NSError error);
//
//                 
//                 bool CreateSymbolicLink (NSUrl url, NSUrl destURL, out NSError error);
//
//                 
//                 bool SetUbiquitous (bool flag, NSUrl url, NSUrl destinationUrl, out NSError error);
//
//                 
//                 bool IsUbiquitous (NSUrl url);
//
//                 
//                 bool StartDownloadingUbiquitous (NSUrl url, out NSError error);
//
//                 
//                 bool EvictUbiquitous (NSUrl url, out NSError error);
//
//                 
//                 NSUrl GetUrlForUbiquityContainer ( string containerIdentifier);
//
//                 
//                 NSUrl GetUrlForPublishingUbiquitousItem (NSUrl url, out NSDate expirationDate, out NSError error);
//
// 		
// 		NSObject UbiquityIdentityToken { get; }
//
// 		
// 		
// 		NSString UbiquityIdentityDidChangeNotification { get; }
//
// 		
// 		
// 		NSUrl GetContainerUrl (string securityApplicationGroupIdentifier);
//
// 		
// 		
// 		bool GetRelationship (out NSUrlRelationship outRelationship, NSSearchPathDirectory directory, NSSearchPathDomain domain, NSUrl toItemAtUrl, out NSError error);
//
// 		
// 		
// 		bool GetRelationship (out NSUrlRelationship outRelationship, NSUrl directoryURL, NSUrl otherURL, out NSError error);
//
// 		
// 		
// 		
// 		void UnmountVolume (NSUrl url, NSFileManagerUnmountOptions mask, Action<NSError> completionHandler);
//
// 		
// 		
// 		void GetFileProviderServices (NSUrl url, Action<NSDictionary<NSString, NSFileProviderService>, NSError> completionHandler);
// 	}
//
// 	
// 	
// 	
// 	interface NSFileManagerDelegate {
// 		
// 		bool ShouldCopyItemAtPath(NSFileManager fm, NSString srcPath, NSString dstPath);
//
// 		
// 		
// 		bool ShouldCopyItemAtUrl(NSFileManager fm, NSUrl srcUrl, NSUrl dstUrl);
// 		
// 		
// 		
// 		bool ShouldLinkItemAtUrl (NSFileManager fileManager, NSUrl srcUrl, NSUrl dstUrl);
//
// 		
// 		
// 		bool ShouldMoveItemAtUrl (NSFileManager fileManager, NSUrl srcUrl, NSUrl dstUrl);
//
// 		
// 		
// 		bool ShouldProceedAfterErrorCopyingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);
//
// 		
// 		
// 		bool ShouldProceedAfterErrorLinkingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);
//
// 		
// 		
// 		bool ShouldProceedAfterErrorMovingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);
//
// 		
// 		
// 		bool ShouldRemoveItemAtUrl (NSFileManager fileManager, NSUrl url);
//
// 		
// 		
// 		bool ShouldProceedAfterErrorRemovingItem (NSFileManager fileManager, NSError error, NSUrl url);
//
// 		
// 		bool ShouldProceedAfterErrorCopyingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);
//
// 		
// 		bool ShouldMoveItemAtPath (NSFileManager fileManager, string srcPath, string dstPath);
//
// 		
// 		bool ShouldProceedAfterErrorMovingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);
//
// 		
// 		bool ShouldLinkItemAtPath (NSFileManager fileManager, string srcPath, string dstPath);
//
// 		
// 		bool ShouldProceedAfterErrorLinkingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);
//
// 		
// 		bool ShouldRemoveItemAtPath (NSFileManager fileManager, string path);
//
// 		
// 		bool ShouldProceedAfterErrorRemovingItem (NSFileManager fileManager, NSError error, string path);
// 	}
//
// 	
// 	
// 	interface NSFileManager_NSUserInformation {
//
// 		
// 		
// 		NSUrl GetHomeDirectoryForCurrentUser ();
//
// 		
// 		
// 		NSUrl GetTemporaryDirectory ();
//
// 		
// 		
// 		
// 		NSUrl GetHomeDirectory (string userName);
// 	}
//
// 	
// 	
// 	
// 	partial interface NSFilePresenter {
// 		
// 		
// #if NETXXX
// 		NSUrl PresentedItemUrl { get; }
// #else
// 		NSUrl PresentedItemURL { get; }
// #endif
//
// 		
// 		
// #if NETXXX
// 		NSOperationQueue PresentedItemOperationQueue { get; }
// #else
// 		NSOperationQueue PesentedItemOperationQueue { get; }
// #endif
//
// #if DOUBLE_BLOCKS
// 		
// 		void RelinquishPresentedItemToReader (NSFilePresenterReacquirer readerAction);
//
// 		
// 		void RelinquishPresentedItemToWriter (NSFilePresenterReacquirer writerAction);
// #endif
//
// 		
// 		void SavePresentedItemChanges (Action<NSError> completionHandler);
//
// 		
// 		void AccommodatePresentedItemDeletion (Action<NSError> completionHandler);
//
// 		
// 		void PresentedItemMoved (NSUrl newURL);
//
// 		
// 		void PresentedItemChanged ();
//
// 		
// 		void PresentedItemGainedVersion (NSFileVersion version);
//
// 		
// 		void PresentedItemLostVersion (NSFileVersion version);
//
// 		
// 		void PresentedItemResolveConflictVersion (NSFileVersion version);
//
// 		
// 		void AccommodatePresentedSubitemDeletion (NSUrl url, Action<NSError> completionHandler);
//
// 		
// 		void PresentedSubitemAppeared (NSUrl atUrl);
//
// 		
// 		void PresentedSubitemMoved (NSUrl oldURL, NSUrl newURL);
//
// 		
// 		void PresentedSubitemChanged (NSUrl url);
//
// 		
// 		void PresentedSubitemGainedVersion (NSUrl url, NSFileVersion version);
//
// 		
// 		void PresentedSubitemLostVersion (NSUrl url, NSFileVersion version);
//
// 		
// 		void PresentedSubitemResolvedConflictVersion (NSUrl url, NSFileVersion version);
//
// 		
// 		
// 		void PresentedItemChangedUbiquityAttributes (NSSet<NSString> attributes);
//
// 		
// 		
// 		NSSet<NSString> PresentedItemObservedUbiquityAttributes { get; }
// 	}
//
// 	delegate void NSFileVersionNonlocalVersionsCompletionHandler ( NSFileVersion nonlocalFileVersions,  NSError error);
//
// 	
// 	// Objective-C exception thrown.  Name: NSGenericException Reason: -: You have to use one of the factory methods to instantiate NSFileVersion.
// 	
// 	interface NSFileVersion {
// 		
// 		NSUrl Url { get;  }
//
// 		
// 		string LocalizedName { get;  }
//
// 		
// 		string LocalizedNameOfSavingComputer { get;  }
//
// 		
// 		NSDate ModificationDate { get;  }
//
// 		
// 		NSObject PersistentIdentifier { get;  }
//
// 		
// 		bool IsConflict {  get;  }
//
// 		
// 		bool Resolved {  get; set;  }
//
// 		
// 		
// 		bool Discardable {  get; set;  }
//
// 		
// 		
// 		
// 		bool HasLocalContents { get; }
//
// 		
// 		
// 		
// 		bool HasThumbnail { get; }
//
// 		
// 		
// 		NSFileVersion GetCurrentVersion (NSUrl url);
//
// 		
// 		
// 		
// 		
// 		
// 		void GetNonlocalVersions (NSUrl url, NSFileVersionNonlocalVersionsCompletionHandler completionHandler);
//
// 		
// 		
// 		NSFileVersion  GetOtherVersions (NSUrl url);
//
// 		
// 		
// 		NSFileVersion  GetUnresolvedConflictVersions (NSUrl url);
//
// 		
// 		
// 		NSFileVersion GetSpecificVersion (NSUrl url, NSObject persistentIdentifier);
//
// 		
// 		
// 		
// 		NSFileVersion AddVersion (NSUrl url, NSUrl contentsURL, NSFileVersionAddingOptions options, out NSError outError);
//
// 		
// 		
// 		
// 		NSUrl TemporaryDirectoryForItem (NSUrl url);
//
// 		
// 		NSUrl ReplaceItem (NSUrl url, NSFileVersionReplacingOptions options, out NSError error);
//
// 		
// 		bool Remove (out NSError outError);
//
// 		
// 		
// 		bool RemoveOtherVersions (NSUrl url, out NSError outError);
//
// 		
// 		
// 		NSPersonNameComponents OriginatorNameComponents { get; }
// 	}
//
// 	
// 	interface NSFileWrapper : NSSecureCoding {
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, NSFileWrapperReadingOptions options, out NSError outError);
//
// 		
// 		
// 		NativeHandle Constructor (NSDictionary childrenByPreferredName);
//
// 		
// 		
// 		NativeHandle Constructor (NSData contents);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrl urlToSymbolicLink);
//
// 		// Constructor clash
// 		//
// 		//NativeHandle Constructor (NSData serializeRepresentation);
//
// 		
// 		bool IsDirectory { get; }
//
// 		
// 		bool IsRegularFile { get; }
//
// 		
// 		bool IsSymbolicLink { get; }
//
// 		
// 		bool MatchesContentsOfURL (NSUrl url);
//
// 		
// 		bool Read (NSUrl url, NSFileWrapperReadingOptions options, out NSError outError);
//
// 		
// 		bool Write (NSUrl url, NSFileWrapperWritingOptions options,  NSUrl originalContentsURL, out NSError outError);
//
// 		
// 		NSData GetSerializedRepresentation ();
//
// 		
// 		string AddFileWrapper (NSFileWrapper child);
//
// 		
// 		string AddRegularFile (NSData dataContents, string preferredFilename);
//
// 		
// 		void RemoveFileWrapper (NSFileWrapper child);
//
// 		
// 		NSDictionary FileWrappers { get; }
//
// 		
// 		string KeyForFileWrapper (NSFileWrapper child);
//
// 		
// 		NSData GetRegularFileContents ();
//
// 		
// 		NSUrl SymbolicLinkDestinationURL { get; }
//
// 		//Detected properties
// 		//  can't be used. It's null by default but, on device, it throws-n-crash
// 		// NSInvalidArgumentException - *** preferredFilename cannot be empty.
// 		
// 		string PreferredFilename { get; set; }
//
// 		 // by default this property is null
// 		
// 		string Filename { get; set; }
//
// 		
// 		NSDictionary FileAttributes { get; set; }
//
// 		
// 		
// 		NSImage Icon { get; set; }
// 	}
//
// 	
// 	interface NSDirectoryEnumerator {
// 		
// 		NSDictionary FileAttributes { get; }
//
// 		
// 		NSDictionary DirectoryAttributes { get; }
//
// 		
// 		void SkipDescendents ();
//
// 		
// 		
// 		nint Level { get; }
//
// 		
// 		
// 		bool IsEnumeratingDirectoryPostOrder { get; }
// 	}
//
// 	delegate bool NSPredicateEvaluator (NSObject evaluatedObject, NSDictionary bindings);
// 	
// 	
// 	// 'init' returns NIL
// 	
// 	interface NSPredicate : NSSecureCoding, NSCopying {
// 		
// 		
// 		
// 		NSPredicate _FromFormat (string predicateFormat,  NSObject arguments);
//
// 		
// 		NSPredicate FromValue (bool value);
//
// 		
// 		NSPredicate FromExpression (NSPredicateEvaluator evaluator);
//
// 		
// 		string PredicateFormat { get; }
//
// 		
// 		NSPredicate PredicateWithSubstitutionVariables (NSDictionary substitutionVariables);
//
// 		
// 		bool EvaluateWithObject (NSObject obj);
//
// 		
// 		bool EvaluateWithObject (NSObject obj, NSDictionary substitutionVariables);
//
// 		
// 		
// 		
// 		
// 		NSPredicate FromMetadataQueryString (string query);
//
// 		
// 		
// 		void AllowEvaluation ();
// 	}
//
// 	
// 	partial interface NSPredicateSupport_NSOrderedSet {
// 		
// 		NSOrderedSet FilterUsingPredicate (NSPredicate p);
// 	}
// 	
// 	
// 	partial interface NSPredicateSupport_NSMutableOrderedSet {
// 		
// 		void FilterUsingPredicate (NSPredicate p);
// 	}
//
// 	
// 	partial interface NSPredicateSupport_NSArray {
// 		
// 		NSArray FilterUsingPredicate (NSArray array);
// 	}
//
// #pragma warning disable 618
// 	
// #pragma warning restore 618
// 	partial interface NSPredicateSupport_NSMutableArray {
// 		
// 		void FilterUsingPredicate (NSPredicate predicate);
// 	}
// 	
// 	
// 	partial interface NSPredicateSupport_NSSet {
// 		
// 		NSSet FilterUsingPredicate (NSPredicate predicate);
// 	}
//
// 	
// 	partial interface NSPredicateSupport_NSMutableSet {
// 		
// 		void FilterUsingPredicate (NSPredicate predicate);
// 	}
// 	
// 	
// 	
// 	interface NSUrlDownload {
// 		
// 		bool CanResumeDownloadDecodedWithEncodingMimeType (string mimeType);
//
// 		
// 		
// 		NativeHandle Constructor (NSUrlRequest request, NSObject delegate1);
//
// 		
// 		
// 		NativeHandle Constructor (NSData resumeData, NSObject delegate1, string path);
//
// 		
// 		void Cancel ();
//
// 		
// 		void SetDestination (string path, bool allowOverwrite);
//
// 		
// 		NSUrlRequest Request { get; }
//
// 		
// 		NSData ResumeData { get; }
//
// 		
// 		bool DeletesFileUponFailure { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSUrlDownloadDelegate {
// 		
// 		void DownloadBegan (NSUrlDownload download);
//
// 		
// 		NSUrlRequest WillSendRequest (NSUrlDownload download, NSUrlRequest request, NSUrlResponse redirectResponse);
//
// 		
// 		void ReceivedAuthenticationChallenge (NSUrlDownload download, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		void CanceledAuthenticationChallenge (NSUrlDownload download, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		void ReceivedResponse (NSUrlDownload download, NSUrlResponse response);
//
// 		//- (void)download:(NSUrlDownload *)download willResumeWithResponse:(NSUrlResponse *)response fromByte:(long long)startingByte;
// 		
// 		void Resume (NSUrlDownload download, NSUrlResponse response, long startingByte);
//
// 		//- (void)download:(NSUrlDownload *)download didReceiveDataOfLength:(NSUInteger)length;
// 		
// 		void ReceivedData (NSUrlDownload download, nuint length);
//
// 		
// 		bool DecodeSourceData (NSUrlDownload download, string encodingType);
//
// 		
// 		void DecideDestination (NSUrlDownload download, string suggestedFilename);
//
// 		
// 		void CreatedDestination (NSUrlDownload download, string path);
//
// 		
// 		void Finished (NSUrlDownload download);
//
// 		
// 		void FailedWithError(NSUrlDownload download, NSError error);
// 	}
//
// 	// Users are not supposed to implement the NSUrlProtocolClient protocol, they're 
// 	// only supposed to consume it. This is why there's no model for this protocol.
// 	
// 	interface NSUrlProtocolClient {
// 		
// 		
// 		void Redirected (NSUrlProtocol protocol, NSUrlRequest redirectedToEequest, NSUrlResponse redirectResponse);
//
// 		
// 		
// 		void CachedResponseIsValid (NSUrlProtocol protocol, NSCachedUrlResponse cachedResponse);
//
// 		
// 		
// 		void ReceivedResponse (NSUrlProtocol protocol, NSUrlResponse response, NSUrlCacheStoragePolicy policy);
//
// 		
// 		
// 		void DataLoaded (NSUrlProtocol protocol, NSData data);
//
// 		
// 		
// 		void FinishedLoading (NSUrlProtocol protocol);
//
// 		
// 		
// 		void FailedWithError (NSUrlProtocol protocol, NSError error);
//
// 		
// 		
// 		void ReceivedAuthenticationChallenge (NSUrlProtocol protocol, NSUrlAuthenticationChallenge challenge);
//
// 		
// 		
// 		void CancelledAuthenticationChallenge (NSUrlProtocol protocol, NSUrlAuthenticationChallenge challenge);
// 	}
//
// 	interface INSUrlProtocolClient {}
//
// 	[BaseType (typeof (NSObject),
// 		   Name="NSURLProtocol",
// 		   Delegates=new string  {"WeakClient"})]
// 	interface NSUrlProtocol {
// 		
// 		
// 		NativeHandle Constructor (NSUrlRequest request,  NSCachedUrlResponse cachedResponse, INSUrlProtocolClient client);
//
// 		
// 		INSUrlProtocolClient Client { get; }
//
// 		
// 		NSUrlRequest Request { get; }
//
// 		
// 		NSCachedUrlResponse CachedResponse { get; }
//
// 		
// 		
// 		bool CanInitWithRequest (NSUrlRequest request);
//
// 		
// 		
// 		NSUrlRequest GetCanonicalRequest (NSUrlRequest forRequest);
//
// 		
// 		
// 		bool IsRequestCacheEquivalent (NSUrlRequest first, NSUrlRequest second);
//
// 		
// 		void StartLoading ();
//
// 		
// 		void StopLoading ();
//
// 		
// 		
// 		NSObject GetProperty (string key, NSUrlRequest inRequest);
//
// 		
// 		
// 		void SetProperty ( NSObject value, string key, NSMutableUrlRequest inRequest);
//
// 		
// 		
// 		void RemoveProperty (string propertyKey, NSMutableUrlRequest request);
//
// 		
// 		
// 		bool RegisterClass (Class protocolClass);
//
// 		
// 		
// 		void UnregisterClass (Class protocolClass);
//
// 		// Commented API are broken and we'll need to provide a workaround for them
// 		// https://trello.com/c/RthKXnyu/381-disabled-nsurlprotocol-api-reminder
//
// 		// * "task" does not answer and is not usable - maybe it only works if created from the new API ?!?
// 		//
// 		// * "canInitWithTask" can't be called as a .NET static method. The ObjC code uses the current type
// 		//    internally (which will always be NSURLProtocol in .NET never a subclass) and complains about it
// 		//    being abstract (which is true)
// 		//    -canInitWithRequest: cannot be sent to an abstract object of class NSURLProtocol: Create a concrete instance!
//
// //		
// //		
// //		NativeHandle Constructor (NSUrlSessionTask task,  NSCachedUrlResponse cachedResponse, INSUrlProtocolClient client);
// //
// //		
// //		
// //		NSUrlSessionTask Task { get; }
// //
// //		
// //		
// //		bool CanInitWithTask (NSUrlSessionTask task);
// 	}
//
// 	
// 	
// 	interface NSPropertyListSerialization {
// 		
// 		NSData DataWithPropertyList (NSObject plist, NSPropertyListFormat format,
// 			NSPropertyListWriteOptions options, out NSError error);
//
// 		
// 		nint WritePropertyList (NSObject plist, NSOutputStream stream, NSPropertyListFormat format,
// 			NSPropertyListWriteOptions options, out NSError error);
//
// 		
// 		NSObject PropertyListWithData (NSData data, NSPropertyListReadOptions options,
// 			ref NSPropertyListFormat format, out NSError error);
//
// 		
// 		NSObject PropertyListWithStream (NSInputStream stream, NSPropertyListReadOptions options,
// 			ref NSPropertyListFormat format, out NSError error);
//
// 		
// 		bool IsValidForFormat (NSObject plist, NSPropertyListFormat format);
// 	}
//
// 	interface INSExtensionRequestHandling { }
//
// 	 // Not defined in 32-bit
// 	
// 	
// 	interface NSExtensionRequestHandling {
// 		
// 		// @required - (void)beginRequestWithExtensionContext:(NSExtensionContext *)context;
// 		
// 		void BeginRequestWithExtensionContext (NSExtensionContext context);
// 	}
//
// 	
// 	interface NSLocking {
//
// 		
// 		
// 		void Lock ();
//
// 		
// 		
// 		void Unlock ();
// 	}
//
// 	
// 	 // An uncaught exception was raised: *** -range cannot be sent to an abstract object of class NSTextCheckingResult: Create a concrete instance!
// 	interface NSTextCheckingResult : NSSecureCoding, NSCopying {
// 		
// 		NSTextCheckingType ResultType { get;  }
//
// 		
// 		NSRange Range { get;  }
//
// 		// From the NSTextCheckingResultOptional category on NSTextCheckingResult
// 		
// 		NSOrthography Orthography { get; }
//
// 		
// 		string GrammarDetails { get; }
//
// 		
// 		NSDate Date { get; }
//
// 		
// 		NSTimeZone TimeZone { get; }
//
// 		
// 		double TimeInterval { get; }
//
// 		
// 		
// 		NSDictionary WeakComponents { get; }
//
// 		
// 		NSTextCheckingTransitComponents Components { get; }
//
// 		
// 		NSUrl Url { get; }
//
// 		
// 		string ReplacementString { get; }
//
// 		
// 		
// 		
// 		string  AlternativeStrings { get; }
//
// //		NSRegularExpression isn't bound
// //		
// //		NSRegularExpression RegularExpression { get; }
//
// 		
// 		string PhoneNumber { get; }
//
// 		
// 		
// 		NSDictionary WeakAddressComponents { get; }
//
// 		
// 		NSTextCheckingAddressComponents AddressComponents { get; }
//
// 		
// 		nuint NumberOfRanges { get; }
//
// 		
// 		NSRange RangeAtIndex (nuint idx);
//
// 		
// 		NSTextCheckingResult ResultByAdjustingRanges (nint offset);
//
// 		// From the NSTextCheckingResultCreation category on NSTextCheckingResult
//
// 		
// 		
// 		NSTextCheckingResult OrthographyCheckingResult (NSRange range, NSOrthography ortography);
//
// 		
// 		
// 		NSTextCheckingResult SpellCheckingResult (NSRange range);
//
// 		
// 		
// 		NSTextCheckingResult GrammarCheckingResult (NSRange range, string details);
//
// 		
// 		
// 		NSTextCheckingResult DateCheckingResult (NSRange range, NSDate date);
//
// 		
// 		
// 		NSTextCheckingResult DateCheckingResult (NSRange range, NSDate date, NSTimeZone timezone, double duration);
//
// 		
// 		
// 		
// 		NSTextCheckingResult AddressCheckingResult (NSRange range, NSDictionary components);
//
// 		
// 		
// 		NSTextCheckingResult AddressCheckingResult (NSRange range, NSTextCheckingAddressComponents components);
//
// 		
// 		
// 		NSTextCheckingResult LinkCheckingResult (NSRange range, NSUrl url);
//
// 		
// 		
// 		NSTextCheckingResult QuoteCheckingResult (NSRange range, NSString replacementString);
//
// 		
// 		
// 		NSTextCheckingResult DashCheckingResult (NSRange range, string replacementString);
//
// 		
// 		
// 		NSTextCheckingResult ReplacementCheckingResult (NSRange range, string replacementString);
//
// 		
// 		
// 		NSTextCheckingResult CorrectionCheckingResult (NSRange range, string replacementString);
//
// 		
// 		
// 		
// 		
// 		NSTextCheckingResult CorrectionCheckingResult (NSRange range, string replacementString, string alternativeStrings);
//
// //		NSRegularExpression isn't bound
// //		
// //		 // FIXME
// //		NSTextCheckingResult RegularExpressionCheckingResult (ref NSRange ranges, nuint count, NSRegularExpression regularExpression);
//
// 		
// 		
// 		NSTextCheckingResult PhoneNumberCheckingResult (NSRange range, string phoneNumber);
//
// 		
// 		
// 		
// 		NSTextCheckingResult TransitInformationCheckingResult (NSRange range, NSDictionary components);
//
// 		
// 		
// 		NSTextCheckingResult TransitInformationCheckingResult (NSRange range, NSTextCheckingTransitComponents components);
//
// 		
// 		
// 		NSRange GetRange (string name);
//
// 	}
//
// 	
// 	interface NSTextCheckingTransitComponents {
// 		string Airline { get; }
//
// 		string Flight { get; }
// 	}
//
// 	
// 	interface NSTextCheckingAddressComponents {
// 		string Name { get; }
//
// 		string JobTitle { get; }
//
// 		string Organization { get; }
//
// 		string Street { get; }
//
// 		string City { get; }
//
// 		string State { get; }
//
// 		
// 		string ZIP { get; }
//
// 		string Country { get; }
//
// 		string Phone { get; }
// 	}
//
// 	
// 	interface NSTextChecking {
// 		
// 		NSString NameKey { get; }
//
// 		
// 		NSString JobTitleKey { get; }
//
// 		
// 		NSString OrganizationKey { get; }
//
// 		
// 		NSString StreetKey { get; }
//
// 		
// 		NSString CityKey { get; }
//
// 		
// 		NSString StateKey { get; }
//
// 		
// 		NSString ZipKey { get; }
//
// 		
// 		NSString CountryKey { get; }
//
// 		
// 		NSString PhoneKey { get; }
//
// 		
// 		NSString AirlineKey { get; }
//
// 		
// 		NSString FlightKey { get; }
// 	}
//
// 	
// 	interface NSLock : NSLocking
// 	{
// 		
// 		bool TryLock (); 
//
// 		
// 		bool LockBeforeDate (NSDate limit);
//
// 		
// 		
// 		string Name { get; set; }
// 	}
//
// 	
// 	interface NSConditionLock : NSLocking {
//
// 		
// 		
// 		NativeHandle Constructor (nint condition);
//
// 		
// 		nint Condition { get; }
//
// 		
// 		void LockWhenCondition (nint condition);
//
// 		
// 		bool TryLock (); 
//
// 		
// 		bool TryLockWhenCondition (nint condition);
//
// 		
// 		void UnlockWithCondition (nint condition);
//
// 		
// 		bool LockBeforeDate (NSDate limit);
//
// 		
// 		bool LockWhenCondition (nint condition, NSDate limit);
//
// 		
// 		
// 		string Name { get; set; }
// 	}
//
// 	
// 	interface NSRecursiveLock : NSLocking
// 	{
// 		
// 		bool TryLock (); 
//
// 		
// 		bool LockBeforeDate (NSDate limit);
//
// 		
// 		
// 		string Name { get; set; }
// 	}
//
// 	
// 	interface NSCondition : NSLocking
// 	{
// 		
// 		void Wait ();
//
// 		
// 		bool WaitUntilDate (NSDate limit);
//
// 		
// 		void Signal ();
//
// 		
// 		void Broadcast ();
//
// 		
// 		
// 		string Name { get; set; }
// 	}
//
// // Not yet, the IntPtr argument isn't handled correctly by the generator (it tries to convert to NSArray, while the native method expects a C array).
// //	
// //	interface NSFastEnumeration {
// //		
// //		
// //		nuint Enumerate (ref NSFastEnumerationState state, IntPtr objects, nuint count);
// //	}
//
// 	// Placeholer, just so we can start flagging things
// 	interface INSFastEnumeration {}
// 		
// 	partial interface NSBundle {
// 		// - (NSImage *)imageForResource:(NSString *)name NS_AVAILABLE_MAC(10_7);
// 		
// 		
// 		NSImage ImageForResource (string name);
// 	}
//
// 	partial interface NSAttributedString {
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSString TextLayoutSectionOrientation { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSString TextLayoutSectionRange { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		NSString TextLayoutSectionsAttribute { get; }
//
// 		
// 		
// 		
// 		nint UnderlineByWordMaskAttributeName { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		
// 		NSString TextScalingDocumentAttribute { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		
// 		NSString SourceTextScalingDocumentAttribute { get; }
//
// #if MONOMAC
// 		
// #else
// 		
// #endif
// 		
// 		
// 		NSString CocoaVersionDocumentAttribute { get; }
// 	}
//
// 	
// 	
// 	interface NSDateInterval : NSCopying, NSSecureCoding {
// 		
// 		NSDate StartDate { get; }
//
// 		
// 		NSDate EndDate { get; }
//
// 		
// 		double Duration { get; }
//
// 		
// 		
// 		NativeHandle Constructor (NSDate startDate, double duration);
//
// 		
// 		NativeHandle Constructor (NSDate startDate, NSDate endDate);
//
// 		
// 		NSComparisonResult Compare (NSDateInterval dateInterval);
//
// 		
// 		bool IsEqualTo (NSDateInterval dateInterval);
//
// 		
// 		bool Intersects (NSDateInterval dateInterval);
//
// 		
// 		
// 		NSDateInterval GetIntersection (NSDateInterval dateInterval);
//
// 		
// 		bool ContainsDate (NSDate date);
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnit : NSCopying, NSSecureCoding {
// 		
// 		string Symbol { get; }
//
// 		
// 		
// 		NativeHandle Constructor (string symbol);
// 	}
//
// 	
// 	
// 	interface NSUnitConverter {
// 		
// 		double GetBaseUnitValue (double value);
//
// 		
// 		double GetValue (double baseUnitValue);
// 	}
//
// 	
// 	
// 	interface NSUnitConverterLinear : NSSecureCoding {
//
// 		
// 		double Coefficient { get; }
//
// 		
// 		double Constant { get; }
//
// 		
// 		NativeHandle Constructor (double coefficient);
//
// 		
// 		
// 		NativeHandle Constructor (double coefficient, double constant);
// 	}
//
// 	
// 	
// 	 // abstract subclass of NSUnit
// 	 // there's a designated initializer
// 	interface NSDimension : NSSecureCoding {
// 		// Inlined from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol);
//
// 		
// 		NSUnitConverter Converter { get; }
//
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		// needs to be overriden in suubclasses
// 		//	NSInvalidArgumentException Reason: *** You must override baseUnit in your class NSDimension to define its base unit.
// 		// we provide a basic, managed, implementation that throws with a similar message
// 		//
// 		//
// 		//NSDimension BaseUnit { get; }
// 	}
//
// 	
// 	
// 	 // base type has a designated initializer
// 	interface NSUnitTemperature : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitTemperature Kelvin { get; }
//
// 		
// 		
// 		NSUnitTemperature Celsius { get; }
//
// 		
// 		
// 		NSUnitTemperature Fahrenheit { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	partial interface NSFileManager {
//
// 		
// 		
// 		bool TrashItem (NSUrl url, out NSUrl resultingItemUrl, out NSError error);
//
// 		
// 		
// 		
// 		
// 		NSFileManager FromAuthorization (NSWorkspaceAuthorization authorization);
// 	}
//
// 	
// 	
// 	
// 	interface NSFileProviderService
// 	{
// 		
// 		string Name { get; }
// 	}
//
// #if MONOMAC
// 	partial interface NSFilePresenter {
// 		
// 		
// 		NSUrl PrimaryPresentedItemUrl { get; }
// 	}
//
// 	
// 	partial interface NSAttributedString {
// 		
// 		
// 		CGRect BoundingRectWithSize (CGSize size, NSStringDrawingOptions options);
// 	}
//
// 	
// 	
// 	
// 	partial interface NSHost {
//
// 		
// 		NSHost _Current { get;}
//
// 		
// 		NSHost _FromName (string name);
//
// 		
// 		NSHost _FromAddress (string address);
//
// 		
// 		bool Equals ( NSHost host);
//
// 		
// 		string Name { get; }
//
// 		
// 		string LocalizedName { get; }
//
// 		
// 		string  Names { get; }
//
// 		
// 		string _Address { get; }
//
// 		
// 		string  _Addresses  { get; }
//
// 		
// 		nuint _Hash { get; }
//
// 		/* Deprecated, here for completeness:
//
// 		
// 		
// 		void SetHostCacheEnabled (bool flag);
//
// 		
// 		
// 		bool IsHostCacheEnabled ();
//
// 		
// 		
// 		void FlushHostCache ();
// 		*/
// 	}
// #endif
//
// 	
// 	
// 	
// 	
// 	partial interface NSScriptCommand : NSCoding {
//
// 		
// 		
// 		
// 		NativeHandle Constructor (NSScriptCommandDescription cmdDescription);
//
// 		
// 		
// 		
// 		IntPtr GetCurrentCommand ();
//
// 		
// 		NSAppleEventDescriptor AppleEvent { get; }
//
// 		
// 		IntPtr Execute ();
// 		
// 		
// 		NSObject EvaluatedReceivers { get; }
// 	}
//
// 	
// 	
// 	
// 	partial interface NSScriptCommandArgumentDescription {
// 		string AppleEventCode { get; set; }
// 		string Type { get; set;}
// 		string Optional { get; set; }
// 	}
//
// 	
// 	
// 	
// 	partial interface NSScriptCommandDescriptionDictionary {
// 		string CommandClass { get; set; } 
// 		string AppleEventCode { get; set; } 
// 		string AppleEventClassCode { get; set; }
// 		string Type { get; set;}
// 		string ResultAppleEventCode { get; set; }
// 		NSMutableDictionary Arguments { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	partial interface NSScriptCommandDescription : NSCoding {
//
// 		
// 		
// 		
// 		NativeHandle Constructor (NSString suiteName, NSString commandName, NSDictionary commandDeclaration);
//
// 		
// 		
// 		int FCCAppleEventClassCode { get; }
//
// 		
// 		
// 		int FCCAppleEventCode { get; }
//
// 		
// 		string ClassName { get; }
//
// 		
// 		string Name { get; }
//
// 		
// 		string SuitName { get; }
//
// 		
// 		
// 		int FCCAppleEventCodeForArgument (NSString name);
//
// 		
// 		string  ArgumentNames { get; }
//
// 		
// 		
// 		bool NSIsOptionalArgument (NSString name);
//
// 		
// 		
// 		NSString GetNSTypeForArgument (NSString name);
//
// 		
// 		
// 		int FCCAppleEventCodeForReturnType { get; }
//
// 		
// 		string ReturnType { get; }
//
// 		
// 		
// 		IntPtr CreateCommandInstancePtr ();
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSAffineTransform : NSSecureCoding, NSCopying {
// 		
// 		NativeHandle Constructor (NSAffineTransform transform);
//
// 		
// 		void Translate (nfloat deltaX, nfloat deltaY);
//
// 		
// 		void RotateByDegrees (nfloat angle);
//
// 		
// 		void RotateByRadians (nfloat angle);
//
// 		
// 		void Scale (nfloat scale);
//
// 		
// 		void Scale (nfloat scaleX, nfloat scaleY);
//
// 		
// 		void Invert ();
//
// 		
// 		void AppendTransform (NSAffineTransform transform);
//
// 		
// 		void PrependTransform (NSAffineTransform transform);
//
// 		
// 		CGPoint TransformPoint (CGPoint aPoint);
//
// 		
// 		CGSize TransformSize (CGSize aSize);
// 		
// 		
// 		
// 		NSBezierPath TransformBezierPath (NSBezierPath path);
//
// 		
// 		void Set ();
//
// 		
// 		void Concat ();
//
// 		
// 		CGAffineTransform TransformStruct { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	
// 	interface NSConnection {
// 		
// 		NSConnection Create ( NSPort receivePort,  NSPort sendPort);
//
// 		
// 		void RunInNewThread ();
//
// 		// enableMultipleThreads, multipleThreadsEnabled - no-op in 10.5+ (always enabled)
//
// 		
// 		void AddRunLoop (NSRunLoop runLoop);
//
// 		
// 		void RemoveRunLoop (NSRunLoop runLoop);
//
// 		
// 		NSConnection CreateService (string name, NSObject root, NSPortNameServer server);
//
// 		
// 		NSConnection CreateService (string name, NSObject root);
//
// 		
// 		bool RegisterName (string name);
//
// 		
// 		bool RegisterName (string name, NSPortNameServer server);
//
// 		
// 		NSObject RootObject { get; set; }
//
// 		
// 		NSConnection LookupService (string name,  string hostName);
//
// 		
// 		NSConnection LookupService (string name,  string hostName, NSPortNameServer server);
//
// 		
// 		IntPtr _GetRootProxy ();
//
// 		
// 		IntPtr _GetRootProxy (string name,  string hostName);
//
// 		
// 		IntPtr _GetRootProxy (string name,  string hostName, NSPortNameServer server);
//
// 		
// 		NSObject  RemoteObjects { get; }
//
// 		
// 		NSObject  LocalObjects { get; }
//
// 		
// 		NSObject CurrentConversation { get; }
//
// 		
// 		NSConnection  AllConnections { get; }
//
// 		
// 		NSTimeInterval RequestTimeout { get; set; }
//
// 		
// 		NSTimeInterval ReplyTimeout { get; set; }
//
// 		
// 		bool IndependentConversationQueueing { get; set; }
//
// 		
// 		void AddRequestMode (NSString runLoopMode);
//
// 		
// 		void RemoveRequestMode (NSString runLoopMode);
//
// 		
// 		NSString  RequestModes { get; }
//
// 		
// 		void Invalidate ();
//
// 		
// 		bool IsValid { get; }
//
// 		
// 		NSPort ReceivePort { get; }
//
// 		
// 		NSPort SendPort { get; }
//
// 		
// 		void Dispatch (NSArray components);
//
// 		
// 		NSDictionary Statistics { get; }
//
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		
// 		NSConnectionDelegate Delegate { get; set; }
// 	}
//
// 	
// 	
// 	
// 	
// 	
// 	
// 	interface NSConnectionDelegate {
// 		
// 		bool AuthenticateComponents (NSArray components, NSData authenticationData);
//
// 		
// 		NSData GetAuthenticationData (NSArray components);
//
// 		
// 		bool ShouldMakeNewConnection (NSConnection parentConnection, NSConnection newConnection);
//
// 		
// 		bool HandleRequest (NSConnection connection, NSDistantObjectRequest request);
//
// 		
// 		NSObject CreateConversation (NSConnection connection);
//
// 		
// 		bool AllowNewConnection (NSConnection newConnection, NSConnection parentConnection);
// 	}
//
// 	
// 	
// 	
// 	
// 	
// 	interface NSDistantObjectRequest {
// 		
// 		NSConnection Connection { get; }
//
// 		
// 		NSObject Conversation { get; }
//
// 		
// 		NSInvocation Invocation { get; }
//
// 		
// 		void Reply ( NSException exception);
// 	}
//
// 	
// 	
// 	
// 	
// 	
// 	interface NSPortNameServer {
// 		
// 		NSPortNameServer SystemDefault { get; }
//
// 		
// 		NSPort GetPort (string portName);
//
// 		
// 		NSPort GetPort (string portName, string hostName);
//
// 		
// 		bool RegisterPort (NSPort port, string portName);
//
// 		
// 		bool RemovePort (string portName);
// 	}
//
// 	
// 	
// 	
// 	interface NSAppleEventDescriptor : NSSecureCoding, NSCopying {
// 		
// 		
// 		NSAppleEventDescriptor NullDescriptor { get; }
//
// 		/*		
// 		
// 		NSAppleEventDescriptor DescriptorWithDescriptorTypebyteslength (DescType descriptorType, void bytes, uint byteCount);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithDescriptorTypedata (DescType descriptorType, NSData data);*/
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithBoolean (Boolean boolean);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithEnumCode (OSType enumerator);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithInt32 (int /* int32 */ signedInt);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithTypeCode (OSType typeCode);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorWithString (string str);
//
// 		/*
// 		
// 		NSAppleEventDescriptor AppleEventWithEventClasseventIDtargetDescriptorreturnIDtransactionID (AEEventClass eventClass, AEEventID eventID, NSAppleEventDescriptor targetDescriptor, AEReturnID returnID, AETransactionID transactionID);*/
//
// 		
// 		
// 		NSAppleEventDescriptor ListDescriptor { get; }
//
// 		
// 		
// 		NSAppleEventDescriptor RecordDescriptor { get; }
//
// 		/*
// 		NSObject InitWithAEDescNoCopy (const AEDesc aeDesc);
//
// 		
// 		NSObject InitWithDescriptorTypebyteslength (DescType descriptorType, void bytes, uint byteCount);
//
// 		
// 		NSObject InitWithDescriptorTypedata (DescType descriptorType, NSData data);
//
// 		
// 		NSObject InitWithEventClasseventIDtargetDescriptorreturnIDtransactionID (AEEventClass eventClass, AEEventID eventID, NSAppleEventDescriptor targetDescriptor, AEReturnID returnID, AETransactionID transactionID);*/
//
// 		
// 		
// 		
// 		IntPtr _InitListDescriptor ();
//
// 		
// 		
// 		
// 		IntPtr _InitRecordDescriptor ();
//
// #if !XAMCORE_3_0
// 		
// 		
// 		NSObject InitListDescriptor ();
//
// 		
// 		
// 		NSObject InitRecordDescriptor ();
// #endif
//
// 		/*
// 		const AEDesc AeDesc ();
//
// 		
// 		DescType DescriptorType ();*/
//
// 		
// 		NSData Data { get; }
//
// 		
// 		Boolean BooleanValue { get; }
//
// 		
// 		OSType EnumCodeValue ();
//
// 		
// 		Int32 Int32Value { get; }
//
// 		
// 		OSType TypeCodeValue { get; }
//
// 		
// 		
// 		string StringValue { get; }
//
// 		
// 		AEEventClass EventClass { get; }
//
// 		
// 		AEEventID EventID { get; }
//
// 		/*
// 		AEReturnID ReturnID ();
//
// 		
// 		AETransactionID TransactionID ();*/
//
// 		
// 		void SetParamDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);
//
// 		
// 		
// 		NSAppleEventDescriptor ParamDescriptorForKeyword (AEKeyword keyword);
//
// 		
// 		void RemoveParamDescriptorWithKeyword (AEKeyword keyword);
//
// 		
// 		void SetAttributeDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);
//
// 		
// 		
// 		NSAppleEventDescriptor AttributeDescriptorForKeyword (AEKeyword keyword);
//
// 		
// 		nint NumberOfItems { get; }
//
// 		
// 		void InsertDescriptoratIndex (NSAppleEventDescriptor descriptor, nint index);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorAtIndex (nint index);
//
// 		
// 		void RemoveDescriptorAtIndex (nint index);
//
// 		
// 		void SetDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);
//
// 		
// 		
// 		NSAppleEventDescriptor DescriptorForKeyword (AEKeyword keyword);
//
// 		
// 		void RemoveDescriptorWithKeyword (AEKeyword keyword);
//
// 		
// 		AEKeyword KeywordForDescriptorAtIndex (nint index);
//
// 		/*
// 		NSAppleEventDescriptor CoerceToDescriptorType (DescType descriptorType);*/
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor CurrentProcessDescriptor { get; }
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromDouble (double doubleValue);
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromDate (NSDate date);
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromFileURL (NSUrl fileURL);
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromProcessIdentifier (int processIdentifier);
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromBundleIdentifier (string bundleIdentifier);
//
// 		
// 		
// 		
// 		NSAppleEventDescriptor FromApplicationURL (NSUrl applicationURL);
//
// 		
// 		
// 		double DoubleValue { get; }
//
// 		
// 		
// 		
// 		
// 		NSAppleEventDescriptor SendEvent (NSAppleEventSendOptions sendOptions, double timeoutInSeconds,  out NSError error);
//
// 		
// 		
// 		bool IsRecordDescriptor { get; }
//
// 		
// 		
// 		NSDate DateValue { get; }
//
// 		
// 		
// 		NSUrl FileURLValue { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSAppleEventManager {
// 		
// 		
// 		NSAppleEventManager SharedAppleEventManager { get; }
//
// 		
// 		void SetEventHandler (NSObject handler, Selector handleEventSelector, AEEventClass eventClass, AEEventID eventID);
//
// 		
// 		void RemoveEventHandler (AEEventClass eventClass, AEEventID eventID);
//
// 		
// 		
// 		NSAppleEventDescriptor CurrentAppleEvent { get; }
//
// 		
// 		
// 		NSAppleEventDescriptor CurrentReplyAppleEvent { get; }
//
// 		
// 		NSAppleEventManagerSuspensionID SuspendCurrentAppleEvent ();
//
// 		
// 		NSAppleEventDescriptor AppleEventForSuspensionID (NSAppleEventManagerSuspensionID suspensionID);
//
// 		
// 		NSAppleEventDescriptor ReplyAppleEventForSuspensionID (NSAppleEventManagerSuspensionID suspensionID);
//
// 		
// 		void SetCurrentAppleEventAndReplyEventWithSuspensionID (NSAppleEventManagerSuspensionID suspensionID);
//
// 		
// 		void ResumeWithSuspensionID (NSAppleEventManagerSuspensionID suspensionID);
//
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSTask {
// 		
// 		
// 		
// 		void Launch ();
//
// 		
// 		void Interrupt ();
//
// 		
// 		void Terminate ();
//
// 		
// 		bool Suspend ();
//
// 		
// 		bool Resume ();
//
// 		
// 		void WaitUntilExit ();
//
// 		
// 		
// 		
// 		NSTask LaunchFromPath (string path, string arguments);
//
// 		//Detected properties
// 		
// 		
// 		
// 		
// 		string LaunchPath { get; set; }
//
// 		
// 		
// 		string  Arguments { get; set; }
//
// 		
// 		
// 		NSDictionary Environment { get; set; }
//
// 		
// 		
// 		
// 		string CurrentDirectoryPath { get; set; }
//
// 		
// 		
// 		NSObject StandardInput { get; set; }
//
// 		
// 		
// 		NSObject StandardOutput { get; set; }
//
// 		
// 		
// 		NSObject StandardError { get; set; }
//
// 		
// 		bool IsRunning { get; }
//
// 		
// 		int ProcessIdentifier { get; } /* pid_t = int */
//
// 		
// 		int TerminationStatus { get; } /* int, not NSInteger */
//
// 		
// 		
// 		NSTaskTerminationReason TerminationReason { get; }
//
// #if !NETXXX && MONOMAC
// 		
// 		NSString NSTaskDidTerminateNotification { get; }
// #endif
//
// 		
// 		
// 		NSString DidTerminateNotification { get; }
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSUserNotification : NSCoding, NSCopying {
// 		
// 		string Title { get; set; }
// 		
// 		
// 		string Subtitle { get; set; }
// 		
// 		
// 		string InformativeText { get; set; }
// 		
// 		
// 		string ActionButtonTitle { get; set; }
// 		
// 		
// 		NSDictionary UserInfo { get; set; }
// 		
// 		
// 		NSDate DeliveryDate { get; set; }
// 		
// 		
// 		NSTimeZone DeliveryTimeZone { get; set; }
// 		
// 		
// 		NSDateComponents DeliveryRepeatInterval { get; set; }
// 		
// 		
// 		NSDate ActualDeliveryDate { get; }
// 		
// 		
// 		bool Presented {  get; }
// 		
// 		
// 		bool Remote {  get; }
// 		
// 		
// 		string SoundName { get; set; }
// 		
// 		
// 		bool HasActionButton { get; set; }
// 		
// 		
// 		NSUserNotificationActivationType ActivationType { get; }
// 		
// 		
// 		string OtherButtonTitle { get; set; }
//
// 		
// 		NSString NSUserNotificationDefaultSoundName { get; }
//
// 		
// 		
// 		string Identifier { get; set; }
//
// 		
// 		
// 		NSImage ContentImage { get; set; }
//
// 		
// 		
// 		bool HasReplyButton { get; set; }
//
// 		
// 		
// 		string ResponsePlaceholder { get; set; }
//
// 		
// 		
// 		NSAttributedString Response { get; }
//
// 		
// 		
// 		NSUserNotificationAction AdditionalActions { get; set; }
//
// 		
// 		
// 		NSUserNotificationAction AdditionalActivationAction { get; }
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSUserNotificationAction : NSCopying
// 	{
// 		
// 		
// 		NSUserNotificationAction GetAction ( string identifier,  string title);
//
// 		
// 		string Identifier { get; }
//
// 		
// 		string Title { get; }
// 	}
// 	
// 	
// 	[BaseType (typeof (NSObject),
// 	           Delegates=new string  {"WeakDelegate"},
// 	Events=new Type  { typeof (NSUserNotificationCenterDelegate) })]
// 	 // crash with: NSUserNotificationCenter designitated initializer is _centerForBundleIdentifier
// 	
// 	interface NSUserNotificationCenter 
// 	{
// 		
// 		NSUserNotificationCenter DefaultUserNotificationCenter { get; }
// 		
// 		
// 		NSObject WeakDelegate { get; set; }
// 		
// 		
// 		
// 		NSUserNotificationCenterDelegate Delegate { get; set; }
// 		
// 		
// 		NSUserNotification  ScheduledNotifications { get; set; }
// 		
// 		
// 		void ScheduleNotification (NSUserNotification notification);
// 		
// 		
// 		void RemoveScheduledNotification (NSUserNotification notification);
// 		
// 		
// 		NSUserNotification  DeliveredNotifications { get; }
// 		
// 		
// 		void DeliverNotification (NSUserNotification notification);
// 		
// 		
// 		void RemoveDeliveredNotification (NSUserNotification notification);
// 		
// 		
// 		void RemoveAllDeliveredNotifications ();
// 	}
// 	
// 	
// 	
// 	
// 	
// 	
// 	interface NSUserNotificationCenterDelegate 
// 	{
// 		
// 		void DidDeliverNotification (NSUserNotificationCenter center, NSUserNotification notification);
// 		
// 		
// 		void DidActivateNotification (NSUserNotificationCenter center, NSUserNotification notification);
// 		
// 		
// 		bool ShouldPresentNotification (NSUserNotificationCenter center, NSUserNotification notification);
// 	}
//
// 	
// 	
// 	
// 	
// 	interface NSAppleScript : NSCopying {
//
// 		// @required - (instancetype)initWithContentsOfURL:(NSURL *)url error:(NSDictionary **)errorInfo;
// 		
// 		
// 		NativeHandle Constructor (NSUrl url, out NSDictionary errorInfo);
//
// 		// @required - (instancetype)initWithSource:(NSString *)source;
// 		
// 		
// 		NativeHandle Constructor (string source);
//
// 		// @property (readonly, copy) NSString * source;
// 		
// 		
// 		string Source { get; }
//
// 		// @property (readonly, getter = isCompiled) BOOL compiled;
// 		
// 		bool Compiled {  get; }
//
// 		// @required - (BOOL)compileAndReturnError:(NSDictionary **)errorInfo;
// 		
// 		bool CompileAndReturnError (out NSDictionary errorInfo);
//
// 		// @required - (NSAppleEventDescriptor *)executeAndReturnError:(NSDictionary **)errorInfo;
// 		
// 		NSAppleEventDescriptor ExecuteAndReturnError (out NSDictionary errorInfo);
//
// 		// @required - (NSAppleEventDescriptor *)executeAppleEvent:(NSAppleEventDescriptor *)event error:(NSDictionary **)errorInfo;
// 		
// 		NSAppleEventDescriptor ExecuteAppleEvent (NSAppleEventDescriptor eventDescriptor, out NSDictionary errorInfo);
//
// 		
// 		
// 		NSAttributedString RichTextSource { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSIso8601DateFormatter : NSSecureCoding {
//
// 		
// 		NSTimeZone TimeZone { get; set; }
//
// 		
// 		NSIso8601DateFormatOptions FormatOptions { get; set; }
//
// 		
// 		string ToString (NSDate date);
//
// 		
// 		
// 		NSDate ToDate (string @string);
//
// 		
// 		
// 		string Format (NSDate date, NSTimeZone timeZone, NSIso8601DateFormatOptions formatOptions);
// 	}
// 	
// 	
// 	
// 	
// 	interface NSUrlSessionTaskTransactionMetrics {
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		NSUrlRequest Request { get; }
//
// 		
// 		NSUrlResponse Response { get; }
//
// 		
// 		NSDate FetchStartDate { get; }
//
// 		
// 		NSDate DomainLookupStartDate { get; }
//
// 		
// 		NSDate DomainLookupEndDate { get; }
//
// 		
// 		NSDate ConnectStartDate { get; }
//
// 		
// 		NSDate SecureConnectionStartDate { get; }
//
// 		
// 		NSDate SecureConnectionEndDate { get; }
//
// 		
// 		NSDate ConnectEndDate { get; }
//
// 		
// 		NSDate RequestStartDate { get; }
//
// 		
// 		NSDate RequestEndDate { get; }
//
// 		
// 		NSDate ResponseStartDate { get; }
//
// 		
// 		NSDate ResponseEndDate { get; }
//
// 		
// 		string NetworkProtocolName { get; }
//
// 		
// 		bool ProxyConnection {  get; }
//
// 		
// 		bool ReusedConnection {  get; }
//
// 		
// 		NSUrlSessionTaskMetricsResourceFetchType ResourceFetchType { get; }
//
// 		
// 		
// 		long CountOfRequestHeaderBytesSent { get; }
//
// 		
// 		
// 		long CountOfRequestBodyBytesSent { get; }
//
// 		
// 		
// 		long CountOfRequestBodyBytesBeforeEncoding { get; }
//
// 		
// 		
// 		long CountOfResponseHeaderBytesReceived { get; }
//
// 		
// 		
// 		long CountOfResponseBodyBytesReceived { get; }
//
// 		
// 		
// 		long CountOfResponseBodyBytesAfterDecoding { get; }
//
// 		
// 		
// 		string LocalAddress { get; }
//
// 		
// 		
// 		// 0-1023
// 		
// 		NSNumber LocalPort { get; }
//
// 		
// 		
// 		string RemoteAddress { get; }
//
// 		
// 		
// 		// 0-1023
// 		
// 		NSNumber RemotePort { get; }
//
// 		
// 		
// 		// <quote>It is a 2-byte sequence in host byte order.</quote> but it refers to (nicer) `tls_protocol_version_t`
// 		
// 		NSNumber NegotiatedTlsProtocolVersion { get; }
//
// 		
// 		
// 		// <quote>It is a 2-byte sequence in host byte order.</quote> but it refers to (nicer) `tls_ciphersuite_t`
// #if NETXXX
// 		
// #else
// 		
// #endif
// 		NSNumber NegotiatedTlsCipherSuite { get; }
//
// 		
// 		
// 		bool Cellular {  get; }
//
// 		
// 		
// 		bool Expensive {  get; }
//
// 		
// 		
// 		bool Constrained {  get; }
//
// 		
// 		
// 		bool Multipath {  get; }
//
// 		
// 		
// 		NSUrlSessionTaskMetricsDomainResolutionProtocol DomainResolutionProtocol { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlSessionTaskMetrics {
//
// 		
// 		
// 		
// 		
// 		
// 		NativeHandle Constructor ();
//
// 		
// 		NSUrlSessionTaskTransactionMetrics TransactionMetrics { get; }
//
// 		
// 		NSDateInterval TaskInterval { get; }
//
// 		
// 		nuint RedirectCount { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitAcceleration : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitAcceleration MetersPerSecondSquared { get; }
//
// 		
// 		
// 		NSUnitAcceleration Gravity { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitAngle : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitAngle Degrees { get; }
//
// 		
// 		
// 		NSUnitAngle ArcMinutes { get; }
//
// 		
// 		
// 		NSUnitAngle ArcSeconds { get; }
//
// 		
// 		
// 		NSUnitAngle Radians { get; }
//
// 		
// 		
// 		NSUnitAngle Gradians { get; }
//
// 		
// 		
// 		NSUnitAngle Revolutions { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitArea : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitArea SquareMegameters { get; }
//
// 		
// 		
// 		NSUnitArea SquareKilometers { get; }
//
// 		
// 		
// 		NSUnitArea SquareMeters { get; }
//
// 		
// 		
// 		NSUnitArea SquareCentimeters { get; }
//
// 		
// 		
// 		NSUnitArea SquareMillimeters { get; }
//
// 		
// 		
// 		NSUnitArea SquareMicrometers { get; }
//
// 		
// 		
// 		NSUnitArea SquareNanometers { get; }
//
// 		
// 		
// 		NSUnitArea SquareInches { get; }
//
// 		
// 		
// 		NSUnitArea SquareFeet { get; }
//
// 		
// 		
// 		NSUnitArea SquareYards { get; }
//
// 		
// 		
// 		NSUnitArea SquareMiles { get; }
//
// 		
// 		
// 		NSUnitArea Acres { get; }
//
// 		
// 		
// 		NSUnitArea Ares { get; }
//
// 		
// 		
// 		NSUnitArea Hectares { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitConcentrationMass : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitConcentrationMass GramsPerLiter { get; }
//
// 		
// 		
// 		NSUnitConcentrationMass MilligramsPerDeciliter { get; }
//
// 		
// 		
// 		NSUnitConcentrationMass GetMillimolesPerLiter (double gramsPerMole);
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitDispersion : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitDispersion PartsPerMillion { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitDuration : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitDuration Seconds { get; }
//
// 		
// 		
// 		NSUnitDuration Minutes { get; }
//
// 		
// 		
// 		NSUnitDuration Hours { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
//
// 		
// 		
// 		
// 		NSUnitDuration Milliseconds { get; }
//
// 		
// 		
// 		
// 		NSUnitDuration Microseconds { get; }
//
// 		
// 		
// 		
// 		NSUnitDuration Nanoseconds { get; }
//
// 		
// 		
// 		
// 		NSUnitDuration Picoseconds { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitElectricCharge : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitElectricCharge Coulombs { get; }
//
// 		
// 		
// 		NSUnitElectricCharge MegaampereHours { get; }
//
// 		
// 		
// 		NSUnitElectricCharge KiloampereHours { get; }
//
// 		
// 		
// 		NSUnitElectricCharge AmpereHours { get; }
//
// 		
// 		
// 		NSUnitElectricCharge MilliampereHours { get; }
//
// 		
// 		
// 		NSUnitElectricCharge MicroampereHours { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitElectricCurrent : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitElectricCurrent Megaamperes { get; }
//
// 		
// 		
// 		NSUnitElectricCurrent Kiloamperes { get; }
//
// 		
// 		
// 		NSUnitElectricCurrent Amperes { get; }
//
// 		
// 		
// 		NSUnitElectricCurrent Milliamperes { get; }
//
// 		
// 		
// 		NSUnitElectricCurrent Microamperes { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitElectricPotentialDifference : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
// 		
// 		
// 		
// 		NSUnitElectricPotentialDifference Megavolts { get; }
//
// 		
// 		
// 		NSUnitElectricPotentialDifference Kilovolts { get; }
//
// 		
// 		
// 		NSUnitElectricPotentialDifference Volts { get; }
//
// 		
// 		
// 		NSUnitElectricPotentialDifference Millivolts { get; }
//
// 		
// 		
// 		NSUnitElectricPotentialDifference Microvolts { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitElectricResistance : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitElectricResistance Megaohms { get; }
//
// 		
// 		
// 		NSUnitElectricResistance Kiloohms { get; }
//
// 		
// 		
// 		NSUnitElectricResistance Ohms { get; }
//
// 		
// 		
// 		NSUnitElectricResistance Milliohms { get; }
//
// 		
// 		
// 		NSUnitElectricResistance Microohms { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitEnergy : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitEnergy Kilojoules { get; }
//
// 		
// 		
// 		NSUnitEnergy Joules { get; }
//
// 		
// 		
// 		NSUnitEnergy Kilocalories { get; }
//
// 		
// 		
// 		NSUnitEnergy Calories { get; }
//
// 		
// 		
// 		NSUnitEnergy KilowattHours { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitFrequency : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitFrequency Terahertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Gigahertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Megahertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Kilohertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Hertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Millihertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Microhertz { get; }
//
// 		
// 		
// 		NSUnitFrequency Nanohertz { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
//
// 		
// 		
// 		
// 		NSUnitFrequency FramesPerSecond { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitFuelEfficiency : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitFuelEfficiency LitersPer100Kilometers { get; }
//
// 		
// 		
// 		NSUnitFuelEfficiency MilesPerImperialGallon { get; }
//
// 		
// 		
// 		NSUnitFuelEfficiency MilesPerGallon { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitLength : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitLength Megameters { get; }
//
// 		
// 		
// 		NSUnitLength Kilometers { get; }
//
// 		
// 		
// 		NSUnitLength Hectometers { get; }
//
// 		
// 		
// 		NSUnitLength Decameters { get; }
//
// 		
// 		
// 		NSUnitLength Meters { get; }
//
// 		
// 		
// 		NSUnitLength Decimeters { get; }
//
// 		
// 		
// 		NSUnitLength Centimeters { get; }
//
// 		
// 		
// 		NSUnitLength Millimeters { get; }
//
// 		
// 		
// 		NSUnitLength Micrometers { get; }
//
// 		
// 		
// 		NSUnitLength Nanometers { get; }
//
// 		
// 		
// 		NSUnitLength Picometers { get; }
//
// 		
// 		
// 		NSUnitLength Inches { get; }
//
// 		
// 		
// 		NSUnitLength Feet { get; }
//
// 		
// 		
// 		NSUnitLength Yards { get; }
//
// 		
// 		
// 		NSUnitLength Miles { get; }
//
// 		
// 		
// 		NSUnitLength ScandinavianMiles { get; }
//
// 		
// 		
// 		NSUnitLength Lightyears { get; }
//
// 		
// 		
// 		NSUnitLength NauticalMiles { get; }
//
// 		
// 		
// 		NSUnitLength Fathoms { get; }
//
// 		
// 		
// 		NSUnitLength Furlongs { get; }
//
// 		
// 		
// 		NSUnitLength AstronomicalUnits { get; }
//
// 		
// 		
// 		NSUnitLength Parsecs { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitIlluminance : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitIlluminance Lux { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitMass : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitMass Kilograms { get; }
//
// 		
// 		
// 		NSUnitMass Grams { get; }
//
// 		
// 		
// 		NSUnitMass Decigrams { get; }
//
// 		
// 		
// 		NSUnitMass Centigrams { get; }
//
// 		
// 		
// 		NSUnitMass Milligrams { get; }
//
// 		
// 		
// 		NSUnitMass Micrograms { get; }
//
// 		
// 		
// 		NSUnitMass Nanograms { get; }
//
// 		
// 		
// 		NSUnitMass Picograms { get; }
//
// 		
// 		
// 		NSUnitMass Ounces { get; }
//
// 		
// 		
// 		NSUnitMass Pounds { get; }
//
// 		
// 		
// 		NSUnitMass Stones { get; }
//
// 		
// 		
// 		NSUnitMass MetricTons { get; }
//
// 		
// 		
// 		NSUnitMass ShortTons { get; }
//
// 		
// 		
// 		NSUnitMass Carats { get; }
//
// 		
// 		
// 		NSUnitMass OuncesTroy { get; }
//
// 		
// 		
// 		NSUnitMass Slugs { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitPower : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitPower Terawatts { get; }
//
// 		
// 		
// 		NSUnitPower Gigawatts { get; }
//
// 		
// 		
// 		NSUnitPower Megawatts { get; }
//
// 		
// 		
// 		NSUnitPower Kilowatts { get; }
//
// 		
// 		
// 		NSUnitPower Watts { get; }
//
// 		
// 		
// 		NSUnitPower Milliwatts { get; }
//
// 		
// 		
// 		NSUnitPower Microwatts { get; }
//
// 		
// 		
// 		NSUnitPower Nanowatts { get; }
//
// 		
// 		
// 		NSUnitPower Picowatts { get; }
//
// 		
// 		
// 		NSUnitPower Femtowatts { get; }
//
// 		
// 		
// 		NSUnitPower Horsepower { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitPressure : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitPressure NewtonsPerMetersSquared { get; }
//
// 		
// 		
// 		NSUnitPressure Gigapascals { get; }
//
// 		
// 		
// 		NSUnitPressure Megapascals { get; }
//
// 		
// 		
// 		NSUnitPressure Kilopascals { get; }
//
// 		
// 		
// 		NSUnitPressure Hectopascals { get; }
//
// 		
// 		
// 		NSUnitPressure InchesOfMercury { get; }
//
// 		
// 		
// 		NSUnitPressure Bars { get; }
//
// 		
// 		
// 		NSUnitPressure Millibars { get; }
//
// 		
// 		
// 		NSUnitPressure MillimetersOfMercury { get; }
//
// 		
// 		
// 		NSUnitPressure PoundsForcePerSquareInch { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitSpeed : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitSpeed MetersPerSecond { get; }
//
// 		
// 		
// 		NSUnitSpeed KilometersPerHour { get; }
//
// 		
// 		
// 		NSUnitSpeed MilesPerHour { get; }
//
// 		
// 		
// 		NSUnitSpeed Knots { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	 // -init should never be called on NSUnit!
// 	
// 	
// 	interface NSUnitVolume : NSSecureCoding {
// 		// inline from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitVolume Megaliters { get; }
//
// 		
// 		
// 		NSUnitVolume Kiloliters { get; }
//
// 		
// 		
// 		NSUnitVolume Liters { get; }
//
// 		
// 		
// 		NSUnitVolume Deciliters { get; }
//
// 		
// 		
// 		NSUnitVolume Centiliters { get; }
//
// 		
// 		
// 		NSUnitVolume Milliliters { get; }
//
// 		
// 		
// 		NSUnitVolume CubicKilometers { get; }
//
// 		
// 		
// 		NSUnitVolume CubicMeters { get; }
//
// 		
// 		
// 		NSUnitVolume CubicDecimeters { get; }
//
// 		
// 		
// 		NSUnitVolume CubicCentimeters { get; }
//
// 		
// 		
// 		NSUnitVolume CubicMillimeters { get; }
//
// 		
// 		
// 		NSUnitVolume CubicInches { get; }
//
// 		
// 		
// 		NSUnitVolume CubicFeet { get; }
//
// 		
// 		
// 		NSUnitVolume CubicYards { get; }
//
// 		
// 		
// 		NSUnitVolume CubicMiles { get; }
//
// 		
// 		
// 		NSUnitVolume AcreFeet { get; }
//
// 		
// 		
// 		NSUnitVolume Bushels { get; }
//
// 		
// 		
// 		NSUnitVolume Teaspoons { get; }
//
// 		
// 		
// 		NSUnitVolume Tablespoons { get; }
//
// 		
// 		
// 		NSUnitVolume FluidOunces { get; }
//
// 		
// 		
// 		NSUnitVolume Cups { get; }
//
// 		
// 		
// 		NSUnitVolume Pints { get; }
//
// 		
// 		
// 		NSUnitVolume Quarts { get; }
//
// 		
// 		
// 		NSUnitVolume Gallons { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialTeaspoons { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialTablespoons { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialFluidOunces { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialPints { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialQuarts { get; }
//
// 		
// 		
// 		NSUnitVolume ImperialGallons { get; }
//
// 		
// 		
// 		NSUnitVolume MetricCups { get; }
//
// 		 // kind of overloading a static member
// 		
// 		
// 		NSDimension BaseUnit { get; }
// 	}
//
// 	
// 	
// 	
// 	interface NSMeasurement<UnitType> : NSCopying, NSSecureCoding
// 		where UnitType : NSUnit {
// 		
// 		NSUnit Unit { get; }
//
// 		
// 		double DoubleValue { get; }
//
// 		
// 		
// 		NativeHandle Constructor (double doubleValue, NSUnit unit);
//
// 		
// 		bool CanBeConvertedTo (NSUnit unit);
//
// 		
// 		NSMeasurement<UnitType> GetMeasurementByConverting (NSUnit unit);
//
// 		
// 		NSMeasurement<UnitType> GetMeasurementByAdding (NSMeasurement<UnitType> measurement);
//
// 		
// 		NSMeasurement<UnitType> GetMeasurementBySubtracting (NSMeasurement<UnitType> measurement);
// 	}
//
// 	
// 	
// 	interface NSMeasurementFormatter : NSSecureCoding {
//
// 		
// 		NSMeasurementFormatterUnitOptions UnitOptions { get; set; }
//
// 		
// 		NSFormattingUnitStyle UnitStyle { get; set; }
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		NSNumberFormatter NumberFormatter { get; set; }
//
// 		
// 		string ToString (NSMeasurement<NSUnit> measurement);
//
// 		
// 		string ToString (NSUnit unit);
// 	}
//
// 	
// 	
// 	interface NSXpcConnection
// 	{
// 		
// 		
// 		NativeHandle Constructor (string xpcServiceName);
//
// 		
// 		string ServiceName { get; }
//
// 		
// 		
// 		NativeHandle Constructor (string machServiceName, NSXpcConnectionOptions options);
//
// 		
// 		NativeHandle Constructor (NSXpcListenerEndpoint endpoint);
//
// 		
// 		NSXpcListenerEndpoint Endpoint { get; }
//
// 		
// 		
// 		NSXpcInterface ExportedInterface { get; set; }
//
// 		
// 		
// 		NSObject ExportedObject { get; set; }
//
// 		
// 		
// 		NSXpcInterface RemoteInterface { get; set; }
//
// 		
// 		Action InterruptionHandler { get; set; }
//
// 		
// 		Action InvalidationHandler { get; set; }
//
// 		
// 		void Resume ();
//
// 		
// 		void Suspend ();
//
// 		
// 		void Invalidate ();
//
// 		
// 		int AuditSessionIdentifier { get; }
//
// 		
// 		int PeerProcessIdentifier { get; }
//
// 		
// 		int PeerEffectiveUserId { get; }
//
// 		
// 		int PeerEffectiveGroupId { get; }
//
// 		
// 		
// 		NSXpcConnection CurrentConnection {  get; }
//
// 		
// 		
// 		void ScheduleSendBarrier (Action block);
//
// 		
// 		IntPtr _CreateRemoteObjectProxy ();
//
// 		
// 		IntPtr _CreateRemoteObjectProxy ( Action<NSError> errorHandler);
//
// 		
// 		
// 		IntPtr _CreateSynchronousRemoteObjectProxy ( Action<NSError> errorHandler);
// 	}
//
// 	interface INSXpcListenerDelegate {}
//
// 	 { "WeakDelegate" })]
// 	
// 	interface NSXpcListener
// 	{
// 		
// 		
// 		NSXpcListener ServiceListener { get; }
//
// 		
// 		
// 		NSXpcListener AnonymousListener { get; }
//
// 		
// 		
// 		
// 		NativeHandle Constructor (string machServiceName);
//
// 		
// 		
// 		NSObject WeakDelegate { get; set; }
//
// 		
// 		INSXpcListenerDelegate Delegate { get; set; }
//
// 		
// 		NSXpcListenerEndpoint Endpoint { get; }
//
// 		
// 		void Resume ();
//
// 		
// 		void Suspend ();
//
// 		
// 		void Invalidate ();
// 	}
//
// 	
// #if NETXXX
// 	
// #else
// 	
// #endif
// 	interface NSXpcListenerDelegate
// 	{
// 		
// 		bool ShouldAcceptConnection (NSXpcListener listener, NSXpcConnection newConnection);
// 	}
//
// 	
// 	
// 	interface NSXpcInterface
// 	{
// 		
// 		
// 		NSXpcInterface Create (Protocol protocol);
//
// 		
// 		Protocol Protocol { get; set; }
//
// 		
// 		void SetAllowedClasses (NSSet<Class> allowedClasses, Selector methodSelector, nuint argumentIndex, bool forReplyBlock);
//
// 		
// 		NSSet<Class> GetAllowedClasses (Selector methodSelector, nuint argumentIndex, bool forReplyBlock);
//
// 		// Methods taking xpc_type_t have been skipped.
// 	}
//
// 	
// 	
// 	interface NSXpcListenerEndpoint : NSSecureCoding
// 	{
// 	}
//
// 	
// 	
// 	interface NSListFormatter {
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		NSFormatter ItemFormatter { get; set; }
//
// 		
// 		
// 		// using `NSString` since they might be one (or many) `NSString` subclass(es) that handle localization
// 		string GetLocalizedString (NSString joinedStrings);
//
// 		
// 		
// 		string GetString (NSObject items);
//
// 		
// 		
// 		string GetString ( NSObject obj);
// 	}
//
// 	
// 	
// 	enum NSRelativeDateTimeFormatterStyle : long {
// 		Numeric = 0,
// 		Named,
// 	}
//
// 	
// 	
// 	enum NSRelativeDateTimeFormatterUnitsStyle : long {
// 		Full = 0,
// 		SpellOut,
// 		Short,
// 		Abbreviated,
// 	}
//
// 	
// 	
// 	interface NSRelativeDateTimeFormatter {
//
// 		
// 		NSRelativeDateTimeFormatterStyle DateTimeStyle { get; set; }
//
// 		
// 		NSRelativeDateTimeFormatterUnitsStyle UnitsStyle { get; set; }
//
// 		
// 		NSFormattingContext FormattingContext { get; set; }
//
// 		
// 		NSCalendar Calendar { get; set; }
//
// 		
// 		NSLocale Locale { get; set; }
//
// 		
// 		string GetLocalizedString (NSDateComponents dateComponents);
//
// 		
// 		string GetLocalizedString (double timeInterval);
//
// 		
// 		string GetLocalizedString (NSDate date, NSDate referenceDate);
//
// 		
// 		
// 		string GetString ( NSObject obj);
// 	}
//
// 	
// 	
// 	enum NSCollectionChangeType : long {
// 		Insert,
// 		Remove,
// 	}
//
// 	
// 	
// 	enum NSOrderedCollectionDifferenceCalculationOptions : ulong {
// 		OmitInsertedObjects = (1uL << 0),
// 		OmitRemovedObjects = (1uL << 1),
// 		InferMoves = (1uL << 2),
// 	}
//
// 	
// 	
// 	 // NSGenericException Reason: -init should never be called on NSUnit!
// 	interface NSUnitInformationStorage : NSSecureCoding {
//
// 		// Inlined from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol);
//
// 		// Inlined from base type
// 		
// 		
// 		NativeHandle Constructor (string symbol, NSUnitConverter converter);
//
// 		
// 		
// 		NSUnitInformationStorage Bytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Bits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Nibbles { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Yottabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Zettabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Exabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Petabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Terabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Gigabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Megabytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Kilobytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Yottabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Zettabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Exabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Petabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Terabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Gigabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Megabits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Kilobits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Yobibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Zebibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Exbibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Pebibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Tebibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Gibibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Mebibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Kibibytes { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Yobibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Zebibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Exbibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Pebibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Tebibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Gibibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Mebibits { get; }
//
// 		
// 		
// 		NSUnitInformationStorage Kibibits { get; }
// 	}
//
// 	
// 	
// 	enum NSUrlSessionWebSocketMessageType : long {
// 		Data = 0,
// 		String = 1,
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlSessionWebSocketMessage {
//
// 		
// 		
// 		NativeHandle Constructor (NSData data);
//
// 		
// 		
// 		NativeHandle Constructor (string @string);
//
// 		
// 		NSUrlSessionWebSocketMessageType Type { get; }
//
// 		
// 		NSData Data { get; }
//
// 		
// 		string String { get; }
// 	}
//
// 	
// 	
// 	enum NSUrlSessionWebSocketCloseCode : long {
// 		Invalid = 0,
// 		NormalClosure = 1000,
// 		GoingAway = 1001,
// 		ProtocolError = 1002,
// 		UnsupportedData = 1003,
// 		NoStatusReceived = 1005,
// 		AbnormalClosure = 1006,
// 		InvalidFramePayloadData = 1007,
// 		PolicyViolation = 1008,
// 		MessageTooBig = 1009,
// 		MandatoryExtensionMissing = 1010,
// 		InternalServerError = 1011,
// 		TlsHandshakeFailure = 1015,
// 	}
//
// 	
// 	
// 	
// 	interface NSUrlSessionWebSocketTask {
//
// 		
// 		
// 		void SendMessage (NSUrlSessionWebSocketMessage message, Action<NSError> completionHandler);
//
// 		
// 		
// 		void ReceiveMessage (Action<NSUrlSessionWebSocketMessage, NSError> completionHandler);
//
// 		
// 		
// 		void SendPing (Action<NSError> pongReceiveHandler);
//
// 		
// 		void Cancel (NSUrlSessionWebSocketCloseCode closeCode,  NSData reason);
//
// 		
// 		nint MaximumMessageSize { get; set; }
//
// 		
// 		NSUrlSessionWebSocketCloseCode CloseCode { get; }
//
// 		
// 		NSData CloseReason { get; }
// 	}
//
// 	
// #if NETXXX
// 	
// #else
// 	
// #endif
// 	
// 	interface NSUrlSessionWebSocketDelegate {
//
// 		
// 		void DidOpen (NSUrlSession session, NSUrlSessionWebSocketTask webSocketTask,  string protocol);
//
// 		
// 		void DidClose (NSUrlSession session, NSUrlSessionWebSocketTask webSocketTask, NSUrlSessionWebSocketCloseCode closeCode,  NSData reason);
// 	}
//
// 	
// 	
// 	enum NSUrlErrorNetworkUnavailableReason : long {
// 		Cellular = 0,
// 		Expensive = 1,
// 		Constrained = 2,
// 	}
//
// 	
// 	
// 	public enum NSBackgroundActivityResult : long
// 	{
// 		Finished = 1,
// 		Deferred = 2,
// 	}
//
// 	delegate void NSBackgroundActivityCompletionHandler (NSBackgroundActivityResult result);
//
// 	delegate void NSBackgroundActivityCompletionAction ( NSBackgroundActivityCompletionHandler handler);
//
// 	
// 	
// 	
// 	interface NSBackgroundActivityScheduler
// 	{
// 		
// 		
// 		NativeHandle Constructor (string identifier);
//
// 		
// 		string Identifier { get; }
//
// 		
// 		NSQualityOfService QualityOfService { get; set; }
//
// 		
// 		bool Repeats { get; set; }
//
// 		
// 		double Interval { get; set; }
//
// 		
// 		double Tolerance { get; set; }
//
// 		
// 		void Schedule (NSBackgroundActivityCompletionAction action);
//
// 		
// 		void Invalidate ();
//
// 		
// 		bool ShouldDefer { get; }
// 	}
//
// 	
// 	
// 	public enum NSUrlSessionTaskMetricsDomainResolutionProtocol : long {
// 		Unknown,
// 		Udp,
// 		Tcp,
// 		Tls,
// 		Https,
// 	}
//
// 	
// 	
// 	
// 	public enum NSNotificationSuspensionBehavior : ulong {
// 		Drop = 1,
// 		Coalesce = 2,
// 		Hold = 3,
// 		DeliverImmediately = 4,
// 	}
//
// 	
// 	
// 	
// 	
// 	public enum NSNotificationFlags : ulong {
// 		DeliverImmediately = (1 << 0),
// 		PostToAllSessions = (1 << 1),
// 	}
//
// 	
// 	
// 	
// 	public enum NSFileManagerUnmountOptions : ulong
// 	{
// 		AllPartitionsAndEjectDisk = 1 << 0,
// 		WithoutUI = 1 << 1,
// 	}
// }

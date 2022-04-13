//
// Convenience methods for NSMetadataItem
//
// Copyright 2014, 2016 Xamarin Inc
//
// Author:
//   Miguel de Icaza
//
using System;
using CoreFoundation;
using ObjCRuntime;

#nullable enable

namespace Foundation {
	public partial class NSMetadataItem {
#if !NETXXX
		bool GetBool (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n is null ? false : n.BoolValue;
		}
#endif

		bool? GetNullableBool (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n?.BoolValue;
		}

		double GetDouble (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n is null ? 0 : n.DoubleValue;
		}

		double? GetNullableDouble (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n?.DoubleValue;
		}

		nint? GetNInt (NSString key)
		{
			var n = Runtime.GetNSObject<NSNumber> (GetHandle (key));
			return n?.NIntValue;
		}

		// same order as NSMetadataAttributes.h

		public NSString? FileSystemName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemFSNameKey));
			}
		}

		public NSString? DisplayName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemDisplayNameKey));
			}
		}

		public NSUrl? Url {
			get {
				return Runtime.GetNSObject<NSUrl> (GetHandle (NSMetadataQuery.ItemURLKey));
			}
		}

		public NSString? Path {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ItemPathKey));
			}
		}

		public NSNumber? FileSystemSize {
			get {
				return Runtime.GetNSObject<NSNumber> (GetHandle (NSMetadataQuery.ItemFSSizeKey));
			}
		}

		public NSDate? FileSystemCreationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ItemFSCreationDateKey));
			}
		}

		public NSDate? FileSystemContentChangeDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ItemFSContentChangeDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,9)]
#endif
		public NSString? ContentType {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ContentTypeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,9)]
#endif
		public NSString?[]? ContentTypeTree {
			get {
				using (var a = Runtime.GetNSObject<NSArray> (GetHandle (NSMetadataQuery.ContentTypeTreeKey)))
					return NSArray.FromArray<NSString> (a);
			}
		}

#if NETXXX
		public bool? IsUbiquitous {
#else
		public bool IsUbiquitous {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.ItemIsUbiquitousKey);
#else
				return GetBool (NSMetadataQuery.ItemIsUbiquitousKey);
#endif
			}
		}

#if NETXXX
		public bool? UbiquitousItemHasUnresolvedConflicts {
#else
		public bool UbiquitousItemHasUnresolvedConflicts {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemHasUnresolvedConflictsKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemHasUnresolvedConflictsKey);
#endif
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios7.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (7,0)]
		[Mac (10,9)]
#endif
#if NETXXX
		public NSItemDownloadingStatus UbiquitousItemDownloadingStatus {
#else
		public NSItemDownloadingStatus DownloadingStatus {
#endif
			get {
				return NSItemDownloadingStatusExtensions.GetValue (Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.UbiquitousItemDownloadingStatusKey)));
			}
		}

#if NETXXX
		public bool? UbiquitousItemIsDownloading {
#else
		public bool UbiquitousItemIsDownloading {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemIsDownloadingKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemIsDownloadingKey);
#endif
			}
		}

#if NETXXX
		public bool? UbiquitousItemIsUploaded {
#else
		public bool UbiquitousItemIsUploaded {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemIsUploadedKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemIsUploadedKey);
#endif
			}
		}

#if NETXXX
		public bool? UbiquitousItemIsUploading {
#else
		public bool UbiquitousItemIsUploading {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemIsUploadingKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemIsUploadingKey);
#endif
			}
		}

#if NETXXX
		public double? UbiquitousItemPercentDownloaded {
#else
		public double UbiquitousItemPercentDownloaded {
#endif
			get {
#if NETXXX
				return GetNullableDouble (NSMetadataQuery.UbiquitousItemPercentDownloadedKey);
#else
				return GetDouble (NSMetadataQuery.UbiquitousItemPercentDownloadedKey);
#endif
			}
		}

#if NETXXX
		public double? UbiquitousItemPercentUploaded {
#else
		public double UbiquitousItemPercentUploaded {
#endif
			get {
#if NETXXX
				return GetNullableDouble (NSMetadataQuery.UbiquitousItemPercentUploadedKey);
#else
				return GetDouble (NSMetadataQuery.UbiquitousItemPercentUploadedKey);
#endif
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios7.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (7,0)]
		[Mac (10,9)]
#endif
		public NSError? UbiquitousItemDownloadingError {
			get {
				return Runtime.GetNSObject<NSError> (GetHandle (NSMetadataQuery.UbiquitousItemDownloadingErrorKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios7.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (7,0)]
		[Mac (10,9)]
#endif
		public NSError? UbiquitousItemUploadingError {
			get {
				return Runtime.GetNSObject<NSError> (GetHandle (NSMetadataQuery.UbiquitousItemUploadingErrorKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.10")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,10)]
#endif
#if NETXXX
		public bool? UbiquitousItemDownloadRequested {
#else
		public bool UbiquitousItemDownloadRequested {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemDownloadRequestedKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemDownloadRequestedKey);
#endif
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.10")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,10)]
#endif
#if NETXXX
		public bool? UbiquitousItemIsExternalDocument {
#else
		public bool UbiquitousItemIsExternalDocument {
#endif
			get {
#if NETXXX
				return GetNullableBool (NSMetadataQuery.UbiquitousItemIsExternalDocumentKey);
#else
				return GetBool (NSMetadataQuery.UbiquitousItemIsExternalDocumentKey);
#endif
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,9)]
#endif
		public NSString? UbiquitousItemContainerDisplayName {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.UbiquitousItemContainerDisplayNameKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("ios8.0")]
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#else
		[iOS (8,0)]
		[Mac (10,9)]
#endif
		public NSUrl? UbiquitousItemUrlInLocalContainer {
			get {
				return Runtime.GetNSObject<NSUrl> (GetHandle (NSMetadataQuery.UbiquitousItemURLInLocalContainerKey));
			}
		}

#if MONOMAC
#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Keywords {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.KeywordsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Title {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.TitleKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Authors {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Editors {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EditorsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Participants {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ParticipantsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Projects {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ProjectsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? DownloadedDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DownloadedDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? WhereFroms {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.WhereFromsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Comment {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CommentKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Copyright {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CopyrightKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? LastUsedDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.LastUsedDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? ContentCreationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ContentCreationDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? ContentModificationDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.ContentModificationDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? DateAdded {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DateAddedKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? DurationSeconds {
			get {
				return GetNullableDouble (NSMetadataQuery.DurationSecondsKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? ContactKeywords {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ContactKeywordsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Version {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.VersionKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? PixelHeight {
			get {
				return GetNInt (NSMetadataQuery.PixelHeightKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? PixelWidth {
			get {
				return GetNInt (NSMetadataQuery.PixelWidthKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? PixelCount {
			get {
				return GetNInt (NSMetadataQuery.PixelCountKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ColorSpace {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ColorSpaceKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? BitsPerSample {
			get {
				return GetNInt (NSMetadataQuery.BitsPerSampleKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? FlashOnOff {
			get {
				return GetNullableBool (NSMetadataQuery.FlashOnOffKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? FocalLength {
			get {
				return GetNullableDouble (NSMetadataQuery.FocalLengthKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AcquisitionMake {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AcquisitionMakeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AcquisitionModel {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AcquisitionModelKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? IsoSpeed {
			get {
				return GetNullableDouble (NSMetadataQuery.IsoSpeedKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? Orientation {
			get {
				return GetNInt (NSMetadataQuery.OrientationKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? LayerNames {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.LayerNamesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? WhiteBalance {
			get {
				return GetNullableDouble (NSMetadataQuery.WhiteBalanceKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Aperture {
			get {
				return GetNullableDouble (NSMetadataQuery.ApertureKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ProfileName {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ProfileNameKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? ResolutionWidthDpi {
			get {
				return GetNInt (NSMetadataQuery.ResolutionWidthDpiKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? ResolutionHeightDpi {
			get {
				return GetNInt (NSMetadataQuery.ResolutionHeightDpiKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? ExposureMode {
			get {
				return GetNInt (NSMetadataQuery.ExposureModeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? ExposureTimeSeconds {
			get {
				return GetNullableDouble (NSMetadataQuery.ExposureTimeSecondsKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ExifVersion {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ExifVersionKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? CameraOwner {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CameraOwnerKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? FocalLength35mm {
			get {
				return GetNInt (NSMetadataQuery.FocalLength35mmKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? LensModel {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.LensModelKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ExifGpsVersion {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ExifGpsVersionKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Altitude {
			get {
				return GetNullableDouble (NSMetadataQuery.AltitudeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Latitude {
			get {
				return GetNullableDouble (NSMetadataQuery.LatitudeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Longitude {
			get {
				return GetNullableDouble (NSMetadataQuery.LongitudeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Speed {
			get {
				return GetNullableDouble (NSMetadataQuery.SpeedKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? Timestamp {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.TimestampKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsTrack {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsTrackKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? ImageDirection {
			get {
				return GetNullableDouble (NSMetadataQuery.ImageDirectionKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? NamedLocation {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.NamedLocationKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? GpsStatus {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GpsStatusKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? GpsMeasureMode {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GpsMeasureModeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDop {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDopKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? GpsMapDatum {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GpsMapDatumKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDestLatitude {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestLatitudeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDestLongitude {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestLongitudeKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDestBearing {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestBearingKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDestDistance {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDestDistanceKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? GpsProcessingMethod {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GpsProcessingMethodKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? GpsAreaInformation {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GpsAreaInformationKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? GpsDateStamp {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.GpsDateStampKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? GpsDifferental {
			get {
				return GetNullableDouble (NSMetadataQuery.GpsDifferentalKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Codecs {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.CodecsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? MediaTypes {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.MediaTypesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? Streamable {
			get {
				return GetNullableBool (NSMetadataQuery.StreamableKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? TotalBitRate {
			get {
				return GetNInt (NSMetadataQuery.TotalBitRateKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? VideoBitRate {
			get {
				return GetNInt (NSMetadataQuery.VideoBitRateKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? AudioBitRate {
			get {
				return GetNInt (NSMetadataQuery.AudioBitRateKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? DeliveryType {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.DeliveryTypeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Album {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AlbumKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? HasAlphaChannel {
			get {
				return GetNullableBool (NSMetadataQuery.HasAlphaChannelKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? RedEyeOnOff {
			get {
				return GetNullableBool (NSMetadataQuery.RedEyeOnOffKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? MeteringMode {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.MeteringModeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? MaxAperture {
			get {
				return GetNullableDouble (NSMetadataQuery.MaxApertureKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? FNumber {
			get {
				return GetNInt (NSMetadataQuery.FNumberKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ExposureProgram {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ExposureProgramKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ExposureTimeString {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ExposureTimeStringKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Headline {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.HeadlineKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Instructions {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.InstructionsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? City {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CityKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? StateOrProvince {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.StateOrProvinceKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Country {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CountryKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? TextContent {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.TextContentKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? AudioSampleRate {
			get {
				return GetNInt (NSMetadataQuery.AudioSampleRateKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? AudioChannelCount {
			get {
				return GetNInt (NSMetadataQuery.AudioChannelCountKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? Tempo {
			get {
				return GetNullableDouble (NSMetadataQuery.TempoKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? KeySignature {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.KeySignatureKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? TimeSignature {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.TimeSignatureKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AudioEncodingApplication {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AudioEncodingApplicationKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Composer {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ComposerKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Lyricist {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.LyricistKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? AudioTrackNumber {
			get {
				return GetNInt (NSMetadataQuery.AudioTrackNumberKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? RecordingDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.RecordingDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? MusicalGenre {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.MusicalGenreKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? IsGeneralMidiSequence {
			get {
				return GetNullableBool (NSMetadataQuery.IsGeneralMidiSequenceKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? RecordingYear {
			get {
				return GetNInt (NSMetadataQuery.RecordingYearKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Organizations {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.OrganizationsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Languages {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.LanguagesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Rights {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.RightsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Publishers {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PublishersKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Contributors {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ContributorsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Coverage {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.CoverageKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Subject {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.SubjectKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Theme {
			get {
				return Runtime.GetNSObject<NSString> (GetHandle (NSMetadataQuery.ThemeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Description {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.DescriptionKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Identifier {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.IdentifierKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Audiences {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AudiencesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public nint? NumberOfPages {
			get {
				return GetNInt (NSMetadataQuery.NumberOfPagesKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? PageWidth {
			get {
				return GetNullableDouble (NSMetadataQuery.PageWidthKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? PageHeight {
			get {
				return GetNullableDouble (NSMetadataQuery.PageHeightKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? SecurityMethod {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.SecurityMethodKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Creator {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CreatorKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? EncodingApplications {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EncodingApplicationsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public NSDate? DueDate {
			get {
				return Runtime.GetNSObject<NSDate> (GetHandle (NSMetadataQuery.DueDateKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public double? StarRating {
			get {
				return GetNullableDouble (NSMetadataQuery.StarRatingKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? PhoneNumbers {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PhoneNumbersKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? EmailAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.EmailAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? InstantMessageAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.InstantMessageAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Kind {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.KindKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Recipients {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? FinderComment {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.FinderCommentKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Fonts {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.FontsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AppleLoopsRoot {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsRootKeyKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AppleLoopsKeyFilterType {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsKeyFilterTypeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? AppleLoopsLoopMode {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.AppleLoopsLoopModeKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? AppleLoopDescriptors {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AppleLoopDescriptorsKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? MusicalInstrumentCategory {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.MusicalInstrumentCategoryKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? MusicalInstrumentName {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.MusicalInstrumentNameKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? CFBundleIdentifier {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.CFBundleIdentifierKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Information {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.InformationKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Director {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.DirectorKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Producer {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ProducerKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? Genre {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.GenreKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? Performers {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.PerformersKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? OriginalFormat {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.OriginalFormatKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? OriginalSource {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.OriginalSourceKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? AuthorEmailAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorEmailAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? RecipientEmailAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientEmailAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? AuthorAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.AuthorAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? RecipientAddresses {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.RecipientAddressesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? IsLikelyJunk {
			get {
				return GetNullableBool (NSMetadataQuery.IsLikelyJunkKey);
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? ExecutableArchitectures {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ExecutableArchitecturesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? ExecutablePlatform {
			get {
				return CFString.FromHandle (GetHandle (NSMetadataQuery.ExecutablePlatformKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public string? []? ApplicationCategories {
			get {
				return CFArray.StringArrayFromHandle (GetHandle (NSMetadataQuery.ApplicationCategoriesKey));
			}
		}

#if NETXXX
		[SupportedOSPlatform ("macos10.9")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("ios")]
#else
		[NoWatch]
		[NoTV]
		[NoiOS]
		[Mac (10, 9)]
#endif
		public bool? IsApplicationManaged {
			get {
				return GetNullableBool (NSMetadataQuery.IsApplicationManagedKey);
			}
		}
#endif
	}
}

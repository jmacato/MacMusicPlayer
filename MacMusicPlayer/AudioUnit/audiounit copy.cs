// ///
// // Authors:
// //  Miguel de Icaza (miguel@xamarin.com)
// //
// // Copyright 2015 Xamarin, Inc.
// //
// //
//
// using System;
// using AudioToolbox;
// //using Foundation;
// using ObjCRuntime; 
// using NativeHandle = System.IntPtr; 
// namespace AudioUnit {
// 	delegate AudioUnitStatus AUInternalRenderBlock (ref AudioUnitRenderActionFlags actionFlags, ref AudioTimeStamp timestamp, uint frameCount, nint outputBusNumber, AudioBuffers outputData, AURenderEventEnumerator realtimeEventListHead, AURenderPullInputBlock pullInputBlock);
// 	delegate AudioUnitStatus AURenderBlock (ref AudioUnitRenderActionFlags actionFlags, ref AudioTimeStamp timestamp, uint frameCount, nint outputBusNumber, AudioBuffers outputData,  AURenderPullInputBlock pullInputBlock);
//
// 	internal delegate AudioUnitStatus AURenderPullInputBlock (ref AudioUnitRenderActionFlags actionFlags, ref AudioTimeStamp timestamp,
// 			uint frameCount, nint inputBusNumber, AudioBuffers inputData);
//
// 	delegate void AUScheduleParameterBlock (AUEventSampleTime eventSampleTime, uint rampDurationSampleFrames, ulong parameterAddress, float value);
// 	
// 	delegate int AUMidiOutputEventBlock (long eventSampleTime, byte cable, nint length, IntPtr midiBytes);
// 	delegate void AUImplementorValueObserver (AUParameter param, float value);
// 	delegate float AUImplementorValueProvider (AUParameter param);
//
// 	delegate void AUParameterObserver (ulong address, float value);
// 	
// 	delegate void AUVoiceIOMutedSpeechActivityEventListener (AUVoiceIOSpeechActivityEvent activityEvent);
//
// // 	AUAudioTODO - We need testing for these bindings
// // 	delegate void AUScheduleMidiEventBlock (AUEventSampleTime eventSampleTime, byte cable, nint length, ref byte midiBytes);
// // 	delegate bool AUHostMusicalContextBlock (ref double currentTempo, ref double timeSignatureNumerator, ref nint timeSignatureDenominator, ref double currentBeatPosition, ref nint sampleOffsetToNextBeat, ref double currentMeasureDownbeatPosition);
// #if !NETXXX
// 	
// 	delegate NSString AUImplementorStringFromValueCallback (AUParameter param, ref float? value);
// #else
// 	delegate string AUImplementorStringFromValueCallback (AUParameter param, ref float? value);
// #endif
//
// 	delegate string AUImplementorDisplayNameWithLengthCallback (AUParameterNode node, nint desiredLength);
// 	delegate void AUParameterRecordingObserver (nint numberOfEvents, ref AURecordedParameterEvent events);
// 	delegate void AUInputHandler (ref AudioUnitRenderActionFlags actionFlags, ref AudioTimeStamp timestamp, uint frameCount, nint inputBusNumber);
// 	delegate bool AUHostTransportStateBlock (ref AUHostTransportStateFlags transportStateFlags, ref double currentSamplePosition, ref double cycleStartBeatPosition, ref double cycleEndBeatPosition);
// 	delegate void AURenderObserver (AudioUnitRenderActionFlags actionFlags, ref AudioTimeStamp timestamp, uint frameCount, nint outputBusNumber);
// 	delegate float AUImplementorValueFromStringCallback (AUParameter param, string str);
// 	
// 	delegate void AUMidiCIProfileChangedCallback (byte cable, byte channel, MidiCIProfile profile, bool enabled);
//
// 	
// 	
// 	
// 	interface AUAudioUnit
// 	{
// 		
// 		 // AUAudioUnitImplementation
// 		void RegisterSubclass (Class cls, AudioComponentDescription componentDescription, string name, uint version);
//
// 		
// 		
// 		NativeHandle Constructor (AudioComponentDescription componentDescription, AudioComponentInstantiationOptions options,  out NSError outError);
//
// 		
// 		NativeHandle Constructor (AudioComponentDescription componentDescription,  out NSError outError);
//
// 		
// 		
// 		
// 		void FromComponentDescription (AudioComponentDescription componentDescription, AudioComponentInstantiationOptions options, Action<AUAudioUnit, NSError> completionHandler);
//
// 		
// 		AudioComponentDescription ComponentDescription { get; }
//
// 		
// 		AURenderBlock RenderBlock { get; }
//
// 		
// 		AUInternalRenderBlock InternalRenderBlock { get; }
//
// 		// @property (readonly, nonatomic) AudioComponent __nonnull component;
// 		
// 		unsafe AudioComponent Component { get; }
//
// 		
// 		string ComponentName { get; }
//
// 		
// 		string AudioUnitName { get; }
//
// 		
// 		string ManufacturerName { get; }
//
// 		
// 		
// 		string ShortName { get; }
//
// 		
// 		uint ComponentVersion { get; }
//
// 		
// 		bool AllocateRenderResources ( out NSError outError);
//
// 		
// 		void DeallocateRenderResources ();
//
// 		
// 		bool RenderResourcesAllocated { get; }
//
// 		
// 		void Reset ();
//
// 		
// 		AUAudioUnitBusArray InputBusses { get; }
//
// 		
// 		AUAudioUnitBusArray OutputBusses { get; }
//
// 		
// 		AUScheduleParameterBlock ScheduleParameterBlock { get; }
//
// 		// TODO: https://github.com/xamarin/xamarin-macios/issues/12489
// 		// 
// 		// 
// 		// 
// 		// AUMidiEventListBlock ScheduleMidiEventListBlock { get; }
//
// // 		
// // 		nint GetToken (AURenderObserver observer);
//
// // 		
// // 		AUScheduleMidiEventBlock ScheduleMidiEventBlock { get; }
//
// // 		
// // 		AUHostMusicalContextBlock MusicalContextBlock { get; set; }
//
// 		
// 		
// 		string MidiOutputNames { get; }
//
// 		// TODO: https://github.com/xamarin/xamarin-macios/issues/12489
// 		// 
// 		// 
// 		// 
// 		// AUMidiEventListBlock MidiOutputEventListBlock { get; set; }
//
// 		// TODO: https://github.com/xamarin/xamarin-macios/issues/12489
// 		// 
// 		// 
// 		// MIDIProtocolID AudioUnitMidiProtocol { get; }
//
// 		// TODO: https://github.com/xamarin/xamarin-macios/issues/12489
// 		// 
// 		// 
// 		// MIDIProtocolID HostMIDIProtocol { get; set; }
//
// 		
// 		
// 		bool ProvidesUserInterface { get; }
//
// 		
// 		
// 		AUMidiOutputEventBlock MidiOutputEventBlock { get; set; }
//
// 		
// 		AUHostTransportStateBlock TransportStateBlock { get; set; }
//
// 		
// 		void RemoveRenderObserver (nint token);
//
// 		
// 		uint MaximumFramesToRender { get; set; }
//
// 		
// 		
// 		AUParameterTree ParameterTree {
// 			get; 
// 			
// 			set;
// 		}
//
// 		
// 		NSNumber GetParametersForOverview (nint count);
//
// 		
// 		bool AllParameterValues { get; }
//
// 		
// 		bool MusicDeviceOrEffect {  get; }
//
// 		
// 		nint VirtualMidiCableCount { get; }
//
// 		// @property (copy, nonatomic) NSDictionary<NSString * __nonnull,id __nonnull> * __nullable fullState;
// 		
// 		NSDictionary FullState { get; set; }
//
// 		// @property (copy, nonatomic) NSDictionary<NSString * __nonnull,id __nonnull> * __nullable fullStateForDocument;
// 		
// 		NSDictionary FullStateForDocument { get; set; }
//
// 		
// 		AUAudioUnitPreset FactoryPresets { get; }
//
// 		
// 		AUAudioUnitPreset CurrentPreset { get; set; }
//
// 		
// 		double Latency { get; }
//
// 		
// 		double TailTime { get; }
//
// 		
// 		nint RenderQuality { get; set; }
//
// 		
// 		bool ShouldBypassEffect { get; set; }
//
// 		
// 		bool CanProcessInPlace { get; }
//
// 		
// 		bool RenderingOffline {  get; set; }
//
// 		
// 		NSNumber ChannelCapabilities { get; }
//
// 		
// 		string ContextName { get; set; }
//
// 		
// 		
// 		bool SupportsMpe { get; }
//
// 		
// 		
// 		NSNumber  ChannelMap { get; set; }
//
// 		
// 		
// 		
// 		void RequestViewController (Action<AUViewControllerBase> completionHandler);
// 		
// 		// AUAudioUnitImplementation
// 		
// 		void SetRenderResourcesAllocated (bool flag);
//
// 		
// 		bool ShouldChangeToFormat (AVAudioFormat format, AUAudioUnitBus bus);
//
// 		
// 		NSString AudioComponentRegistrationsChangedNotification { get; }
//
// 		
// 		NSString AudioComponentInstanceInvalidationNotification { get; }
//
// 		
// 		
// 		nint MidiOutputBufferSizeHint { get; set; }
//
// 		
// 		
// 		MidiCIProfileState GetProfileState (byte cable, byte channel);
//
// 		
// 		
// 		AUMidiCIProfileChangedCallback ProfileChangedCallback { get; set; }
//
// 		
// 		
// 		bool Disable (MidiCIProfile profile, byte cable, byte channel,  out NSError outError);
//
// 		
// 		
// 		bool Enable (MidiCIProfile profile, byte cable, byte channel,  out NSError outError);
//
// 		
// 		
// 		AUAudioUnitPreset UserPresets { get; }
//
// 		
// 		
// 		bool SaveUserPreset (AUAudioUnitPreset userPreset,  out NSError outError);
//
// 		
// 		
// 		bool DeleteUserPreset (AUAudioUnitPreset userPreset,  out NSError outError);
//
// 		
// 		
// 		
// 		NSDictionary<NSString, NSObject> GetPresetState (AUAudioUnitPreset userPreset,  out NSError outError);
//
// 		
// 		
// 		bool SupportsUserPresets { get; }
//
// 		 // needed since it's not in iOS
// 		
// 		
// 		bool IsLoadedInProcess { get; }
// 	}
//
// 	// kept separate from AUAudioUnit, quote:
// 	// These methods will fail if the audio unit is not an input/output audio unit.
// 	
// 	
// 	
// 	interface AUAudioUnit_AUAudioInputOutputUnit {
//
// 		
// 		
// 		uint GetDeviceId ();
//
// 		
// 		
// 		bool SetDeviceId (uint deviceID, out NSError outError);
//
// 		
// 		bool GetCanPerformInput ();
//
// 		
// 		bool CanPerformOutput ();
//
// 		
// 		bool IsInputEnabled ();
// 	
// 		
// 		bool SetInputEnabled (bool enabled);
//
// 		
// 		bool IsOutputEnabled ();
//
// 		
// 		bool SetOutputEnabled (bool enabled);
// 		
// 		
// 		
// 		AUInputHandler GetInputHandler ();
//
// 		
// 		void SetInputHandler ( AUInputHandler handler);
//
// 		
// 		bool StartHardware ( out NSError outError);
//
// 		
// 		void StopHardware ();
//
// 		
// 		
// 		AURenderPullInputBlock GetOutputProvider ();
//
// 		
// 		void SetOutputProvider ( AURenderPullInputBlock provider);
//
// 		// the following are properties but we cannot have properties in Categories.
// 		
// 		
// 		double GetDeviceInputLatency ();
//
// 		
// 		
// 		double GetDeviceOutputLatency ();
//
// 		
// 		
// 		bool IsRunning ();
// 	}
//
// 	
// 	
// 	interface AUAudioUnitBus
// 	{
// 		
// 		NativeHandle Constructor (AVAudioFormat format,  out NSError outError);
//
// 		
// 		AVAudioFormat Format { get; }
//
// 		
// 		bool SetFormat (AVAudioFormat format,  out NSError outError);
//
// 		
// 		bool Enabled {  get; set; }
//
// 		
// 		string Name { get; set; }
//
// 		
// 		nuint Index { get; }
//
// 		
// 		AUAudioUnitBusType BusType { get; }
//
// 		
// 		AUAudioUnit OwnerAudioUnit { get; }
//
// 		
// 		NSNumber SupportedChannelLayoutTags { get; }
//
// 		
// 		double ContextPresentationLatency { get; set; }
//
// 		// AUAudioUnitImplementation
// 		
// 		NSNumber SupportedChannelCounts { get; set; }
//
// 		
// 		uint MaximumChannelCount { get; set; }
//
// 		
// 		
// 		bool ShouldAllocateBuffer { get; set; }
// 	}
//
// 	
// 	
// 	
// 	interface AUAudioUnitBusArray : INSFastEnumeration
// 	{
// 		
// 		
// 		NativeHandle Constructor (AUAudioUnit owner, AUAudioUnitBusType busType, AUAudioUnitBus busArray);
//
// 		
// 		NativeHandle Constructor (AUAudioUnit owner, AUAudioUnitBusType busType);
//
// 		
// 		nuint Count { get; }
//
// 		// -(AUAudioUnitBus * __nonnull)objectAtIndexedSubscript:(NSUInteger)index;
// 		
// 		AUAudioUnitBus GetObject (nuint index);
//
// 		
// 		bool CountChangeable {  get; }
//
// 		
// 		bool SetBusCount (nuint count,  out NSError outError);
//
// 		// -(void)addObserverToAllBusses:(NSObject * __nonnull)observer forKeyPath:(NSString * __nonnull)keyPath options:(NSKeyValueObservingOptions)options context:(void * __nullable)context;
// 		
// 		void AddObserver (NSObject observer, string keyPath, NSKeyValueObservingOptions options, /* void * */ IntPtr context);
//
// 		// -(void)removeObserverFromAllBusses:(NSObject * __nonnull)observer forKeyPath:(NSString * __nonnull)keyPath context:(void * __nullable)context;
// 		
// 		void RemoveObserver (NSObject observer, string keyPath, /* void * */ IntPtr context);
//
// 		
// 		AUAudioUnit OwnerAudioUnit { get; }
//
// 		
// 		AUAudioUnitBusType BusType { get; }
//
// 		//AUAudioUnitBusImplementation
// 		
// 		void ReplaceBusses (AUAudioUnitBus busArray);
// 	}
//
// 	
// 	
// 	interface AUAudioUnitPreset : NSSecureCoding
// 	{
// 		
// 		nint Number { get; set; }
//
// 		
// 		string Name { get; set; }
// 	}
//
// 	
// 	
// 	interface AUParameter : NSSecureCoding
// 	{
// 		
// 		float MinValue { get; }
//
// 		
// 		float MaxValue { get; }
//
// 		
// 		AudioUnitParameterUnit Unit { get; }
//
// 		
// 		string UnitName { get; }
//
// 		
// 		AudioUnitParameterOptions Flags { get; }
//
// 		
// 		ulong Address { get; }
//
// 		
// 		string ValueStrings { get; }
//
// 		
// 		NSNumber DependentParameters { get; }
//
// 		
// 		float Value { get; set; }
//
// 		
// 		void SetValue (float value, IntPtr originator);
//
// 		
// 		void SetValue (float value, AUParameterObserverToken originator);
//
// 		
// 		void SetValue (float value, IntPtr originator, ulong hostTime);
//
// 		
// 		void SetValue (float value, AUParameterObserverToken originator, ulong hostTime);
//
// 		// -(NSString * __nonnull)stringFromValue:(const AUValue * __nullable)value;
// 		
// 		string GetString (ref float value);
//
// 		
// 		string _GetString (IntPtr value);
//
// 		
// 		float GetValue (string str);
//
// 		
// 		
// 		
// 		
// 		void SetValue (float value, IntPtr originator, ulong hostTime, AUParameterAutomationEventType eventType);
//
// 		
// 		
// 		void SetValue (float value, AUParameterObserverToken originator, ulong hostTime, AUParameterAutomationEventType eventType);
// 	}
//
// 	
// 	delegate void AUParameterAutomationObserver (ulong address, float value);
//
// 	
// 	
// 	interface AUParameterNode
// 	{
// 		
// 		string Identifier { get; }
//
// 		
// 		string KeyPath { get; }
//
// 		
// 		string DisplayName { get; }
//
// 		
// 		string GetDisplayName (nint maximumLength);
//
// 		
// 		/* void * */ IntPtr TokenByAddingParameterObserver (AUParameterObserver observer);
//
// 		
// 		AUParameterObserverToken CreateTokenByAddingParameterObserver (AUParameterObserver observer);
//
// 		
// 		/* void * */ IntPtr TokenByAddingParameterRecordingObserver (AUParameterRecordingObserver observer);
//
// 		
// 		AUParameterObserverToken CreateTokenByAddingParameterRecordingObserver (AUParameterRecordingObserver observer);
//
// 		
// 		AUImplementorValueObserver ImplementorValueObserver { get; set; }
//
// 		
// 		AUImplementorValueProvider ImplementorValueProvider { get; set; }
//
//  		
//  		AUImplementorValueFromStringCallback ImplementorValueFromStringCallback { get; set; }
//
// 		
// 		void RemoveParameterObserver (/* void * */ IntPtr token);
//
// 		
// 		void RemoveParameterObserver (AUParameterObserverToken token);
//
// 		
// 		AUImplementorStringFromValueCallback ImplementorStringFromValueCallback { get; set; }
//
// 		
// 		AUImplementorDisplayNameWithLengthCallback ImplementorDisplayNameWithLengthCallback { get; set; }
//
// 		
// 		
// 		
// 		
// 		IntPtr _GetToken (AUParameterAutomationObserver observer);
//
// 		
// 		
// 		
// 		AUParameterObserverToken GetToken (AUParameterAutomationObserver observer);
// 	}
//
// 	
// 	
// 	interface AUParameterGroup : NSSecureCoding
// 	{
// 		
// 		AUParameterNode Children { get; }
//
// 		
// 		AUParameter AllParameters { get; }
// 	}
//
// 	
// 	
// 	interface AUParameterTree : NSSecureCoding
// 	{
// 		
// 		
// 		AUParameter GetParameter (ulong address);
//
// 		
// 		
// 		AUParameter GetParameter (uint paramID, uint scope, uint element);
//
// 		//Factory
// 		
// 		
// 		AUParameter CreateParameter (string identifier, string name, ulong address, float min, float max, AudioUnitParameterUnit unit,  string unitName, AudioUnitParameterOptions flags,  string valueStrings,  NSNumber dependentParameters);
//
// 		
// 		
// 		AUParameterGroup CreateGroup (string identifier, string name, AUParameterNode children);
//
// 		
// 		
// 		AUParameterGroup CreateGroupTemplate (AUParameterNode children);
//
// 		
// 		
// 		AUParameterGroup CreateGroup (AUParameterGroup templateGroup, string identifier, string name, ulong addressOffset);
//
// 		
// 		
// 		AUParameterTree CreateTree (AUParameterNode children);
// 	}
//
// 	
// 	interface AUAudioUnitFactory : NSExtensionRequestHandling
// 	{
// 		
// 		
// 		
// 		AUAudioUnit CreateAudioUnit (AudioComponentDescription desc,  out NSError error);
// 	}
// }

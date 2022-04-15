// 
// ScheduledAudioFileRegion.cs: A wrapper class around ScheduledAudioFileRegionProxy struct
//
// Authors:
//    Rustam Zaitov (rustam.zaitov@xamarin.com)
//    Alex Soto (alex.soto@xamarin.com)
// 
// Copyright 2015 Xamarin Inc.
//

#nullable enable

using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.AudioToolbox;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioUnit;

public delegate void AUScheduledAudioFileRegionCompletionHandler(AUScheduledAudioFileRegion audioFileRegion,
    AudioUnitStatus status);

public class AUScheduledAudioFileRegion : IDisposable
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ScheduledAudioFileRegion
    {
        public AudioTimeStamp TimeStamp;
        public ScheduledAudioFileRegionCompletionHandler CompletionHandler;
        public /* void * */ IntPtr CompletionHandlerUserData;
        public IntPtr AudioFile;
        public uint LoopCount;
        public long StartFrame;
        public uint FramesToPlay;
    }

    private GCHandle handle;
    private AUScheduledAudioFileRegionCompletionHandler? completionHandler;
    private bool alreadyUsed = false;

    public AudioTimeStamp TimeStamp { get; set; }
    public AudioFile AudioFile { get; private set; }
    public uint LoopCount { get; set; }
    public long StartFrame { get; set; }
    public uint FramesToPlay { get; set; }

    public AUScheduledAudioFileRegion(AudioFile audioFile,
        AUScheduledAudioFileRegionCompletionHandler? completionHandler = null)
    {
        if (audioFile is null)
            ThrowHelper.ThrowArgumentNullException(nameof(audioFile));

        AudioFile = audioFile;
        this.completionHandler = completionHandler;
    }

    internal delegate void ScheduledAudioFileRegionCompletionHandler(
        /* void * */ IntPtr userData,
        /* ScheduledAudioFileRegion * */ IntPtr fileRegion,
        /* OSStatus */ AudioUnitStatus result);

    private static readonly ScheduledAudioFileRegionCompletionHandler static_ScheduledAudioFileRegionCompletionHandler =
        new(ScheduledAudioFileRegionCallback);

    private static void ScheduledAudioFileRegionCallback(IntPtr userData, IntPtr fileRegion, AudioUnitStatus status)
    {
        if (userData == IntPtr.Zero)
            return;

        var handle = GCHandle.FromIntPtr(userData);
        var inst = (AUScheduledAudioFileRegion?) handle.Target;
        if (inst?.completionHandler is not null)
            inst.completionHandler(inst, status);
    }

    internal ScheduledAudioFileRegion GetAudioFileRegion()
    {
        if (alreadyUsed)
            throw new InvalidOperationException(
                "You should not call SetScheduledFileRegion with a previously set region instance");

        var ptr = IntPtr.Zero;
        if (completionHandler is not null)
        {
            handle = GCHandle.Alloc(this);
            ptr = GCHandle.ToIntPtr(handle);
        }

        var ret = new ScheduledAudioFileRegion
        {
            TimeStamp = TimeStamp,
            CompletionHandlerUserData = ptr,
            AudioFile = AudioFile.Handle,
            LoopCount = LoopCount,
            StartFrame = StartFrame,
            FramesToPlay = FramesToPlay
        };

        if (ptr != IntPtr.Zero)
            ret.CompletionHandler = static_ScheduledAudioFileRegionCompletionHandler;

        alreadyUsed = true;
        return ret;
    }

    ~AUScheduledAudioFileRegion()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            completionHandler = null;

        if (handle.IsAllocated)
            handle.Free();
    }
}
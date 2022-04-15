using System;
using System.Runtime.InteropServices;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioToolbox;

public abstract class AudioSource : AudioFile
{
    private static ReadProc dRead;
    private static WriteProc dWrite;
    private static GetSizeProc dGetSize;
    private static SetSizeProc dSetSize;

    private GCHandle gch;

    static AudioSource()
    {
        dRead = SourceRead;
        dWrite = SourceWrite;
        dGetSize = SourceGetSize;
        dSetSize = SourceSetSize;
    }

    // [MonoPInvokeCallback (typeof(ReadProc))]
    private static int SourceRead(IntPtr clientData, long inPosition, int requestCount, IntPtr buffer,
        out int actualCount)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var audioSource = handle.Target as AudioSource;
        actualCount = 0;
        return audioSource?.Read(inPosition, requestCount, buffer, out actualCount) == true ? 0 : 1;
    }

    public abstract bool Read(long position, int requestCount, IntPtr buffer, out int actualCount);

    // [MonoPInvokeCallback (typeof(WriteProc))]
    private static int SourceWrite(IntPtr clientData, long position, int requestCount, IntPtr buffer,
        out int actualCount)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var audioSource = handle.Target as AudioSource;
        actualCount = 0;
        return audioSource?.Write(position, requestCount, buffer, out actualCount) == true ? 0 : 1;
    }

    public abstract bool Write(long position, int requestCount, IntPtr buffer, out int actualCount);

    // [MonoPInvokeCallback (typeof(GetSizeProc))]
    private static long SourceGetSize(IntPtr clientData)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var audioSource = handle.Target as AudioSource;
        return audioSource?.Size ?? 0;
    }

    // [MonoPInvokeCallback (typeof(SetSizeProc))]
    private static int SourceSetSize(IntPtr clientData, long size)
    {
        var handle = GCHandle.FromIntPtr(clientData);
        var audioSource = handle.Target as AudioSource;

        if (audioSource is not null)
            audioSource.Size = size;
        return 0;
    }

    public abstract long Size { get; set; }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (gch.IsAllocated)
            gch.Free();
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern int AudioFileInitializeWithCallbacks(
        IntPtr inClientData, ReadProc inReadFunc, WriteProc inWriteFunc, GetSizeProc inGetSizeFunc,
        SetSizeProc inSetSizeFunc,
        AudioFileType inFileType, ref AudioStreamBasicDescription format, uint flags, out IntPtr id);

    public AudioSource(AudioFileType inFileType, AudioStreamBasicDescription format)
    {
        Initialize(inFileType, format);
    }

    public AudioSource()
    {
    }

    protected void Initialize(AudioFileType inFileType, AudioStreamBasicDescription format)
    {
        gch = GCHandle.Alloc(this);
        var code = AudioFileInitializeWithCallbacks(GCHandle.ToIntPtr(gch), dRead, dWrite, dGetSize, dSetSize,
            inFileType, ref format, 0, out var handle);
        if (code == 0)
        {
            InitializeHandle(handle);
            return;
        }

        throw new Exception($"Unable to create AudioSource, code: 0x{code:x}");
    }

    [DllImport(Constants.AudioToolboxLibrary)]
    private static extern int AudioFileOpenWithCallbacks(
        IntPtr inClientData, ReadProc inReadFunc, WriteProc inWriteFunc,
        GetSizeProc inGetSizeFunc, SetSizeProc inSetSizeFunc, AudioFileType inFileTypeHint,
        out IntPtr outAudioFile);

    public AudioSource(AudioFileType fileTypeHint)
    {
        Open(fileTypeHint);
    }

    protected void Open(AudioFileType fileTypeHint)
    {
        gch = GCHandle.Alloc(this);
        var code = AudioFileOpenWithCallbacks(GCHandle.ToIntPtr(gch), dRead, dWrite, dGetSize, dSetSize,
            fileTypeHint, out var handle);
        if (code == 0)
        {
            InitializeHandle(handle);
            return;
        }

        throw new Exception($"Unable to create AudioSource, code: 0x{code:x}");
    }
}
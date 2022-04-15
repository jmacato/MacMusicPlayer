using System;
using System.Collections;
using System.Collections.Generic;
using MacMusicPlayer.ObjCRuntime;

namespace MacMusicPlayer.AudioUnit;

public unsafe class AURenderEventEnumerator : INativeObject
    , IEnumerator<AURenderEvent>
{
    private AURenderEvent* current;

    public IntPtr Handle { get; private set; }

    public bool IsEmpty => Handle == IntPtr.Zero;

    public bool IsAtEnd => current is null;

    public AURenderEventEnumerator(IntPtr ptr)
        : this(ptr, false)
    {
    }

    ////[Preserve (Conditional = true)]
    internal AURenderEventEnumerator(IntPtr handle, bool owns)
    {
        Handle = handle;
        current = (AURenderEvent*) (IntPtr) handle;
    }

    public void Dispose()
    {
        Handle = IntPtr.Zero;
        current = null;
    }

    public AURenderEvent* UnsafeFirst => (AURenderEvent*) (IntPtr) Handle;

    public AURenderEvent First
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException("Can not get First on AURenderEventEnumerator when empty");
            return *(AURenderEvent*) (IntPtr) Handle;
        }
    }

    public AURenderEvent Current
    {
        get
        {
            if (IsAtEnd)
                throw new InvalidOperationException("Can not get Current on AURenderEventEnumerator when at end");
            return *current;
        }
    }

    object IEnumerator.Current => Current;

    private bool IsAt(nint now)
    {
        return current is not null && current->Head.EventSampleTime == now;
    }

    public IEnumerable<AURenderEvent> EnumeratorCurrentEvents(nint now)
    {
        if (IsAtEnd)
            throw new InvalidOperationException("Can not enumerate events on AURenderEventEnumerator when at end");

        do
        {
            yield return Current;
            MoveNext();
        } while (IsAt(now));
    }

    public bool /*IEnumerator<AURenderEvent>.*/ MoveNext()
    {
        if (current is not null)
            current = ((AURenderEvent*) current)->Head.UnsafeNext;
        return current is not null;
    }

    public void /*IEnumerator<AURenderEvent>.*/ Reset()
    {
        current = (AURenderEvent*) (IntPtr) Handle;
    }
}
using System.Runtime.InteropServices;

namespace MacMusicPlayer.CoreFoundation;

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
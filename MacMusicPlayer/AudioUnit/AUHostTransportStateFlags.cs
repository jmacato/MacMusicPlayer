namespace MacMusicPlayer.AudioUnit;

public enum AUHostTransportStateFlags : ulong
{
    Changed = 1,
    Moving = 2,
    Recording = 4,
    Cycling = 8
}
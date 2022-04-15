namespace MacMusicPlayer.AudioUnit;

public enum AudioComponentValidationResult : uint
{
    Unknown = 0,
    Passed,
    Failed,
    TimedOut,
    UnauthorizedErrorOpen,
    UnauthorizedErrorInit
}
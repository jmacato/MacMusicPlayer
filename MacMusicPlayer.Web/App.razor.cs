using Avalonia.Web.Blazor;

namespace MacMusicPlayer.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<MacMusicPlayer.App>()
            .SetupWithSingleViewLifetime();
    }
}
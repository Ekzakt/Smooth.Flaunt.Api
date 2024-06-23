using Ekzakt.Utilities.Extensions;

namespace Smooth.Flaunt.Shared.Configurations;

public class AppVersions
{
    public string App { get; set; } = string.Empty;

    public string FrameWork { get; init; } = string.Empty;


    public AppVersions() { }


    public AppVersions(Version assemblyVersion, Version environmentVersion)
    {
        App = assemblyVersion.Format();
        FrameWork = environmentVersion.Format();
    }
}

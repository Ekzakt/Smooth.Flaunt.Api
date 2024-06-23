namespace Smooth.Flaunt.Shared.Configurations.Options.Azure;

public class AzureSignalROptions
{
    public const string SectionName = "Azure:SignalR";

    public string? ConnectionString { get; init; }
}

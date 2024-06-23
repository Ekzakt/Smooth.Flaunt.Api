namespace Smooth.Flaunt.Shared.Configurations.Options.Azure;

public class AzureApplicationInsightsOptions
{
    public const string SectionName = "Azure:ApplicationInsights";

    public string ConnectionString { get; init; } = string.Empty;
}

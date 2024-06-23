namespace Smooth.Flaunt.Shared.Configurations.Options;

public class CorsOptions
{
    public const string SectionName = "Cors";

    public const string POLICY_NAME = "AllowedOrigins";

    public string[] AllowedOrigins { get; init; } = Array.Empty<string>();
}

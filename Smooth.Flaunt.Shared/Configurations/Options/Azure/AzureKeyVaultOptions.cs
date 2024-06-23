namespace Smooth.Flaunt.Shared.Configurations.Options.Azure;

public class AzureKeyVaultOptions
{
    public const string SectionName = "Azure:KeyVault";

    public string VaultUri { get; init; } = string.Empty;
}
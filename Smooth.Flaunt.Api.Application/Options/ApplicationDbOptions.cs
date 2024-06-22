namespace Smooth.Flaunt.Api.Application.Options;

public class ApplicationDbOptions
{
    public const string SectionName = "ApplicationDb";

    public string? ConnectionString { get; init; }
}

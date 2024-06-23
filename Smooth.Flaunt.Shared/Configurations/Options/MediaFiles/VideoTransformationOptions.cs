namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public class VideoTransformationOptions : IMediaFileTransformationOptions
{
    public string Name { get; init; } = string.Empty;
    public string[] Tags { get; init; } = Array.Empty<string>();
}

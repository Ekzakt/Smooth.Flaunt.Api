namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public class VideoOptions : IMediaFileOptions
{
    public static string SectionName => "Videos";

    public long MaxLength { get; init; } = 104857600; // 100 MB
    public string[] Destinations { get; init; } = Array.Empty<string>();
    public MimeType[] MimeTypes { get; init; } = Array.Empty<MimeType>();
    public string OutputMimeTypeValue { get; init; } = string.Empty;
    public string[] Tags { get; init; } = Array.Empty<string>();
    public VideoTransformationOptions[] Transformations { get; init; } = Array.Empty<VideoTransformationOptions>();
    public int UploadCount => Transformations.Length == 0 ? 1 : Transformations.Length;
}

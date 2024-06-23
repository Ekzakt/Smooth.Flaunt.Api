namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public class SoundOptions : IMediaFileOptions
{
    public static string SectionName => "Sounds";

    public long MaxLength { get; init; } = 52428800; // 50 MB
    public string OutputMimeTypeValue { get; init; } = string.Empty;
    public string[] Destinations { get; init; } = Array.Empty<string>();
    public MimeType[] MimeTypes { get; init; } = Array.Empty<MimeType>();
    public string[] Tags { get; init; } = Array.Empty<string>();
    public int UploadCount => 1;
}

namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public interface IMediaFileOptions
{
    static string? SectionName { get; }

    long MaxLength { get; init; }
    string OutputMimeTypeValue { get; init; }
    string[] Destinations { get; init; }
    MimeType[] MimeTypes { get; init; }
    string[] Tags { get; init; }

    public int UploadCount { get; }
}

namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public class MediaFilesOptions
{
    public static string SectionName => "MediaFiles";

    public ImageOptions Images { get; init; } = new();
    public VideoOptions Videos { get; init; } = new();
    public SoundOptions Sounds { get; set; } = new();
    public List<MimeType> AllMimeTypes => Images.MimeTypes.Concat(Videos.MimeTypes).ToList();
}

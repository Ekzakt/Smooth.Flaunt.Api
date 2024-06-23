using System.Drawing;

namespace Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

public class ImageTransformationOptions : IMediaFileTransformationOptions
{
    public string Name { get; init; } = string.Empty;
    public string[] Tags { get; init; } = Array.Empty<string>();
    public Size Size { get; init; } = new Size(0, 0);
    public Rectangle Crop { get; init; } = new Rectangle(-1, -1, 0, 0);

    public bool IsProcessable()
    {
        return Size.Width != 0 || Size.Height != 0 || Crop.Width != 0 || Crop.Height != 0;
    }

    public bool IsCroppable()
    {
        return Crop.Width != 0 && Crop.Height != 0;
    }

    public bool IsResizable()
    {
        return Size.Width != 0 && Size.Height != 0;
    }
}

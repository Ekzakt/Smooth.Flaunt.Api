namespace Smooth.Flaunt.Shared.Configurations.Options;

public class FileManagerOptions
{
    public string[] ContainerNames { get; set; } = Array.Empty<string>();

    public UploadOptions Upload { get; set; } = new();


    public class UploadOptions
    {
        public long InitialTransferSize { get; init; } = 4 * 1024 * 1024;

        public long MaximumTransferSize { get; init; } = 4 * 1024 * 1024;
    }

}



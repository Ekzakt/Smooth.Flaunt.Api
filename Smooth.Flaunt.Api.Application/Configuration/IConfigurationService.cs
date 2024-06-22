using Smooth.Shared.Configurations;
using Smooth.Shared.Configurations.Options;
using Smooth.Shared.Configurations.Options.Azure;
using Smooth.Shared.Configurations.Options.MediaFiles;

namespace Smooth.Flaunt.Api.Application.Configuration;

public interface IConfigurationService
{
    Task<MediaFilesOptions> GetMediaFilesOptionsAsync();

    Task<IMediaFileOptions> GetMediaFileOptionsAsync(string mediaFileOptionsName);

    Task<AppVersions> GetAppVersionsAsync(Version assemblyVersion, Version environmentVersion);

    Task<AzureOptions> GetAzureOptionsAsync();

    Task<CorsOptions> GetCorsOptionsAsync();

    Task<FileManagerOptions> GetEkzaktFileManagerOptions();
}

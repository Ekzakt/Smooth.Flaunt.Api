using Smooth.Flaunt.Shared.Configurations;
using Smooth.Flaunt.Shared.Configurations.Options;
using Smooth.Flaunt.Shared.Configurations.Options.Azure;
using Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

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

using Microsoft.Extensions.Options;
using Smooth.Flaunt.Api.Application.Configuration;
using Smooth.Flaunt.Shared.Configurations;
using Smooth.Flaunt.Shared.Configurations.Options;
using Smooth.Flaunt.Shared.Configurations.Options.Azure;
using Smooth.Flaunt.Shared.Configurations.Options.MediaFiles;

namespace Smooth.Flaunt.Api.Infrastructure.Configuration;

public class ConfigurationService
    : IConfigurationService
{
    private readonly MediaFilesOptions _mediaFileOptions;
    private readonly FileManagerOptions _fileManagerOptions;
    private readonly AzureOptions _azureOptions;
    private readonly CorsOptions _corsOptions;


    public ConfigurationService(
        IOptions<MediaFilesOptions> mediaFileOptions,
        IOptions<FileManagerOptions> fileManagerOptions,
        IOptions<AzureOptions> azureOptions,
        IOptions<CorsOptions> corsOptions)
    {
        _mediaFileOptions = mediaFileOptions.Value;
        _fileManagerOptions = fileManagerOptions.Value;
        _azureOptions = azureOptions.Value;
        _corsOptions = corsOptions.Value;
    }


    public async Task<IMediaFileOptions> GetMediaFileOptionsAsync(string mediaFileOptionsName)
    {
        IMediaFileOptions options = mediaFileOptionsName switch
        {
            nameof(ImageOptions) => _mediaFileOptions.Images,
            nameof(VideoOptions) => _mediaFileOptions.Videos,
            nameof(SoundOptions) => _mediaFileOptions.Sounds,
            _ => throw new NotImplementedException()
        };

        IMediaFileOptions result = await Task.Run(() =>
        {
            return options;
        });

        return result;
    }


    public async Task<MediaFilesOptions> GetMediaFilesOptionsAsync()
    {
        MediaFilesOptions result = await Task.Run(() =>
        {
            return _mediaFileOptions;
        });

        return result;
    }


    public async Task<FileManagerOptions> GetEkzaktFileManagerOptions()
    {
        FileManagerOptions result = await Task.Run(() =>
        {
            return _fileManagerOptions;
        });

        return result;
    }


    public async Task<AppVersions> GetAppVersionsAsync(Version assemblyVersion, Version environmentVersion)
    {
        AppVersions result = await Task.Run(() =>
        {
            return new AppVersions(assemblyVersion, environmentVersion);
        });

        return result;
    }


    public async Task<AzureOptions> GetAzureOptionsAsync()
    {
        AzureOptions result = await Task.Run(() =>
        {
            return _azureOptions;
        });

        return result;
    }


    public async Task<CorsOptions> GetCorsOptionsAsync()
    {
        CorsOptions result = await Task.Run(() =>
        {
            return _corsOptions;
        });

        return result;
    }
}

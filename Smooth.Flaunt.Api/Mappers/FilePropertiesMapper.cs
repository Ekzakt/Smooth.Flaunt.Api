using AutoMapper;
using Ekzakt.FileManager.Core.Models;
using Smooth.Shared.Models;

namespace Smooth.Flaunt.Api.Mappers;

public class FilePropertiesMapper : Profile
{
    public FilePropertiesMapper()
    {
        CreateMap<FileInformation, FileInformationDto>()
            .ReverseMap();
    }
}
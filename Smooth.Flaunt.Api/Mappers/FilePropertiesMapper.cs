using AutoMapper;
using Ekzakt.FileManager.Core.Models;
using Smooth.Flaunt.Shared.Models.Dtos;

namespace Smooth.Flaunt.Api.Mappers;

public class FilePropertiesMapper : Profile
{
    public FilePropertiesMapper()
    {
        CreateMap<FileInformation, FileInformationDto>()
            .ReverseMap();
    }
}
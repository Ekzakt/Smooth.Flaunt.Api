using Smooth.Flaunt.Shared.Models.Dtos;

namespace Smooth.Flaunt.Shared.Models.Responses;

public class GetFilesListResponse
{
    public List<FileInformationDto> Files { get; set; } = new();
}

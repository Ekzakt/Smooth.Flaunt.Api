using Smooth.Flaunt.Shared.Models;

namespace Smooth.Flaunt.Shared.Models.Responses;

public class GetFilesListResponse
{
    public List<FileInformationDto> Files { get; set; } = new();
}

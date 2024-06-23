namespace Smooth.Flaunt.Shared.Models;

public class FileInformationDto
{
    public string Name { get; set; } = string.Empty;

    public long Size { get; set; } = 0;

    public DateTime? CreatedOn { get; set; }
}

namespace Smooth.Flaunt.Shared.Models.Requests;

#nullable disable

public class SaveFileFormContentRequest
{
    public Guid Id { get; set; }

    public string ContentType { get; set; }

    public long InitialFileSize { get; set; }
}

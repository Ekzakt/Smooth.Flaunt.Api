namespace Smooth.Flaunt.Shared.Models.HubMessages;

public class ProgressHubMessage
{
    public Guid ProgressId { get; set; }

    public double PercentageDone { get; set; } = 0;
}

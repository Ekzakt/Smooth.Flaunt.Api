using Microsoft.AspNetCore.SignalR;
using Smooth.Flaunt.Shared.Models.HubMessages;

namespace Smooth.Flaunt.Api.Hubs;

public class ProgressHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }


    public async Task SendMessage(ProgressHubMessage progressHubMessage)
    {
        await Clients.All.SendAsync("ProgressChanged", progressHubMessage);
    }
}

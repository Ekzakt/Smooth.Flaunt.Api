using Microsoft.AspNetCore.SignalR;

namespace Smooth.Flaunt.Api.Hubs;

public class NotificationsHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public string ConnectionId => Context?.ConnectionId ?? string.Empty;


    public async Task SendMessage(int id)
    {
        await Clients.All.SendAsync("ReceiveMessage", id);
    }
}

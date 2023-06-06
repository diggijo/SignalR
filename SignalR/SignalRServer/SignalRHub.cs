using Microsoft.AspNetCore.SignalR;

public class SignalRHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("SentMessage", message);
    }
}
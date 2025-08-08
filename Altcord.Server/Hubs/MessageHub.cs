using Altcord.Server.Models;
using Altcord.Server.Models.Chat;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Hubs;

public class MessageHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", new ChatMessage
        {
            User = new User
            {
                UserName = user,
                AvatarUrl = "https://www.pravilamag.ru/upload/img_cache/6b5/6b5117915527810f6a2d20a9e38d5f46_ce_590x394x0x121.jpg"
            },
            Text = message,
            Timestamp = DateTime.UtcNow.ToString("dd.MM.yyyy HH:mm")
        });
    }
}

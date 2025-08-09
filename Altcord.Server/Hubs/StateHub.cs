using Altcord.Server.Services.Tracker;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Hubs;

public class StateHub(IOnlineTracker tracker) : Hub
{
    public async Task Heartbeat(Guid userId)
        => await tracker.Touch(userId, Context.ConnectionAborted);
    
    public async Task Typing(Guid userId)
    {
        await Clients.Others.SendAsync("typing", new { userId });
    }
}

using Altcord.Server.Core.Models;
using Altcord.Server.Core.Repositories.VoiceUsers;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Hubs;

public class VoiceHub(IVoiceUserRepository repository) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var username = Context.GetHttpContext()?.Request.Query["username"];

        if (username.HasValue)
            await repository.AddUser(Context.ConnectionId, username.Value!);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await repository.DeleteUser(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendOffer(string toConnectionId, string sdp, string username)
    {
        await Clients.Client(toConnectionId).SendAsync("ReceiveOffer", Context.ConnectionId, sdp, username);
    }

    public async Task SendAnswer(string toConnectionId, string sdp)
    {
        await Clients.Client(toConnectionId).SendAsync("ReceiveAnswer", Context.ConnectionId, sdp);
    }

    public async Task SendIceCandidate(string toConnectionId, string candidate)
    {
        await Clients.Client(toConnectionId).SendAsync("ReceiveIceCandidate", Context.ConnectionId, candidate);
    }

    public Task<List<PeerInfo>> GetPeers()
    {
        return Task.FromResult(
            repository
                .GetAll()
                .Where(x => x.ConnectionId != Context.ConnectionId)
                .ToList()
        );
    }
}

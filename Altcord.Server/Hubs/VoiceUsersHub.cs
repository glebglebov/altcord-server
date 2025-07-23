using Altcord.Server.Repositories.VoiceUsers;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Hubs;

public class VoiceUsersHub : Hub
{
    private readonly IVoiceUserRepository _repository;

    public VoiceUsersHub(IVoiceUserRepository repository, IHubContext<VoiceUsersHub> hubContext)
    {
        _repository = repository;

        _repository.Subscribe(async () =>
        {
            var allUsers = repository
                .GetAll()
                .Select(u => u.Username)
                .Distinct()
                .ToList();

            await hubContext.Clients.All.SendAsync("VoiceUsersUpdated", allUsers);
        });
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();

        var allUsers = _repository
            .GetAll()
            .Select(u => u.Username)
            .Distinct()
            .ToList();

        await Clients.Caller.SendAsync("VoiceUsersUpdated", allUsers);
    }
}

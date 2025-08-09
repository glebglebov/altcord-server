using Altcord.Server.Core.Repositories.Users;
using Altcord.Server.Hubs;
using Altcord.Server.Models;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Services.Notifications;

public class StateNotificator(IUserRepository repository, IHubContext<StateHub> hub)
    : IStateNotificator
{
    public async Task SendUserUpdated(Guid userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(userId);

        if (user is null)
            return;

        await Send(user, false, cancellationToken);
    }

    public async Task SendUserOnline(Guid userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(userId);

        if (user is null)
            return;

        await Send(user, true, cancellationToken);
    }

    public async Task SendUserOffline(Guid userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(userId);

        if (user is null)
            return;

        await Send(user, false, cancellationToken);
    }

    private async Task Send(Core.Models.User user, bool isOnline, CancellationToken cancellationToken)
    {
        await hub.Clients.All.SendAsync("userUpdated", Create(user, isOnline), cancellationToken);
    }

    private static User Create(Core.Models.User user, bool isOnline)
        => new()
        {
            Id = user.Id.ToString(),
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            Color = user.Color ?? "",
            IsOnline = isOnline
        };
}

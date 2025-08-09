using Altcord.Server.Core.Repositories.Messages;
using Altcord.Server.Core.Repositories.Users;
using Altcord.Server.Hubs;
using Altcord.Server.Models;
using Altcord.Server.Models.Events;
using Altcord.Server.Models.Events.Chat;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Services.Notifications;

public class StateNotificator(
    IUserRepository userRepository,
    IMessageRepository messageRepository,
    IHubContext<StateHub> hub)
    : IStateNotificator
{
    public async Task SendNewMessage(Guid messageId, CancellationToken cancellationToken)
    {
        var message = await messageRepository.GetById(messageId);

        if (message is null)
            return;

        await hub.Clients.All.SendAsync(
            "chatStateChanged",
            new NewMessageSent
            {
                Type = "new",
                Message = message.Map()
            },
            cancellationToken);
    }

    public async Task SendNewUserJoined(Guid userId, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(userId);

        if (user is null)
            return;

        await hub.Clients.All.SendAsync(
            "newUserJoined",
            new NewUserJoined
            {
                User = Map(user)
            },
            cancellationToken);
    }

    public async Task SendUserOnline(Guid userId, CancellationToken cancellationToken)
        => await SendUserStatusChanged(userId, true, cancellationToken);

    public async Task SendUserOffline(Guid userId, CancellationToken cancellationToken)
        => await SendUserStatusChanged(userId, false, cancellationToken);

    private async Task SendUserStatusChanged(Guid userId, bool isOnline, CancellationToken cancellationToken)
        => await hub.Clients.All.SendAsync(
            "userStatusChanged",
            new UserStatusChanged
            {
                UserId = userId.ToString(),
                IsOnline = isOnline
            },
            cancellationToken);

    private static User Map(Core.Models.User user)
        => new()
        {
            Id = user.Id.ToString(),
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            Color = user.Color ?? ""
        };
}

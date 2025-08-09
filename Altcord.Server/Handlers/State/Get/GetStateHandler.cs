using Altcord.Server.Core.Repositories.Messages;
using Altcord.Server.Core.Repositories.Users;
using Altcord.Server.Models;
using Altcord.Server.Services.Tracker;
using MediatR;

namespace Altcord.Server.Handlers.State.Get;

public class GetStateHandler(
    IUserRepository userRepository,
    IMessageRepository messageRepository,
    IOnlineTracker tracker)
    : IRequestHandler<GetStateCommand, ServerState>
{
    public async Task<ServerState> Handle(GetStateCommand command, CancellationToken cancellationToken)
    {
        var allUsers = await GetAllUsers(cancellationToken);
        var messages = await GetLastMessages(cancellationToken);

        return new ServerState
        {
            ServerName = Constants.ServerName,
            Users = allUsers,
            VoiceChannelUsers = [],
            Messages = messages
        };
    }

    private async Task<IReadOnlyCollection<ChatMessage>> GetLastMessages(CancellationToken cancellationToken)
    {
        var messages = await messageRepository.GetMessages(50, cancellationToken);

        return messages
            .Select(x => x.Map())
            .ToArray();
    }

    private async Task<IReadOnlyCollection<UserState>> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll();

        if (users.Count == 0)
            return [];

        var guids = users
            .Select(x => x.Id)
            .ToArray();

        var isOnlineMap = tracker.IsOnline(guids);

        return users
            .Select(u =>
            {
                var isOnline = isOnlineMap.TryGetValue(u.Id, out var value) && value;
                return Create(u, isOnline);
            })
            .ToArray();
    }

    private static UserState Create(Core.Models.User user, bool isOnline)
        => new()
        {
            Id = user.Id.ToString(),
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            Color = user.Color ?? "",
            IsOnline = isOnline
        };
}

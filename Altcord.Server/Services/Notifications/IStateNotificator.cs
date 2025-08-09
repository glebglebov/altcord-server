using Altcord.Server.Models;

namespace Altcord.Server.Services.Notifications;

public interface IStateNotificator
{
    Task SendUserUpdated(Guid userId, CancellationToken cancellationToken);
    Task SendUserOnline(Guid userId, CancellationToken cancellationToken);
    Task SendUserOffline(Guid userId, CancellationToken cancellationToken);
}

namespace Altcord.Server.Services.Notifications;

public interface IStateNotificator
{
    Task SendNewMessage(Guid messageId, CancellationToken cancellationToken);
    Task SendNewUserJoined(Guid userId, CancellationToken cancellationToken);
    Task SendUserOnline(Guid userId, CancellationToken cancellationToken);
    Task SendUserOffline(Guid userId, CancellationToken cancellationToken);
}

namespace Altcord.Server.Services.Tracker;

public interface IOnlineTracker
{
    bool IsOnline(Guid userId);
    Dictionary<Guid, bool> IsOnline(IReadOnlyList<Guid> userIds);

    Task RemoveUser(Guid userId, CancellationToken cancellationToken);
    Task Touch(Guid userId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Guid>> GetOnlineUserIds();
    Task<DateTimeOffset?> GetLastUserHeartbeat(Guid userId);
}

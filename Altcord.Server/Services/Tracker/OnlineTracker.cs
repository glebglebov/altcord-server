using System.Collections.Concurrent;
using Altcord.Server.Services.Notifications;

namespace Altcord.Server.Services.Tracker;

public class OnlineTracker(IStateNotificator notificator) : IOnlineTracker
{
    private readonly ConcurrentDictionary<Guid, DateTimeOffset> _lastHeartbeats = new();

    public bool IsOnline(Guid userId)
        => _lastHeartbeats.ContainsKey(userId);

    public Dictionary<Guid, bool> IsOnline(IReadOnlyList<Guid> userIds)
        => userIds.ToDictionary(k => k, v => _lastHeartbeats.ContainsKey(v));

    public async Task RemoveUser(Guid userId, CancellationToken cancellationToken)
    {
        if(_lastHeartbeats.TryRemove(userId, out _))
            await notificator.SendUserOffline(userId, cancellationToken);
    }

    public async Task Touch(Guid userId, CancellationToken cancellationToken)
    {
        var wasOffline = !_lastHeartbeats.ContainsKey(userId);

        _lastHeartbeats[userId] = DateTimeOffset.UtcNow;

        if (wasOffline)
            await notificator.SendUserOnline(userId, cancellationToken);
    }

    public Task<IReadOnlyCollection<Guid>> GetOnlineUserIds()
    {
        return Task.FromResult<IReadOnlyCollection<Guid>>(_lastHeartbeats.Keys.ToArray());
    }

    public Task<DateTimeOffset?> GetLastUserHeartbeat(Guid userId)
        => Task.FromResult<DateTimeOffset?>(_lastHeartbeats.TryGetValue(userId, out var value)
            ? value
            : null);
}

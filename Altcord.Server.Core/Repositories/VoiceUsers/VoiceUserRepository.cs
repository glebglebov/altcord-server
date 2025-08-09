using System.Collections.Concurrent;
using Altcord.Server.Core.Models;

namespace Altcord.Server.Core.Repositories.VoiceUsers;

public class VoiceUserRepository : IVoiceUserRepository
{
    private readonly ConcurrentDictionary<string, string> _users = [];
    private readonly List<Func<Task>> _subscribers = [];

    public async Task AddUser(string connectionId, string userName)
    {
        _users[connectionId] = userName;
        await NotifySubscribers();
    }

    public async Task DeleteUser(string connectionId)
    {
        _users.Remove(connectionId, out _);
        await NotifySubscribers();
    }

    public IEnumerable<PeerInfo> GetAll()
        => _users.Select(kv => new PeerInfo { ConnectionId = kv.Key, Username = kv.Value });

    public void Subscribe(Func<Task> onChange)
    {
        _subscribers.Add(onChange);
    }

    private async Task NotifySubscribers()
    {
        foreach (var callback in _subscribers)
        {
            try
            {
                await callback();
            }
            catch
            {
                /* логгировать при необходимости */
            }
        }
    }
}

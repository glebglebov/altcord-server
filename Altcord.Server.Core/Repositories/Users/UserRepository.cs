using System.Collections.Concurrent;
using Altcord.Server.Core.Models;

namespace Altcord.Server.Core.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<Guid, User> _users = new();

    public Task Create(User user, CancellationToken cancellationToken)
    {
        _users[user.Id] = user;
        return Task.CompletedTask;
    }

    public Task<User?> GetById(Guid id)
    {
        var result = _users.GetValueOrDefault(id);
        return Task.FromResult(result);
    }

    public Task<IReadOnlyCollection<User>> GetAll()
    {
        var results = _users.Values.ToArray();
        return Task.FromResult<IReadOnlyCollection<User>>(results);
    }
}

using System.Collections.Concurrent;
using Altcord.Server.Models;

namespace Altcord.Server.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<Guid, User> _users = new();

    public User Create(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required", nameof(username));

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = username.Trim(),
            Color = "#34D399",
            AvatarUrl = "https://www.pravilamag.ru/upload/img_cache/6b5/6b5117915527810f6a2d20a9e38d5f46_ce_590x394x0x121.jpg"
        };

        _users[user.Id] = user;
        return user;
    }

    public User? GetById(Guid id)
        => _users.GetValueOrDefault(id);

    public IEnumerable<User> GetAll()
        => _users.Values;
}
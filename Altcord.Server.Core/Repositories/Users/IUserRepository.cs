using Altcord.Server.Core.Models;

namespace Altcord.Server.Core.Repositories.Users;

public interface IUserRepository
{
    Task Create(User user, CancellationToken cancellationToken);
    Task<User?> GetById(Guid id);
    Task<IReadOnlyCollection<User>> GetAll();
}

using Altcord.Server.Models;

namespace Altcord.Server.Repositories.Users;

public interface IUserRepository
{
    User Create(string username);
    User? GetById(Guid id);
    IEnumerable<User> GetAll();
}
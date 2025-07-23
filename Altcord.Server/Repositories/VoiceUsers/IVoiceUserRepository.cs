using Altcord.Server.Models;

namespace Altcord.Server.Repositories.VoiceUsers;

public interface IVoiceUserRepository
{
    IEnumerable<PeerInfo> GetAll();
    Task AddUser(string connectionId, string userName);
    Task DeleteUser(string connectionId);

    void Subscribe(Func<Task> onChange);
}

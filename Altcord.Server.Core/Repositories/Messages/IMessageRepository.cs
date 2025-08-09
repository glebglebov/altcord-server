using Altcord.Server.Core.Models;

namespace Altcord.Server.Core.Repositories.Messages;

public interface IMessageRepository
{
    Task Create(ChatMessage message, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<ChatMessage>> GetMessages(int limit, CancellationToken cancellationToken);
    Task<ChatMessage?> GetById(Guid id);
}

using System.Collections.Concurrent;
using Altcord.Server.Core.Models;

namespace Altcord.Server.Core.Repositories.Messages;

public class MessageRepository : IMessageRepository
{
    private readonly ConcurrentDictionary<Guid, ChatMessage> _messages = new();

    public Task Create(ChatMessage message, CancellationToken cancellationToken)
    {
        _messages[message.Id] = message;
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<ChatMessage>> GetMessages(int limit, CancellationToken cancellationToken)
    {
        var results = _messages.Values
            .OrderByDescending(x => x.CreatedAtUtc)
            .Take(limit)
            .ToArray();

        return Task.FromResult<IReadOnlyCollection<ChatMessage>>(results);
    }

    public Task<ChatMessage?> GetById(Guid id)
    {
        var result = _messages.GetValueOrDefault(id);
        return Task.FromResult(result);
    }
}

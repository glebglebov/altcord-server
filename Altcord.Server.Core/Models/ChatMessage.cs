namespace Altcord.Server.Core.Models;

public class ChatMessage
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public required string Text { get; init; }
    public DateTimeOffset CreatedAtUtc { get; init; }
}

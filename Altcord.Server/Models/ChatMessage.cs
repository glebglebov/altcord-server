namespace Altcord.Server.Models;

public class ChatMessage
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public required string Text { get; init; }
    public required string Timestamp { get; init; }
}

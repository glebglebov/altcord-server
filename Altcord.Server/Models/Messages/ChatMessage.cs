namespace Altcord.Server.Models.Messages;

public class ChatMessage
{
    public required User User { get; init; }
    public required string Text { get; init; }
    public required string Timestamp { get; init; }
}

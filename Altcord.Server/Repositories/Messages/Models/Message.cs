namespace Altcord.Server.Repositories.Messages.Models;

public class Message
{
    public Guid UserId { get; init; }
    public required string Text { get; init; }
}

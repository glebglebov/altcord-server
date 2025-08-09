namespace Altcord.Server.Models.Events.Chat;

public abstract class ChatStateChanged
{
    public required string Type { get; init; }
}

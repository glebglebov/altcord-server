namespace Altcord.Server.Models.Events.Chat;

public class NewMessageSent : ChatStateChanged
{
    public required ChatMessage Message { get; init; }
}

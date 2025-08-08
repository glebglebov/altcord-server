using Altcord.Server.Models.Chat;

namespace Altcord.Server.Models.State;

public class ServerState
{
    public required string ServerName { get; init; }
    public required IReadOnlyCollection<UserState> Users { get; init; }
    public required IReadOnlyCollection<ChatMessage> Messages { get; init; }
}

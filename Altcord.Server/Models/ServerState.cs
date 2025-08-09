namespace Altcord.Server.Models;

public class ServerState
{
    public required string ServerName { get; init; }
    public required IReadOnlyCollection<UserState> Users { get; init; }
    public required IReadOnlyCollection<User> VoiceChannelUsers { get; init; }
    public required IReadOnlyCollection<ChatMessage> Messages { get; init; }
}

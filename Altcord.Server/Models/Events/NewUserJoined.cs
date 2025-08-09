namespace Altcord.Server.Models.Events;

public class NewUserJoined
{
    public required User User { get; init; }
}

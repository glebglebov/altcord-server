namespace Altcord.Server.Models.State;

public class UserState
{
    public required User User { get; init; }
    public bool IsOnline { get; init; }
}

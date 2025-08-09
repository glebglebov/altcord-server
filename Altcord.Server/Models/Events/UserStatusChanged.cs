namespace Altcord.Server.Models.Events;

public class UserStatusChanged
{
    public required string UserId { get; init; }
    public bool IsOnline { get; init; }
}

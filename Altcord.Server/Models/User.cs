namespace Altcord.Server.Models;

public class User
{
    public long Id { get; init; }
    public required string UserName { get; init; }
    public required string AvatarUrl { get; init; }
    public string? Color { get; init; }
}

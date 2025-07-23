namespace Altcord.Server.Models;

public class ServerInfo
{
    public required string ServerName { get; init; }
    public required User[] Members { get; init; }
}

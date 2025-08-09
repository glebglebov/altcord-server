using System.Text.Json.Serialization;

namespace Altcord.Server.Models;

public class User
{
    public required string Id { get; init; }

    [JsonPropertyName("username")]
    public required string UserName { get; init; }
    public required string AvatarUrl { get; init; }
    public required string Color { get; init; }
    public bool IsOnline { get; init; }
}

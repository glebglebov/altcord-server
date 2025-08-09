using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Altcord.Server.Controllers.Auth.Requests;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class AuthRequest
{
    [JsonPropertyName("username")]
    public required string Username { get; init; }
}

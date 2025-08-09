using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Altcord.Server.Controllers.Auth.Responses;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class AuthResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

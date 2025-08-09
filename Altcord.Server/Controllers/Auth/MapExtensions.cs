using Altcord.Server.Controllers.Auth.Requests;
using Altcord.Server.Controllers.Auth.Responses;
using Altcord.Server.Handlers.Users.Create;

namespace Altcord.Server.Controllers.Auth;

public static class MapExtensions
{
    public static CreateUserCommand ToCommand(this AuthRequest request)
        => new()
        {
            UserName = request.Username
        };

    public static AuthResponse ToResponse(this CreateUserResult result)
        => new()
        {
            Id = result.Id.ToString()
        };
}

using Altcord.Server.Models;
using MediatR;

namespace Altcord.Server.Handlers.Users.Create;

public class CreateUserCommand : IRequest<User>
{
    public required string UserName { get; init; }
}

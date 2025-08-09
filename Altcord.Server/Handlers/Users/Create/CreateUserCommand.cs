using MediatR;

namespace Altcord.Server.Handlers.Users.Create;

public class CreateUserCommand : IRequest<CreateUserResult>
{
    public required string UserName { get; init; }
}

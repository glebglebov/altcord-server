using Altcord.Server.Core.Models;
using Altcord.Server.Core.Repositories.Users;
using Altcord.Server.Services.Notifications;
using MediatR;

namespace Altcord.Server.Handlers.Users.Create;

public class CreateUserHandler(IUserRepository repository, IStateNotificator notificator)
    : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            AvatarUrl = "https://www.pravilamag.ru/upload/img_cache/6b5/6b5117915527810f6a2d20a9e38d5f46_ce_590x394x0x121.jpg",
            Color = "#34D399"
        };

        await repository.Create(user, cancellationToken);
        await notificator.SendUserUpdated(user.Id, cancellationToken);

        return new CreateUserResult
        {
            Id = user.Id
        };
    }
}

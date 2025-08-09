using Altcord.Server.Core.Models;
using Altcord.Server.Core.Repositories.Messages;
using Altcord.Server.Services.Notifications;
using MediatR;

namespace Altcord.Server.Handlers.Messages.Send;

public class SendMessageHandler(IMessageRepository repository, IStateNotificator notificator)
    : IRequestHandler<SendMessageCommand>
{
    public async Task Handle(SendMessageCommand command, CancellationToken cancellationToken)
    {
        var message = new ChatMessage
        {
            Id = Guid.NewGuid(),
            UserId = command.UserId,
            Text = command.Text,
            CreatedAtUtc = DateTimeOffset.UtcNow
        };

        await repository.Create(message, cancellationToken);
        await notificator.SendNewMessage(message.Id, cancellationToken);
    }
}

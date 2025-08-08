using MediatR;

namespace Altcord.Server.Handlers.Messages.Send;

public class SendMessageCommand : IRequest
{
    public Guid UserId { get; init; }
    public required string Text { get; init; }
}

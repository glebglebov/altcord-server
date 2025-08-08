using Altcord.Server.Models.State;
using MediatR;

namespace Altcord.Server.Handlers.State.Get;

public class GetStateHandler : IRequestHandler<GetStateCommand, ServerState>
{
    public async Task<ServerState> Handle(GetStateCommand command, CancellationToken cancellationToken)
    {
        return new ServerState
        {
            ServerName = Constants.ServerName,
            Users = null,
            Messages = null
        };
    }
}

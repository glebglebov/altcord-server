using Altcord.Server.Models.State;
using MediatR;

namespace Altcord.Server.Handlers.State.Get;

public class GetStateCommand : IRequest<ServerState>;

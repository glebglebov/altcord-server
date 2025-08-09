using Altcord.Server.Models;
using MediatR;

namespace Altcord.Server.Handlers.State.Get;

public class GetStateCommand : IRequest<ServerState>;

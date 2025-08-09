using Altcord.Server.Handlers.State.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Altcord.Server.Controllers.State;

[ApiController]
[Route("api/state")]
public class StateController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetState()
    {
        var result = await mediator.Send(new GetStateCommand(), HttpContext.RequestAborted);
        return Ok(result);
    }
}

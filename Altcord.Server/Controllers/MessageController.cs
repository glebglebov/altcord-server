using Altcord.Server.Handlers.Messages.Send;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Altcord.Server.Controllers;

[ApiController]
[Route("api/messages")]
public class MessageController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] SendMessageCommand command)
    {
        await mediator.Send(command, HttpContext.RequestAborted);
        return Ok();
    }
}

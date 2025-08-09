using Altcord.Server.Controllers.Auth.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Altcord.Server.Controllers.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] AuthRequest request)
    {
        var result = await mediator.Send(request.ToCommand(), HttpContext.RequestAborted);
        return Ok(result.ToResponse());
    }
}

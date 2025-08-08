using Altcord.Server.Controllers.Messages.Requests;
using Altcord.Server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Altcord.Server.Controllers.Messages;

[ApiController]
[Route("api/messages")]
public class MessageController(IHubContext<StateHub> stateHubContext)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] SendMessageRequest request)
    {
        await stateHubContext.Clients.All.SendAsync("newMessage", message);

        return Ok();
    }
}

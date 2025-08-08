using Altcord.Server.Models;

namespace Altcord.Server.Controllers.Messages.Requests;

public class SendMessageRequest
{
    public Guid UserId { get; set; }
    public string Text { get; set; } = "";
}

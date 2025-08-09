namespace Altcord.Server.Models;

public static class MapExtensions
{
    public static ChatMessage Map(this Core.Models.ChatMessage message)
        => new()
        {
            Id = message.Id.ToString(),
            UserId = message.UserId.ToString(),
            Text = message.Text,
            Timestamp = message.CreatedAtUtc.ToString()
        };
}

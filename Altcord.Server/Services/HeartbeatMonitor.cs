using Altcord.Server.Services.Tracker;

namespace Altcord.Server.Services;

public class HeartbeatMonitor(IOnlineTracker tracker) : BackgroundService
{
    private readonly TimeSpan _grace = TimeSpan.FromSeconds(40); // timeout > ClientTimeoutInterval

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();

        while (!cancellationToken.IsCancellationRequested)
        {
            var now = DateTimeOffset.UtcNow;
            var onlineUserIds = await tracker.GetOnlineUserIds();

            foreach (var userId in onlineUserIds)
            {
                var hb = await tracker.GetLastUserHeartbeat(userId);

                if (hb is {} t && now - t > _grace)
                    await tracker.RemoveUser(userId, cancellationToken);
            }

            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        }
    }
}

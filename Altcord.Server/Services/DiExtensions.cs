using Altcord.Server.Services.Notifications;
using Altcord.Server.Services.Tracker;

namespace Altcord.Server.Services;

public static class DiExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddSingleton<IStateNotificator, StateNotificator>()
            .AddSingleton<IOnlineTracker, OnlineTracker>()
            .AddHostedService<HeartbeatMonitor>();
}

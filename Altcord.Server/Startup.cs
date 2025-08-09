using System.Reflection;
using Altcord.Server.Core.Repositories;
using Altcord.Server.Hubs;
using Altcord.Server.Services;

namespace Altcord.Server;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddRepositories()
            .AddServices();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(Startup))!));

        services.AddCors(o =>
        {
            o.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddSignalR(o =>
        {
            o.EnableDetailedErrors = true;
            o.KeepAliveInterval = TimeSpan.FromSeconds(10);
            o.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        => app
            .UseCors()
            .UseRouting()
            .UseEndpoints(e =>
            {
                e.MapHub<MessageHub>("/hub");
                e.MapHub<VoiceHub>("/voice");
                e.MapHub<StateHub>("/hub/state");
                e.MapControllers();
            });
}

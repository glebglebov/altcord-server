using Altcord.Server.Hubs;
using Altcord.Server.Repositories.VoiceUsers;

namespace Altcord.Server;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IVoiceUserRepository, VoiceUserRepository>();

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

        services.AddSignalR(o => o.EnableDetailedErrors = true);
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
                e.MapHub<VoiceUsersHub>("/voiceUsers");
                e.MapControllers();
            });
}

using Altcord.Server.Core.Repositories.Messages;
using Altcord.Server.Core.Repositories.Users;
using Altcord.Server.Core.Repositories.VoiceUsers;
using Microsoft.Extensions.DependencyInjection;

namespace Altcord.Server.Core.Repositories;

public static class DiExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IMessageRepository, MessageRepository>()
            .AddSingleton<IVoiceUserRepository, VoiceUserRepository>();
}

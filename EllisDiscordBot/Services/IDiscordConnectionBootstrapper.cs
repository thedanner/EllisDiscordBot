using Discord.WebSocket;
using System.Threading;
using System.Threading.Tasks;

namespace EllisDiscordBot.Services;

public interface IDiscordConnectionBootstrapper
{
    Task StartAsync(DiscordSocketClient client, CancellationToken cancellationToken);
}

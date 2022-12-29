using Discord.Interactions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using EllisDiscordBot.Models.Configuration;
using EllisDiscordBot.Helpers.Extensions;
using Discord;
using System.Globalization;
using Discord.Rest;

namespace EllisDiscordBot.Discord.Modules;

public class DefaultInteractionModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly ILogger<DefaultInteractionModule> _logger;
    private readonly Settings _settings;

    public DefaultInteractionModule(ILogger<DefaultInteractionModule> logger, IOptions<Settings>? settings)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
    }

    [SlashCommand("story", "Tell one of my famous stories.")]
    public async Task KeithStoryAsync()
    {
        var quote = RandomHelper.PickSecureRandom(_settings.StoriesMarkdown);
        await RespondAsync(quote);
    }
}

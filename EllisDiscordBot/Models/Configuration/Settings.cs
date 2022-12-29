using System.Collections.Generic;

namespace EllisDiscordBot.Models.Configuration;

public class Settings
{
    public string BotToken { get; set; } = "";
    public List<string> StoriesMarkdown { get; set; } = new List<string>();
}

public class SettingsLinks
{
    public string History { get; set; } = "";
}

﻿using System;

namespace EllisDiscordBot.Helpers.Extensions;

public static class StringExtensions
{
    public static bool StartsWithHttpProtocol(this string value)
    {
        if (string.IsNullOrEmpty(value)) return false;

        return value.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase)
                || value.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase);
    }
}

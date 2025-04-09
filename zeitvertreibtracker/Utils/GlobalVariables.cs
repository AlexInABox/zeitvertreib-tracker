using System;
using System.Collections.Generic;

namespace zeitvertreibtracker.Utils;

public sealed class GlobalVariables
{
    private static readonly Lazy<GlobalVariables> _instance = new(() => new GlobalVariables());

    private GlobalVariables()
    {
    }

    public static GlobalVariables Instance => _instance.Value;


    //Round statistics
    public long RoundStartTime { get; set; }


    // Stores player ID and the round start time in milliseconds
    public Dictionary<string, long> PlayerStartTimes { get; } = new();

    public long GetCurrentMillis()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
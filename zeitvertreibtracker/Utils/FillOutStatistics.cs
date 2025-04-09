using System;
using System.Collections.Generic;

namespace zeitvertreibtracker.Utils;

public sealed class FillOutStatistics
{
    private static readonly Lazy<FillOutStatistics> _instance = new(() => new FillOutStatistics());

    private bool alreadySubmitedPlayerStatisticsToDatabase;

    private FillOutStatistics()
    {
    }

    public static FillOutStatistics Instance => _instance.Value;

    // Stores player ID and the round start time in milliseconds
    public Dictionary<string, PlayerStats> PlayerStatistics { get; } = new();

    public void EnsurePlayerExists(string playerId)
    {
        if (!PlayerStatistics.ContainsKey(playerId))
            PlayerStatistics[playerId] = new PlayerStats();
    }

    /// <summary>
    ///     This function will take the current state of the PlayerStatistics Dictionary and submit it to the Database after
    ///     some sanitization.
    ///     This function will protect itself from running more than once per round.
    /// </summary>
    public void SubmitCollectedPlayerStatisticsToDatabase()
    {
        if (alreadySubmitedPlayerStatisticsToDatabase) return;
        alreadySubmitedPlayerStatisticsToDatabase = true;
    }
}

public class PlayerStats
{
    public int Kills { get; set; } = 0;
    public int Deaths { get; set; } = 0;
    public int RoundsPlayed { get; set; } = 0;
    public int UsedMedkits { get; set; } = 0;
    public int UsedColas { get; set; } = 0;
    public int PocketEscapes { get; set; } = 0;
    public int UsedAdrenaline { get; set; } = 0;
    public int Coins { get; set; } = 0;
    public bool RoundStartedAsHuman { get; set; } = true;
    public long GameStartTime { get; set; } = 9999999999999;
}
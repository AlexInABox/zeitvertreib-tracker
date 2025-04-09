using System.ComponentModel;
using Exiled.API.Interfaces;

namespace zeitvertreibtracker;

/// <inheritdoc cref="IConfig" />
public sealed class Config : IConfig
{
    [Description("Minimum round duration (in minutes) required for coin rewards to be granted.")]
    public int minimumRoundDurationMinutes { get; set; } = 8;

    [Description("Coins awarded at the end of a round as a human-class player.")]
    public int coinsOnRoundEndHuman { get; set; } = 15;

    [Description("Coins awarded at the end of a round as an SCP, typically higher due to increased difficulty.")]
    public int coinsOnRoundEndSCP { get; set; } = 40;

    /// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public bool Debug { get; set; }
}
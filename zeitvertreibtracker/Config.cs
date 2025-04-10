using System.ComponentModel;
using Exiled.API.Interfaces;

namespace zeitvertreibtracker;

/// <inheritdoc cref="IConfig" />
public sealed class Config : IConfig
{
    [Description("XP to award for suriving the entire round without dying.")]
    public int xpForSurvivingTheEntireRound { get; set; } = 5000;

    [Description("XP to award the user for every 20 seconds of playtime.")]
    public int xpPer20secondsPlaytime { get; set; } = 7;

    [Description("XP to award the user for escaping.")]
    public int xpForEscaping { get; set; } = 400;

    [Description("XP to award the user for killing a human as an SCP.")]
    public int xpForKillingAHumanAsAnSCP { get; set; } = 200;

    [Description("XP to award the user for killing a human as an human.")]
    public int xpForKillingAHumanAsAnHuman { get; set; } = 300;
    
    [Description("XP to award the user for killing an SCP as an human.")]
    public int xpForKillingAnSCPAsAHuman { get; set; } = 500;

/// <inheritdoc />
    public bool IsEnabled { get; set; } = true;

    /// <inheritdoc />
    public bool Debug { get; set; }
}
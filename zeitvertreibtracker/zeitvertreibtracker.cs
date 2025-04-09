using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using zeitvertreibtracker.Events;
using Server = Exiled.Events.Handlers.Server;

namespace zeitvertreibtracker;

public class zeitvertreibtracker : Plugin<Config, Translation>
{
    private RoundStarted roundStarted;
    public override string Prefix => "zeitvertreibtracker";
    public override string Name => "zeitvertreibtracker";
    public override string Author => "AlexInABox";
    public override Version Version => new(1, 0, 1);
    public static Translation Translations => Instance.Translation;
    public static zeitvertreibtracker Instance { get; private set; }

    public override PluginPriority Priority { get; } = PluginPriority.Last;

    public override void OnEnabled()
    {
        Instance = this;
        Log.Info("zeitvertreibtracker has been enabled!");

        Server.RoundStarted += roundStarted.OnRoundStarted;

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Log.Info("zeitvertreibtracker has been disabled!");

        Server.RoundStarted -= roundStarted.OnRoundStarted;

        base.OnDisabled();
    }
}
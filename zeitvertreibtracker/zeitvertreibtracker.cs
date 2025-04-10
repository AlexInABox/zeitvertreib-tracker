using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using zeitvertreibtracker.Events;

namespace zeitvertreibtracker;

public class zeitvertreibtracker : Plugin<Config, Translation>
{
    private RoundStarted roundStarted;
    private Dying dying;
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

        Exiled.Events.Handlers.Server.RoundStarted += roundStarted.OnRoundStarted;
        Exiled.Events.Handlers.Player.Dying += dying.OnDying;

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Log.Info("zeitvertreibtracker has been disabled!");

        Exiled.Events.Handlers.Server.RoundStarted -= roundStarted.OnRoundStarted;
        Exiled.Events.Handlers.Player.Dying -= dying.OnDying;

        base.OnDisabled();
    }
}
using LabApi.Features.Wrappers;
using zeitvertreibtracker.Utils;
using Player = Exiled.Events.Handlers.Player;

namespace zeitvertreibtracker.Events;

internal sealed class Dying
{
    public void OnDying(Exiled.Events.EventArgs.Player.DyingEventArgs ev)
    {
        if (ev.Player == null || ev.Attacker == null) return;

        FillOutStatistics.Instance.PlayerStatistics[ev.Player.UserId].Deaths += 1;
        FillOutStatistics.Instance.PlayerStatistics[ev.Attacker.UserId].Kills += 1;

        if (ev.Attacker.IsHuman && ev.Player.IsHuman)
        {
            FillOutStatistics.Instance.PlayerStatistics[ev.Attacker.UserId].Experience +=
                zeitvertreibtracker.Instance.Config.xpForKillingAHumanAsAnHuman;
        }

        if (ev.Attacker.IsHuman && !ev.Player.IsHuman)
        {
            FillOutStatistics.Instance.PlayerStatistics[ev.Attacker.UserId].Experience +=
                zeitvertreibtracker.Instance.Config.xpForKillingAnSCPAsAHuman;
        }

        if (!ev.Attacker.IsHuman && ev.Player.IsHuman)
        {
            FillOutStatistics.Instance.PlayerStatistics[ev.Attacker.UserId].Experience +=
                zeitvertreibtracker.Instance.Config.xpForKillingAHumanAsAnSCP;
        }
    }
}
using LabApi.Features.Wrappers;
using zeitvertreibtracker.Utils;

namespace zeitvertreibtracker.Events;

internal sealed class RoundStarted
{
    public void OnRoundStarted()
    {
        GlobalVariables.Instance.RoundStartTime = GlobalVariables.Instance.GetCurrentMillis();
        foreach (var player in Player.List)
            FillOutStatistics.Instance.PlayerStatistics[player.UserId].PlayerJoinTime
                = GlobalVariables.Instance.GetCurrentMillis();
    }
}
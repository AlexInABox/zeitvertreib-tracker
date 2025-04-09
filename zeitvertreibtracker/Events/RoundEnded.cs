using LabApi.Features.Wrappers;
using zeitvertreibtracker.Utils;

namespace zeitvertreibtracker.Events;

internal sealed class RoundEnded
{
    public void OnRoundEnded()
    {
        var currentMillis = GlobalVariables.Instance.GetCurrentMillis();
        foreach (var player in Player.List)
        {
            FillOutStatistics.Instance.EnsurePlayerExists(player.UserId);
            FillOutStatistics.Instance.PlayerStatistics[player.UserId].Coins =
                zeitvertreibtracker.Instance.Config.coinsOnRoundEndHuman;
        }
    }
}
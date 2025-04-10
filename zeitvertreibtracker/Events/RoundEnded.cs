using LabApi.Features.Wrappers;
using zeitvertreibtracker.Utils;

namespace zeitvertreibtracker.Events;

internal sealed class RoundEnded
{
    public void OnRoundEnded()
    {
        foreach (var player in Player.List)
        {
            FillOutStatistics.Instance.EnsurePlayerExists(player.UserId);
            
            
            FillOutStatistics.Instance.PlayerStatistics[player.UserId].PlayerLeaveTime = GlobalVariables.Instance.GetCurrentMillis();
            if (!FillOutStatistics.Instance.PlayerStatistics[player.UserId].UserDiedThisRound)
            {
                FillOutStatistics.Instance.PlayerStatistics[player.UserId].Experience += zeitvertreibtracker.Instance.Config.xpForSurvivingTheEntireRound;
            }
        }
        FillOutStatistics.Instance.SubmitCollectedPlayerStatisticsToDatabase();
    }
}
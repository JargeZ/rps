using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerWins
{
    public int Count { get; set; }
    public string Name { get; set; }
}

public class LeaderBoard : MonoBehaviour
{
    void Start()
    {
        TMP_Text leaderBoardText = GetComponent<TMP_Text>();
        var leaderBoardData = GetLeaderboardData();
        leaderBoardText.text = GetLeaderboardText(leaderBoardData);        

    }

    PlayerWins[] GetLeaderboardData()
    {
        var winnerHistory = GameLogicScript._saveSystem.winnerHistory;

        var sortedWinners = winnerHistory
            .GroupBy(winner => winner.name)
            .Select(group => new PlayerWins { Count = group.Count(), Name = group.Key })
            .OrderByDescending(item => item.Count)
            .ToArray();

        // Вывод результатов для проверки
        foreach (var item in sortedWinners)
        {
            Debug.Log($"Name: {item.Name}, Wins: {item.Count}");
        }

        return sortedWinners;
    }

    string GetLeaderboardText(PlayerWins[] data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += $"{i + 1}. {data[i].Name} - {data[i].Count} wins\n";
        }

        return result;
    }
}
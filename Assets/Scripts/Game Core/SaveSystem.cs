using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
    {
    public List<PlayerState> winnerHistory = new List<PlayerState>();
    public void saveRoundResult(PlayerState winner)
    {
        winnerHistory.Add(winner);
    }
}

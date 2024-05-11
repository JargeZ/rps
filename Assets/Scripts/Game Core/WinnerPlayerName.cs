using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text winnerName = GetComponent<TMP_Text>();
        winnerName.text = GlobalState.winner?.name ?? "No шinner";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPlayerNames : MonoBehaviour
{
    public TMP_Text player1NameText;
    public TMP_Text player2NameText;

    void Start()
    {
        string player1Name = PlayerPrefs.GetString("Player1Name", "Player 1");
        string player2Name = PlayerPrefs.GetString("Player2Name", "Player 2");

        Debug.Log("Player 1 Name: " + player1Name);
        Debug.Log("Player 2 Name: " + player2Name);

        player1NameText.text = "Player 1: " + player1Name;
        player2NameText.text = "Player 2: " + player2Name;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField player1NameInputField;
    public TMP_InputField player2NameInputField;

    public void SavePlayerNames()
    {
        string player1Name = PlayerPrefs.GetString("Player1Name", "Player 1");
        string player2Name = PlayerPrefs.GetString("Player2Name", "Player 2");

        Debug.Log("Player 1 Name: " + player1Name);
        Debug.Log("Player 2 Name: " + player2Name);
    }
}
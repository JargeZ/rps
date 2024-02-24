using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoice
{
    None = 0,
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

[System.Serializable]
public struct PlayerState
{
    public string name;
    public GameChoice currentChoose;
}


public class Player : MonoBehaviour
{
    public PlayerState state;

    public void SetName(string name)
    {
        state.name = name;
    }

    public void Start()
    {
        state = new PlayerState(){
            name = "Player 1",
            currentChoose = GameChoice.None
        };
    }

    void SyncState()
    {
        // Отправляем состояние игрока на сервер
        Debug.Log("Sending state to server: " + state.name + " " + state.currentChoose);
    }

    public void SetChoice(GameChoice choice)
    {
        state.currentChoose = choice;
        SyncState();
    }

    public void ButtonRock(Button button) { SetChoice(GameChoice.Rock); }
    public void ButtonPaper() { SetChoice(GameChoice.Paper); }
    public void ButtonScissors() { SetChoice(GameChoice.Scissors); }
    public void ButtonDeselect() { SetChoice(GameChoice.None); }
    

    
}
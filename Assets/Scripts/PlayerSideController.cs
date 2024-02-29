using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


public class PlayerSideController : MonoBehaviour
{
    public PlayerState playerState;
    private CharController _character;
    public string PlayerName;
    private GameLogicScript _gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponentInChildren<CharController>();
        _gameLogic = GetComponentInParent<GameLogicScript>();
        playerState.currentChoose = GameChoice.None;
        playerState.name = PlayerName;
    }

    public void SetChoice(GameChoice choice)
    {
        playerState.currentChoose = choice;
        Debug.Log(playerState.name + " chose " + choice);
        
        ChoiceButton[] childButtons = GetComponentsInChildren<ChoiceButton>();
        foreach (ChoiceButton button in childButtons)
        {
            button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        
        _gameLogic.CheckForGameResults();
    }



    public void AnimateWin(int animation)
    {
        Debug.Log("Set " + playerState.name + " animation: Win");
    }
    
    public void AnimateLose(int animation)
    {
        Debug.Log("Set " + playerState.name + " animation: Lose");
    }

    public void AnimateDraw(int animation)
    {
        Debug.Log("Set " + playerState.name + " animation: Draw");
    }
}

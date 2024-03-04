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

public static class AnimationTriger
{
    public static string Win = "IsWin";
    public static string Lose = "IsLose";
    public static string Draw = "IsDraw";
    public static string Idle = "IsLoop";
    public static string Chosen = "IsChosen";
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
        _character.SetAnimation(AnimationTriger.Chosen);
        playerState.currentChoose = choice;
        Debug.Log(playerState.name + " chose " + choice);
        
        ChoiceButton[] childButtons = GetComponentsInChildren<ChoiceButton>();
        foreach (ChoiceButton button in childButtons)
        {
            button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }

        _gameLogic.CheckForGameResults();
    }



    public void AnimateWin()
    {
        Debug.Log("Set " + playerState.name + " animation: Win");
        _character.SetAnimation(AnimationTriger.Win);
    }
    
    public void AnimateLose()
    {
        Debug.Log("Set " + playerState.name + " animation: Lose");
        _character.SetAnimation(AnimationTriger.Lose);
    }

    public void AnimateDraw()
    {
        Debug.Log("Set " + playerState.name + " animation: Draw");
        _character.SetAnimation(AnimationTriger.Draw);
    }
    public void AnimateIdle()
    {
        Debug.Log("Set " + playerState.name + " animation: Idle");
        _character.SetAnimation(AnimationTriger.Idle);
    }
}

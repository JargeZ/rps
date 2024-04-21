using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

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
    public int score;
}


public class PlayerSideController : MonoBehaviour
{
    public PlayerState playerState;
    private CharController _character;
    // public string PlayerName;
    private GameLogicScript _gameLogic;
    public CharacterSelector characterSelector;
    public PlayerSide playerSide;
    private TMP_Text _playerNameText;


    // Start is called before the first frame update
    void Start()
    {
        _playerNameText = transform.Find("PlayerName")?.GetComponent<TMP_Text>();

        setCharDataFromMainScreen();
        _character = characterSelector.GetActiveCharacter();
        _gameLogic = GetComponentInParent<GameLogicScript>();
        playerState.currentChoose = GameChoice.None;

        _playerNameText.text = playerState.name;
    }

    public void setCharDataFromMainScreen(){
        SelectedPlayerInfo info = new SelectedPlayerInfo();

        if(playerSide == PlayerSide.Left){
            info = GlobalState.LeftPlayerInfo;
        }
        if(playerSide == PlayerSide.Right){
            info = GlobalState.RightPlayerInfo;
        }
        playerState.name = info.SelectedPlayerName;

        characterSelector.Select(info.SelectedCharSkin);
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


    private IEnumerator SetHandAfterAnimation(string hand)
    {
        Animator animator = _character.GetAnimator();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;
        float remainingTime = animationLength * (1 - Mathf.Repeat(stateInfo.normalizedTime, 1));

        yield return new WaitForSeconds(remainingTime - 0.69f);

        Debug.Log("Set " + playerSide + " hand: " + hand);
        _character.SetHand(hand);
    }

    public void UpdateHand()
    {
        Dictionary<GameChoice, string> hands = new Dictionary<GameChoice, string>
        {
            {GameChoice.Rock, CharHands.Rock},
            {GameChoice.Paper, CharHands.Paper},
            {GameChoice.Scissors, CharHands.Scissors}
        };
        
        string hand = hands.GetValueOrDefault(playerState.currentChoose, CharHands.Idle);

        StartCoroutine(SetHandAfterAnimation(hand));
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

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameResult
{
    Draw,
    PlayerLeftWins,
    PlayerRightWins
}

public class GameLogicScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _result;
    public PlayerSideController _leftPlayer;
    public PlayerSideController _rightPlayer;

    private void ResetGame()
    {
        ChoiceButton[] buttons = FindObjectsOfType<ChoiceButton>();
        foreach (ChoiceButton button in buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        _result.text = "Make your choice!";
        _leftPlayer.AnimateIdle();
        _rightPlayer.AnimateIdle();
        _leftPlayer.playerState.currentChoose = GameChoice.None;
        _rightPlayer.playerState.currentChoose = GameChoice.None;
        _rightPlayer.UpdateHand();
        _leftPlayer.UpdateHand();
    }

    private IEnumerator PerformDelayedReset()
    {
        // Ждем 5 секунд
        yield return new WaitForSeconds(3);

        // Выполняем действие
        ResetGame();
    }

    private string getScreenText(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                return "Draw!";
            case GameResult.PlayerLeftWins:
                return "Player " + _leftPlayer.playerState.name + " wins!";
            case GameResult.PlayerRightWins:
                return "Player " + _rightPlayer.playerState.name + " wins!";
            default:
                throw new System.Exception("Unknown game result");
        }
    }

    private void setResultAnimation(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                _leftPlayer.AnimateDraw();
                break;
            case GameResult.PlayerLeftWins:
                _leftPlayer.AnimateWin();
                _rightPlayer.AnimateLose();
                break;
            case GameResult.PlayerRightWins:
                _rightPlayer.AnimateWin();
                _leftPlayer.AnimateLose();
                break;
            default:
                throw new System.Exception("Unknown game result");
        }
    }

    // Этот метод вызывается, например, при нажатии кнопки сравнения

    public void TryAgain()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public void CheckForGameResults()
    {
        GameChoice ChooseLeft = _leftPlayer.playerState.currentChoose;
        GameChoice ChooseRight = _rightPlayer.playerState.currentChoose;

        if ((ChooseLeft != GameChoice.None && ChooseRight == GameChoice.None)||(ChooseLeft == GameChoice.None && ChooseRight != GameChoice.None))
        {
            _result.text = "Game starts!";
        }

        if (ChooseLeft != GameChoice.None && ChooseRight != GameChoice.None)
        {
            GameResult result = DetermineWinner(ChooseLeft, ChooseRight);
            _result.text = getScreenText(result);
            setResultAnimation(result);
            StartCoroutine(PerformDelayedReset());
            _leftPlayer.UpdateHand();
            _rightPlayer.UpdateHand();
        }

    }

    void Start()
    {
        ResetGame();
    }
    
    public GameResult DetermineWinner(GameChoice leftValue, GameChoice rightValue)
    {

        // Правила камень-ножницы-бумаги
        if (leftValue == rightValue)
        {
            return GameResult.Draw;
        }
        else if (
            (leftValue == GameChoice.Rock && rightValue == GameChoice.Scissors) ||
            (leftValue == GameChoice.Paper && rightValue == GameChoice.Rock) ||
            (leftValue == GameChoice.Scissors && rightValue == GameChoice.Paper)
        )
        {
            return GameResult.PlayerLeftWins;
        }
        else
        {
            return GameResult.PlayerRightWins;
        }
    }
}

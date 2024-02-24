using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameResult
{
    Draw,
    Player1Wins,
    Player2Wins
}

public class GameLogicScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _result;
    public CharController _character;

    public string ChooseLeft;
    public string ChooseRight;

    private void ResetGame()
    {
        ChooseLeft = "";
        ChooseRight = "";
    }

    private string getScreenText(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                return "Draw!";
            case GameResult.Player1Wins:
                return "Player 1 wins!";
            case GameResult.Player2Wins:
                return "Player 2 wins!";
            default:
                throw new System.Exception("Unknown game result");
        }
    }

    private void setResultAnimation(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                _character.SetAnimation("Draw");
                break;
            case GameResult.Player1Wins:
                _character.SetAnimation("Win");
                break;
            case GameResult.Player2Wins:
                _character.SetAnimation("Lose");
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


    public void CompareSharedValues()
    {

        if ((ChooseLeft != "" && ChooseRight == "")||(ChooseLeft == "" && ChooseRight != ""))
        {
            _character.SetAnimation("Idle");
            _result.text = "Game starts!";
        }

        if (ChooseLeft != "" && ChooseRight != "")
        {
            GameResult result = DetermineWinner(ChooseLeft, ChooseRight);
            _result.text = getScreenText(result);
            setResultAnimation(result);
            ResetGame();
        }
    }

    void Start()
    {
        ResetGame();
        _character = CharController.FindFirstObjectByType<CharController>();
    }
    
    public GameResult DetermineWinner(string value1, string value2)
    {

        // Правила камень-ножницы-бумаги
        if (value1 == value2)
        {
            return GameResult.Draw;
        }
        else if (
            (value1 == "Rock" && value2 == "Scissors") ||
            (value1 == "Paper" && value2 == "Rock") ||
            (value1 == "Scissors" && value2 == "Paper")
        )
        {
            return GameResult.Player1Wins;
        }
        else
        {
            return GameResult.Player2Wins;
        }
    }
}

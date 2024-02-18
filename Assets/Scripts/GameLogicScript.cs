using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogicScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _result;

    public string ChooseLeft { get; set; }
    public string ChooseRight { get; set; }

    // Этот метод вызывается, например, при нажатии кнопки сравнения
    public void CompareSharedValues()
    {
        _result.text = DetermineWinner(ChooseLeft, ChooseRight);
        Debug.Log("update " + ChooseLeft + " / " + ChooseRight + " = " + _result.text);
    }
    
    public string DetermineWinner(string value1, string value2)
    {

        // Правила камень-ножницы-бумаги
        if (value1 == value2)
        {
            return "It's a draw!";
        }
        else if (
            (value1 == "Rock" && value2 == "Scissors") ||
            (value1 == "Paper" && value2 == "Rock") ||
            (value1 == "Scissors" && value2 == "Paper")
        )
        {
            return "Player 1 wins!";
        }
        else
        {
            return "Player 2 wins!";
        }
    }
}

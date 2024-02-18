using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public string player1;
    public string player2;

    // Этот метод вызывается, например, при нажатии кнопки сравнения
    public void CompareSharedValues()
    {
      
    }

    private string DetermineWinner(string value1, string value2)
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

using UnityEngine;
using UnityEngine.UI;

public class GetValue2 : MonoBehaviour
{
    // Общая переменная, которую вы хотите установить
    public static string Player2Value;

    // Этот метод вызывается при нажатии кнопки 1
    public void OnButton1Click()
    {
        Player2Value = "Rock";
        Debug.Log("Button 1 Clicked. Shared Value: " + Player2Value);
    }

    // Этот метод вызывается при нажатии кнопки 2
    public void OnButton2Click()
    {
        Player2Value = "Paper";
        Debug.Log("Button 2 Clicked. Shared Value: " + Player2Value);
    }

    // Этот метод вызывается при нажатии кнопки 3
    public void OnButton3Click()
    {
        Player2Value = "Scissors";
        Debug.Log("Button 3 Clicked. Shared Value: " + Player2Value);
    }
}

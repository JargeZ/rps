using UnityEngine;
using UnityEngine.UI;

public class GetValue2 : MonoBehaviour
{
    // Общая переменная, которую вы хотите установить
    public void setChoose(string choose)
    {
        GameLogicScript jopa = GameLogicScript.FindFirstObjectByType<GameLogicScript>();
        jopa.ChooseRight = choose;
        jopa.CompareSharedValues();
        Debug.Log("Set value: " + choose);
    }

    // Этот метод вызывается при нажатии кнопки 1
    public void OnButton1Click()
    {
        setChoose("Rock");
    }

    // Этот метод вызывается при нажатии кнопки 2
    public void OnButton2Click()
    {
        setChoose("Paper");

    }

    // Этот метод вызывается при нажатии кнопки 3
    public void OnButton3Click()
    {
        setChoose("Scissors");
    }
}

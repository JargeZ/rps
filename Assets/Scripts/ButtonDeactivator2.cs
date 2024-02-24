using UnityEngine;
using UnityEngine.UI;

public class DisableButtons2 : MonoBehaviour
{
    public Button[] buttonsToDisable;

    void Start()
    {
        // Добавляем метод-обработчик для события нажатия каждой кнопки
        foreach (Button button in buttonsToDisable)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    void OnButtonClicked(Button clickedButton)
    {
        // Деактивируем все кнопки из массива buttonsToDisable после нажатия одной из них
        foreach (Button button in buttonsToDisable)
        {
            button.interactable = false;
        }

        // Здесь можно добавить дополнительную логику, которая выполнится после выбора игрока
        Debug.Log("Button clicked: " + clickedButton.name);
    }
}

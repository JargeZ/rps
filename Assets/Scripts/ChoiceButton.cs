using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField]
    public GameChoice choice;
    public KeyCode activationKey;
    private Button _button;
    private PlayerSideController _playerSideController;

    void Start()
    {
        // Получаем компонент Button к которому назначен этот скрипт
        _button = GetComponent<Button>();

        // Получаем компонент PlayerSideController, который назначен на объекте с этим скриптом
        _playerSideController = GetComponentInParent<PlayerSideController>();

        // Добавляем обработчик события клика на кнопку
        _button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log("Button " + choice + " clicked");
        _playerSideController.SetChoice(choice);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            _button.onClick.Invoke();
        }
    }
}

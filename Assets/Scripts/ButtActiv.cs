using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonActivation : MonoBehaviour
{
    [System.Serializable]
    public class ButtonKeyPair
    {
        public Button button;
        public KeyCode activationKey;
    }

    public List<ButtonKeyPair> buttonKeyPairs = new List<ButtonKeyPair>(); // List of button-key pairs

    void Update()
    {
        foreach (var pair in buttonKeyPairs)
        {
            if (Input.GetKeyDown(pair.activationKey))
            {
                pair.button.onClick.Invoke();
            }
        }
    }
}

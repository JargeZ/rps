using UnityEngine;
using TMPro;

public class CharSelectScreenController : MonoBehaviour
{
    public TMP_Text leftName;
    public TMP_Text rightName;
   
    public void StartGame()
    {
        // Save names that inpiutted in text objects on this scene 
        // to global state that shared between scenes
        GlobalState.LeftPlayerInfo.SelectedPlayerName = leftName.text;
        GlobalState.RightPlayerInfo.SelectedPlayerName = rightName.text;

        // Switch to the game scene
        SceneSwitcher.setScene("SampleScene");
    }
}

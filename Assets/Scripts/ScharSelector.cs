using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class SelectedPlayerInfo
{
    public string SelectedPlayerName;
    public string SelectedCharSkin;
}

public static class SelectScreen
{
    public static SelectedPlayerInfo LeftPlayerInfo = new SelectedPlayerInfo();
    public static SelectedPlayerInfo RightPlayerInfo = new SelectedPlayerInfo();
}


public enum PlayerSide
{
    Left,
    Right
}

public class ScharSelector : MonoBehaviour
{

    public SpriteRenderer SpriteRenderer;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public PlayerSide playerSide;

   public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        SpriteRenderer.sprite = skins[selectedSkin];
        SetChar();
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count -1 ;
        }
        SpriteRenderer.sprite = skins[selectedSkin];
        SetChar();
    }

    public void SetChar()
    {
        Dictionary<int, string> indexToCharNameMapping = new Dictionary<int, string>
        {
            {0, "nokia"},
            {1, "pavel"},
            {2, "dean"},
            {3, "vanish"},
        };

        string currentCharSkinName = indexToCharNameMapping[selectedSkin];
        string currentPlayerName = transform.parent.GetComponentsInChildren<TMP_Text>()[0].text;
        Debug.Log("Selected character: " + currentCharSkinName);
        Debug.Log("Selected player name: " + currentPlayerName);
        
        if (playerSide == PlayerSide.Left)
        {
            SelectScreen.LeftPlayerInfo.SelectedCharSkin = currentCharSkinName;
            SelectScreen.LeftPlayerInfo.SelectedPlayerName = currentPlayerName;
        }
        if (playerSide == PlayerSide.Right)
        {
            SelectScreen.RightPlayerInfo.SelectedCharSkin = currentCharSkinName;
            SelectScreen.RightPlayerInfo.SelectedPlayerName = currentPlayerName;
        }
    }

}

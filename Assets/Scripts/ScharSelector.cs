using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class ScharSelector : MonoBehaviour
{

    public SpriteRenderer SpriteRenderer;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public PlayerSide playerSide;

    public void Start()
    {
        SetChar();
    }

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
        Debug.Log("Selected character: " + currentCharSkinName);
        
        if (playerSide == PlayerSide.Left)
        {
            GlobalState.LeftPlayerInfo.SelectedCharSkin = currentCharSkinName;
        }
        if (playerSide == PlayerSide.Right)
        {
            GlobalState.RightPlayerInfo.SelectedCharSkin = currentCharSkinName;
        }
    }

}

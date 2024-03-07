using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ScharSelector : MonoBehaviour
{

    public SpriteRenderer SpriteRenderer;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;

   public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        SpriteRenderer.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count -1 ;
        }
        SpriteRenderer.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
            }

}

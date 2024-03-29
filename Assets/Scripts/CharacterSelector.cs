using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public void Select(string characterName)
    {
        Debug.Log("Selected character: " + characterName);
        
        foreach (Transform child in transform){
            if (child.gameObject.name == characterName)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public CharController GetActiveCharacter() {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                return child.gameObject.GetComponent<CharController>();
            }
        }
        throw new System.Exception("No active character found");
    }
}

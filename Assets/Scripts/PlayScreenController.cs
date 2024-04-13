using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScreenController : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}

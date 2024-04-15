using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This function will be called when the quit button is clicked
    public void Quit()
    {
        // This will quit the application when running as standalone or in the editor

            Application.Quit();
    }
}
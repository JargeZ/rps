using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name of the scene to switch to
    public string sceneName;

    // Function to switch to the specified scene
    public void SwitchScene()
    {
        setScene(sceneName);
    }

    public static void setScene(string name)
    {
        // Check if the scene name is not empty
        if (!string.IsNullOrEmpty(name))
        {
            // Load the specified scene
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogError("Scene name is empty or null. Please provide a valid scene name.");
        }
    }
}
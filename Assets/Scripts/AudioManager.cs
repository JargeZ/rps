using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isSoundEnabled = true;

    void Start()
    {
        // Assuming your audio source is attached to the same GameObject as this script.
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleSound()
    {
        isSoundEnabled = !isSoundEnabled;

        // Mute/unmute the audio source based on the button press.
        audioSource.mute = !isSoundEnabled;
    }
}

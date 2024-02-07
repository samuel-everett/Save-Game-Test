using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set; }


    // Singleton classes should only have one instance.. 
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Duplicate Audio Managers...");
        }

        instance = this;
    }

    public void Play() {
        GetComponent<AudioSource>().Play();
    }
}

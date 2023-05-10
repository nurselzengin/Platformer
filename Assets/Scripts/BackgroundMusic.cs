using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public static BackgroundMusic instance;
    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();

        if (!instance)
        { 
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            Debug.Log("Sahnede birden fazla Background Music var");
        }
        DontDestroyOnLoad(gameObject);

        
    }
    private void Update()
    {
        MuteMusic();
    }
    void MuteMusic()
    {
        if (PauseMenu.isPause)

        {
            audioSource.mute = true;
            Debug.Log("Mute Music");
        }
        else
        {
            audioSource.mute = false;
            Debug.Log("Play Music");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip[] sounds;

    //Singleton ile sahnede tek bulunan objeler tanýmlanmýþ olur. GetComponent ile tanýmlama bu durumda kullanýlmaz.
    #region Singleton
    public static SoundManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
           
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //index ile ses ekleme fonsiyonu
    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

}

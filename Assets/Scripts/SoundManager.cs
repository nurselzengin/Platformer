using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip fallSound;
    [SerializeField] AudioClip attackEnemySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip runDoorSound;


    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazladan ses var");
        }
        else
        {
            instance = this;
        }
    }

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpSound()
    { 
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("Jump");
    }
    public void LandSoundSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("Land");
    }
    public void DeathbyEnemySound()
    {
       
            audioSource.PlayOneShot(deathSound);
            Debug.Log("Death Music");
        

    }

    public void DeathbyFall()
    {
        
            audioSource.PlayOneShot(fallSound);
            Debug.Log("Fall Music");
        

    }
    public void AttackEnemySound()
    {

        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("Attack Music");


    }
    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
        Debug.Log("Win Sound");
    }
    public void RunDoorSound()
    {
        audioSource.PlayOneShot(runDoorSound);
        Debug.Log("Run Door Sound");
    }

}

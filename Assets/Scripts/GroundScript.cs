using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private SoundManager soundManager;
    void Start()
    {
       soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            soundManager.LandSoundSound();
    }
}

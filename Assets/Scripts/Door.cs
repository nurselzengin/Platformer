using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            winPanel.SetActive(true);
            
            SoundManager.instance.PlayWithIndex(12);
            collision.gameObject.SetActive(false);
        }
    }

}

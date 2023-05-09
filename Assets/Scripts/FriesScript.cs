using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesScript : MonoBehaviour
{
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.CompareTag("Player"))
        {
            levelManager.count++;
            levelManager.FriesSpawnerCourotine();
            Destroy(gameObject);
            //levelManager.FriesSpawner();
            
        }
    }
}

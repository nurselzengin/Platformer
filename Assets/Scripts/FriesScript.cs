using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesScript : MonoBehaviour
{
    LevelManager levelManager;
    private int friesValue;

    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    private void Start()
    {
        friesValue = Random.Range(1, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.CompareTag("Player"))
        {
            levelManager.count++;
            ScoreManager.instance.AddPoint(friesValue);
            levelManager.FriesSpawnerCourotine();
            Destroy(gameObject);
            //levelManager.FriesSpawner();
            
        }
    }
}

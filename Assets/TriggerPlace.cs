using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlace : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    bool moveEnemy = false;

    private void FixedUpdate()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        if (moveEnemy)
        { 
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*10,0);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveEnemy = true;
        }
    }

}

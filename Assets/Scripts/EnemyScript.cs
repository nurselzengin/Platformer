using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry; //enemy prefab�n�n i�inde enemy scriptinde boundry olu�tu ona platformun s�n�r�n� verdik
    [SerializeField] float yBoundry;
    LevelManager levelManager;
    DelayScript delayScript;
    UiManager uiManager;
    PlayerHealth playerHealth;
    bool isAttacking;

    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        EnemyDestroyer();
        
    }
    private void FixedUpdate()
    {
        EnemyAttack();
    }
    void EnemyAttack()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0);
        

        while (!isAttacking)
        {
            SoundManager.instance.PlayWithIndex(0);
            isAttacking = true;
        }
        
    }
    void EnemyDestroyer()
    {
        if (transform.position.x < xBoundry || transform.position.y <yBoundry)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Movement.Cancel();
            playerHealth.Lives();

            
            if (delayScript.delayTime == true)
            {
                delayScript.StartDelayTime();
            }
            SoundManager.instance.PlayWithIndex(2);
           
        }
    }
}

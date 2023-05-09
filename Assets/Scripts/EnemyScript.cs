using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry; //enemy prefab�n�n i�inde enemy scriptinde boundry olu�tu ona platformun s�n�r�n� verdik
    [SerializeField] float yBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    DelayScript delayScript;
    UiManager uiManager;
    PlayerHealth playerHealth;
    bool isAttacking;

    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
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
            soundManager.AttackEnemySound();
            isAttacking = true;
        }
        //delta time belirli bir zaman aral��� //Time playa bas�ld��� anda i�lenen zaman // �ok kullan�l�r frame olarak
        //SpriteRenderer ba��ndaki tiki kald�rd���m�zda spwnpos g�r�nm�yor
    }
    void EnemyDestroyer()
    {
        if (transform.position.x < xBoundry || transform.position.y <yBoundry)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //dokundu�unda
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(collision.gameObject);
            playerHealth.Lives();
            
            if (delayScript.delayTime == true)
            {
                delayScript.StartDelayTime();
            }
            
            
            soundManager.DeathbyEnemySound();
            //uiManager.GetComponent<Canvas>().enabled = true;
            //levelManager.RespawnPlayer();//enemy �arpt���nda da tekrar player olu�tur
        }
    }
}

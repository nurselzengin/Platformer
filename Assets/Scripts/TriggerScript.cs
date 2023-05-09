using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    //[SerializeField] GameObject enemy; //�oklu enemy ayn� �zellikleri kar��lamas� i�in GameObject[] dizi olarak tan�ml�yoruz MoveEemyde if i�inde for ile d�ng� yaz�yoruz
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPos;
    
    //[SerializeField] float enemySpeed;
    bool moveEnemy = false;
    private void FixedUpdate()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        if (moveEnemy)
        {
            //enemy.GetComponent<Rigidbody2D>().velocity =  new Vector2 (-1*10, 0); //0.5f verince yukar�ya do�ruda hareket ediyor, 10 huzun veriyor, -1 x ekseninde geriye do�ru
            SpawnEnemy();
            moveEnemy = false;
        }
    }
    void SpawnEnemy()
    {
        //enemy kald�rd�k spawnpos ekledik onun yerine
        Instantiate(enemyPrefab, spawnPos.position, enemyPrefab.transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            moveEnemy = true;
        }
        //Debug.Log(collision.gameObject.name + " Objesi giri� yapt�.");
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " Objesi trigger i�inde");
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " Objesi triggerdan ��kt�");
    //}
}

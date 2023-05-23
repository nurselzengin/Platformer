using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    //public static LevelManager instance;//singleton pattern kullan�m� respawnplayer i�in
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject friesPrefab;
    [SerializeField] GameObject door;
    [SerializeField] GameObject RunText;

    [Header("Knife Spawner")]
    [SerializeField] GameObject knifePrefab;
    [SerializeField] Vector2 spawnValues;
    [SerializeField] float startSpawn;
    [SerializeField] float minSpawn;
    [SerializeField] float maxSpawn;
    [SerializeField] float startWait;
    public static bool knifeStop;
    private float xSpawn = 10f;

    [Header("Bool")]
  
    public int count;
    public bool canWin;
    public static bool canMove=true;

    [Header("Move Spawn")]
    [SerializeField] float easySpawn;
    [SerializeField] float normalSpawn;
    [SerializeField] float hardSpawn;

    private SoundManager soundManager;

    private void Awake()
    {
        
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        PlayerSpawner();
       
    }
    private void Start()
    {
        
        //FriesSpawner();
        StartCoroutine(SpawnFries());
        StartCoroutine(CreateKnife());
        maxSpawn = HardenedScript.instance.HardenedLevel(maxSpawn, easySpawn, normalSpawn, hardSpawn);
        canMove = true;
    }
    private void Update()
    {
        startSpawn = Random.Range(minSpawn, maxSpawn);
    }
    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity); //konumunu yani 0,0,0 pozisyonda playerim� olu�tur.
    }
    public void RespawnPlayer()//bo�lu�a d���p �ld���nde yeniden olu�turuluyor player�m�z
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
    public void FriesSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-2.3F, 2.1f), 0);
        Instantiate(friesPrefab, spawnPos, Quaternion.identity);
    }
    IEnumerator SpawnFries()
    {
        if (count == 5)
        { 
            canWin = true;
            door.SetActive(true);
            knifeStop = true;
            RunText.SetActive(true);
            soundManager.RunDoorSound();
        }
        yield return new WaitForSeconds(1.5f);

        if (count < 5)
        {
            FriesSpawner();
        }
    }

    public void FriesSpawnerCourotine()
    {
        StartCoroutine(SpawnFries());
    }
    private IEnumerator CreateKnife() 
    {
        yield return new WaitForSeconds(startWait);

        while (!knifeStop)
        {
            Vector2 spawnPos = new Vector2(xSpawn, Random.Range(-spawnValues.y+1, spawnValues.y+1));
            Instantiate(knifePrefab, spawnPos, Quaternion.identity);
            SoundManager.instance.PlayWithIndex(6);
            yield return new WaitForSeconds(startSpawn);
        }
    }
    
}

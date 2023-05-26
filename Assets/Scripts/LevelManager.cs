using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
  
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

    #region Singleton
    public static LevelManager instance;

    private void Awake()
    {
        
        if (instance == null)
        {

            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        
        SpawnPlayer();
    }
    #endregion
  
    
    private void Start()
    {
       
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
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity); //Playerin oldukten sonra yeniden yaratilmasini saglayan fonksiyon.
    }
    public void RespawnPlayer()
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
        if (count == CountManager.instance.countForWin)
        { 
            canWin = true;
            door.SetActive(true);
            knifeStop = false;
            RunText.SetActive(true);
            SoundManager.instance.PlayWithIndex(10);
        }
        yield return new WaitForSeconds(1.5f);

        if (count < CountManager.instance.countForWin)
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
            SoundManager.instance.PlayWithIndex(13);
            yield return new WaitForSeconds(startSpawn);
        }
    }

    void SpawnPlayer()
    { 
       StartCoroutine(PlayerSpawnerWait());
    }

    IEnumerator PlayerSpawnerWait()
    {
        yield return new WaitForSeconds(1);
        PlayerSpawner();
    }
    
}

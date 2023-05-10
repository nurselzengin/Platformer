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

    private SoundManager soundManager;

    public int count;
    public bool canWin;
    public static bool canMove=true;
    
    // Start is called before the first frame update
    private void Awake()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        PlayerSpawner();
    }
    private void Start()
    {
        //FriesSpawner();
        StartCoroutine(SpawnFries());
    }
    // Update is called once per frame
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
        if (count == 2)
        { 
            canWin = true;
            door.SetActive(true);
            RunText.SetActive(true);
            soundManager.RunDoorSound();
        }
        yield return new WaitForSeconds(1.5f);

        if (count < 2)
        {
            FriesSpawner();
        }
    }

    public void FriesSpawnerCourotine()
    {
        StartCoroutine(SpawnFries());
    }
}

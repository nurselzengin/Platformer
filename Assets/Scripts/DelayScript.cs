using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] float delayTimer;
    public bool delayTime = true;   
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartDelayTime()
    {
        StartCoroutine(DelayNewTime());
    }

    IEnumerator DelayNewTime()
    { 
        yield return new WaitForSeconds(delayTimer);
        levelManager.RespawnPlayer();
    }
}

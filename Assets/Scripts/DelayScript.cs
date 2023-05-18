using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] float delayTimer;
    public bool delayTime = true;

    #region Singleton
    public static DelayScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazladan ses var");
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

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

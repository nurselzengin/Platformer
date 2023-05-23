using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{ 
    UiManager uiManager;
    [SerializeField] Image[] playerHealthIcons;
    [SerializeField] int playerLifeCount = 3;
    DelayScript delayScript;

    #region Singleton
    public static PlayerHealth instance;

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
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
    }

    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);

        if (playerLifeCount < 1)

        {
            uiManager.GetComponent<Canvas>().enabled = true;
            LevelManager.knifeStop = true;
            delayScript.delayTime = false;
            
        }
    }
}

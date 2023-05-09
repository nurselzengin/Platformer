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

    void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        delayScript = GameObject.Find("Level Manager").GetComponent<DelayScript>();
    }

    
    void Update()
    {
        
    }
    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);

        if (playerLifeCount < 1)

        {
            uiManager.GetComponent<Canvas>().enabled = true;
            delayScript.delayTime = false;
            
        }
    }
}

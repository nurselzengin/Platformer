using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    public int countForWin;
    public int level=1;

    #region Singleton
    public static CountManager instance;

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
        DontDestroyOnLoad(this);
    }
    #endregion

    public bool EndCount()
    {
        if (countForWin == LevelManager.instance.count)
        { 
            return true;
        }
        return false;

    
    }

   
}

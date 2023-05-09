using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelManager.canMove = true;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}



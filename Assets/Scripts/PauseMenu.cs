using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{


    public static bool isPause;
    [SerializeField] GameObject pauseMenu;
    


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            { 
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    { 
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        LevelManager.canMove = true;
        isPause = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        LevelManager.canMove = true;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        LevelManager.canMove = false;
        Time.timeScale = 0;
        isPause=true;
    }
}

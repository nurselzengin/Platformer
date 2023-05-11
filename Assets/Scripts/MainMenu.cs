using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI highScoretext;

    private void Update()
    {
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
        highScoretext.text = "Your High Score : " + ScoreManager.highScore.ToString();
    }
    public void Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

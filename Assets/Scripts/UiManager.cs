using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoretext;
    Canvas canvas;

    
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        scoreText.text = "Your Score: " + ScoreManager.score.ToString();
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
        highScoretext.text = "Your High Score : " + ScoreManager.highScore.ToString(); 
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.enabled = false;
        ScoreManager.score = 0;
        
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
           CountManager.instance.countForWin = 1;
        }
        if (PlayerPrefs.HasKey("Normal Mode"))
        {
            CountManager.instance.countForWin = 2;
        }
        if (PlayerPrefs.HasKey("Hard Mode"))
        {
            CountManager.instance.countForWin = 3;
        }
        LevelManager.knifeStop = false;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
        LevelManager.knifeStop = false;

    }
}

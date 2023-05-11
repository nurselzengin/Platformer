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
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinPanelScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        scoreText.text = "Score : " + ScoreManager.score.ToString();
    }
    public void NextLevel()
    {
        int scorePoint = ScoreManager.score;
        CountManager.instance.countForWin++;
        CountManager.instance.level++;
        scoreText.text = scorePoint.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelManager.canMove = true;
        LevelManager.knifeStop = false;

    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}



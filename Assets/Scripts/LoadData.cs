using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI loadText;

    private void Update()
    {
        if (PlayerPrefs.HasKey("Name"))
        { 
            loadText.text ="Your name is " + PlayerPrefs.GetString("Name");
        }
        else
        {
            loadText.text = "There is no registered key.";
        }
    }
    public void Delete()
    { 
        PlayerPrefs.DeleteKey("Name");
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}

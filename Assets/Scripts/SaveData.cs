using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] TMP_InputField textBox;
    [SerializeField] TextMeshProUGUI InfoText;
    
    public void Save()
    {
        PlayerPrefs.SetString("Name", textBox.text);
        InfoText.text = "Your data saved.";
    }

    public void Next()
    {
        SceneManager.LoadScene(1);

    
    }
    public void Default()
    {
        PlayerPrefs.DeleteAll();
    }
}

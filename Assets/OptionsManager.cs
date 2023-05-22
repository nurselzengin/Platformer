using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Toggle mute;
    [SerializeField] Toggle Windowed;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeText;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Mute"))
        {
            PlayerPrefs.SetInt("Mute",0);

        }
        else
        {
            LoadMuteToggle();
        }
        if (!PlayerPrefs.HasKey("Windowed"))
        {
            PlayerPrefs.SetInt("Windowed", 0);

        }
        else
        {
            LoadWindowedToggle();
        }

    }
    private void Update()
    {
        LoadVolume();
    }

    public void WindowedToggle()
    {
        PlayerPrefs.SetInt("Windowed", Windowed.isOn ? 1 : 0);

        if(!Windowed.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    
    private void LoadMuteToggle()
    {
        mute.isOn = PlayerPrefs.GetInt("Mute") == 1;

    }

    public void MuteToggle()
    { 
        PlayerPrefs.SetInt("Mute", mute.isOn ? 1 : 0) ;
        if(mute.isOn )
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;

        }
        
    }
    public void LoadWindowedToggle()
    {
        Windowed.isOn = PlayerPrefs.GetInt("Windowed") == 1;

    }

    public void LoadVolume() // bu fonksiyon kontrol ediyor
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;

    }

    public void VolumeControl(float volume) // bu fonksiyon islemi uyguluyor
    { 
        volumeText.text = "Volume " + volume.ToString("0"); // Ýcerisine sýfýr degeri verilmese de olur
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [Header("Game Objects:")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] StateManager StateManager;

    /// <summary>
    /// This function checks if the player has prefs for volume and sets it to previous settings
    /// </summary>
    /// 
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 100);
            loadPrefs();
        }
        else 
        {
            loadPrefs();
        }
    }

    /// <summary>
    /// This function will set the audio on the audio mixer to what is on the slider
    /// </summary>
    /// <param name="SliderValue"></param>
    /// 
    public void SetAudioLevel(float SliderValue)
    {
        if (SliderValue < 1) 
        {
            SliderValue = 0.001f;
        }
        refreshSlider(SliderValue);
        savePrefs(SliderValue);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(SliderValue / 100) * 20.0f);
        
    }

    /// <summary>
    /// This function loads the playerPrefs and sets the volumeSlider to the value
    /// </summary>
    /// 
    private void loadPrefs()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("musicVolume", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume") / 100) * 20.0f);
    }

    /// <summary>
    /// This function saves the slider value to the playerPrefs
    /// </summary>
    /// <param name="SliderValue"></param>
    /// 
    private void savePrefs(float SliderValue)
    {
        PlayerPrefs.SetFloat("musicVolume", SliderValue);
    }

    /// <summary>
    /// This function just refreshes the value if its below 1
    /// </summary>
    ///  <param name="_value"></param>
    private void refreshSlider(float _value)
    {
        volumeSlider.value = _value;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [Header("Game Objects:")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    /// <summary>
    /// This function checks if the player has prefs for volume and sets it to previous settings
    /// </summary>
    /// 
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
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
        audioMixer.SetFloat("musicVolume", Mathf.Log10(SliderValue) * 20);
        savePrefs(SliderValue);
    }

    /// <summary>
    /// This function loads the playerPrefs and sets the volumeSlider to the value
    /// </summary>
    /// 
    private void loadPrefs()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume"));
    }

    /// <summary>
    /// This function saves the slider value to the playerPrefs
    /// </summary>
    /// <param name="SliderValue"></param>
    /// 
    private void savePrefs(float SliderValue)
    {
        PlayerPrefs.SetFloat("musicVolume", Mathf.Log10(SliderValue) * 20);
    }
}

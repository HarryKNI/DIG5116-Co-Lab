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

    /// <summary>
    /// This function checks if the player has prefs for volume and sets it to previous settings
    /// </summary>
    /// 
    private void Start()
    {
        loadPrefs();
    }

    /// <summary>
    /// This function will set the audio on the audio mixer to what is on the slider
    /// </summary>
    /// <param name="SliderValue"></param>
    /// 
    public void SetAudioLevel(float SliderValue)
    {
        savePrefs(SliderValue);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(SliderValue) * 20.0f);
    }

    /// <summary>
    /// This function loads the playerPrefs and sets the volumeSlider to the value and defaults to 1 if not present
    /// </summary>
    /// 
    private void loadPrefs()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume", 1)) * 20.0f);
    }

    /// <summary>
    /// This function saves the slider value to the playerPrefs
    /// </summary>
    /// <param name="SliderValue"></param>
    /// 
    private void savePrefs(float SliderValue)
    {
        PlayerPrefs.SetFloat("musicVolume", SliderValue);
        PlayerPrefs.Save();
    }
}

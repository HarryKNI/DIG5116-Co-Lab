using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioReducer : MonoBehaviour
{
    [Header("Audio inputs:")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private GameManager GameManager;

    [Header("Audio reducer inputs:")]
    [SerializeField] private float BGMReductionValue;
    [SerializeField] private float OtherAudioReductionValue;


    private float StartingBGMVolume;
    private float[] StartingOtherAudioVolume;
    private AudioSource[] OtherAudioSources;
    private void Start()
    {
        StartingBGMVolume = BGM.volume;
        GetOtherAudioLevels();
    }
    private void Update()
    {
        SetBGMAudioLevel(GameManager.isGamePaused);
        SetOtherAudioLevel(GameManager.isGamePaused);
    }

    /// <summary>
    /// This function will check for game state and set the BGM levels accordingly
    /// </summary>
    /// <param name="isGamePaused"></param>
    private void SetBGMAudioLevel(bool isGamePaused)
    {
        switch (isGamePaused)
        {
            case true:
                {
                    BGM.volume = StartingBGMVolume / BGMReductionValue;
                    break;
                }
            case false:
                {
                    BGM.volume = StartingBGMVolume;
                    break;
                }
        }
    }
    /// <summary>
    /// This function will check for all possible audio sources and set their levels accordingly
    /// </summary>
    /// <param name="isGamePaused"></param>
    private void SetOtherAudioLevel(bool isGamePaused)
    {
        switch (isGamePaused)
        {
            case true:
                {
                    for (int i = 0; i < OtherAudioSources.Length; i++)
                    {
                        if (OtherAudioSources[i] != null)
                        {
                            OtherAudioSources[i].volume = StartingOtherAudioVolume[i] / OtherAudioReductionValue;
                        }
                    }
                    break;
                }
            case false:
                {
                    for (int i = 0; i < OtherAudioSources.Length; i++)
                    {
                        if (OtherAudioSources[i] != null)
                        {
                            OtherAudioSources[i].volume = StartingOtherAudioVolume[i];
                        }
                    }
                    break;
                }
        }
    }

    private void GetOtherAudioLevels()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("AudioSource");
        OtherAudioSources = new AudioSource[audioObjects.Length];
        StartingOtherAudioVolume = new float[audioObjects.Length];

        for (int i = 0; i < audioObjects.Length; i++)
        {
            AudioSource source = audioObjects[i].GetComponent<AudioSource>();
            OtherAudioSources[i] = source;
            StartingOtherAudioVolume[i] = source.volume;
        }
    }
}

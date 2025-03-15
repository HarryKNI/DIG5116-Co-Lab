using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Vennce;

public class StateManager : MonoBehaviour
{
    [Header("Game State Checker")]
    public bool isGamePaused;

    [Header("Audio Input Parametres")]
    [SerializeField] AudioMixer audioMixer;

    [Header("Audio Reducer Parametre")]
    public float audioVolume;
    public float audioReducer = 2;

    [Header("Ui Manager")]
    [SerializeField] FPSUiManagers UiManager;

    [Header("Input Manager")]
    [SerializeField] InputMapSubscriptions GetInput;

    private void Awake()
    {
        audioVolume = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Update()
    {
        CheckPauseInput();
        SetAudioLevels();
    }

    /// <summary>
    /// This function sets the audio levels depending on the game state
    /// </summary>
    private void SetAudioLevels()
    {
        switch (isGamePaused)
        {
            case true:
                {
                    audioMixer.SetFloat("musicVolume", audioVolume / audioReducer);
                    break;
                }
            case false:
                {
                    audioMixer.SetFloat("musicVolume", audioVolume);
                    break;
                }
        }
    }
    /// <summary>
    /// This function checks the pause input and will pause or unpause the game depending on game status
    /// </summary>
    /// Vennce
    private void CheckPauseInput()
    {
        switch (GetInput.PauseBinds)
        {
            case true:
                {
                    if (isGamePaused)
                    {
                        UnPauseGame();
                    }
                    else
                    {
                        PauseGame();
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    /// <summary>
    /// This function pauses the game
    /// </summary>
    /// Vennce
    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        UiManager.ActivatePauseMenu();
    }

    /// <summary>
    /// This function unpauses the game
    /// </summary>
    /// Vennce
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        UiManager.ResumeGame();
    }

}

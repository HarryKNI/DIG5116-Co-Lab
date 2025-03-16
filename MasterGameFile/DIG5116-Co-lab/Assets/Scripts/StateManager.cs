using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Vennce;

public class StateManager : MonoBehaviour
{
    [Header("Game State Checker")]
    public bool isGamePaused;

    [Header("Ui Manager")]
    [SerializeField] FPSUiManagers UiManager;

    [Header("Input Manager")]
    [SerializeField] InputMapSubscriptions GetInput;

    private void Update()
    {
        CheckPauseInput();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Vennce;

public class PauseManager : MonoBehaviour
{
    [Header("Game State Checker")]
    [SerializeField] GameManager GameManager;

    [Header("Ui Manager")]
    [SerializeField] FPSUiManager UiManager;

    [Header("Input Manager")]
    [SerializeField] InputMapSubscriptions GetInput;
    [SerializeField] FPSController PlayerController;

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
                    if (GameManager.disablePausing == false)
                    {
                        if (GameManager.isGamePaused)
                        {

                            UnPauseGame();
                        }
                        else
                        {
                            PauseGame();
                        }
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
        PlayerController.UnlockCursor();
        PlayerController.CanMove = false;
        GameManager.PauseGame();
        UiManager.DeactivateTaskUi();
        UiManager.ActivatePauseMenu();
    }

    /// <summary>
    /// This function unpauses the game
    /// </summary>
    /// Vennce
    public void UnPauseGame()
    {
        PlayerController.LockCursor();
        PlayerController.CanMove = true;
        GameManager.UnPauseGame();
        UiManager.ActivateTaskUi();
        UiManager.ResumeGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class FPSUiManagers : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] GameObject pauseMenuUi;
    [SerializeField] GameObject settingUi;

    [Header("Button defaults")]
    [SerializeField] GameObject defaultPauseButton;
    [SerializeField] GameObject defaultSettingsButton;

    [Header("Event system")]
    [SerializeField] EventSystem _EventSystem;

    [Header("Locking/Unlocking Cursor Parametre")]
    [SerializeField] FPSController PlayerController;

    /// <summary>
    /// This function opens the pause menu and closes the settings menu if it is open
    /// </summary>
    /// Vennce
    public void ActivatePauseMenu()
    {
        pauseMenuUi.SetActive(true);
        SetDefaultButton(defaultPauseButton);
        settingUi.SetActive(false);
        PlayerController.UnlockCursor();
        PlayerController.CanMove = false;
    }

    /// <summary>
    /// This function opens the settings menu and closes the pause menu if it is open
    /// </summary>
    /// Vennce
    public void ActivateSettingsMenu()
    {
        settingUi.SetActive(true);
        SetDefaultButton(defaultSettingsButton);
        pauseMenuUi.SetActive(false);
    }

    /// <summary>
    /// This function resumes the game
    /// </summary>
    /// Vennce
    public void ResumeGame()
    {
        pauseMenuUi.SetActive(false);
        settingUi.SetActive(false);
        PlayerController.LockCursor();
        PlayerController.CanMove = true;
        //this is failsafe for when the button is pressed when the game is paused
        Time.timeScale = 1;
    }

    /// <summary>
    /// This function goes back to menu
    /// </summary>
    /// Vennce
    public void BackToMenu()
    {
        //Need to add main menu scene here
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// This function quits the game
    /// </summary>
    /// Vennce
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// This function sets the default button hover when switching uis
    /// </summary>
    /// <param name="button"></param>
    /// Vennce
    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }
}

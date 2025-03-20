using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;


    //
    // These functions are just used to normalise pausing in both PauseManager and FPSUiManager
    //

    /// <summary>
    /// This function pauses the game
    /// </summary>
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// This function unpauses the game
    /// </summary>
    public void UnPauseGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMAudioReducer : MonoBehaviour
{
    [Header("Audio inputs:")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private GameManager GameManager;

    private void Update()
    {
        SetBGMAudioLevel(GameManager.isGamePaused);
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
                    BGM.volume = 0.25f;
                    break;
                }
            case false:
                {
                    BGM.volume = 0.5f;
                    break;
                }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewspaperUi : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] GameObject TaskUi;
    [SerializeField] GameObject NpUi;
    [SerializeField] GameObject CrosshairUi;

    [Header("Button defaults")]
    [SerializeField] GameObject defaultButton;

    [Header("Event system")]
    [SerializeField] EventSystem _EventSystem;

    [Header("Locking/Unlocking Cursor Parametre")]
    [SerializeField] FPSController PlayerController;

    [Header("Game State Checker")]
    [SerializeField] GameManager GameManager;

    private bool DoOnce = false;

    private void Update()
    {
        if ((GameManager.isTask3Completed == true) && (DoOnce == false))
        {
            DoOnce = true;
            ActivateNewspaperUi();
        }
    }

    private void ActivateNewspaperUi()
    {
        TaskUi.SetActive(false);
        CrosshairUi.SetActive(false);
        NpUi.SetActive(true);
        SetDefaultButton(defaultButton);
        PlayerController.UnlockCursor();
        PlayerController.CanMove = false;
        GameManager.disablePausing = true;
        GameManager.PauseGame();
    }

    public void DeactivateNewspaperUi()
    {
        TaskUi.SetActive(true);
        CrosshairUi.SetActive(true);
        NpUi.SetActive(false);
        PlayerController.LockCursor();
        PlayerController.CanMove = true;
        GameManager.disablePausing = false;
        GameManager.UnPauseGame();
    }

    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }
}

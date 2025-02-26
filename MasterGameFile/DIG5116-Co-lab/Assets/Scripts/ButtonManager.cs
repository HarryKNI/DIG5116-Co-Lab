using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] private GameObject firstMenuUi;
    [SerializeField] private GameObject settingUi;

    [Header ("Button defaults")]
    [SerializeField] private GameObject defaultMenuButton;
    [SerializeField] private GameObject defaultSettingButton;

    [Header("Event system")]
    [SerializeField] private EventSystem _EventSystem;

    public bool shouldFirstUiBeVisable;

    private void Start()
    {
        //this disables the view of the settings ui
        firstMenuUi.SetActive(shouldFirstUiBeVisable);
        if (firstMenuUi.activeSelf)
        {
            SetDefaultButton(defaultMenuButton);
        }
        settingUi.SetActive(false);
    }

    //
    //This function loads the first level/scene in the game 
    //
    public void StartGame()
    {
        //Need to add first game scene here
        SceneManager.LoadScene("");
    }

    //
    //This function loads the settings Ui, this should only be available in the main menu
    //but can be added to other scenes if they incorperate a pause menu.
    //
    public void LoadSettingsUi()
    {
        firstMenuUi.SetActive(false);
        settingUi.SetActive(true);
        SetDefaultButton(defaultSettingButton);
    }

    //
    //This function should load the first menu that pops up
    //
    public void LoadFirstMenuUi()
    {
        settingUi.SetActive(false);
        firstMenuUi.SetActive(true);
        SetDefaultButton(defaultMenuButton);
    }
    //
    //This function quits the game
    //
    public void QuitGame()
    {
        Application.Quit();
    }

    //
    //This function sets the default button hover when switching uis
    //
    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }
}

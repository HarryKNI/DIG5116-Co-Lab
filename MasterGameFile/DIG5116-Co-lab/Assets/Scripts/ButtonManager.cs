using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    [SerializeField] private bool shouldFirstUiBeVisable;

    [Header("Scene to switch to")]
    [SerializeField] private string sceneToSwitchTo;
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

    ///<summary>
    ///This function loads the settings Ui, this should only be available in the main menu but can be added to other scenes if they incorperate a pause menu.
    ///</summary>
    ///Vennce
    public void LoadSettingsUi()
    {
        firstMenuUi.SetActive(false);
        settingUi.SetActive(true);
        SetDefaultButton(defaultSettingButton);
    }

    ///<summary>
    ///This function should load the first menu that pops up
    ///</summary>
    ///Vennce
    public void LoadFirstMenuUi()
    {
        settingUi.SetActive(false);
        firstMenuUi.SetActive(true);
        SetDefaultButton(defaultMenuButton);
    }

    ///<summary>
    ///This function sets the default button hover when switching uis
    ///</summary>
    ///<param name="button"></param>
    ///Vennce
    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }

    ///<summary>
    ///This function quits the game
    ///</summary>
    ///Vennce
    public void QuitGame()
    {
        Application.Quit();
    }
    
    ///<summary>
    ///This function loads the first level/scene in the game 
    ///</summary>
    ///Vennce
    public void StartGame()
    {
        //Need to add first game scene here
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}

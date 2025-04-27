using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InformationScript : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] private GameObject firstMenuUi;

    [Header("Button defaults")]
    [SerializeField] private GameObject defaultMenuButton;

    [Header("Event system")]
    [SerializeField] private EventSystem _EventSystem;

    [Header("Scene to switch to")]
    [SerializeField] private string sceneToSwitchTo;

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
    ///This function loads the first level/scene in the game 
    ///</summary>
    ///Vennce
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}

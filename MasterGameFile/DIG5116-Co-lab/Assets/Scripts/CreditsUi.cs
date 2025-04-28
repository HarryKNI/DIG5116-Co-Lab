using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsUi : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] private GameObject MainMenuUi;
    [SerializeField] private GameObject CreditUi;

    [Header("Button defaults")]
    [SerializeField] private GameObject DefaultMenuButton;
    [SerializeField] private GameObject DefaultCreditsButton;

    [Header("Event system")]
    [SerializeField] private EventSystem _EventSystem;
    public void CloseCreditsUi()
    {
        CreditUi.SetActive(false);
        MainMenuUi.SetActive(true);
        SetDefaultButton(DefaultMenuButton);
    }
    public void OpenCreditsUi()
    {
        CreditUi.SetActive(true);
        MainMenuUi.SetActive(false);
        SetDefaultButton(DefaultCreditsButton);
    }

    ///<summary>
    ///This function sets the default button hover when switching uis
    ///</summary>
    ///<param name="button"></param>
    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vennce;
public class SceneSwitcher : MonoBehaviour
{
    //Boolean to check if the player can interact with the object
    [Header("Interaction Options")]
    public bool PlayerCanInteract = false;
    public bool CanInteract = true;

    [Header("Scene index")]
    [SerializeField] private string SceneString;

    [Header("Game manager")]
    [SerializeField] GameManager GameManager;
    [SerializeField] FPSUiManager FPSUiManager;

    [Header("Input Manager")]
    [SerializeField] InputMapSubscriptions GetInput;

    private bool InteractionButtonPressed;

    [Header("Game Objects")]
    [SerializeField] GameObject interactUi;
    [SerializeField] MeshRenderer ArrowModel;
    [SerializeField] MeshRenderer IndicatorModel;


    private void Start()
    {
        SetObjectVisability(false);
        FPSUiManager = GameObject.Find("UIManager").GetComponent<FPSUiManager>();
    }

    private void Update()
    {
        CheckIfCanInteract();

        InteractionButtonPressed = GetInput.InteractionBinds;
        if (PlayerCanInteract && InteractionButtonPressed && CanInteract)
        {
            FPSUiManager.SetInteractUiVisability(false);
            HandleSceneSwitch(SceneString);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                PlayerCanInteract = true;
                FPSUiManager.SetInteractUiVisability(true);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                PlayerCanInteract = false;
                FPSUiManager.SetInteractUiVisability(false);
                break;
            default:
                break;
        }
    }

    private void CheckIfCanInteract()
    {
        if (GameManager.isTask1Completed && GameManager.isTask2Completed && GameManager.isTask3Completed)
        {
            SetObjectVisability(true);
            CanInteract = true;
        }
    }

    private void HandleSceneSwitch(string Scene)
    {
        SceneManager.LoadSceneAsync(Scene);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void SetObjectVisability(bool state)
    {
        ArrowModel.GetComponent<MeshRenderer>().enabled = state;
        IndicatorModel.GetComponent<MeshRenderer>().enabled = state;
        gameObject.GetComponent<BoxCollider>().enabled = state;
    }
}

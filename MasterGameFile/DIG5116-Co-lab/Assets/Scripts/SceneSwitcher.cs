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

    [Header("Input Manager")]
    [SerializeField] InputMapSubscriptions GetInput;
    private bool InteractionButtonPressed;

    private void Start()
    {
        SetObjectVisability(false);
    }

    private void Update()
    {
        CheckIfCanInteract();

        InteractionButtonPressed = GetInput.InteractionBinds;
        if (PlayerCanInteract && InteractionButtonPressed && CanInteract)
        {
            HandleSceneSwitch(SceneString);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                PlayerCanInteract = true;
                break;
            default:
                break;
        }
    }

    private void CheckIfCanInteract()
    {
        if (GameManager.isTask1Completed && GameManager.isTask2Completed && GameManager.isTask3Completed)
        {
            Debug.Log("Player can interact with the object");
            SetObjectVisability(true);
            CanInteract = true;
        }
    }

    private void HandleSceneSwitch(string Scene)
    {
        SceneManager.LoadScene(Scene);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void SetObjectVisability(bool state)
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = state;
        gameObject.GetComponent<BoxCollider>().enabled = state;
    }
}

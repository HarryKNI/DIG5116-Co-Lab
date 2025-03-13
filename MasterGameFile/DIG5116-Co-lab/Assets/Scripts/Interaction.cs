using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vennce;

public class Interaction : MonoBehaviour
{
    //Input handlers and holders
    InputMapSubscriptions GetInput;
    private bool InteractionButtonPressed;

    //Boolean to check if the player can interact with the object
    [Header("Interaction Options")]
    public bool PlayerCanInteract = false;
    public bool CanInteract = true;

    private void Awake()
    {
        GetInput = GameObject.Find("---PLAYER---").GetComponent<InputMapSubscriptions>();
    }

    private void Update()
    {
        //Debug.Log(InteractionButtonPressed);
        InteractionButtonPressed = GetInput.InteractionBinds;
        if (PlayerCanInteract && InteractionButtonPressed && CanInteract)
        {
            HandleInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                Debug.Log("Player has entered the trigger");
                PlayerCanInteract = true;
                break;
            default:
                Debug.Log("Something has entered the trigger");
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                Debug.Log("Player has exited the trigger");
                PlayerCanInteract = false;
                break;
            default:
                Debug.Log("Something has exited the trigger");
                break;
        }
    }
    private void HandleInteraction()
    {
        //this makes the player only be able to interact once with this object
        CanInteract = false;
        Debug.Log("Player has interacted with the object");
    }
}

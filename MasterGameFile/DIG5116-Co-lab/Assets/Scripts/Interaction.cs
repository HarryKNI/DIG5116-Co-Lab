using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vennce;

public class Interaction : MonoBehaviour
{
    //Input handlers and holders
    [SerializeField] InputMapSubscriptions GetInput;
    private bool InteractionButtonPressed;

    //Boolean to check if the player can interact with the object
    [Header("Interaction Options")]
    public bool PlayerCanInteract = false;
    public bool CanInteract = true;

    [Header("Task Related Options")]
    [SerializeField] GameManager GameManager;
    [SerializeField] int TaskNumber;

    [Header("SFX Options")]
    [SerializeField] float ShrinkDuration = 1f;
    [SerializeField] float MinScale = 0.1f;
    [SerializeField] AudioClip PickUpSound;
    [SerializeField] AudioClip DestroySound;
    private void Start()
    {
        SetObjectVisability(false);
    }
    private void Update()
    {
        UpdateVisibility();

        InteractionButtonPressed = GetInput.InteractionBinds;
        if (PlayerCanInteract && InteractionButtonPressed && CanInteract)
        {
            HandleInteraction();
            IncrementTask();
        }
    }

    private void HandleInteraction()
    {
        //this makes the player only be able to interact once with this object
        CanInteract = false;
        Debug.Log("Player has interacted with the object");
        HandleDestroy();
    }

    private void IncrementTask()
    {
        switch (TaskNumber)
        {
            case 1:
                GameManager.IncrementTask1();
                break;
            case 2:
                GameManager.IncrementTask2();
                break;
            case 3:
                GameManager.IncrementTask3();
                break;
            default:
                Debug.Log("Task number is not valid");
                break;
        }
    }
    /// <summary>
    /// This function handles the destruction of the object
    /// </summary>
    private void HandleDestroy()
    {
        StartCoroutine(ShrinkAndDestroy());
    }

    /// <summary>
    /// This function handles the shrinking of the object then destroys it after 4 seconds
    /// </summary>
    private IEnumerator ShrinkAndDestroy()
    {
        Vector3 originalScale = transform.localScale;
        float elapsedTime = 0.0f;
        while (elapsedTime < ShrinkDuration)
        {
            float scale = Mathf.Lerp(originalScale.x, MinScale, elapsedTime / ShrinkDuration);
            transform.localScale = new Vector3(scale, scale, scale);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
        Destroy(gameObject, 4f);
    }
    /// <summary>
    /// This function should update the visibility of the object based on the task number when called
    /// </summary>
    private void UpdateVisibility()
    {
        switch (TaskNumber)
        {
            case 1:
                if (!GameManager.isTask1Completed && !GameManager.isTask2Completed && !GameManager.isTask3Completed)
                {
                    SetObjectVisability(true);
                }
                break;
            case 2:
                if (GameManager.isTask1Completed && !GameManager.isTask2Completed && !GameManager.isTask3Completed)
                {
                    SetObjectVisability(true);
                }
                break;
            case 3:
                if (GameManager.isTask1Completed && GameManager.isTask2Completed && !GameManager.isTask3Completed)
                {
                    SetObjectVisability(true);
                }
                break;
            default:
                Debug.Log("Task number is not valid");
                break;
        }
    }
    /// <summary>
    /// This function should be called when selecting what state the object should be
    /// </summary>
    private void SetObjectVisability(bool state)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = state;
        gameObject.GetComponent<CapsuleCollider>().enabled = state;
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
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                PlayerCanInteract = false;
                break;
            default:
                break;
        }
    }
}

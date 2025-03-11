using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vennce;

public class FPSController : MonoBehaviour
{
    InputMapSubscriptions GetInput;
    Camera playerCamera;
    CharacterController characterController;

    //Can include anims here
    //Rigidbody rb;

    [Header("Functional Options")]
    public bool CanMove = true;

    [Header("Movement Speed Parameters")]
    public float MovementSpeed = 5.0f;
    private Vector3 MovementDirection;
    Vector2 CurrentInput;

    [Header("Gravity Parameters")]
    public float Gravity = 30.0f;

    [Header("Movement Speed Parameters")]
    public float Sensitivity = 0.1f;
    private float RotationX = 0.0f;
    private float ViewAngle = 85.0f;

    [Header("UI HANDLER")]
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject CrosshairMenu;
    public bool shouldCrosshairBeVisable;
    private bool IsGamePaused;
    private bool PauseMenuActive;

    private void Awake()
    {
        GetInput = GetComponent<InputMapSubscriptions>();
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        IsGamePaused = false;
        PauseMenuActive = false;
    }

    private void Start()
    {
        LockCursor();
        //Activating crosshair
        CrosshairMenu.SetActive(shouldCrosshairBeVisable);
    }


    private void Update()
    {
        //Need to add movement logic here
        if (CanMove)
        {
            HandleMovementInput();
            //HandleCameraInput();
            HandleFPSCamera();
            ApplyFinalMovements();
        }
    }

    ///<summary>
    /// This will lock the cursor to the center of the screen
    /// Need to check logic for locking contoller input
    /// </summary>
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    ///<summary>
    ///This will unlock the cursor from the center of the screen
    ///</summary>
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    ///<summary>
    ///This function handles the movement of the player
    ///</summary>
    private void HandleMovementInput()
    {
        CurrentInput = new Vector2(GetInput.NormalisedMovementInput.x, GetInput.NormalisedMovementInput.y) * MovementSpeed;

        float moveDirectionY = MovementDirection.y;
        MovementDirection = (transform.TransformDirection(Vector3.forward) * CurrentInput.y) + (transform.TransformDirection(Vector3.right) * CurrentInput.x);
        MovementDirection.y = moveDirectionY;
    }

    ///<summary>
    ///This function handles the camera movement of the player
    ///</summary>
    private void HandleFPSCamera()
    {
        RotationX -= GetInput.CameraMovement.y * Sensitivity;
        RotationX = Mathf.Clamp(RotationX, -ViewAngle, ViewAngle);
        playerCamera.transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, GetInput.CameraMovement.x * Sensitivity, 0);
    }

    ///<summary>
    ///This function applies the movement to the player
    ///</summary>
    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
        {
            MovementDirection.y -= Gravity * Time.deltaTime;
        }
        characterController.Move(MovementDirection * Time.deltaTime);
    }
}

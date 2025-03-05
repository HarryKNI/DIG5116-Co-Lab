using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Vennce;

public class FPSController : MonoBehaviour
{
    InputMapSubscriptions inputMapSubscriptions;
    Camera playerCamera;
    CharacterController characterController;

    //Can include anims here
    //Rigidbody rb;

    [Header("Functional Options")]
    public bool CanMove = true;

    [Header("Movement Speed Parameters")]
    public float MovementSpeed = 5.0f;
    private Vector3 MovementDirection;

    [Header("Gravity Parameters")]
    public float Gravity = 30.0f;

    [Header("Movement Speed Parameters")]
    public float Sensitivity = 0.1f;
    private float RotationX = 0.0f;
    private float ViewAngle = 85.0f;

    [Header("UI HANDLER")]
    [SerializeField] GameObject PauseMenu;
    private bool IsGamePaused;
    private bool PauseMenuActive;

    private void Awake()
    {
        inputMapSubscriptions = GetComponent<InputMapSubscriptions>();
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        IsGamePaused = false;
        PauseMenuActive = false;
    }

    private void Start()
    {
        
    }
}

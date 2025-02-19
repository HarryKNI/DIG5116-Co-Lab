using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapSubscriptions : MonoBehaviour
{
    //Current input binds

    //MovementBinds
    //AnalogMovementBinds
    //InteractionBinds
    //PauseBinds
    //CameraMovement
    
    public Vector2 NormalisedMovementInput { get; private set; } = Vector2.zero;
    public Vector2 AnalogMovementInput { get; set; } = Vector2.zero;
    public Vector2 CameraMovement { get; private set; } = Vector2.zero;
    public bool InteractionBinds { get; private set; } = false;
    public bool PauseBinds { get; private set; } = false;

    InputMap Input = null;

    private void OnEnable() {
        Input = new InputMap();

        Input.PlayerControls.Enable();

        Input.PlayerControls.MovementBinds.performed += SetMoveNormal;
        Input.PlayerControls.MovementBinds.canceled += SetMoveNormal;

        Input.PlayerControls.AnalogMovementBinds.performed += SetMoveAnalog;
        Input.PlayerControls.AnalogMovementBinds.canceled += SetMoveAnalog;

        Input.PlayerControls.CameraMovement.performed += SetCameraDelta;
        Input.PlayerControls.CameraMovement.canceled += SetCameraDelta;
    }

    private void OnDisable() {
        Input.PlayerControls.MovementBinds.performed -= SetMoveNormal;
        Input.PlayerControls.MovementBinds.canceled -= SetMoveNormal;

        Input.PlayerControls.AnalogMovementBinds.performed -= SetMoveAnalog;
        Input.PlayerControls.AnalogMovementBinds.canceled -= SetMoveAnalog;

        Input.PlayerControls.CameraMovement.performed -= SetCameraDelta;
        Input.PlayerControls.CameraMovement.canceled -= SetCameraDelta;

        Input.PlayerControls.Disable();
    }

    private void Update() {
        //These only get called once when pressed
        InteractionBinds = Input.PlayerControls.InteractionBinds.WasPressedThisFrame();
        PauseBinds = Input.PlayerControls.PauseBinds.WasPressedThisFrame();
    }

    //Calling these functions make them repeat whilst held
    private void SetMoveNormal(InputAction.CallbackContext context) {
        NormalisedMovementInput = context.ReadValue<Vector2>();
    }
    private void SetMoveAnalog(InputAction.CallbackContext context) { 
        AnalogMovementInput = context.ReadValue<Vector2>();
    }
    private void SetCameraDelta(InputAction.CallbackContext context) {
        CameraMovement = context.ReadValue<Vector2>();
    }
}

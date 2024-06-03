using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private MovementController movementController;
    public MovementController MovementController {  get { if (movementController == null) 
                movementController = GetComponent<MovementController>(); return movementController; }}

    private PlayerController playerController;
    private PlayerController.MovementActions movementActions;

    private float horizontalInput;

    private void Awake()
    {
        playerController = new PlayerController();
        movementActions = playerController.Movement;
    }

    private void Update()
    {
        MovementController.OnHorizontalMovement(horizontalInput);
    }

    private void OnEnable()
    {
        playerController.Enable();

        movementActions.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<float>();
        movementActions.Jump.performed += ctx => MovementController.OnJump();
    }

    private void OnDisable()
    {
        playerController.Disable();

        movementActions.HorizontalMovement.performed -= ctx => horizontalInput = ctx.ReadValue<float>();
        movementActions.Jump.performed -= ctx => MovementController.OnJump();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    // Movement Vectors
    Vector2 currentMoveInput;
    Vector3 currentMove;
    Vector3 currentRunMove;

    // Booleans
    bool isMovePressed;
    bool isRunPressed;
    bool isFliped;
    bool isMoveVertical;

    // Speed
    public float Speed = 0.5f;
    private const float runSpeed = 2.0f;

    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Move.started += context =>
        {
            OnMovementInput(context);
        };
        playerInput.CharacterControls.Move.canceled += context =>
        {
            OnMovementInput(context);
        };
        playerInput.CharacterControls.Move.performed += context =>
        {
            OnMovementInput(context);
            isFliped = currentMove.x < 0;
            isMoveVertical = currentMove.x == 0;
        };
        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimation();
        HandleGravity();

        if (isRunPressed)
        {
            characterController.Move(currentRunMove * Speed * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMove * Speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMoveInput = context.ReadValue<Vector2>();
        currentMove.x = currentMoveInput.x;
        currentMove.z = currentMoveInput.y;
        currentRunMove.x = currentMoveInput.x * runSpeed;
        currentRunMove.z = currentMoveInput.y * runSpeed;
        isMovePressed = currentMoveInput.x != 0 || currentMoveInput.y != 0;
    }

    private void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    private void HandleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if (isMovePressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if (!isMovePressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }

        if (!isMoveVertical)
        {
            animator.SetBool("flip", isFliped);
        }
    }

    private void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            const float groundedGravity = -.05f;
            currentMove.y = groundedGravity;
            currentRunMove.y = groundedGravity;
        }
        else
        {
            const float gravity = -9.8f;
            currentMove.y += gravity;
            currentRunMove.y += gravity;
        }
    }
}

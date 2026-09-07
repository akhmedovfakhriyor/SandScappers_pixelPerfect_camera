using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControl playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;    

    public Vector2 movementInput;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool l_shift_input;

    public void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControl();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Sprint.performed += i => l_shift_input = true;
            playerControls.PlayerActions.Sprint.canceled += i => l_shift_input = false;
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInputs();
        HandleSprintingInputs();
    }

    private void HandleMovementInputs()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorVales(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInputs()
    {
        if (l_shift_input && moveAmount > 0f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

}

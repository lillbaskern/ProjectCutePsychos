using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExperimentalInputController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction direction;
    ExperimentalPlayer _player;
    Vector2 directionalInput;
    public Vector2 dirTest;
    void Awake()
    {
        _player = GetComponent<ExperimentalPlayer>();
        playerInput = GetComponent<PlayerInput>();
        direction = playerInput.actions["Move"];
    }

    public void PollDirection()
    {
        directionalInput = direction.ReadValue<Vector2>();
        _player.SetDirectionalInput(directionalInput);
        Debug.Log(directionalInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
        _player.SetDirectionalInput(directionalInput);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) _player.OnJumpInputDown();

        if (context.canceled) _player.OnJumpInputUp();
    }
}

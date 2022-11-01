using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExperimentalInputController : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _direction;
    ExperimentalPlayer _player;
    Vector2 directionalInput;
    public static bool PausePressed;
    public bool HasInitialized = false;

    void Awake()
    {
        _player = GetComponent<ExperimentalPlayer>();
        _playerInput = GetComponent<PlayerInput>();
        _direction = _playerInput.actions["Move"];
    }
    private void Start() {
        HasInitialized = true;
    }



    public void PollDirection()//if you just want to poll for a vector2 value without requiring an input event to occur.
    {
        if (!HasInitialized) { return; }//guard clause to prevent null reference exception on initial startup
        directionalInput = _direction.ReadValue<Vector2>();
        _player.SetDirectionalInput(directionalInput);
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) _player.Dash();
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

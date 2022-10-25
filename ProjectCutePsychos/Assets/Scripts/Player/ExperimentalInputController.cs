using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExperimentalInputController : MonoBehaviour
{
    // Start is called before the first frame update
    ExperimentalPlayer _player;
    Vector2 directionalInput;
    void Start()
    {
        _player = GetComponent<ExperimentalPlayer>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
        _player.SetDirectionalInput(directionalInput);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _player.OnJumpInputDown();
        }
        if(context.canceled){
            _player.OnJumpInputUp();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttack : MonoBehaviour
{
    [SerializeField] private GameObject _attackArea = default;

    private bool _attacking = false;

    [SerializeField] private float _timeToAttack = 0.25f;
    [SerializeField] private float _timer = 0f;

    private float _attackAreaLocalxPos;
    //the local pos on the x axis in 2d space. this is set in start to the current local x pos of the attackarea gameobject

    private ExperimentalPlayer _player;

    private void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
        _attackAreaLocalxPos = _attackArea.transform.localPosition.x;
        _player = GetComponent<ExperimentalPlayer>();//concise, easily readable. porgramming
    }

    private void Update()
    {
        if (_attacking)
        {
            _attackArea.transform.localPosition = new Vector3(_attackAreaLocalxPos * _player.DirX, 0, 0); 
            _timer += Time.deltaTime;
            if (_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
                _attackArea.SetActive(_attacking);

            }
        }
    }


    private void Attack() // When called set "_attackArea" to active.
    {
        _attacking = true;
        _attackArea.SetActive(_attacking);
    }

    public void BasicAttack(InputAction.CallbackContext context) // If button pressed call Function
    {
        if (context.performed)
        {
            Attack();
        }
    }
}

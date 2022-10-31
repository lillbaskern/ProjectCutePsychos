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

    private void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (_attacking)
        {
            _timer += Time.deltaTime;

            if(_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
                _attackArea.SetActive(_attacking);

            }
        }
    }

    private void Attack()
    {
        _attacking = true;
        _attackArea.SetActive(_attacking);
    }

    public void BasicAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    
    [SerializeField] private int _damage = 0;
    public PlayerHealth PlayerHP;

    public void Awake()
    {
        PlayerHP = FindObjectOfType<PlayerHealth>(); //Get object with the component "Player Health".
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHP.TakeDamage(_damage); //Call Take damage function do dmg = _damage.
            Debug.Log("player Collision");
        }
    }
}

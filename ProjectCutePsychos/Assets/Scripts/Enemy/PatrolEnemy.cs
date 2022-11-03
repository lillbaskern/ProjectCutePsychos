using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    
    [SerializeField] private int _damage = 0;
    public PlayerHealth playerHP;

    public void Awake()
    {
        playerHP = FindObjectOfType<PlayerHealth>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHP.TakeDamage(_damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    
    [SerializeField] private int _damage = 1;
    public PlayerHealth playerHP;

    public void Awake()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (!col)
        {
            col = this.transform.AddComponent<PolygonCollider2D>();   
        }
        col.isTrigger = true;


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

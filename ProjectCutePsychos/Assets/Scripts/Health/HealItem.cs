using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private int healthValue;
    public PlayerHealth playerHP;

    public void Awake()
    {
        playerHP = FindObjectOfType<PlayerHealth>();
    }

    //If the object collides with the tag "player" restore health to player equal to healthValue
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHP.RestoreHealth(healthValue);
            Destroy(gameObject);
        }
    }
}

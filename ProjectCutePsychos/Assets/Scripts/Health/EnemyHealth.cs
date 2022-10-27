using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public void TakeDamage(int _damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= _damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, 1f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PatrolEnemy>().enabled = false;
        GetComponentInParent<EnemyPatrol>().enabled = false;
    }
}

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
    public void SetHP(int input)
    {
        currentHealth = Mathf.Clamp(input, 1, maxHealth);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}

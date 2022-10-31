using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    [SerializeField] private int _damage;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(_damage);
        }
    }
}

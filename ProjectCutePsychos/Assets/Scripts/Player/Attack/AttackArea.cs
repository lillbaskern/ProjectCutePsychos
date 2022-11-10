using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    [SerializeField] private int _damage;
    private bool hasHitThisAttack = false;//has the character hit during the attack?

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null && !hasHitThisAttack)
        {
            hasHitThisAttack = true;
            collider.GetComponent<EnemyHealth>().TakeDamage(_damage);
        }
    }
    private void OnDisable()
    {
        hasHitThisAttack = false;
    }
}

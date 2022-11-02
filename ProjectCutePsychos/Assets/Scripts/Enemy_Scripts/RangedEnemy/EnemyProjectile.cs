using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 30;
    [SerializeField] private int _damage;
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _projectileSpeed;
        Destroy(gameObject, .5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject targetHit = collision.gameObject;
        if (targetHit.tag == "Player")
            targetHit.GetComponent<PlayerHealth>().TakeDamage(_damage);

        Destroy(gameObject);
    }
}

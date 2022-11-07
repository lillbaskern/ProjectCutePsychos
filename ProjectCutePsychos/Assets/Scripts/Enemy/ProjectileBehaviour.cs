using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 30;
    [SerializeField] private int _damage;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _projectileSpeed; //move projectile horizontaly at projectilespeed.
        Destroy(gameObject, .5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject targetHit = collision.gameObject; // Get tag or target hit
        if (targetHit.tag == "Player")
            targetHit.GetComponent<PlayerHealth>().TakeDamage(_damage); // If target hit has the tag "Player" call TakeDamage function.

        Destroy(gameObject);
    }
}

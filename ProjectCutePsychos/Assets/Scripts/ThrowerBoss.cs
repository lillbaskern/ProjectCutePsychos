using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerBoss : MonoBehaviour
{
public float ProjectileSpeed;

    private void Update()
    {
         transform.position += transform.forward * Time.deltaTime * ProjectileSpeed;
        //Destroy(gameObject, .5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            //add a way to despawn player at start of fight
        }
    }

}

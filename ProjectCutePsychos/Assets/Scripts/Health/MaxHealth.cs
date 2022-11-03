using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    [SerializeField] private int increaseValue;
    [SerializeField] private int amountCollected;
    private PlayerHealth playerHP;

    public void Awake()
    {
        playerHP = GetComponentInParent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    //Check for the tag of collided object.
        if (other.tag == "MaxHealthItem")
            //If the amount collected it less than 3 increase the amount of collected and destroy the gameobject
            if (amountCollected < 3)
            {
                amountCollected++;
                Destroy(other.gameObject, 0.1f);
            }       

        //If the amount collected = 3 or higher increase the maxhealth by increasevalue and reset amount collected to 0 before destroying the gameobject.
            if (amountCollected >= 3)
            {
                playerHP.IncreaseMaxHealth(increaseValue);
                amountCollected = 0;
                Destroy(other.gameObject, 0.1f);
            }
    }
}

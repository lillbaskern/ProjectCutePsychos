using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected : MonoBehaviour
{
    [SerializeField] private int value;



    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check for the tag of collided object.
        if (other.tag == "Coin")
        {            
            Destroy(other.gameObject);
            CoinTracker.instance.IncreaseCoins(value);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
//Script that finds all active GameObjects tagged with "Coin" in a scene and makes sure that they have the necessary components and settings for functionality with the coins
public class coinscript : MonoBehaviour
{
    public static bool initialized = false;
    GameObject[] coins;
    void Start()
    {
        if (!initialized) { 
            initialized = true;
            CoinTracker coinTrackerTemp = (CoinTracker)FindObjectOfType(typeof(CoinTracker));
            if (!coinTrackerTemp)
            {
                this.gameObject.AddComponent<CoinTracker>();
            }
            coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject co in coins)
            {
                Collider2D colTemp = GetComponent<Collider2D>();
                if (!colTemp)
                {
                    BoxCollider2D boxCol = co.AddComponent<BoxCollider2D>();
                    boxCol.isTrigger = true;
                }
                co.AddComponent<CoinsCollected>();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
//For a time during development few of the assets in the scene had actual functionality. this script adds colliders and sets them to be triggers
//this was not meant to stick around, which is why it's name doesnt adhere to naming conventions
public class coinscript : MonoBehaviour
{
    public static bool initialized = false;
    GameObject[] coins;
    GameObject[] hearts;
    GameObject[] enemies;
    public int EnemiesInLevel;// We wanted this for UI functionality but had no time
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();//wait for end of frame to let the execution order do its thing    

        //Cointracker is needed for UI functionality. So to prevent bugs add that component if its missing
        CoinTracker coinTrackerTemp = (CoinTracker)FindObjectOfType(typeof(CoinTracker));
        if (!coinTrackerTemp)
        {
            this.gameObject.AddComponent<CoinTracker>();
        }
        

        //coins and hearts pickups need colliders that are marked as istrigger. To save time having each designer place these per level
        //we just fix it here.
        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject co in coins)
        {
            Collider2D colTemp = GetComponent<Collider2D>();
            if (!colTemp)
            {
                BoxCollider2D boxCol = co.AddComponent<BoxCollider2D>();
                boxCol.isTrigger = true;
            }
        }
        hearts = GameObject.FindGameObjectsWithTag("MaxHealthItem");
        foreach (GameObject heart in hearts)
        {
            Collider2D colTemp = GetComponent<Collider2D>();
            if (!colTemp)
            {
                BoxCollider2D boxCol = heart.AddComponent<BoxCollider2D>();
                boxCol.isTrigger = true;
            }
        }

        // //(DEPRECATED) Insert dependencies and Set each enemy's hp to 1 
        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // EnemiesInLevel = enemies.Length + 1;
        // foreach (GameObject enemy in enemies)
        // {
        //     Collider2D colTemp = GetComponent<Collider2D>();
        //     if (!colTemp)
        //     {
        //         BoxCollider2D boxCol = enemy.AddComponent<BoxCollider2D>();
        //         boxCol.isTrigger = true;
        //     }
        //     EnemyHealth nmy = enemy.GetComponent<EnemyHealth>();
        //     if (!nmy)
        //     {
        //        nmy = enemy.AddComponent<EnemyHealth>();
        //     }
        //     nmy.SetHP(1);
        // }


    }

}

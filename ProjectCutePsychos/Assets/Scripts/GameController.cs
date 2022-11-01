using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
//class which is meant to control different aspects of the overarching game state
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public Transform Player;

    void Start()
    {
        //setting up singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(Player);
    }

    void Update()
    {

    }

    //<Summary>
    //Coroutine which respawns the player by setting the player as inactive, then waiting for "delay" amount of time, then reactivating the player
    //the rest of the respawn functionality is done in OnEnable and OnDisable locally in the experimentalplayer script.
    //</Summary>
    public IEnumerator Respawn(float delay)
    {
        Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        Player.gameObject.SetActive(true);
    }
}

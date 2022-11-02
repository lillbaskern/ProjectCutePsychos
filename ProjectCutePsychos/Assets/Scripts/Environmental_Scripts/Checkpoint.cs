using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private ExperimentalPlayer _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<ExperimentalPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == _player.gameObject){
            _player.SetSpawnPos(this.transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private ExperimentalPlayer _player;
    GameObject _checkpointOn;
    bool childIsActive = false;//is the current checkpoint active?

    private GameObject gameController;
    Vector2 thisPosition;
    void Start()
    {
        _checkpointOn = this.transform.GetChild(0).gameObject;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<ExperimentalPlayer>();
        thisPosition = this.transform.position;
    }

    private void Update()
    {
        if(_player.SpawnPos != thisPosition){
            _checkpointOn.SetActive(false);
            childIsActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!childIsActive)
        {
            _checkpointOn.SetActive(true);
            childIsActive = true;
        }
        if (other.gameObject == _player.gameObject && _player.SpawnPos != thisPosition)
        {
            _player.SetSpawnPos(this.transform.position);
        }
    }
}

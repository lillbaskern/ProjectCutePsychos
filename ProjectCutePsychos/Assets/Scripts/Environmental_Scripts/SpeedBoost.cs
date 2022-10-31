using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("The amount that movementspeed will be multiplied by")]
    public float speedMultiplier;
    [Header("How long the player will move faster for")]
    public float duration = 0.5f;//

    private void OnTriggerEnter2D(Collider2D other) {
        var _player = other.GetComponent<ExperimentalPlayer>();
        if (_player != null){
           _player.StartCoroutine(_player.Boost(speedMultiplier, duration));
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("thing");
        var _player = other.transform.GetComponent<ExperimentalPlayer>();
        Debug.Log(_player);
        if (_player != null){
           _player.StartCoroutine(_player.Boost(speedMultiplier, duration));
        }
    }
}

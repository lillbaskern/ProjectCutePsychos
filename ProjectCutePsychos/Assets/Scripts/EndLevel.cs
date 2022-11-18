using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//written by Elias F
/* 
SUMMARY: a miniscule script component meant to be added onto an object with a Collider2D marked as a trigger on it.
When a collider enters the trigger the script checks if the collider has the tag "Player" and if so it simply
calls the static function "LoadNext()" from the static class SceneController
*/
[RequireComponent(typeof(Collider2D))]
public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) SceneController.LoadNext();
    }
}

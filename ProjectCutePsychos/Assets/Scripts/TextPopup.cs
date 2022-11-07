using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public GameObject TextPopupText;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            TextPopupText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            TextPopupText.SetActive(false);
        }
    }


}

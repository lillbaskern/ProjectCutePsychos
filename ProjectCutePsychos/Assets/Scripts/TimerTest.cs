using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerTest : MonoBehaviour
{
    //int i = 0;
    int seconds;
    int minutes;
    TextMeshProUGUI text;
    void Start()
    {
        text = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        minutes = (int)Time.time / 60;
        seconds = (int)Time.time % 60;
        text.SetText($"{minutes}m{seconds}s");
    }
}

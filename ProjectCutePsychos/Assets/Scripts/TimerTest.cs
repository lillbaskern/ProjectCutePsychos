using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerTest : MonoBehaviour
{

    float lapsedTime = 0;
    int seconds;
    int minutes;
    TextMeshProUGUI text;
    void Start()
    {
        text = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        lapsedTime += Time.deltaTime;
        minutes = (int)lapsedTime / 60;
        seconds = (int)lapsedTime % 60;
        text.SetText($"{minutes}m{seconds}s");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    int i = 0;
    void Start()
    {
        Debug.Log(Time.time);
    }

    void FixedUpdate()
    {
        Debug.Log(i%2);
        if (i % 2 == 0)
        {
            Debug.Log(Time.time);
        }
        i++;
    }
}

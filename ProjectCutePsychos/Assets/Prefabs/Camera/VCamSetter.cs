using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VCamSetter : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

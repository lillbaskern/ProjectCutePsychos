using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_02 : MonoBehaviour 
{

    //Snapping Parallax effect to the Camera
    private float lenght, startpos;
    Transform cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Defining the startposition
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;


        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = cam.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}

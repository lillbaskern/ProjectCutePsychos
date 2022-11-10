using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    //Snapping Parallax effect to the Camera
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Defining the startposition
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;




    }

    // Update is called once per frame
    void Update()
    {
        float dist = (Camera.main.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}

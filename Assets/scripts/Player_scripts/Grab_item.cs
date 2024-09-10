using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_item : MonoBehaviour
{
    private BoxCollider2D zone;
    void Start()
    {
        zone = GetComponent<BoxCollider2D>();
        zone.enabled = false;
    }

    private float time_left = 0;
    void Update()
    {
        if (time_left > 0)
        {
            time_left-= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            zone.enabled = true;
            time_left = .2f;
        }
        else if(time_left <=0)
        {
            zone.enabled = false;
        }
    }
}

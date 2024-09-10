using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_track : MonoBehaviour
{
    //After getting a certain distance away, the camera will start speeding up based on how far away it is, follow_mod is a variable that increases
    //how fast it gets
    [SerializeField] private float follow_mod, cam_speed;

    private GameObject Player;
    private Transform player_loc;
    private Rigidbody2D rb;
    public bool locked = false;
    void Start()
    {
        Player = GameObject.Find("Player");
        player_loc = Player.transform;
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private Vector2 distance;
    void Update()
    {
        if(locked) return;

        distance = player_loc.position - transform.position;
        if(distance.sqrMagnitude > 2)
            transform.position = new Vector3(transform.position.x + distance.x * Time.deltaTime * follow_mod, transform.position.y + distance.y * Time.deltaTime * follow_mod, -10);
        else if(distance.sqrMagnitude > .1f)
        {
            transform.position = new Vector3(transform.position.x + distance.normalized.x * Time.deltaTime * cam_speed, transform.position.y + distance.normalized.y * Time.deltaTime * cam_speed, -10);
        }
    }
}

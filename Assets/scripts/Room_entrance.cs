using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_entrance : MonoBehaviour
{
    [SerializeField] private bool enters_village = false;
    private Transform player, player_camera;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        player_camera = GameObject.Find("Main Camera").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (enters_village)
            {
                player_camera.gameObject.GetComponent<cam_track>().locked = false;
                player.position = transform.parent.position;
                return;
            }
            player.position = transform.parent.position;
            player_camera.gameObject.GetComponent<cam_track>().locked = true;
            player_camera.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y, -10);
        }
    }
}

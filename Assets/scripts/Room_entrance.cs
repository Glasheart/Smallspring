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
            if(gameObject.name == "Forest_entrance")
            {
                GameObject.Find("Music_controller").GetComponent<Music_Controller>().change_clip(Audio_space.FOREST);
            }
            if (enters_village)
            {
                GameObject.Find("Music_controller").GetComponent<Music_Controller>().change_clip(Audio_space.VILLAGE);

                player_camera.gameObject.GetComponent<cam_track>().locked = false;
                player.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
                return;
            }
            player.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
            player_camera.gameObject.GetComponent<cam_track>().locked = true;
            player_camera.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y, -10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float max_speed, acceleration;
    [SerializeField] private float oxygen = 3;

    public bool chest_mode = false;
    private slot_highlight slot;
    private Rigidbody2D rb;
    private float horzontal, vertical;
    private GameObject chestUI;
    private BoxCollider2D player_collider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        slot = GameObject.Find("Highlight").GetComponent<slot_highlight>();
        chestUI = GameObject.Find("chest_inventory");
        player_collider = GetComponent<BoxCollider2D>();
    }

    private float cur_speed;
    private Vector2 direction;
    void FixedUpdate()
    {
        if (chest_mode)
        {
            return;
        }
        horzontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        direction = new Vector2(horzontal, vertical);

        if(rb.velocity.magnitude < cur_speed)
            rb.velocity = new Vector3(cur_speed * horzontal, cur_speed * vertical);
        else
        {
            rb.velocity = new Vector3(cur_speed * horzontal * Mathf.Abs(direction.normalized.x), cur_speed * vertical * Mathf.Abs(direction.normalized.y));
        }

        if ((rb.velocity.x < 0 && transform.localScale.x > 0) || (rb.velocity.x > 0 && transform.localScale.x < 0))
            flip();
    }
    private void Update()
    {
        if (chest_mode)
        {
            rb.velocity = new Vector3(0, 0);
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                slot.change_vert(1);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                slot.change_vert(-1);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                slot.change_highlighted_slot(1);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                slot.change_highlighted_slot(-1);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                slot.transfer_item();
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                slot.vertical_slot = 0;
                chestUI.SetActive(false);
                chest_mode = false;
            }

            return;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            slot.change_highlighted_slot(1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            slot.drop_item();
        }
        if (player_collider.IsTouchingLayers(LayerMask.NameToLayer("Flooded")))
        {
            oxygen-=Time.deltaTime;
            cur_speed = max_speed / 2;
            if (oxygen < 0)
                Debug.Log("You drowned");
        }
        else
        {
            oxygen = 3;
            cur_speed = max_speed;
        }
    }
    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
    }
}
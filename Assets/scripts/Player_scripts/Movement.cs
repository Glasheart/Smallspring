using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float max_speed, acceleration;

    private slot_highlight slot;
    private Rigidbody2D rb;
    private float horzontal, vertical;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        slot = GameObject.Find("Highlight").GetComponent<slot_highlight>();
    }

    private float cur_speed;
    private Vector2 direction;
    void FixedUpdate()
    {
        horzontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        direction = new Vector2(horzontal, vertical);

        if(rb.velocity.magnitude < max_speed)
            rb.velocity = new Vector3(max_speed * horzontal, max_speed * vertical);
        else
        {
            rb.velocity = new Vector3(max_speed * horzontal * Mathf.Abs(direction.normalized.x), max_speed * vertical * Mathf.Abs(direction.normalized.y));
        }

        if ((rb.velocity.x < 0 && transform.localScale.x > 0) || (rb.velocity.x > 0 && transform.localScale.x < 0))
            flip();

        if (Input.GetKeyUp(KeyCode.Q))
        {
            slot.change_highlighted_slot(1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            slot.drop_item();
        }
    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
    }
}
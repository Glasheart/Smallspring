using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float max_speed, acceleration;

    private Rigidbody2D rb;
    private float horzontal, vertical;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
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
    }
}
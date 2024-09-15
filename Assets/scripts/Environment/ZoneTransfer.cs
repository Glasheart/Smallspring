using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTransfer: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    private LayerMask playerLayer;
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            collision.transform.position = target.position;
        }
    }
}

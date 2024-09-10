using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private LayerMask tool_layer;
    private BoxCollider2D tree_collider;
    void Start()
    {
        tree_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tree_collider.IsTouchingLayers(tool_layer)) 
        {
            Destroy(gameObject);
        }
    }
}

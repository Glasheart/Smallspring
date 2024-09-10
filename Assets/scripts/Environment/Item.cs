using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private LayerMask tool_layer;
    [SerializeField] private Item_types item_types;
    private Inventory inventory;
    public bool is_tree = false;
    private BoxCollider2D tree_collider;
    void Start()
    {
        tree_collider = GetComponent<BoxCollider2D>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tree_collider.IsTouchingLayers(tool_layer)) 
        {
            inventory.add_item(item_types);
            Destroy(gameObject);
        }
    }
}

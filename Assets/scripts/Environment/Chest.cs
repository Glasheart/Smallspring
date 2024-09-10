using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private LayerMask interact_layer;

    private Inventory player_inventory, chest_inventory;
    private BoxCollider2D chest_collider;
    void Start()
    {
        chest_inventory = GetComponent<Inventory>();
        player_inventory = GameObject.Find("Player").GetComponent<Inventory>();
        chest_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

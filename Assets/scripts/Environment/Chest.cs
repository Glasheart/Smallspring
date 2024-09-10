using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private LayerMask interact_layer;
    private GameObject chestUI;

    private Inventory player_inventory, chest_inventory;
    private BoxCollider2D chest_collider;
    private Movement movement;
    void Start()
    {
        chestUI = GameObject.Find("chest_inventory");
        chest_inventory = GetComponent<Inventory>();
        player_inventory = GameObject.Find("Player").GetComponent<Inventory>();
        movement = GameObject.Find("Player").GetComponent<Movement>();
        chest_collider = GetComponent<BoxCollider2D>();
    }

    private bool chest_active = true;
    void Update()
    {
        if (chest_active)
        {
            StartCoroutine(delayed_disable());
            chest_active = false;
        }
        if (chest_collider.IsTouchingLayers(interact_layer))
        {
            movement.chest_mode = true;
            chestUI.SetActive(true);
        }
    }
    /*Version of chest that sells when interacting
     if (chest_collider.IsTouchingLayers(interact_layer))
        {
            player_inventory.sell_items();
        }
    */
    IEnumerator delayed_disable()
    {
        yield return new WaitForSeconds(.2f);
        chestUI.SetActive(false);
    }
}

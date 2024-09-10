using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_highlight : MonoBehaviour
{
    private Transform[] positions;
    private GameObject inventory_visuals;
    private Inventory player_inventory;
    private int highlighted_slot = 0;

    void Start()
    {
        int i = 0;
        inventory_visuals = GameObject.Find("Inventory_visuals");
        player_inventory = GameObject.Find("Player").GetComponent<Inventory>();
        positions = new Transform[inventory_visuals.transform.childCount];

        foreach (Transform t in inventory_visuals.transform)
        {
            positions[i] = t;
            i++;
        }
    }

    public void change_highlighted_slot(int i)
    {
        highlighted_slot += i;
        if(highlighted_slot >= positions.Length)
        {
            highlighted_slot = 0;
        }
        else if (highlighted_slot < 0)
        {
            highlighted_slot = positions.Length-1;
        }
        transform.position = positions[highlighted_slot].position;
    }

    public void drop_item()
    {
        player_inventory.empty_inventory_slot(highlighted_slot);
    }
}

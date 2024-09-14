using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class slot_highlight : MonoBehaviour
{
    private Transform[] positions, chest_postions;
    private GameObject inventory_visuals, chest_visuals;
    private Inventory player_inventory, chest_inventory;
    private slot_highlight currSlot;
    private int highlighted_slot = 0;
    public int vertical_slot = 0;

    void Start()
    {
        int i = 0;
        inventory_visuals = GameObject.Find("Inventory_visuals");
        player_inventory = GameObject.Find("Player").GetComponent<Inventory>();
        positions = new Transform[inventory_visuals.transform.childCount];

        chest_inventory = GameObject.Find("chest").GetComponent<Inventory>();
        chest_visuals = GameObject.Find("chest_inventory");
        chest_postions = new Transform[chest_visuals.transform.childCount - 1];

        foreach (Transform t in inventory_visuals.transform)
        {
            positions[i] = t;
            i++;
        }
        i = 0;
        foreach (Transform t in chest_visuals.transform)
        {
            if (i != 0)
            {
                chest_postions[i - 1] = t;
            }
            i++;
        }
    }

    public void change_highlighted_slot(int i)
    {
        highlighted_slot += i;
        if (vertical_slot == 0)
        {
            if (highlighted_slot >= positions.Length)
            {
                highlighted_slot = 0;
            }
            else if (highlighted_slot < 0)
            {
                highlighted_slot = positions.Length - 1;
            }
            transform.position = positions[highlighted_slot].position;
            return;
        }
        if (highlighted_slot >= 9)
        {
            highlighted_slot = 0;
        }
        else if (highlighted_slot < 0)
        {
            highlighted_slot = 8;
        }
        if(vertical_slot != 0)
            transform.position = chest_postions[highlighted_slot + ((3-vertical_slot) * 9)].position;
        else
        {
            highlighted_slot = 0;
            change_highlighted_slot(0);
        }

        return;
    }


    public void drop_item()
    {
        player_inventory.empty_inventory_slot(highlighted_slot);
    }

    public void transfer_item()
    {
        if(vertical_slot == 0)
        {
            chest_inventory.add_slot(player_inventory.slots[highlighted_slot]);
            player_inventory.empty_inventory_slot(highlighted_slot);
        }
        else
        {
            player_inventory.add_slot(chest_inventory.slots[highlighted_slot + ((3 - vertical_slot) * 9)]);
            chest_inventory.empty_inventory_slot(highlighted_slot + ((3 - vertical_slot) * 9));
        }
    }
    public void change_vert(int i)
    {
        if(vertical_slot + i < 0)
        {
            vertical_slot = 3;
        }
        else if(vertical_slot + i > 3) { vertical_slot = 0; }
        else
        {
            vertical_slot += i;
        }
        change_highlighted_slot(highlighted_slot);
    }
}

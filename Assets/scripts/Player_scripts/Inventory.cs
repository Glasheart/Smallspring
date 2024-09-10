using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public struct slot
{
    public int count;
    public Item_types type;
}
public enum Item_types
{
    EMPTY = 0,
    HERB = 2,
    WOOD = 1
}
public class Inventory : MonoBehaviour
{
    public slot[] slots;
    public int slot_count, slot_max;
    public int money = 0;
    private Player_inventory_visuals vis;

    private void Start()
    {
        slots = new slot[slot_count];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].count = 0;
            slots[i].type = Item_types.EMPTY;
        }
        vis = GameObject.Find("Inventory_visuals").GetComponent<Player_inventory_visuals>();
    }
    public void add_item(Item_types type)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].type == Item_types.EMPTY)
            {
                slots[i].type = type;
                slots[i].count++;
                vis.change_slot(i);
                break;
            }
            if (slots[i].type == type && slots[i].count < slot_max)
            {
                slots[i].count++;
                vis.change_slot(i);
                break;
            }
        }
    }

    public void sell_items()
    {
       for(int i = 0;i < slots.Length;i++)
        {
            money += slots[i].count * (int)slots[i].type;

            empty_inventory_slot(i);
        }

        Debug.Log(money);
    }
    public void empty_inventory_slot(int i)
    {
        slots[i].type = Item_types.EMPTY;
        slots[i].count = 0;
        vis.change_slot(i);

        if(i < slots.Length-1)
        {
            if (slots[i + 1].type != Item_types.EMPTY)
            {
                slots[i] = slots[i + 1];
                vis.change_slot(i);
                empty_inventory_slot(i + 1);
            }
        }
    }
}

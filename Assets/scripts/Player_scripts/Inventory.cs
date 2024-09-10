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
    EMPTY,
    HERB,
    WOOD
}
public class Inventory : MonoBehaviour
{
    private slot[] slots;
    public int slot_count, slot_max;
    public int money = 0;

    private void Start()
    {
        slots = new slot[slot_count];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].count = 0;
            slots[i].type = Item_types.EMPTY;
        }
    }
    public void add_item(Item_types type)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].type == Item_types.EMPTY)
            {
                slots[i].type = type;
                slots[i].count++;
                Debug.Log("herb, " + slots[i].count.ToString());
                break;
            }
            if (slots[i].type == type && slots[i].count < slot_max)
            {
                slots[i].count++;
                Debug.Log("herb, " + slots[i].count.ToString());
                break;
            }
        }
    }
}

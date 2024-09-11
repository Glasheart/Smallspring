using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_inventory_visuals : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sprite empty;
    [SerializeField] private bool chest = false;

    private Image[] visual_slots;
    private TMP_Text[] texts;
    private Inventory inventory;
    
    void Start()
    {
        int i = 0;
        if(!chest)
            inventory = GameObject.Find("Player").GetComponent<Inventory>();
        else
            inventory = GameObject.Find("chest").GetComponent<Inventory>();

        visual_slots = new Image[transform.childCount];
        texts = new TMP_Text[transform.childCount];

        foreach (Transform t in transform) 
        {
            if(!chest)
            {
                visual_slots[i] = t.gameObject.GetComponent<Image>();
                texts[i] = t.GetChild(0).GetComponent<TMP_Text>();
            }
            else
            {
                if (i != 0)
                {
                    visual_slots[i - 1] = t.gameObject.GetComponent<Image>();
                    texts[i - 1] = t.GetChild(0).GetComponent<TMP_Text>();
                }
            }
            
            i++;
        }
    }

    public void change_slot(int i)
    {
        if (inventory.slots[i].type == Item_types.EMPTY)
        {
            visual_slots[i].sprite = empty;
            texts[i].text = "";
            return;
        }
        
        texts[i].text = inventory.slots[i].count.ToString();

        switch (inventory.slots[i].type)
        {
            case Item_types.HERB:
                visual_slots[i].sprite = sprites[0];
                return;
            case Item_types.WOOD:
                visual_slots[i].sprite = sprites[1];
                return;
            case Item_types.BLUEBERRIES:
                visual_slots[i].sprite = sprites[2];
                return;
            case Item_types.COFFEEBEANS:
                visual_slots[i].sprite = sprites[3];
                return;
            case Item_types.PUREBERRIES:
                visual_slots[i].sprite = sprites[4];
                return;
            case Item_types.STRAWBERRIES:
                visual_slots[i].sprite = sprites[5];
                return;

        }
    }
}

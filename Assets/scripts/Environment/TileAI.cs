using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAI : MonoBehaviour
{
    [SerializeField] private Item_types[] spawn_options = { Item_types.EMPTY};
    [SerializeField] private Sprite[] sprites;

    private Item item;
    private SpriteRenderer spriteRenderer;
    private Item_types selected_item;
    private BoxCollider2D boxCollider;

    void Start()
    {
        item = GetComponent<Item>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        float chance = Random.Range(0.0f, 1.0f);
        selected_item = spawn_options[Random.Range(1, spawn_options.Length)];

        if (chance - (float)selected_item/100 + .01f < .9f)
        {
            selected_item = Item_types.EMPTY;
        }
        sprite_update();
    }

    void sprite_update()
    {
        if (selected_item == Item_types.EMPTY)
        {
            boxCollider.enabled = false;
            return;
        }
        item.item_types = selected_item;

        switch(selected_item)
        {
            case Item_types.HERB:
                spriteRenderer.sprite = sprites[0];
                return;
            case Item_types.WOOD:
                spriteRenderer.sprite = sprites[1];
                return;
        }
    }
}

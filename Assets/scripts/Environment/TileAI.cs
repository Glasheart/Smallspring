using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileAI : MonoBehaviour
{
    [SerializeField] private Item_types[] spawn_options = { Item_types.EMPTY};
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sprite flood_sprite;

    private Item item;
    private SpriteRenderer spriteRenderer;
    private Item_types selected_item;
    private BoxCollider2D boxCollider;

    private Item_types[] one_val = { Item_types.WOOD, Item_types.COFFEEBEANS, Item_types.BLUEBERRIES, Item_types.STRAWBERRIES, Item_types.TEALEAVES};
    private Item_types[] two_val = { Item_types.HERB, Item_types.RASPBERRIES, Item_types.BLACKBERRIES, Item_types.APPLES, Item_types.CAMOMILE, Item_types.GINGER};
    private Item_types[] three_val = { Item_types.GLOWBERRIES, Item_types.FEVERFEW, Item_types.GINSENG};
    private Item_types four_val = Item_types.PUREBERRIES;

    void Start()
    {
        item = GetComponent<Item>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        float chance = Random.Range(0.0f, 1.0f);
        selected_item = spawn_options[Random.Range(1, spawn_options.Length)];

        if (chance - get_rarity(selected_item) /50 < .9f)
        {
            selected_item = Item_types.EMPTY;
        }
        sprite_update();
    }

    void sprite_update()
    {
        if (selected_item == Item_types.EMPTY)
        {
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
            case Item_types.BLUEBERRIES:
                spriteRenderer.sprite = sprites[2];
                return;
            case Item_types.COFFEEBEANS:
                spriteRenderer.sprite = sprites[3];
                return;
            case Item_types.PUREBERRIES:
                spriteRenderer.sprite = sprites[4];
                return;
            case Item_types.STRAWBERRIES:
                spriteRenderer.sprite = sprites[5];
                return;

        }
    }
    public float get_rarity(Item_types selected)
    {
        if (selected == Item_types.EMPTY)
            return 0;
        if (one_val.Contains(selected))
            return 1;
        if (two_val.Contains(selected))
            return 2;
        if (three_val.Contains(selected))
            return 3;
        return 4;
    }
    public void flood()
    {
        if(Random.Range(0.0f, 1.0f) <= .1f)
        {
            spriteRenderer.sprite = flood_sprite;
            item.item_types = Item_types.EMPTY;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] public Button[] Slots = new Button[9];
    [SerializeField] public TextMeshProUGUI[] sellMessages = new TextMeshProUGUI[9];
    [SerializeField] public TextMeshProUGUI[] price = new TextMeshProUGUI[9];
    [SerializeField] public Image[] images = new Image[9];

    public Sprite BerrySprite;
    public Sprite DrinkSprite;
    public Sprite HerbSprite;
    public Sprite WoodSprite;
//these buttons will be activated only if the player has items in those slots.

    private Inventory inventory; 

    // Start is called before the first frame update
    void Start()
    {
        images[0].sprite = BerrySprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUpShop()
    {
        int count = 0;
        for(int i = 0; i < inventory.slot_count; i++)
        {
            if (inventory.slots[i].type != Item_types.EMPTY)
            {
                /*if (inventory.slots[i].type == Item_types.COFFEEBEANS || inventory.slots[i].type == Item_types.STRAWBERRIES 
                    || inventory.slots[i].type == Item_types.RASPBERRIES || inventory.slots[i].type == Item_types.BLACKBERRIES 
                    || inventory.slots[i].type == Item_types.BLACKBERRIES || inventory.slots[i].type == Item_types.GLOWBERRIES 
                    || inventory.slots[i].type == Item_types.PUREBERRIES)//different types of berries
                {
                    images[count].sprite = BerrySprite;
                } */
                Slots[count].gameObject.SetActive(true);
            }
        }
    }
}

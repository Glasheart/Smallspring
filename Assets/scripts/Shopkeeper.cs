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
    [SerializeField] public GameObject shopPanel;


    public Sprite BerrySprite;
    public Sprite DrinkSprite;
    public Sprite HerbSprite;
    public Sprite WoodSprite;
//these buttons will be activated only if the player has items in those slots.

    private Inventory inventory;

    public int[] inventorySlots = new int[9];

    // Start is called before the first frame update
    void Start()
    {
        //images[0].sprite = BerrySprite;
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].gameObject.SetActive(false);
        }
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
                //Set up sprites
                if (inventory.slots[i].type == Item_types.COFFEEBEANS || inventory.slots[i].type == Item_types.STRAWBERRIES 
                    || inventory.slots[i].type == Item_types.RASPBERRIES || inventory.slots[i].type == Item_types.BLACKBERRIES 
                    || inventory.slots[i].type == Item_types.BLACKBERRIES || inventory.slots[i].type == Item_types.GLOWBERRIES 
                    || inventory.slots[i].type == Item_types.PUREBERRIES)//different types of berries
                {
                    images[count].sprite = BerrySprite;                    
                } else if (inventory.slots[i].type == Item_types.SAP || inventory.slots[i].type == Item_types.CAMOMILE 
                || inventory.slots[i].type == Item_types.GINGER || inventory.slots[i].type == Item_types.GINSENG 
                || inventory.slots[i].type == Item_types.FEVERFEW)
                {
                    images[count].sprite = HerbSprite;
                } else if (inventory.slots[i].type == Item_types.WOOD)
                {
                    images[count].sprite = WoodSprite;
                }
                


                if (inventory.slots[i].type == Item_types.COFFEEBEANS)
                 {
                    sellMessages[count].text = "Sell coffee beans?";
                 } else if (inventory.slots[i].type == Item_types.STRAWBERRIES)
                 {
                    sellMessages[count].text = "Sell coffee Strawberries?";
                 } else if (inventory.slots[i].type == Item_types.RASPBERRIES)
                 {
                    sellMessages[count].text = "Sell Raspberries?";
                 } else if (inventory.slots[i].type == Item_types.BLUEBERRIES)
                 {
                    sellMessages[count].text = "Sell Blueberries?";
                 } else if (inventory.slots[i].type == Item_types.BLACKBERRIES)
                 {
                    sellMessages[count].text = "Sell Blackberries?";
                 } else if (inventory.slots[i].type == Item_types.GLOWBERRIES)
                 {
                    sellMessages[count].text = "Sell Glowberries?";
                 } else if (inventory.slots[i].type == Item_types.PUREBERRIES)
                 {
                    sellMessages[count].text = "Sell Pureberries?";
                 } else if (inventory.slots[i].type == Item_types.TEALEAVES)
                 {
                    sellMessages[count].text = "Sell Tea leaves?";
                 } else if (inventory.slots[i].type == Item_types.SAP)
                 {
                    sellMessages[count].text = "Sell sap?";
                 } else if (inventory.slots[i].type == Item_types.CAMOMILE)
                 {
                    sellMessages[count].text = "Sell Chamomile?";
                 } else if (inventory.slots[i].type == Item_types.GINGER)
                 {
                    sellMessages[count].text = "Sell Ginger?";
                 } else if (inventory.slots[i].type == Item_types.FEVERFEW)
                 {
                    sellMessages[count].text = "Sell Feverfew?";
                 } else if (inventory.slots[i].type == Item_types.GINSENG)
                 {
                    sellMessages[count].text = "Sell Ginseng?";
                 } else if (inventory.slots[i].type == Item_types.WOOD)
                 {
                    sellMessages[count].text = "Sell Wood?";
                 }
                 

                //set up price


                int priceText = inventory.slots[i].count * (int)inventory.slots[i].type;
                price[count].text = priceText.ToString();
                

                inventorySlots[count] = i;
                Slots[count].gameObject.SetActive(true);
                count++;
            }
        }
        shopPanel.SetActive(true);
    }

    public void sell(int slot) //slot passed through will correspond to the button, which the slot the item being sold is in is held in inventorySlots
    {
        //inventory.sell_items(inventorySlots[slot]);
    }
}

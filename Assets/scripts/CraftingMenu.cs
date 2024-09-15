using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons = new Button[14];
    [SerializeField] private Button leftButton; //these will move page left and right, one page for coffee, one for teas
    [SerializeField] private Button rightButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private LayerMask interact_layer;
    private Inventory inventory;

    public bool hasCoffeeBeans;
    public bool hasTeaLeaves;

    public int firstSlot;
    public int secondSlot;

    private BoxCollider2D craft_collider;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        craft_collider = GetComponent<BoxCollider2D>();
        leftButton.interactable = false;
        rightButton.interactable = true;
    }

    private bool is_crafting = false;
    void Update()
    {
        if (craft_collider.IsTouchingLayers(interact_layer) && !is_crafting)
        {
            is_crafting = true;
            SetUp();
        }
        if (Input.GetKeyDown(KeyCode.Tab) && is_crafting)
        {
            is_crafting = false;
            panel.SetActive(false);
        }
    }

    public void SetUp()
    {
        updateShop();
        leftButton.interactable = false;
        rightButton.interactable = true;

        panel.SetActive(true);
    }

    public void updateShop() //called to 
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].type == Item_types.COFFEEBEANS)
            {
                hasCoffeeBeans = true;
            } else if (inventory.slots[i].type == Item_types.TEALEAVES)
            {
                hasTeaLeaves = true;
            }
        }
        if (hasCoffeeBeans)
        {
            buttons[0].interactable = true;
        }
        if (hasTeaLeaves)
        {
            buttons[7].interactable= true;
        }

        for(int i = 0; i < inventory.slots.Length; i++) //second loop needed so we know if they have beans or leaves for sure before starting to activate/deactivate buttons
        {
            //COFFEE
            if (hasCoffeeBeans && inventory.slots[i].type == Item_types.STRAWBERRIES)
            {
                buttons[1].interactable = true;
            } else if (hasCoffeeBeans && inventory.slots[i].type == Item_types.BLUEBERRIES)
            {
                buttons[2].interactable = true;
            } else if (hasCoffeeBeans && inventory.slots[i].type == Item_types.RASPBERRIES)
            {
                buttons[3].interactable = true;
            } else if (hasCoffeeBeans && inventory.slots[i].type == Item_types.BLACKBERRIES)
            {
                buttons[4].interactable = true;
            } else if (hasCoffeeBeans && inventory.slots[i].type == Item_types.GLOWBERRIES)
            {
                buttons[5].interactable = true;
            } else if (hasCoffeeBeans && inventory.slots[i].type == Item_types.PUREBERRIES)
            {
                buttons[6].interactable = true;
            }
            //TEA
            if (hasTeaLeaves && inventory.slots[i].type == Item_types.STRAWBERRIES)
            {
                buttons[8].interactable = true;
            }
            else if (hasTeaLeaves && inventory.slots[i].type == Item_types.BLUEBERRIES)
            {
                buttons[9].interactable = true;
            }
            else if (hasTeaLeaves && inventory.slots[i].type == Item_types.RASPBERRIES)
            {
                buttons[10].interactable = true;
            }
            else if (hasTeaLeaves && inventory.slots[i].type == Item_types.BLACKBERRIES)
            {
                buttons[11].interactable = true;
            }
            else if (hasTeaLeaves && inventory.slots[i].type == Item_types.SAP)
            {
                buttons[12].interactable = true;
            }
            else if (hasTeaLeaves && inventory.slots[i].type == Item_types.CAMOMILE)
            {
                buttons[13].interactable = true;
            }

        }
    }

    public void nextPage(int i)
    {
        if(i == 0) //go to tea page
        {
            for (int j = 0; j < buttons.Length/2; j++)
            {
                buttons[j + buttons.Length / 2].gameObject.SetActive(true);
                buttons[j].gameObject.SetActive(false);
            }
            rightButton.interactable = false;
            leftButton.interactable = true;
        }
        else //go back to coffee page
        {
            for (int j = buttons.Length/2; j < buttons.Length; j++)
            {
                buttons[j - buttons.Length / 2].gameObject.SetActive(true); 
                buttons[j].gameObject.SetActive(false);
            }
            rightButton.interactable= true;
            leftButton.interactable= false;
        }
    }



    public void ItemSelected(int type)
    {
        switch (type)
        {
            case 0:
                itemDescription.text = "Coffee, a great way to start your day.";
                break;
            case 1:
                itemDescription.text = "A latte dyed a light pink. Strawberry flavored, a latte resting on a bed of strawberries";
                break;
            case 2:
                itemDescription.text = "A latte with added blueberries. The blueberries add a subtle sweetness";
                break;
            case 3:
                itemDescription.text = "A latte with a decorative raspberry floating on the surface.";
                break;
            case 4:
                itemDescription.text = "A latte with a tart flavor. Despite the blackberries added, it is indistinguishable from a normal latte.";
                break;
            case 5:
                itemDescription.text = "A coffe that gives off a faint glow. Drinking it can soothe fatigue, and heal minor wounds,";
                break;
            case 6:
                itemDescription.text = "A coffee in truest of forms. The pureberries enhance the bitterness of the coffee, while not becoming overwhelming.";
                break;
            case 7:
                itemDescription.text = "Tea, a soothing way to start your day.";
                break;
            case 8:
                itemDescription.text = "Sweetened iced tea. Syrup adds a sweetness enjoyed by all.";
                break;
            case 9:
                itemDescription.text = "Ginger tea, a drink that helps with nausea.";
                break;
            case 10:
                itemDescription.text = "Chamomile tea, a relaxing drink that grants better sleep, and soothes anxiety.";
                break;
            case 11:
                itemDescription.text = "Feverfew tea, an effective way to fight off fevers while also giving an earthy flavor.";
                break;
            case 12:
                itemDescription.text = "Ginseng tea, a drink to boost your energy.";
                break;
            case 13:
                itemDescription.text = "A tea in the truest of forms. The pureberries enhance the tea's soothing nature, and add a subtle sweetness.";
                break;
        }
    }
    public void CraftItem(int type) //each button will pass a seperate int to determine what to craft
    {
        switch (type)
        {
            case 0: //Cofee
                //take 1 bean away, give coffee
                for(int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.add_item(Item_types.COFFEE);
                break;
            case 1: //Strawberry Latte
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.STRAWBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.STRAWBERRYLATTE);

                break;
            case 2: //Blueberry
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.BLUEBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.BLUEBERRYLATTE);

                break;
            case 3: //Raspberry
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.RASPBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.RASPBERRYLATTE);
                break;
            case 4: //Blackberry
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.BLACKBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.BLACKBERRYLATTE);
                break;
            case 5: //Glowfee
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.GLOWBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.GLOWFEE);
                break;
            case 6: //Pure Coffee
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.COFFEEBEANS) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.PUREBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.PURECOFFEE);
                break;
            case 7: //Tea
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.TEA);
                break;
            case 8: //Sweetened Ice Tea sap
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.SAP) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.SWEETENEDICETEA);
                break;
            case 9: //Ginger Tea
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.GINGER) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.GINGERTEA);
                break;
            case 10: //Chamomile
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.CAMOMILE) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.CHAMOMILETEA);
                break;
            case 11: //Feverfew
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.FEVERFEW) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.FEVERFEWTEA);
                break;
            case 12: //Ginseng
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.GINSENG) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.GINSENGTEA);
                break;
            case 13: //Pureberry Coffee
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].type == Item_types.TEALEAVES) firstSlot = i;
                    else if (inventory.slots[i].type == Item_types.PUREBERRIES) secondSlot = i;
                }
                inventory.increment_slot(firstSlot, -1);
                inventory.increment_slot(secondSlot, -1);
                inventory.add_item(Item_types.PUREBERRYTEA);
                break;
        }
        updateShop();
    }
}

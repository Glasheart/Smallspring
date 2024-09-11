using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons = new Button[14];
    [SerializeField] private Button leftButton; //these will move page left and right, one page for coffee, one for teas
    [SerializeField] private Button rightButton;
    [SerializeField] private GameObject panel;
    private Inventory inventory;

    public bool hasCoffeeBeans;
    public bool hasTeaLeaves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            buttons[buttons.Length].interactable= true;
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
                buttons[i].gameObject.SetActive(false);
            }
            rightButton.interactable = false;
            leftButton.interactable = true;
        }
        else //go back to coffee page
        {
            for (int j = buttons.Length/2 + 1; j < buttons.Length; j++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            rightButton.interactable= true;
            leftButton.interactable= false;
        }
    }
    public void CraftItem(int type) //each button will pass a seperate int to determine what to craft
    {
        switch (type)
        {
            case 0: //Cofee

                break;
            case 1: //

                break;
        }
        updateShop();
    }
}

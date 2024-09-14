using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    private Inventory inventory;

    private Vector2[] moveChoices = new Vector2[] { Vector2.zero, Vector2.right, Vector2.up, Vector2.left, Vector2.down, Vector2.zero };

    public float lowChoiceTime = 1.0f;
    public float highChoiceTime = 2.0f;
    public float decisionTime = 0f;

    public int currDirection = 0;

    public float speed = 0.5f;

    public int hourWanderStart;//when they will start to wander the village
    public int hourWanderEnd; //when they will be back home

    public Dialogue[] dialogue = new Dialogue[3]; //requested drink, thank you, wrong drink response

    [SerializeField] private slot_highlight currSlot;

    public int drinkID;
    public Item_types desiredDrink;

    // Start is called before the first frame update
    void Start()
    {
        //decisionTime = Random.Range(lowChoiceTime, highChoiceTime);
        decisionTime = 12.5f;
        currDirection = 3;
        drinkID = Random.Range(0, 14);
        GetDrink(drinkID);
        //ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = moveChoices[currDirection] * speed;
        if (decisionTime > 0) decisionTime -= Time.deltaTime;
        else
        {
            body.velocity = Vector2.zero;
            decisionTime = Random.Range(lowChoiceTime, highChoiceTime);
            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        currDirection = Mathf.FloorToInt(Random.Range(0, moveChoices.Length));
    }

    public void Talk()
    {
        speed = 0f;
        FindObjectOfType<DialogueController>().StartConversation(dialogue[0]);
    }
    public void GiveDrink(Item_types given)
    {
        if (desiredDrink == given) //correct drink given
        {
            FindObjectOfType<DialogueController>().StartConversation(dialogue[1]);
            //take item away, sell item, walk away
            //inventory.increment_slot(currSlot.highlighted_slot, -1);
            Leave();
        }
        else //wrong drink given
        {
            FindObjectOfType<DialogueController>().StartConversation(dialogue[2]);
            Leave();
        }
    }
    public IEnumerator Leave()
    {
        decisionTime = 4f;
        currDirection = 4;
        yield return new WaitForSeconds(4);
        decisionTime = 8f;
        currDirection = 1;
        gameObject.SetActive(false);

    }

    public void GetDrink(int ID)
    {
        switch (ID)
        {
            case 0:
                desiredDrink = Item_types.COFFEE;
                break;
            case 1:
                desiredDrink = Item_types.STRAWBERRYLATTE;
                break;
            case 2:
                desiredDrink = Item_types.BLUEBERRYLATTE;
                break;
            case 3:
                desiredDrink = Item_types.RASPBERRYLATTE;
                break;
            case 4:
                desiredDrink = Item_types.BLACKBERRYLATTE;
                break;
            case 5:
                desiredDrink = Item_types.GLOWFEE;
                break;
            case 6:
                desiredDrink = Item_types.PURECOFFEE;
                break;
            case 7:
                desiredDrink = Item_types.TEA;
                break;
            case 8:
                desiredDrink = Item_types.SWEETENEDICETEA;
                break;
            case 9:
                desiredDrink = Item_types.GINGERTEA;
                break;
            case 10:
                desiredDrink = Item_types.CHAMOMILETEA;
                break;
            case 11:
                desiredDrink = Item_types.FEVERFEWTEA;
                break;
            case 12:
                desiredDrink = Item_types.GINSENGTEA;
                break;
            case 13:
                desiredDrink = Item_types.PUREBERRYTEA;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript: MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    

    private Vector2[] moveChoices = new Vector2[] {Vector2.zero, Vector2.right, Vector2.up, Vector2.left, Vector2.down, Vector2.zero};

    public float lowChoiceTime = 1.0f;
    public float highChoiceTime = 2.0f;
    public float decisionTime = 0f;

    public int currDirection = 0;

    public float speed = 0.5f;

    public int hourWanderStart;//when they will start to wander the village
    public int hourWanderEnd; //when they will be back home

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        decisionTime = Random.Range(lowChoiceTime, highChoiceTime);

        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = moveChoices[currDirection] * speed;
        if(decisionTime > 0) decisionTime -= Time.deltaTime;
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

    public void talk()
    {
        FindObjectOfType<DialogueController>().StartConversation(dialogue);
    }
}

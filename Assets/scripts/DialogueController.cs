using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }
    }

    public void StartConversation(Dialogue dialogue)
    {
        
        sentences.Clear();
        nameText.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if(sentences.Count > 0)
        {
            dialoguePanel.SetActive(true);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0) 
        {
            dialoguePanel.SetActive(false);
            return;
        }
        dialoguePanel.SetActive(true);
        dialogueText.text = sentences.Dequeue();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator anim;

    private Queue<string> dialogue;


    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);
        StopPlayer();
        foreach (string sentence in sentences)
        {
            dialogue.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void StopPlayer()
    {
        player.GetComponent<Character>().enabled = false;
        anim.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void ResumePlayer()
    {
        player.GetComponent<Character>().enabled = true;
    }

    public void DisplayNextSentence()
    {
        if(dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string text = dialogue.Dequeue();
        dialogueText.text = text;
    }


    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        dialogue.Clear();
        ResumePlayer();
    }

}

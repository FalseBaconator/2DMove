using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{

    public enum InteractiveType
    {
        nothing,
        pickup,
        info,
        dialogue
    }

    [Header("Type of Interactable")]
    public InteractiveType interactiveType;

    [Header("Info Object")]
    TMP_Text infoText;
    public string infoMessage;
    public float infoTime;

    [Header("Dialogue Object")]
    [TextArea]
    public string[] dialogue;

    private void Start()
    {
        infoText = GameObject.FindGameObjectWithTag("InfoText").GetComponent<TMP_Text>();
    }

    public void Nothing()
    {
        Debug.Log("This is Unassigned");
    }

    public void PickUp()
    {
        Debug.Log("Picked Up " + gameObject.name);
        gameObject.SetActive(false);
    }

    public void Info()
    {
        StartCoroutine(ShowInfo(infoMessage, infoTime));
    }

    public void Dialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }

}

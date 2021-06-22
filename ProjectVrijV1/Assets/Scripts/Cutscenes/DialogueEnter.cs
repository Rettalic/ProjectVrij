using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnter : MonoBehaviour
{

    public GameObject dialogueUI;
    private bool hasEntered;

    public Dialogue dialogue;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider>().CompareTag("Player") && !hasEntered) 
        {
            hasEntered = true;
            dialogueUI.SetActive(true);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

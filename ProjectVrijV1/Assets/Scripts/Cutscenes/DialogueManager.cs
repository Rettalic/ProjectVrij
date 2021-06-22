using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float delay = 0.1f;
    private Queue<string> sentences;
    public float timeLeft = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (timeLeft < 0)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {   
        sentences.Clear();
        StartCoroutine(Countdown());

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence() 
    {
        StartCoroutine(Countdown());

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }
    private IEnumerator Countdown()
    {
        timeLeft = 5f;

        timeLeft -= 1;

        if (timeLeft < 0)
        {
            timeLeft = 5f;
        }

        yield return null;
    }

        void EndDialogue() 
    {
    }
}

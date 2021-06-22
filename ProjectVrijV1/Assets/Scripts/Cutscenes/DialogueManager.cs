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
    public bool number;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {

        if(number == true)
        {
            number = false;
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {   
        sentences.Clear();
        StartCoroutine(NextSentence());
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (sentences.Count == -1)
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(NextSentence());
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

    IEnumerator NextSentence()
    {

        yield return new WaitForSeconds(3f);
        number = true;
    }

    void EndDialogue() 
    {
        gameObject.SetActive(false);
    }
}

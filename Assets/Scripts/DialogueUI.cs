using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DialogueBoxController : MonoBehaviour {
    
    public static DialogueBoxController instance;
    
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject dialogueBox;

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;
    bool skipLineTriggered;
    public void Start() { 
        this.gameObject.SetActive(false);
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }
    public void StartDialogue(string[] dialogue, int startPosition, string name)
    {
        nameText.text = name;
        dialogueBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(RunDialogue(dialogue, startPosition) );
            
    }
    IEnumerator RunDialogue(string[] dialogue, int startPosition)
    {
        skipLineTriggered = false;
        OnDialogueStarted?.Invoke();
        for (int i = startPosition; i < dialogue.Length; i++)
        {
            dialogueText.text = dialogue[i];
            while (!skipLineTriggered)
            {
                yield return null;
            }
            skipLineTriggered = false;
        }
        OnDialogueEnded?.Invoke();
        dialogueBox?.SetActive(false);
    }
    public void SkipLine()
    {
        skipLineTriggered = true;
    }
  /*  public void showDialogue(string dialogue, string name)
    {
        nameText.text = name;
        dialogueText.text = dialogue;
        dialogueBox.SetActive(true);
    }
    public void endDialogue()
    {
        nameText = null;
        dialogueText = null;
        dialogueBox.SetActive(false);
    } */
}

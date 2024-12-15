using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DialogueTree : ScriptableObject
{
    public DialogueSection[] sections;


    [System.Serializable]
    public struct DialogueSection
    {
        public Dialogue[] dialogueContent;
        public bool endAfterDialogue;
        public BranchPoint branchPoint;
    }

    [System.Serializable]
    public struct Dialogue
    {
        [TextArea]
        public string characterName;
        [TextArea]
        public string dialogueText;
    }
    [System.Serializable]
    public struct BranchPoint
    {
        [TextArea]
        public string question;
        public Answer[] answers;
    }

    [System.Serializable]
    public struct Answer
    {
        public string answerLabel;
        public int nextElement;
    }

}
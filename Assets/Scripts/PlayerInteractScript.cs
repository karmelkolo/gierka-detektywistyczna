using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    bool inConvo = false;
    bool inInteract = false;
    InteractChat interactable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inInteract == true)
        {
            Interact();
        }       
    }
    void Interact()
    {

            if (inConvo)
            {
                DialogueBoxControllerMulti.instance.SkipLine();
            }
            else
            {

                DialogueBoxControllerMulti.instance.StartDialogue(interactable.dialogueAsset, interactable.StartPosition);
                
            }

    }
 
    void JoinConversation()
    {
        inConvo = true;
    }
    void LeaveConversation()
    {
        inConvo = false;
    }
    private void OnEnable()
    {
        DialogueBoxControllerMulti.OnDialogueStarted += JoinConversation;
        DialogueBoxControllerMulti.OnDialogueEnded += LeaveConversation;

    }
    private void OnDisable()
    {
        DialogueBoxControllerMulti.OnDialogueStarted -= JoinConversation;
        DialogueBoxControllerMulti.OnDialogueEnded -= LeaveConversation;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        inInteract = true;
        col.gameObject.TryGetComponent(out InteractChat interactable1);
        interactable = interactable1;
       
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        inInteract = false;
        interactable = null;
    }
}

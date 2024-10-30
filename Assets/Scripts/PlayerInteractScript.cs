using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    bool inConvo = false;
    bool inInteract = false;
 /*   void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inInteract == true)
        {
            Interact();
        }       
    }
    void Interact()
    {
        Debug.Log("Interact sie wykonuje");
        
    }
 */
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
        DialogueBoxController.OnDialogueStarted += JoinConversation;
        DialogueBoxController.OnDialogueEnded += LeaveConversation;

    }
    private void OnDisable()
    {
        DialogueBoxController.OnDialogueStarted -= JoinConversation;
        DialogueBoxController.OnDialogueEnded -= LeaveConversation;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (inConvo)
            {
                DialogueBoxController.instance.SkipLine();
            }
            else
            {
                col.gameObject.TryGetComponent(out InteractChat interactable);
                Debug.Log(interactable);
                DialogueBoxController.instance.StartDialogue(interactable.dialogueAsset.dialogue,interactable.StartPosition, interactable.npcName);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        inInteract = false;
    }
}

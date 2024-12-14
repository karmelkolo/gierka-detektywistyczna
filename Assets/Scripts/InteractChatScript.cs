using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChat : MonoBehaviour
{
    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;

    [SerializeField] public DialogueTree dialogueAsset;
    
    [HideInInspector]
    public int StartPosition
    {   
        get
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                return 0;
            }
            else
            {
                return repeatStartPosition;
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dManager;

    public string[] dialogueLines;

    void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Monk")
        {
            if (!dManager.dialogueActive)
            {
                dManager.dialogueLines = dialogueLines;
                dManager.currentLine = 0;
                dManager.ShowDialogue();
            }
        }
    }
}

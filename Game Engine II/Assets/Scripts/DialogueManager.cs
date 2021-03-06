using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBOX;
    public Text dText;

    public bool dialogueActive;
    private bool readEnter;

    public string[] dialogueLines;
    public int currentLine;

    void FixedUpdate()
    {
        if (dialogueActive && readEnter)
        {
            readEnter = false;
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length)
        {
            dBOX.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine];
    }

    public void OnRead(InputAction.CallbackContext context)
    {
        readEnter = context.performed;
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBOX.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBOX.SetActive(true);
    }
}

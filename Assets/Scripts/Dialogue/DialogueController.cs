using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue.DialogueGraph dialogueGraph;
    bool Active = false;

    private void Awake() {
        dialogueGraph.Initialize(this);
    }

    private void Update() {
        if(Active) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                dialogueGraph.TryAnswer(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                dialogueGraph.TryAnswer(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                dialogueGraph.TryAnswer(2);
            }
        }
        
    }

    public void Interact() {
        if(Active) {
            TryAdvance();
        }
        else {
            StartDialogue();
        }
    }

    public void TryAdvance() {
        dialogueGraph.TryAdvance();
    }

    public void StartDialogue() {
        Active = true;
        dialogueGraph.Reset();
    }

    public void EndDialogue() {
        Debug.Log("The NPC turns their attention away from you");
        Active = false;
    }
}

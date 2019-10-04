using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue.DialogueGraph dialogueGraph;

    private void Awake() {
        dialogueGraph.Initialize(this);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            dialogueGraph.TryAnswer(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            dialogueGraph.TryAnswer(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            dialogueGraph.TryAnswer(2);
        }
    }

    public void TryAdvance() {
        dialogueGraph.TryAdvance();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Dialogue.DialogueGraph dialogueGraph;
    public GameObject DialogueDisplayBoxPrefab;
    public Vector3 DialogueBoxPositionOffset;
    bool Active = false;

    DialogueDisplayBox npcTextBox;
    DialogueDisplayBox playerTextBox;

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
    
    public void DisplayNPCText(string text, float displayRate) {

    }

    public DialogueDisplayBox MakeNewDisplayBox() {
        GameObject g = Instantiate(DialogueDisplayBoxPrefab, GlobalCanvas.Instance.transform);

        // set up the tracker component
        UITransformTracker tracker = g.GetComponent<UITransformTracker>();

        tracker.LocalPositionOffset = DialogueBoxPositionOffset;
        tracker.TrackedTransform = transform;

        // return the display box component
        return g.GetComponent<DialogueDisplayBox>();
    }
}

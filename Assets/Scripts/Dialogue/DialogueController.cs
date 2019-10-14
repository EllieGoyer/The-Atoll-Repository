using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour
{
    public Dialogue.DialogueGraph dialogueGraph;
    public GameObject DialogueDisplayBoxPrefab;
    public GameObject ResponsePromptBoxesPrefab;
    public Vector3 DialogueBoxPositionOffset;
    bool Active = false;

    
    DialogueDisplayBox npcTextBox;
    DialogueDisplayBox playerTextBox;
    ResponsePromptBoxes playerResponseBoxes;

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
        RemoveNPCText();
        RemovePlayerText();
        RemovePlayerChoice();
        Active = false;
    }
    
    /// <summary>
    /// make a text box to display some text, return an event that will 
    /// be called when the text finishes displaying
    /// </summary>
    /// <param name="text"></param>
    /// <param name="displayRate"></param>
    /// <returns></returns>
    public UnityEvent DisplayNPCText(string text, float displayRate) {
        if(npcTextBox == null) {
            npcTextBox = MakeNewNPCDisplayBox();
        }

        npcTextBox.DisplayText(text, displayRate);
        return npcTextBox.OnDisplayComplete;
    }
    public void RemoveNPCText() {
        if(npcTextBox != null) {
            Destroy(npcTextBox.gameObject);
        }
    }
    public DialogueDisplayBox MakeNewNPCDisplayBox() {
        GameObject g = Instantiate(DialogueDisplayBoxPrefab, GlobalCanvas.Instance.transform);

        // set up the tracker component
        UITransformTracker tracker = g.GetComponent<UITransformTracker>();

        tracker.LocalPositionOffset = DialogueBoxPositionOffset;
        tracker.TrackedTransform = transform;

        // return the display box component
        return g.GetComponent<DialogueDisplayBox>();
    }

    public void DisplayPlayerText(string text, float displayRate) {
        if(playerTextBox == null) {
            playerTextBox = MakeNewPlayerDisplayBox();
        }

        playerTextBox.DisplayText(text, displayRate);
    }
    public void RemovePlayerText() {
        if (playerTextBox != null) {
            Destroy(playerTextBox.gameObject);
        }
    }
    public DialogueDisplayBox MakeNewPlayerDisplayBox() {
        return PlayerDialogueHandler.Instance.MakeNewDisplayBox();
    }
    public void MakePlayerChoice(string[] choices) {
        playerResponseBoxes = Instantiate(ResponsePromptBoxesPrefab, GlobalCanvas.Instance.transform).GetComponent<ResponsePromptBoxes>();
        UITransformTracker tracker = playerResponseBoxes.GetComponent<UITransformTracker>();

        tracker.LocalPositionOffset = PlayerDialogueHandler.Instance.DialogueBoxPositionOffset;
        tracker.TrackedTransform = PlayerDialogueHandler.Instance.transform;

        UnityEvent[] events = playerResponseBoxes.SetUp(choices);

        // for each onClick event created,
        for(int n = 0; n < choices.Length; n++) {

            // listen for that onClick event to occur, and try the corresponding answer\
            int temp = n;
            events[n].AddListener(delegate {
                dialogueGraph.TryAnswer(temp);
            });
        }
    }
    public void RemovePlayerChoice() {
        if(playerResponseBoxes != null) {
            Destroy(playerResponseBoxes.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour {
    public string CharacterName;
    public Dialogue.DialogueGraph masterDialogueGraph;

    Stack<Dialogue.DialogueGraph> GraphStack;

    [HideInInspector] public Dialogue.DialogueGraph CurrentGraph {
        get {
            if (GraphStack.Count == 0) return null;
            return GraphStack.Peek();
        }
    }

    GameObject DialogueDisplayBoxPrefab;
    GameObject ResponsePromptBoxesPrefab;
    GameObject NametagPrefab;
    public Vector3 DialogueBoxPositionOffset;
    bool Active = false;

    DialogueDisplayBox npcNameTag;
    DialogueDisplayBox npcTextBox;
    DialogueDisplayBox playerTextBox;
    ResponsePromptBoxes playerResponseBoxes;

    Animator playerAnimator;

    private void Awake() {
        DialogueDisplayBoxPrefab = Resources.Load<GameObject>("Dialog_Box");
        ResponsePromptBoxesPrefab = Resources.Load<GameObject>("ResponsePrompts");
        NametagPrefab = Resources.Load<GameObject>("Nametag_Box");
        playerAnimator = World.CURRENT.ActivePlayer.GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (Active) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                CurrentGraph.TryAnswer(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                CurrentGraph.TryAnswer(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                CurrentGraph.TryAnswer(2);
            }
        }

    }

    public void Interact() {
        if (Active) {
            if (!npcTextBox.isBuildingText) {
                TryAdvance();
            }
            else {
                npcTextBox.ForceCompleteText();
            }

        }
        else {
            StartDialogue();
        }
    }

    public void TryAdvance() {

        CurrentGraph.TryAdvance();
    }

    public void OpenGraph(Dialogue.DialogueGraph newGraph) {
        GraphStack.Push(newGraph);
        CurrentGraph.Initialize(this);
        CurrentGraph.Reset();
    }

    public void CloseCurrentGraph() {
        GraphStack.Pop();

        if (CurrentGraph == null) {
            EndDialogue();
        }
        else {
            CurrentGraph.TryAdvance();
        }
    }

    public void StartDialogue() {
        DisplayNameTag();

        GraphStack = new Stack<Dialogue.DialogueGraph>();

        OpenGraph(masterDialogueGraph);

        Active = true;
    }

    public void EndDialogue() {
        RemoveNameTag();
        RemoveNPCText();
        RemovePlayerText();
        RemovePlayerChoice();
        Active = false;
    }


    public void DisplayNameTag() {
        if(npcNameTag == null) {
            GameObject g = Instantiate(NametagPrefab, GlobalCanvas.Instance.transform);

            // set up the tracker component
            UITransformTracker tracker = g.GetComponent<UITransformTracker>();

            tracker.LocalPositionOffset = DialogueBoxPositionOffset;
            tracker.TrackedTransform = transform;

            npcNameTag = g.GetComponent<DialogueDisplayBox>();
        }

        npcNameTag.DisplayText(CharacterName,0.1f);
    }
    public void RemoveNameTag() {
        if (npcNameTag != null) {
            Destroy(npcNameTag.gameObject);
        }

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
                playerAnimator.SetTrigger("Nod");
                CurrentGraph.TryAnswer(temp);
            });
        }
    }
    public void RemovePlayerChoice() {
        if(playerResponseBoxes != null) {
            Destroy(playerResponseBoxes.gameObject);
        }
    }
}

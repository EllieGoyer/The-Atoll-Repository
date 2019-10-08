using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueHandler : MonoBehaviour
{
    public static PlayerDialogueHandler Instance;
    public Vector3 DialogueBoxPositionOffset;
    public GameObject DialogueDisplayBoxPrefab;

    private void Awake() {
        Instance = this;
    }

    public DialogueDisplayBox MakeNewDisplayBox() {
        GameObject g = Instantiate(DialogueDisplayBoxPrefab,GlobalCanvas.Instance.transform);

        // set up the tracker component
        UITransformTracker tracker = g.GetComponent<UITransformTracker>();

        tracker.LocalPositionOffset = DialogueBoxPositionOffset;
        tracker.TrackedTransform = transform;

        // return the display box component
        return g.GetComponent<DialogueDisplayBox>();
    }
}

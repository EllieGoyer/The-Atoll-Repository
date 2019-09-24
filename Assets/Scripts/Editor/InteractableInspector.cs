using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interactable))]
public class InteractableInspector : Editor
{
    Interactable self;

    public override void OnInspectorGUI() {
        self = target as Interactable;

        if(self.GetComponent<Check>() == null)
        {
            EditorGUILayout.HelpBox("Attach Checks as components to set requirements", MessageType.Info);
        }

        base.OnInspectorGUI();
    }
}

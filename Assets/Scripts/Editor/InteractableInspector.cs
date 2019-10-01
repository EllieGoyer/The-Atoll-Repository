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

        self.AutoReset = EditorGUILayout.Toggle(new GUIContent("Auto Reset","Should the interactable return to its idle state after use?"),self.AutoReset);
        if (self.AutoReset) {
            self.ResetCooldownTime = Mathf.Max(0, EditorGUILayout.FloatField(new GUIContent("Reset Cooldown Time", "must be >=0. Set to 0 to reset next frame."), self.ResetCooldownTime));
        }
    }
}

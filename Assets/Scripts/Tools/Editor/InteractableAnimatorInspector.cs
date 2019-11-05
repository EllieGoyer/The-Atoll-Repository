using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractableAnimator))]
public class InteractableAnimatorInspector : Editor
{
    InteractableAnimator self;

    public override void OnInspectorGUI() {
        self = target as InteractableAnimator;

        if (self.renderers == null || self.renderers.Length == 0) {
            EditorGUILayout.HelpBox("Object contains no Renderers! Try hitting \"Setup\"", MessageType.Warning);
        }

        if(GUILayout.Button("Setup")) {
            Undo.RegisterCompleteObjectUndo(self, "Set up InteractableAnimator");

            self.renderers = self.GetComponentsInChildren<Renderer>();
            self.DefaultMaterial = Resources.Load<Material>("EntityDefault");
            if (self.Type == InteractableAnimator.TYPE.Normal) {
                self.ActivatedMaterial = Resources.Load<Material>("EntityOutlinedInteractable");
            }
            else {
                self.ActivatedMaterial = Resources.Load<Material>("EntityOutlinedToy");
            }

            EditorUtility.SetDirty(self);
        }

        base.OnInspectorGUI();
    }
}

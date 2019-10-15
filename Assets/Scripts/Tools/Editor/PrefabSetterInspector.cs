using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefabSetter))]
public class PrefabSetterInspector : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if(GUILayout.Button("Replace all children")) {
            PrefabSetter self = target as PrefabSetter;
            if(self.ReplacementPrefab == null) {
                Debug.LogError("missing replacement prefab!");
                return;
            }

            Undo.SetCurrentGroupName("Replace Children");

            Transform transform = self.transform;
            int count = transform.childCount;
            string Name = self.Name ?? "Child";
            GameObject ReplacementPrefab = self.ReplacementPrefab;

            for (int n = 0; n < count; n++) {
                Transform child = transform.GetChild(0);

                //ReplacementPrefab, child.position, child.rotation, transform
                GameObject replacementObject = PrefabUtility.InstantiatePrefab(ReplacementPrefab, transform) as GameObject;
                Undo.RegisterCreatedObjectUndo(replacementObject, Name + " " + n);

                replacementObject.transform.localPosition = child.localPosition;
                replacementObject.transform.localRotation = child.localRotation;
                
                replacementObject.name = Name + " " + n;

                DestroyImmediate(child.gameObject);
            }

            Undo.CollapseUndoOperations(Undo.GetCurrentGroup());

            EditorUtility.SetDirty(self);
        }
    }
}

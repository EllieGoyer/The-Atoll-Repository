using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerModifyRelationship))]
public class TriggerModifyRelationshipInspector : Editor
{
    TriggerModifyRelationship self;

    public override void OnInspectorGUI() {

        self = target as TriggerModifyRelationship;

        base.OnInspectorGUI();

        // if the scripter chooses any type other than 
        if(self.ModificationType != TriggerModifyRelationship.Type.Unlock) {
            self.amount = EditorGUILayout.IntField("Amount", self.amount);
        }
    }
}

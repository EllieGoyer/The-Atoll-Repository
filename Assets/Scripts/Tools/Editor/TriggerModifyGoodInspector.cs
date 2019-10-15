using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerModifyGood))]
public class TriggerModifyGoodInspector : Editor
{
    TriggerModifyGood self;

    public override void OnInspectorGUI() {

        self = target as TriggerModifyGood;

        base.OnInspectorGUI();

        // should only ask for the amount if our trigger type is of the appropriate type
        if(self.ModificationType != TriggerModifyGood.Type.Unlock) {
            self.amount = EditorGUILayout.IntField("Amount", self.amount);
        }
    }
}

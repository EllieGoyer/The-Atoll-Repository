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

        // if the scripter chooses any type other than 
        if(self.ModificationType != TriggerModifyGood.Type.Unlock) {
            self.amount = EditorGUILayout.IntField("Amount", self.amount);
        }
    }
}

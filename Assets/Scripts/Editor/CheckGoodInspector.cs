using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CheckGood))]
public class CheckGoodInspector : Editor
{
    CheckGood self;

    public override void OnInspectorGUI() {

        self = target as CheckGood;

        base.OnInspectorGUI();

        // should only ask for the amount if our check type is of the appropriate type
        if(self.goodCheckType == CheckGood.Type.GreaterThanOrEqualTo 
            || self.goodCheckType == CheckGood.Type.LessThanOrEqualTo) {
            self.CheckAmount = EditorGUILayout.IntField("Check Amount", self.CheckAmount);
        }
    }
}

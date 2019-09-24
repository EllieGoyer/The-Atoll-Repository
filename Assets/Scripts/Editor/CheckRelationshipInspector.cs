using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CheckRelationship))]
public class CheckRelationshipInspector : Editor
{
    CheckRelationship self;

    public override void OnInspectorGUI() {

        self = target as CheckRelationship;

        base.OnInspectorGUI();

        // should only ask for the amount if our check type is of the appropriate type
        if(self.relationshipCheckType == CheckRelationship.Type.GreaterThanOrEqualTo 
            || self.relationshipCheckType == CheckRelationship.Type.LessThanOrEqualTo) {
            self.CheckAmount = EditorGUILayout.IntField("Check Amount", self.CheckAmount);
        }
    }
}

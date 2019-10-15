using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerBoatTransition))]
public class TriggerBoatInspectorInspector : Editor {
    TriggerBoatTransition self;

    public override void OnInspectorGUI() {

        self = target as TriggerBoatTransition;

        base.OnInspectorGUI();

        // should only ask for the amount if our trigger type is of the appropriate type
        if (self.TransitionType == TriggerBoatTransition.Type.ToLandMode) {
            self.LandSpawnPoint = EditorGUILayout.ObjectField("Land Spawn Point", self.LandSpawnPoint, typeof(Transform), true) as Transform;
        }
    }
}
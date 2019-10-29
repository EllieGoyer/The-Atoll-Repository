using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(World))]
public class WorldInspector : Editor
{
    public override void OnInspectorGUI()
    {
        World world = (World)target;
        world.ActivePlayer = (GameObject)EditorGUILayout.ObjectField("Active Player", world.ActivePlayer, typeof(GameObject), true);
        world.ActiveOcean = (GameObject)EditorGUILayout.ObjectField("Active Ocean", world.ActiveOcean, typeof(GameObject), true);
        world.ActiveCamera = (GameObject)EditorGUILayout.ObjectField("Active Camera", world.ActiveCamera, typeof(GameObject), true);
        serializedObject.FindProperty("activePlayer").objectReferenceValue = world.ActivePlayer;
        serializedObject.FindProperty("activeOcean").objectReferenceValue = world.ActiveOcean;
        serializedObject.FindProperty("activeOceanRenderer").objectReferenceValue = world.ActiveOceanRenderer;
        serializedObject.FindProperty("activeCamera").objectReferenceValue = world.ActiveCamera;
        serializedObject.FindProperty("activeCameraFollow").objectReferenceValue = world.ActiveCameraFollow;
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
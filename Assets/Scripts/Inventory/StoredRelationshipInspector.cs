using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//uses example code from https://docs.unity3d.com/ScriptReference/PropertyDrawer.html

[CustomPropertyDrawer(typeof(StoredRelationship))]
public class StoredRelationshipInspector : PropertyDrawer
{
    readonly int RECT_OFFSET = 80;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var relationshipRect = new Rect(position.x, position.y, RECT_OFFSET, position.height);
        var amountRect = new Rect(position.x + RECT_OFFSET + 10, position.y, position.width - RECT_OFFSET - 10, position.height);

        EditorGUI.PropertyField(relationshipRect, property.FindPropertyRelative("relationship"), GUIContent.none);
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

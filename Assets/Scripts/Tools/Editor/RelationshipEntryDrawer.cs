using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(RelationshipEntry))]
public class RelationshipEntryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);

        //EditorStyles.textField.wordWrap = true;

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // calculate rects
        var RelationshipRect = new Rect(position.x, position.y, position.width, position.height/4);
        var TextRect = new Rect(position.x, position.y + position.height/4, position.width, 3 * position.height / 4);

        // draw fields
        EditorGUI.PropertyField(RelationshipRect, property.FindPropertyRelative("target"), GUIContent.none);
        EditorGUI.PropertyField(TextRect, property.FindPropertyRelative("text"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return base.GetPropertyHeight(property, label) * 4;
    }
}

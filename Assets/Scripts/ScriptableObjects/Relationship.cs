using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Relationship", menuName = "ScriptableObject/New Relationship")]
public class Relationship : NotebookItem {
    public static int MAX_VALUE = 100;
    public static int MIN_VALUE = 0;
    public static int ClampValue(int value) {
        return Mathf.Clamp(value, MIN_VALUE, MAX_VALUE);
    }
}

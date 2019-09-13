﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Relationship", menuName = "ScriptableObject/New Relationship")]
public class Relationship : NotebookItem {
    public static float MAX_VALUE = 1;
    public static float MIN_VALUE = 0;
    public static float ClampValue(float value) {
        return Mathf.Clamp(value, MIN_VALUE, MAX_VALUE);
    }
}

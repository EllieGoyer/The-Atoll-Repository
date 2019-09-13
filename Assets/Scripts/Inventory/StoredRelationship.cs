using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoredRelationship
{
    [Tooltip(tooltip: "Drag in a Relationship from Assets/Notebook Items/Relationships")]
    public Relationship relationship;
    public float value;

    public StoredRelationship(Relationship _relationship, float _value = 0.5f) {
        relationship = _relationship;
        value = _value;
    }
}

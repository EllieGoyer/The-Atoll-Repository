using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoredRelationship
{
    [Tooltip(tooltip: "Drag in a Relationship from Assets/Notebook Items/Relationships")]
    public Relationship relationship;
    public int amount;

    public StoredRelationship(Relationship _relationship, int _amount = 50) {
        relationship = _relationship;
        amount = _amount;
    }
}

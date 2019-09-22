using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerModifyRelationship : Trigger {
    
    public enum Type { Unlock, SetAmount, AddAmount, SubtractAmount };
    public Relationship relationship;
    [Tooltip(tooltip: "Select what type of action to perform for this relationship")]
    public Type ModificationType;
    [HideInInspector] public int amount;

    protected override void Perform() {
        switch(ModificationType) {
            case Type.Unlock:
                Inventory.Instance.UnlockRelationship(relationship);
                break;
            case Type.SetAmount:
                Inventory.Instance.SetRelationshipAmount(relationship, amount);
                break;
            case Type.AddAmount:
                Inventory.Instance.AddRelationshipAmount(relationship, amount);
                break;
            case Type.SubtractAmount:
                Inventory.Instance.SubtractRelationshipAmount(relationship, amount);
                break;
        }
    }
}

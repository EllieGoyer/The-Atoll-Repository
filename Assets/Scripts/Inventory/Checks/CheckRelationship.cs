using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckRelationship : Check
{
    public enum Type { Unlocked, NotUnlocked, GreaterThanOrEqualTo, LessThanOrEqualTo }
    public Relationship relationship;
    public Type relationshipCheckType;
    [HideInInspector] public int CheckAmount;

    public override bool Perform() {
        int? amount = Inventory.Instance.CheckRelationship(relationship);

        if(relationshipCheckType == Type.Unlocked) {
            return (amount != null);
        }
        else if(relationshipCheckType == Type.NotUnlocked) {
            return (amount == null);
        }
        if (relationshipCheckType == Type.GreaterThanOrEqualTo) {
            return (amount != null && amount >= CheckAmount);
        }
        else {// if(relationshipCheckType == Type.LessThanOrEqualTo) {
            return (amount == null || amount <= CheckAmount);
        }
    }

}

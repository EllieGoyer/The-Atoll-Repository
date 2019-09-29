using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckGood : Check
{
    public enum Type { Unlocked, NotUnlocked, GreaterThanOrEqualTo, LessThanOrEqualTo }
    public Good good;
    public Type goodCheckType;
    [HideInInspector] public int CheckAmount;

    public override bool Perform() {
        int? amount = Inventory.Instance.CheckGood(good);

        if(goodCheckType == Type.Unlocked) {
            return (amount == null);
        }
        else if(goodCheckType == Type.NotUnlocked) {
            return (amount != null);
        }
        if (goodCheckType == Type.GreaterThanOrEqualTo) {
            return (amount != null && amount >= CheckAmount);
        }
        else {// if(goodCheckType == Type.LessThanOrEqualTo) {
            return (amount == null || amount <= CheckAmount);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerModifyCollectable : Trigger
{
    public enum Type { Unlock };
    public Collectable collectable;
    [Tooltip(tooltip: "Select what type of action to perform for this collectable")]
    public Type ModificationType;
    protected override void Perform() {
        switch(ModificationType) {
            case Type.Unlock:
                Inventory.Instance.UnlockCollectable(collectable);
                break;
        }
    }
}

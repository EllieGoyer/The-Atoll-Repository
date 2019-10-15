using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckCollectable : Check {

    public enum Type { Has, DoesNotHave };
    public Collectable collectable;
    public Type collectableCheckType;

    public override bool Perform() {
        if (collectableCheckType == Type.Has) return Inventory.Instance.CheckCollectable(collectable);

        //else if( collectableCheckType == Type.DoesNotHave )
        return !Inventory.Instance.CheckCollectable(collectable);
    }
}
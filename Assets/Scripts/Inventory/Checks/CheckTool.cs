using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckTool : Check {

    public enum Type { Has, DoesNotHave };
    public Type toolCheckType;
    public Tool tool;

    public override bool Perform() {
        if(toolCheckType == Type.Has) return Inventory.Instance.CheckTool(tool);

        //else if( toolCheckType == Type.DoesNotHave )
        return !Inventory.Instance.CheckTool(tool);
    }
}

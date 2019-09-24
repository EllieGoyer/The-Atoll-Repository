using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerModifyTool : Trigger
{
    public enum Type { Unlock };
    public Tool tool;
    [Tooltip(tooltip: "Select what type of action to perform for this tool")]
    public Type ModificationType;
    protected override void Perform() {
        switch(ModificationType) {
            case Type.Unlock:
                Inventory.Instance.UnlockTool(tool);
                break;
        }
    }
}

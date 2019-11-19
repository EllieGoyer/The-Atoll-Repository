using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class TriggerModifyToolNode : TriggerNode {
        public enum Type { Unlock };
        public Tool tool;
        [Tooltip(tooltip: "Select what type of action to perform for this tool")]
        public Type ModificationType;
        public override void Perform() {
            switch (ModificationType) {
                case Type.Unlock:
                    Inventory.Instance.UnlockTool(tool);
                    break;
            }
        }
    }
}
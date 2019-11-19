using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class CheckToolNode : CheckNode {

        public enum Type { Has, DoesNotHave };
        public Tool tool;
        public Type toolCheckType;

        public override bool Perform() {
            if (toolCheckType == Type.Has) return Inventory.Instance.CheckTool(tool);

            //else if( toolCheckType == Type.DoesNotHave )
            return !Inventory.Instance.CheckTool(tool);
        }
    }
}
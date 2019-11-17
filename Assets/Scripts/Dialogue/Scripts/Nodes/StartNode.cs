using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FFFFFF")]
    public class StartNode : Node {
        [Output] public DialogueFlowNode startNode;

        public DialogueFlowNode GetStartingFlowNode() {
            return GetOutputPort("startNode").Connection.node as DialogueFlowNode;
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}

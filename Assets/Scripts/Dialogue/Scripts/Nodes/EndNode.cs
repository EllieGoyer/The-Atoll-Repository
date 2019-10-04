using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("FFFFFF")]
    public class EndNode : DialogueFlowNode {
        [Input] public DialogueFlowNode input;

        public override DialogueFlowNode OnEnter() {
            DialogueGraph dgraph = graph as DialogueGraph;

            Debug.Log("The NPC turns their attention away from you");

            dgraph.Reset();

            return null;
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}

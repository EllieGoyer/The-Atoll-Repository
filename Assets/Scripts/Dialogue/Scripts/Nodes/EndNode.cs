using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("FFFFFF")]
    public class EndNode : DialogueFlowNode {

        public override DialogueFlowNode OnEnter() {
            DialogueGraph dgraph = graph as DialogueGraph;

            dgraph.dialogueController.EndDialogue();

            return null;
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}

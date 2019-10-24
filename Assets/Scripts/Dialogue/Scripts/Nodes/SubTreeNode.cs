using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FFFF00")]
    public class SubTreeNode : DialogueFlowNode {
        [Output] public DialogueFlowNode nextNode;

        public DialogueGraph SubGraph;

        public override DialogueFlowNode Advance() {
            return GetOutputPort("nextNode").Connection.node as DialogueFlowNode;

        }

        public override DialogueFlowNode OnEnter() {
            DialogueGraph dgraph = graph as DialogueGraph;

            dgraph.dialogueController.OpenGraph(SubGraph);

            return null;
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}

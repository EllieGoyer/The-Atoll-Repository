using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FF80FF")]
    public abstract class TriggerNode : DialogueFlowNode{
        [Output] public DialogueFlowNode Output;

        public override DialogueFlowNode OnEnter() {
            Perform();
            return GetOutputPort("Output").Connection.node as DialogueFlowNode;
        }

        public override object GetValue(NodePort port) {
            Perform();
            return null;
        }

        public abstract void Perform();
    }
}
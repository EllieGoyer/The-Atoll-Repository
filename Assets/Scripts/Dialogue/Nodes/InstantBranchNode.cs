using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FFCCFF")]
    public class InstantBranchNode : DialogueFlowNode {

        [Input(dynamicPortList = true)] public CheckNode[] Checks;

        [Output] public DialogueFlowNode PassPath;
        [Output] public DialogueFlowNode FailPath;

        public override DialogueFlowNode OnEnter() {

            for (int n = 0; n < Checks.Length; n++) {
                CheckNode check = GetInputPort("Checks " + n).Connection.node as CheckNode;
                if (!check.Perform()) {
                    return GetOutputPort("FailPath").Connection.node as DialogueFlowNode;
                }
            }

            return GetOutputPort("PassPath").Connection.node as DialogueFlowNode;
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#CCFFFF")]
    public class QuestionBranchNode : SegmentNode {
        [TextArea] public string promptText;
        [Input(dynamicPortList = true)] public CheckNode[] Checks;

        public bool CanTakeBranch() {
            for (int n = 0; n < Checks.Length; n++) {
                CheckNode check = GetInputPort("Checks " + n).Connection.node as CheckNode;

                if (!check.Perform()) return false;
            }

            return true;
        }

        public override object GetValue(NodePort port) {
            return CanTakeBranch();
        }

        public override void DisplayText() {
            Debug.Log("You: " + text);
        }
    }
}
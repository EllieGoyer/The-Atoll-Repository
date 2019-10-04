using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#CCFFCC")]
    public class SegmentNode : TextNode {
        [Output] public DialogueFlowNode nextNode;

        public override DialogueFlowNode Advance() {
            return GetOutputPort("nextNode").Connection.node as DialogueFlowNode;
        }
    }
}
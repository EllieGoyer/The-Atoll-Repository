using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FFFFCC")]
    public class PlayerSegmentNode : SegmentNode {
        public override void DisplayText() {
            DialogueGraph dgraph = graph as DialogueGraph;
            
            dgraph.dialogueController.DisplayPlayerText(text, displayRate);
        }
    }
}
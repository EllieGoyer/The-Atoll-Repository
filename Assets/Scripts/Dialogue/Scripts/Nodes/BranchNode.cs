using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#CCFFCC")]
    public class BranchNode : TextNode {
        [TextArea] public string promptText;

        public bool isEnabled;
        [Output] public DialogueFlowNode nextNode;
        public bool CanTakeBranch() {
            return isEnabled;
        }
    }
}
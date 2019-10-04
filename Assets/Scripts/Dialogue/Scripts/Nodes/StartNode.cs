using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class StartNode : Node {
        [Output] public DialogueFlowNode startNode;

        public DialogueFlowNode GetStartingFlowNode() {
            return startNode;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FF8888")]
    public abstract class CheckNode : Node {
        [Output] public QuestionBranchNode branch;

        public override object GetValue(NodePort port) {
            return Perform();
        }

        public abstract bool Perform();

        
    }
}
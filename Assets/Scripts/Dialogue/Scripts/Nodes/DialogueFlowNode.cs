using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue { 
    public abstract class DialogueFlowNode : Node {

        [Input] public DialogueFlowNode previousNode;

        /// <summary>
        /// called when this node is set as the new active node
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// returns a dialogueflownode to go to when the conversation should advance,
        /// OR nothing if the input should be ignored.
        /// </summary>
        /// <returns></returns>
        public virtual DialogueFlowNode Advance() {
            return null;
        }
        /// <summary>
        /// returns a dialogueflownode to go to when the answer is taken,
        /// OR nothing if the input should be ignored.
        /// </summary>
        /// <returns></returns>
        public virtual DialogueFlowNode Answer(int answerNumber) {
            return null;
        }
    }
}

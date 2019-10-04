using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/Graph", order = 0)]
    public class DialogueController : NodeGraph {
        [HideInInspector]
        public DialogueFlowNode current;

        public void Initialize() {
            // Find our start node
            StartNode startNode = nodes.Find(x => x is StartNode) as StartNode;

            // Set our current node to the start node's output
            current = startNode.GetStartingFlowNode();
        }

        public void PerformCurrent() {
            current.OnEnter();
        }

        public void TryAdvance() {
            DialogueFlowNode nextNode = current.Advance();
            if(nextNode != null) {
                current = nextNode;
                PerformCurrent();
            }
        }

        public void TryAnswer(int answerNumber) {
            DialogueFlowNode nextNode = current.Answer(answerNumber);
            if(nextNode != null) {
                current = nextNode;
                PerformCurrent();
            }
        }
    }
}
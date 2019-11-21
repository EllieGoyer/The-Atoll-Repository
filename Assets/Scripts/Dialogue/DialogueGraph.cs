using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/Graph", order = 0)]
    public class DialogueGraph : NodeGraph {
        [HideInInspector]
        public DialogueFlowNode current;
        public DialogueController dialogueController;
        public bool Active;

        public void Initialize(DialogueController _dialogueController) {
            dialogueController = _dialogueController;
        }

        public void Reset() {
            // Find our start node
            StartNode startNode = nodes.Find(x => x is StartNode) as StartNode;

            // Set our current node to the start node's output
            current = startNode.GetStartingFlowNode();
            PerformCurrent();
        }

        public void PerformCurrent() {
            DialogueFlowNode nextNode = current.OnEnter();
            if(nextNode != null) {
                current = nextNode;
                PerformCurrent();
            }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#CCFFFF")]
    public class QuestionNode : TextNode {
        static int MAX_ANSWERS = 3;

        [Output(dynamicPortList = true)] public QuestionBranchNode[] Branches;
        private QuestionBranchNode[] ActiveBranches;
        private int activeBranchCount;

        public override DialogueFlowNode OnEnter() {
            DialogueFlowNode d = base.OnEnter();

            SetupBranches();

            DisplayActiveBranches();

            return d;
        }

        /// <summary>
        /// create our array of possible answers
        /// </summary>
        public void SetupBranches() {
            ActiveBranches = new QuestionBranchNode[MAX_ANSWERS];
            activeBranchCount = 0;

            // for each possible branch...
            for(int n = 0; n < Branches.Length; n++) {
                QuestionBranchNode branch = GetOutputPort("Branches " + n).Connection.node as QuestionBranchNode;
                // if our checks pass
                if (branch.CanTakeBranch()) {

                    // add this to our list of active branches
                    ActiveBranches[activeBranchCount] = branch;
                    activeBranchCount += 1;

                    // if we hit the max amount we can have active at once
                    if(activeBranchCount >= MAX_ANSWERS) {
                        // ignore the rest of our branches
                        break;
                    }
                }
            }

            if(activeBranchCount == 0) {
                Debug.LogError("No valid branches from dialogue question node!!!");
            }
        }

        public void DisplayActiveBranches() {
            for(int n = 0; n < activeBranchCount; n++) {
                Debug.Log((n + 1) + ": " + ActiveBranches[n].promptText);
            }
        }

        public override DialogueFlowNode Answer(int answerNumber) {
            if (answerNumber >= activeBranchCount) return null;

            return ActiveBranches[answerNumber];
        }
    }
}
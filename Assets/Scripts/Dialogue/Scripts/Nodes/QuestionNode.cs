using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.Events;

namespace Dialogue {
    [NodeTint("#CCFFFF")]
    public class QuestionNode : TextNode {
        static int MAX_ANSWERS = 3;

        [Output(dynamicPortList = true)] public QuestionBranchNode[] Branches;
        private QuestionBranchNode[] ActiveBranches;
        private int activeBranchCount;

        public override DialogueFlowNode OnEnter() {
            SetupBranches();

            return base.OnEnter();
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
        
        public string[] GetBranchesAsStrings() {
            string[] texts = new string[activeBranchCount];
            for (int n = 0; n < activeBranchCount; n++) {
                texts[n] = ActiveBranches[n].promptText;
            }
            return texts;
        }

        public override DialogueFlowNode Answer(int answerNumber) {
            if (answerNumber >= activeBranchCount) return null;

            return ActiveBranches[answerNumber];
        }

        public override void DisplayText() {
            DialogueGraph dgraph = graph as DialogueGraph;

            dgraph.dialogueController.RemovePlayerText();

            UnityEvent onFinished = dgraph.dialogueController.DisplayNPCText(text, displayRate);
            
            onFinished.AddListener(delegate {
                dgraph.dialogueController.MakePlayerChoice(GetBranchesAsStrings());
            });
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#CCFFFF")]
    public class QuestionNode : TextNode {
        static int MAX_ANSWERS = 3;

        [Output(dynamicPortList = true)] public BranchNode[] Branches;
        private BranchNode[] ActiveBranches;
        private int activeBranchCount;

        public override void OnEnter() {
            base.OnEnter();
            
            SetupBranches();

            DisplayActiveBranches();
        }

        /// <summary>
        /// create our array of possible answers
        /// </summary>
        public void SetupBranches() {
            ActiveBranches = new BranchNode[MAX_ANSWERS];
            activeBranchCount = 0;

            // for each possible branch...
            foreach(BranchNode branch in Branches) {

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
                Debug.Log(n + ": " + ActiveBranches[n].promptText);
            }
        }
    }
}
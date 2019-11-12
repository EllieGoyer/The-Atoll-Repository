using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class TriggerNotebookEntryNode: TriggerNode {
        public Relationship relationship;
        public string text;
        public override void Perform() {
            Debug.Log("dummy added " + relationship + "notebook text: " + text);
        }
    }
}
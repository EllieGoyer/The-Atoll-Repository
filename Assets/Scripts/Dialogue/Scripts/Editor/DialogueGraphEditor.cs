using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using XNodeEditor;

namespace DialogueEditor {
	[CustomNodeGraphEditor(typeof(DialogueGraph))]
	public class DialogueGraphEditor : NodeGraphEditor {
		
		public override string GetNodeMenuName(System.Type type) {
            if (type.Namespace == "Dialogue") {
                string s = base.GetNodeMenuName(type).Replace("Dialogue/", "");

                if(type.IsSubclassOf(typeof(CheckNode))) {
                    s = "Check/" + s;
                }
                else if(type.IsSubclassOf(typeof(TriggerNode))) {
                    s = "Trigger/" + s;
                }

                return s;
            }
            else return null;
		}
	}
}
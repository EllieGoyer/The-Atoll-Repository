using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public abstract class TextNode : DialogueFlowNode {
        [TextArea] public string text;
        public float displayRate = 0.1f;

        public override void OnEnter() {
            DisplayText();
            base.OnEnter();
        }

        public void DisplayText() {
            Debug.Log("TEXTNODE: " + text);
        }
    }
}
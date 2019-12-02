using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [NodeTint("#FFFFFF")]
    public class NoteNode : Node {
        [TextArea(minLines:12,maxLines:12)] public string Note;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class TriggerModifyCollectableNode : TriggerNode {
        public enum Type { Unlock, Lock };
        public Collectable collectable;
        [Tooltip(tooltip: "Select what type of action to perform for this collectable")]
        public Type ModificationType;
        public override void Perform() {
            switch (ModificationType) {
                case Type.Unlock:
                    Inventory.Instance.UnlockCollectable(collectable);
                    break;
                case Type.Lock:
                    Inventory.Instance.LockCollectable(collectable);
                    break;
            }
        }
    }
}
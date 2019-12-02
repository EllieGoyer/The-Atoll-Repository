using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class CheckCollectableNode : CheckNode {
        public enum Type { Has, DoesNotHave };
        public Collectable collectable;
        public Type collectableCheckType;

        public override bool Perform() {
            if (collectableCheckType == Type.Has) return Inventory.Instance.CheckCollectable(collectable);

            //else if( collectableCheckType == Type.DoesNotHave )
            return !Inventory.Instance.CheckCollectable(collectable);
        }
    }
}
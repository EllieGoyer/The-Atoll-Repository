using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class TriggerModifyGoodNode : TriggerNode {
        public enum Type { Unlock, SetAmount, AddAmount, SubtractAmount };
        public Good good;
        [Tooltip(tooltip: "Select what type of action to perform for this good")]
        public Type ModificationType;
        public int amount;

        public override void Perform() {
            switch (ModificationType) {
                case Type.Unlock:
                    Inventory.Instance.UnlockGood(good);
                    break;
                case Type.SetAmount:
                    Inventory.Instance.SetGoodAmount(good, amount);
                    break;
                case Type.AddAmount:
                    Inventory.Instance.AddGoodAmount(good, amount);
                    break;
                case Type.SubtractAmount:
                    Inventory.Instance.SubtractGoodAmount(good, amount);
                    break;
            }
        }
    }
}
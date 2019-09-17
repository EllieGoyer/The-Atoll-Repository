using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoredGood
{
    [Tooltip(tooltip:"Drag in a Good from Assets/Notebook Items/Goods")]
    public Good good;
    [Min(min:0)]
    public int amount;

    public StoredGood(Good _good, int _amount = 0) {
        good = _good;
        amount = _amount;
    }
}

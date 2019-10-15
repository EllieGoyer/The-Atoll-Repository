using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInventoryDisplay : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        UpdateDisplayText();
    }
    
    public void UpdateDisplayText() {
        text.text = Inventory.Instance.DebugString();
    }
}

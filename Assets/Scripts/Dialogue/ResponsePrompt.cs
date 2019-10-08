using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsePrompt : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public TMPro.TextMeshProUGUI textObj;

    public UnityEngine.Events.UnityEvent SetUp(string text) {
        textObj.text = text;
        return button.onClick;
    }
}

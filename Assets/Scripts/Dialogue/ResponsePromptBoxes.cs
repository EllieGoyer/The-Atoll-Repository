using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResponsePromptBoxes : MonoBehaviour
{
    public GameObject ResponsePromptPrefab;
    public float PromptVerticalOffset;

    /// <summary>
    /// make a text box for each response, add text to it, return a list of the OnClickEvents
    /// </summary>
    /// <param name="promptTexts"></param>
    /// <returns></returns>
    public UnityEvent[] SetUp(string[] promptTexts) {
        int count = promptTexts.Length;

        UnityEvent[] eventArray = new UnityEvent[count];
        for(int n = count - 1; n >= 0; n--) {
            GameObject promptObj = Instantiate(ResponsePromptPrefab, transform);
            float offset = PromptVerticalOffset * (count - 1 - n);
            promptObj.GetComponent<RectTransform>().localPosition = new Vector3(0, offset, 0);

            eventArray[n] = promptObj.GetComponent<ResponsePrompt>().SetUp(promptTexts[n]);
        }


        return eventArray;
    }
}

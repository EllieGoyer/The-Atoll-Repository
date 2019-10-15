using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.StateGraph;
using TMPro;
using UnityEngine.Events;

public class DialogueDisplayBox : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnDisplayComplete;
    public TextMeshProUGUI textComponent;
    string text;
    float characterInsertDelay;
    [HideInInspector] IEnumerator textBuilder;

    public bool isBuildingText = false;
    
    public void DisplayText(string _text, float _characterInsertDelay) {
        text = _text;
        characterInsertDelay = _characterInsertDelay;
        if(!isBuildingText)
        {
            StartCoroutine("BuildText");

        }
        else
        {
            StopCoroutine("BuildText");
        }
        isBuildingText = !isBuildingText;
       



    }

    public void ForceCompleteText() {

        StopCoroutine("BuildText");
        isBuildingText = false;
        textComponent.text = text;
        OnDisplayComplete.Invoke();
    }

    private IEnumerator BuildText()
    {
     //   isBuildingText = true;
        textComponent.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textComponent.text = textComponent.text + text[i];
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSecondsRealtime(characterInsertDelay);
        }
        OnDisplayComplete.Invoke();
       /// isBuildingText = false;
    }
}

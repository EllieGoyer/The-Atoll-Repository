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
    Coroutine buildTextRoutine;

    public bool isBuildingText = false;
    
    public void DisplayText(string _text, float _characterInsertDelay) {
        text = _text;
        characterInsertDelay = _characterInsertDelay;
        if(!isBuildingText)
        {
            buildTextRoutine = StartCoroutine("BuildText");
            isBuildingText = true;
        }
        else
        {
            ForceCompleteText();
        }
       
    }

    public void ForceCompleteText() {

        StopCoroutine(buildTextRoutine);
        isBuildingText = false;
        textComponent.text = text;
        OnDisplayComplete.Invoke();
    }

    private IEnumerator BuildText()
    {
        textComponent.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textComponent.text = textComponent.text + text[i];
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSecondsRealtime(characterInsertDelay);
        }
        OnDisplayComplete.Invoke();
        isBuildingText = false;
    }
}

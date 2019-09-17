using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.StateGraph;

public class DisText : MonoBehaviour
{
    public TextMesh textComponent;
    public string text;
    public float timeLapse;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BuildText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textComponent.text = textComponent.text + text[i];
            print(text[i]);
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSecondsRealtime(timeLapse);
        }
    }
}

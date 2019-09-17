using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.StateGraph;

public class NPC : MonoBehaviour
{

    private static int trust;
    private static int speakingSpeed;

    StateGraph sg;

    private TextMesh text_tap;

    // Start is called before the first frame update
    void Start()
    {
        text_tap = GameObject.Find("text").GetComponent<TextMesh>();
        sg = (StateGraph) Resources.Load("New State Graph");//GameObject.Find("New State Graph").GetComponent<StateGraph>()
       
        text_tap.text = sg.current.text;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            text_tap.text = sg.current.text;
            sg.Continue();

        }
    }
}

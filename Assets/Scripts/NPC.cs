using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private static int trust;
    private static int speakingSpeed;

    private string text = "Hey There!";

    private TextMesh text_tap;

    // Start is called before the first frame update
    void Start()
    {
        text_tap = GameObject.Find("text").GetComponent<TextMesh>();
        text_tap.gameObject.SetActive(false);
        text_tap.text = text;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            text_tap.gameObject.SetActive(true);
        }
    }
}

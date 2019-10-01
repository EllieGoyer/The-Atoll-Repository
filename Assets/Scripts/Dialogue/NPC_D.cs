using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dialogue;


public class NPC_D : MonoBehaviour
{

    private static int trust;
    private static int speakingSpeed;

    Dialogue.DialogueGraph sg;

    bool startCou;

    private TextMeshProUGUI text_tap;

    private string Itext;



    // Start is called before the first frame update
    void Start()
    {
        text_tap = GameObject.Find("Dialog_Text").GetComponent<TextMeshProUGUI>();
        sg = (DialogueGraph) Resources.Load("NPC_DT");
        sg.Restart();
        print(sg.current);
        text_tap.text = sg.current.text;

    }

    public void AdvanceDialog() {

        sg.AnswerQuestion(0);
        Itext = sg.current.text;

        if (!startCou) {
            StartCoroutine("BuildText");
        }
        else {
            StopCoroutine("BuildText");
        }

        startCou = !startCou;
    }

    private IEnumerator BuildText()
    {
        text_tap.text = "";
        for (int i = 0; i < sg.current.text.Length; i++)
        {
            text_tap.text = text_tap.text + Itext[i];

            yield return new WaitForSecondsRealtime(.5f);
            
        }
    }
}

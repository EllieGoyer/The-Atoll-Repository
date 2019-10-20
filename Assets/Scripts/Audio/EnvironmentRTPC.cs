using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentRTPC : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
   // {
        
    //}

    // Update is called once per frame

    float t = 0;
    float value;
    public int duration;
    public string GameParameter;
    public int start;
    public int end;

    public void RtpcSet()
    {
        void Update()
        {
            t += Time.deltaTime / duration;
            value = Mathf.Lerp(start, end, t);

            AkSoundEngine.SetRTPCValue(GameParameter, value);
        }
    }
}


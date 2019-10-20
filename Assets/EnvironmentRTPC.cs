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
    public string GameParameter;
    public int start;
    public int end;
    void Update()
    {
        t += Time.deltaTime / 3;
       value = Mathf.Lerp(start, end, t);

        AkSoundEngine.SetRTPCValue(GameParameter, value);
    }
}

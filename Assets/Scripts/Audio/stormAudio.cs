using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stormAudio : MonoBehaviour
{
    //set your RTPCID to the name of your desired gameparameter (under GameSyncs)
    public string Storm;
    
    private float value;
    [Range(0, 100)]
    public float valueSlider;

    // Update is called once per frame
    void Update()
    {

        // RTPCValue_type.RTPCValue_Global
        // for whatever reason, this constant isn't exposed by name by WWise C#/Unity headers
        int type = 1;

        // will contain the value of the RTPC parameter after the GetRTPCValue call
        
        float value = valueSlider;

        AkSoundEngine.SetRTPCValue(Storm, value);

        if (value < 30)
        {   //Need delay timer set, probability at 50% set in wwise 
            //AkSoundEngine.PostEvent("Sea_Oneshot", gameObject);
        }

    }
}

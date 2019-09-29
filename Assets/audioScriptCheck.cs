using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScriptCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("pop_hit", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

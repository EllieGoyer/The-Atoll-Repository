using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingAudio : AudioInteractable
{
    public float Period = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Play", 0, Period);
    }
}

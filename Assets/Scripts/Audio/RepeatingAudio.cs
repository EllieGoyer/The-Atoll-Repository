using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingAudio : AudioInteractable
{
    public float MinPeriod = 0.5F;
    public float MaxPeriod = 3.0F;



    // Start is called before the first frame update
    void Start()
    {
        PlayRepeatingRandom();
    }

    void PlayRepeatingRandom()
    {
        Debug.Log("Play");
        Play();
        Invoke("PlayRepeatingRandom", Random.Range(MinPeriod, MaxPeriod));
    }
}

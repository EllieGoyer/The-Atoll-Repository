using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractable : MonoBehaviour
{
    public AK.Wwise.Event AudioEvent;

    public void Play()
    {
        AudioEvent.Post(gameObject);
    }
}

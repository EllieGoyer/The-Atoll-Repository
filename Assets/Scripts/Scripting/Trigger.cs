using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [Tooltip(tooltip:"Time to wait in seconds after triggered before performing")]public float Delay = 0;
    public void DoTrigger() {
        if(Delay <= 0) {
            // if there isn't any sort of delay, trigger the action right now
            Perform();
        }
        else {
            // if there is some delay, start a coroutine to wait for the delay THEN trigger
            StartCoroutine(PerformDelayed());
        }
    }
    IEnumerator PerformDelayed() {
        yield return new WaitForSeconds(Delay);
        Perform();
    }
    protected abstract void Perform();
}

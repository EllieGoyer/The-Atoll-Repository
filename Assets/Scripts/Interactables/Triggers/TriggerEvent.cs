using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : Trigger
{
    public UnityEvent OnTrigger;

    protected override void Perform() {
        OnTrigger.Invoke();
    }
}

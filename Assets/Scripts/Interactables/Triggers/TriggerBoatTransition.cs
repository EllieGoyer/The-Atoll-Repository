using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoatTransition : Trigger {

    public enum Type { ToOceanMode, ToLandMode }
    public Type TransitionType;

    [HideInInspector] public Transform LandSpawnPoint;

    protected override void Perform() {
        if(TransitionType == Type.ToOceanMode) {
            BoatTransitionHandler.Instance.EnterOceanMode();
        }
        else { //if(TransitionType == Type.ToLandMode) {
            BoatTransitionHandler.Instance.EnterLandMode(LandSpawnPoint);
        }
    }
}

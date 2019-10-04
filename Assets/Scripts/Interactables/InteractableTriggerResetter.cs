using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTriggerResetter : MonoBehaviour
{
    CharacterController CC;

    private void Awake() {
        CC = GetComponent<CharacterController>();
    }

    public void FixTouchedInteractables() {
        Collider[] touches = SimpleOverlap(CC.transform.position);
        foreach( Collider collider in touches) {
            
            //if this isn't a trigger, it isn't an interactable so ignore
            if (!collider.isTrigger) continue;

            // if this doesn't have an attached interactable, ignore
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable == null) continue;

            interactable.ResetTrigger();
        }
    }

    public Collider[] SimpleOverlap(Vector3 position) {
        Vector3 p1 = position + CC.center + Vector3.down * (CC.height * .5f - CC.radius);
        Vector3 p2 = p1 + CC.transform.rotation * Vector3.up * (CC.height - CC.radius * 2);
        return Physics.OverlapCapsule(p1, p2, CC.radius);
    }
}

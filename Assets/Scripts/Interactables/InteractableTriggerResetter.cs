using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTriggerResetter : MonoBehaviour
{
    new public Collider collider;

    public void FixTouchedInteractables() {
        Collider[] touches = SimpleOverlap(collider.transform.position);
        foreach( Collider c in touches) {
            
            //if this isn't a trigger, it isn't an interactable so ignore
            if (!c.isTrigger) continue;

            // if this doesn't have an attached interactable, ignore
            Interactable interactable = c.GetComponent<Interactable>();
            if (interactable == null) continue;

            interactable.ResetTrigger();
        }
    }

    public Collider[] SimpleOverlap(Vector3 position) {
        if (collider.GetType() == typeof(CharacterController)) {
            CharacterController CC = collider as CharacterController;
            Vector3 p1 = position + CC.center + Vector3.down * (CC.height * .5f - CC.radius);
            Vector3 p2 = p1 + CC.transform.rotation * Vector3.up * (CC.height - CC.radius * 2);
            return Physics.OverlapCapsule(p1, p2, CC.radius);
        }
        else if(collider.GetType() == typeof(BoxCollider)) {
            BoxCollider BC = collider as BoxCollider;
            return Physics.OverlapBox(BC.center + BC.transform.position, BC.size, BC.transform.rotation);
        }
        else {
            Debug.LogError("InteractableTriggerResetter collider of invalid type");
            return null;
        }

        
    }
}

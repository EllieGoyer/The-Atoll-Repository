using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableAnimator))]
public class ShipGlow : MonoBehaviour
{
    private void Awake()
    {
        InteractableAnimator ri = GetComponent<InteractableAnimator>();
        ri.renderers = new Renderer[1]
        {
            World.CURRENT.ActiveCamera.GetComponent<BoatTransitionHandler>().OceanTarget.GetComponentInChildren<Renderer>()
        };
    }
}

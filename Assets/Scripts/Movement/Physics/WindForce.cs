using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public float WindSpeed;
    public float WindDensity;

    private void OnTriggerStay(Collider collision)
    {
        Rigidbody otherRb = collision.attachedRigidbody;

        if(otherRb != null)
        {
            WindSurface surface = collision.gameObject.GetComponent<WindSurface>();

            if(surface != null)
            {
                float relativeVelocity = WindSpeed - Vector3.Project(otherRb.velocity, transform.forward).magnitude;
                float force = 0.5F * relativeVelocity * relativeVelocity * WindDensity * surface.DragCoefficient(transform.forward) * surface.CrossSectionArea(transform.forward);
                otherRb.AddForce(transform.forward * force);
            }
        }
    }
}

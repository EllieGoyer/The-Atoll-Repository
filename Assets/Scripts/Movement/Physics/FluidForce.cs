using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidForce : MonoBehaviour
{
    public float FluidSpeed;
    public float FluidDensity;

    private void OnTriggerStay(Collider collision)
    {
        Rigidbody otherRb = collision.attachedRigidbody;

        if(otherRb != null)
        {
            FluidSurface surface = collision.gameObject.GetComponent<FluidSurface>();

            if(surface != null)
            {
                //Drag calculations
                float crossArea = surface.CrossSectionArea(transform.forward);
                float relativeVelocity = FluidSpeed - Vector3.Project(otherRb.velocity, transform.forward).magnitude;
                float force = 0.5F * relativeVelocity * relativeVelocity * FluidDensity * surface.DragCoefficient(transform.forward) * crossArea;
                float vCoefficient = (relativeVelocity > 0 ? 1 : -1);
                otherRb.AddForceAtPosition(transform.forward * force * vCoefficient, surface.gameObject.transform.position);

                //Lift calculations
                //float perpArea = surface.CrossSectionArea(transform.right);
                //float lift = 0.5F * relativeVelocity * relativeVelocity * FluidDensity * perpArea * surface.LiftCoefficient(transform.forward);
                //Vector3 dirVector = Vector3.Dot(transform.right, surface.transform.right) < 0 ? -surface.transform.right : surface.transform.right;
                //otherRb.AddForceAtPosition(transform.right * lift * vCoefficient * (Vector3.Dot(dirVector, ) ? ), surface.transform.position);
                //Debug.Log(lift);
            }
        }
    }
}

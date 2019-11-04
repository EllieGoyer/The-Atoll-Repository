using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanDrag : MonoBehaviour
{
    public static float OCEAN_DENSITY = 1000;
    protected Rigidbody rb;
    protected FluidSurface surface;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.y <= World.CURRENT.ActiveOceanRenderer.GenerationModel.HeightAt(new Vector2(pos.x, pos.z), Time.time))
        {
            float relativeVelocity = Vector3.Project(rb.velocity, transform.forward).magnitude;
            float force = 0.5F * relativeVelocity * relativeVelocity * OCEAN_DENSITY * surface.DragCoefficient(transform.forward) * surface.CrossSectionArea(transform.forward);
            rb.AddForceAtPosition(rb.velocity.normalized * -force, surface.gameObject.transform.position);
        }
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Collider>().attachedRigidbody;
        surface = gameObject.GetComponent<FluidSurface>();
    }
}

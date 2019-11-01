using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalWindSurface : WindSurface
{
    public Vector3 Center;
    public float Radius;
    public override float CrossSectionArea(Vector3 normal)
    {
        return Radius * Radius * Mathf.PI;
    }

    public override float DragCoefficient(Vector3 normal)
    {
        return 0.47F;
    }

    public static SphericalWindSurface FromSphericalCollider(SphereCollider collider)
    {
        SphericalWindSurface surface = new SphericalWindSurface();

        surface.Radius = collider.radius;
        surface.Center = collider.center;

        return surface;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(gameObject.transform.localToWorldMatrix.MultiplyVector(Center), Radius);
    }
}

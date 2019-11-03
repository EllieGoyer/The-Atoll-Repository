using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarFluidSurface : FluidSurface
{
    public Vector2 Size;
    public Vector3 Center;

    public override float CrossSectionArea(Vector3 windNormal)
    {
        Vector3 b = Vector3.ProjectOnPlane(Size.x * transform.right, windNormal);
        Vector3 h = Vector3.ProjectOnPlane(Size.y * transform.up, windNormal);

        return b.magnitude * h.magnitude;
    }

    public override float DragCoefficient(Vector3 windNormal)
    {
        return Mathf.Lerp(0.005F, 1.28F, CrossSectionArea(windNormal) / (Size.x * Size.y));
    }

    public override float LiftCoefficient(Vector3 normal)
    {
        return 1.0F;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, new Vector3(Size.x, Size.y, 0.01F));
    }
}

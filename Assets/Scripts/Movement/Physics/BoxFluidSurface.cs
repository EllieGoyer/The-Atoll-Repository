using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxFluidSurface : FluidSurface
{
    protected BoxCollider box;
    public override float CrossSectionArea(Vector3 normal)
    {
        Vector3 size = box.size;
        //Top/Bottom or Left/Right does not matter because of cube symmetry and only one of two faces can ever face the wind at once
        float frontSection = FaceCrossSection(transform.right, transform.up, new Vector2(size.x, size.y), normal);
        float topSection = FaceCrossSection(transform.right, transform.forward, new Vector2(size.x, size.z), normal);
        float rightSection = FaceCrossSection(transform.up, transform.forward, new Vector2(size.y, size.z), normal);
        return frontSection + topSection + rightSection;
    }

    public static float FaceCrossSection(Vector3 axis1, Vector3 axis2, Vector2 size, Vector3 windNormal)
    {
        Vector3 b = Vector3.ProjectOnPlane(size.x * axis1, windNormal);
        Vector3 h = Vector3.ProjectOnPlane(size.y * axis2, windNormal);

        return b.magnitude * h.magnitude;
    }

    public override float LiftCoefficient(Vector3 normal)
    {
        return 1.0F;
    }

    public override float DragCoefficient(Vector3 normal)
    {
        return 1.04F;
    }

    private void Awake()
    {
        box = gameObject.GetComponent<BoxCollider>();
    }
}

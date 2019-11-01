using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicWindSurface : WindSurface
{
    public Vector3 Size;
    public Vector3 Center;
    public override float CrossSectionArea(Vector3 normal)
    {
        //TODO orientation of cube
        return Size.x * Size.y + Size.x * Size.z + Size.y * Size.z;
    }

    public override float DragCoefficient(Vector3 normal)
    {
        return 1.04F;
    }
}

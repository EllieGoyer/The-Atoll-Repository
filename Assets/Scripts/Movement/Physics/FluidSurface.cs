using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FluidSurface : MonoBehaviour
{
    public abstract float CrossSectionArea(Vector3 normal);
    public abstract float DragCoefficient(Vector3 normal);

    public abstract float LiftCoefficient(Vector3 normal);
}

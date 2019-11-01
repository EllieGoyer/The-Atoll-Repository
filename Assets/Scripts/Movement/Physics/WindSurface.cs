using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindSurface : MonoBehaviour
{
    public abstract float CrossSectionArea(Vector3 normal);
    public abstract float DragCoefficient(Vector3 normal);
}

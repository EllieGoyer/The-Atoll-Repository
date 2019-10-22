using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class ConstantForce : MonoBehaviour
{
    public Vector3 Force = new Vector3(0, -9.8F, 0);

    protected Moveable moveable;

    public bool RefreshMoveable()
    {
        moveable = gameObject.GetComponent<Moveable>();
        return moveable != null;
    }

    void Start()
    {
        RefreshMoveable();
    }

    void Update()
    {
        moveable.ApplyForce(Force);
    }
}

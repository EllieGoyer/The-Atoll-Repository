using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ConstantForce : MonoBehaviour
{
    public Vector3 Force = new Vector3(0, -9.8F, 0);

    protected Rigidbody moveable;

    public bool RefreshMoveable()
    {
        moveable = gameObject.GetComponent<Rigidbody>();
        return moveable != null;
    }

    void Start()
    {
        RefreshMoveable();
    }

    void Update()
    {
        moveable.AddForce(Force, ForceMode.Force);
    }
}

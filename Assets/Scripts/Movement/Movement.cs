﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float ForwardTopSpeed;
    public float ForwardAcceleration;
    public float ForwardDeceleration;

    public float BackwardTopSpeed;
    public float BackwardAcceleration;
    public float BackwardDeceleration;

    /// <summary>
    /// The constant turning rate expressed as degrees per second
    /// </summary>
    public float TurningRate;

    public string ForwardAxisInputName;
    public string SideAxisInputName;

    protected virtual void Update()
    {
        float forwardInput = Input.GetAxis(ForwardAxisInputName);

        if (forwardInput > Mathf.Epsilon)
        {
            ForwardVelocity = Mathf.Clamp(ForwardVelocity + ForwardAcceleration, -BackwardTopSpeed, ForwardTopSpeed);
        }
        else if (forwardInput < -Mathf.Epsilon)
        {
            ForwardVelocity = Mathf.Clamp(ForwardVelocity - BackwardAcceleration, -BackwardTopSpeed, ForwardTopSpeed);
        }
        else
        {
            if(ForwardVelocity > 0)
            {
                ForwardVelocity = Mathf.Clamp(ForwardVelocity - ForwardDeceleration, 0, float.PositiveInfinity);
            }
            else if(ForwardVelocity < 0)
            {
                ForwardVelocity = Mathf.Clamp(ForwardVelocity + BackwardDeceleration, float.NegativeInfinity, 0);
            }
        }

        float sideInput = Input.GetAxis(SideAxisInputName);

        if (sideInput > Mathf.Epsilon)
        {
            AngularVelocity = TurningRate;
        }
        else if (sideInput < -Mathf.Epsilon)
        {
            AngularVelocity = -TurningRate;
        }
        else
        {
            AngularVelocity = 0;
        }
    }

    protected abstract float ForwardVelocity
    {
        get;
        set;
    }

    protected abstract float AngularVelocity
    {
        set;
    }
}
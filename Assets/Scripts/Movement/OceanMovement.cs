﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class OceanMovement : Movement {
    public float BuoyancyStrength = 20.5F;
    public float GravityStrength = 9.8F;
    public float MaxDisplacement = 1;
    public WaveRenderer WaveRenderer;

    [HideInInspector]
    protected SpectralWaveGenerationModel model;
    [HideInInspector]
    protected Moveable controller;
    [HideInInspector]
    protected float forwardVelocity;
    [HideInInspector]
    protected float angularVelocity;

    protected float verticalVelocity = 0;
    public float AirDrag;
    public float WaterDrag;

    protected override float ForwardVelocity {
        get => forwardVelocity;
        set => forwardVelocity = value;
    }
    protected override float AngularVelocity {
        set => angularVelocity = value;
    }

    // Start is called before the first frame update
    void Start() {
        ReloadReferences();
    }

    public void ReloadReferences() {
        controller = gameObject.GetComponent<Moveable>();
        model = WaveRenderer.GenerationModel;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        Transform transform = gameObject.transform;

        controller.ApplyTorque(new Vector3(0, angularVelocity * controller.AngularInertia, 0));

        Vector3 moveVector = forwardVelocity * transform.forward;

        if(Vector3.Project(controller.Velocity, transform.forward).magnitude < ForwardTopSpeed)
            controller.ApplyForce(moveVector * controller.Mass);
    }
}

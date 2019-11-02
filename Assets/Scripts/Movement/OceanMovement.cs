using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class OceanMovement : Movement {
    public float BuoyancyStrength = 20.5F;
    public float GravityStrength = 9.8F;
    public float MaxDisplacement = 1;

    [HideInInspector]
    protected Rigidbody controller;
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
        controller = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected override void Update() {
        if(AcceptingInput && !IsAirborne())
        {
            float forwardAxis = Input.GetAxis(ForwardAxisInputName), sideAxis = Input.GetAxis(SideAxisInputName);

            Vector3 forwardVelocity = Vector3.Project(controller.velocity, transform.forward);
            if (forwardAxis > 0 && Vector3.Dot(forwardVelocity, transform.forward) >= 0 && forwardVelocity.magnitude < ForwardTopSpeed)
            {
                controller.AddRelativeForce(new Vector3(0, 0, ForwardAcceleration), ForceMode.Acceleration);
            }
            if (forwardAxis < 0 && Vector3.Dot(forwardVelocity, transform.forward) <= 0 && forwardVelocity.magnitude < BackwardTopSpeed)
            {
                controller.AddRelativeForce(new Vector3(0, 0, -BackwardAcceleration), ForceMode.Acceleration);
            }
            if (sideAxis < 0)
            {
                controller.AddTorque(0, -TurningRate, 0, ForceMode.Acceleration);
            }
            if (sideAxis > 0)
            {
                controller.AddTorque(0, TurningRate, 0, ForceMode.Acceleration);
            }
        }
        
    }

    public bool IsAirborne() {
        float shipHeight = transform.position.y;
        float waterHeight = World.CURRENT.ActiveOceanRenderer.GenerationModel.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        return shipHeight >= waterHeight;
    }
}

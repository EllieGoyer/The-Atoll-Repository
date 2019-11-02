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
        get => Vector3.Project(controller.velocity, transform.forward).magnitude * Mathf.Sign(Vector3.Dot(controller.velocity, transform.forward));
        set
        {
            if(AcceptingInput)
            {
                Vector3 remainder = Vector3.ProjectOnPlane(controller.velocity, transform.forward);
                remainder += transform.forward * value;
                controller.velocity = remainder;
            }
        }
    }
    protected override float AngularVelocity {
        set
        {
            if(AcceptingInput)
            {
                Vector3 av = controller.angularVelocity;
                controller.angularVelocity = new Vector3(av.x, Mathf.LerpAngle(av.y, value, 0.3F), av.z);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        ReloadReferences();
    }

    public void ReloadReferences() {
        controller = gameObject.GetComponent<Rigidbody>();
    }

    public bool IsAirborne() {
        float shipHeight = transform.position.y;
        float waterHeight = World.CURRENT.ActiveOceanRenderer.GenerationModel.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        return shipHeight >= waterHeight;
    }
}

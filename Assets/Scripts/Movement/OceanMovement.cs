using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class OceanMovement : Movement {
    public float BuoyancyStrength = 20.5F;
    public float GravityStrength = 9.8F;
    public float MaxDisplacement = 1;
    public WaveRenderer WaveRenderer;

    [HideInInspector]
    protected SpectralWaveGenerationModel model;
    [HideInInspector]
    protected CharacterController controller;
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
        controller = gameObject.GetComponent<CharacterController>();
        model = WaveRenderer.GenerationModel;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        Transform transform = gameObject.transform;

        transform.Rotate(0, angularVelocity * Time.deltaTime, 0, Space.Self);

        Vector3 moveVector = forwardVelocity * transform.forward;
        verticalVelocity += (ComputeBuoyancy() - GravityStrength) * Time.deltaTime;

        float drag = IsAirborne() ? AirDrag : WaterDrag;
        verticalVelocity *= (1 - (drag * Time.deltaTime));

        moveVector.y += verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);

    }

    public float ComputeBuoyancy() {
        float shipHeight = transform.position.y;
        float waterHeight = model.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        if (shipHeight >= waterHeight) {
            return 0;
        }
        else {
            return BuoyancyStrength * Mathf.Min(MaxDisplacement, waterHeight - shipHeight);
        }
    }

    public bool IsAirborne() {
        float shipHeight = transform.position.y;
        float waterHeight = model.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        return shipHeight >= waterHeight;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class OceanMovement : Movement
{
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

    protected override float ForwardVelocity
    {
        get => forwardVelocity;
        set => forwardVelocity = value;
    }
    protected override float AngularVelocity
    {
        set => angularVelocity = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        ReloadReferences();
    }

    public void ReloadReferences()
    {
        controller = gameObject.GetComponent<CharacterController>();
        model = WaveRenderer.GenerationModel;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Transform transform = gameObject.transform;

        Vector3 moveVector = forwardVelocity * transform.forward;
        moveVector.y += ComputeBuoyancy();
        moveVector.y -= GravityStrength;

        Quaternion rotationQuat = Quaternion.Euler(0, angularVelocity * Time.deltaTime, 0);
        Vector3 right = rotationQuat * transform.right, forward = rotationQuat * transform.forward;
        Vector3 tempRight = right, tempForward = forward;
        tempRight.y = 0;
        tempForward.y = 0;
        tempRight.Normalize();
        tempForward.Normalize();

        transform.forward = tempForward;
        transform.right = tempRight;

        controller.Move(moveVector * Time.deltaTime);

        transform.forward = forward;
        transform.right = right;

        float depth = ComputeDepth();
        if (Mathf.Abs(depth) <= 10)
        {
            Vector3 pos = transform.position;

            Vector3 left = pos - tempRight, right2 = pos + tempRight, front = pos + tempForward, back = pos - tempForward;

            float leftHeight = ComputeHeight(left.x, left.z), rightHeight = ComputeHeight(right2.x, right2.z), forwardHeight = ComputeHeight(front.x, front.z), backHeight = ComputeHeight(back.x, back.z);

            left.y = leftHeight;
            right2.y = rightHeight;
            front.y = forwardHeight;
            back.y = backHeight;

            transform.forward = (front - back).normalized;
            transform.right = (right2 - left).normalized;
        }
    }

    public float ComputeBuoyancy()
    {
        float shipHeight = transform.position.y;
        float waterHeight = ComputeHeight(transform.position.x, transform.position.z);
        float depth = ComputeDepth();

        if (depth < 0)
        {
            return 0;
        }
        else
        {
            return BuoyancyStrength * Mathf.Min(MaxDisplacement, waterHeight - shipHeight);
        }
    }

    public float ComputeDepth()
    {
        float shipHeight = transform.position.y - 1;
        float waterHeight = ComputeHeight(transform.position.x, transform.position.z);

        return waterHeight - shipHeight;
    }

    public float ComputeHeight(float x, float z)
    {
        return model.HeightAt(new Vector2(x, z), Time.time);
    }
}

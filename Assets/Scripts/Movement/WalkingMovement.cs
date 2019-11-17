using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class WalkingMovement : Movement
{
    [HideInInspector]
    protected CharacterController controller;
    public Animator Animator;
    [HideInInspector]
    protected float forwardVelocity;
    [HideInInspector]
    protected float angularVelocity;

    public CameraFollow cameraFollow;

    protected override float ForwardVelocity
    {
        get => forwardVelocity;
        set => forwardVelocity = value;
    }
    protected override float AngularVelocity
    {
        set => angularVelocity = value;
    }

    void Start()
    {
        cameraFollow = World.CURRENT.ActiveCameraFollow;
        ReloadCharacterController();
    }

    protected override void Update()
    {
        base.Update();

        Transform transform = gameObject.transform;

        transform.Rotate(0, angularVelocity * Time.deltaTime, 0, Space.Self);

        Vector3 moveVector = forwardVelocity * transform.forward;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning && forwardVelocity > 0) moveVector *= 3;

        controller.SimpleMove(moveVector);

        if (Mathf.Approximately(0, moveVector.magnitude))
        {
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsSprinting", false);
        }
        else
        {
            Animator.SetBool("IsWalking", true);
            if(forwardVelocity > 0)
            {
                Animator.SetBool("Forwards", true);
                if (isRunning) Animator.SetBool("IsSprinting", true);
                else Animator.SetBool("IsSprinting", false);
            }
            else
            {
                Animator.SetBool("Forwards", false);
                Animator.SetBool("IsSprinting", false);
            }
        }
    }

    protected override void DoSideInput(float sideInput) {
        if (sideInput > Mathf.Epsilon) {
            AngularVelocity = TurningRate;
        }
        else if (sideInput < -Mathf.Epsilon) {
            AngularVelocity = -TurningRate;
        }
        else if (cameraFollow.IsDragging) {
            float deadZone = 10;

            // calculate difference between our player's aim direction and our camera's
            float cameraYaw = cameraFollow.transform.eulerAngles.y;
            float thisYaw = transform.eulerAngles.y;
            float yawDiff = (cameraYaw - thisYaw + 720) % 360;
            
            // if we're looking to the left
            if (yawDiff > 180) {
                float diff = 360 - yawDiff;

                // turn left, slowing down as we get close to looking straight ahead
                AngularVelocity = Mathf.Lerp(0,-TurningRate,diff / deadZone);
            }
            else {
                // otherwise we're looking right
                float diff = yawDiff;
                
                // turn right, slowing down as we get close to looking straight ahead
                AngularVelocity = Mathf.Lerp(0, TurningRate, diff / deadZone);
            }

        }
        else {
            AngularVelocity = 0;
        }
    }

    public void ReloadCharacterController()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}

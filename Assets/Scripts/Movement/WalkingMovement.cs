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

    public void ReloadCharacterController()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}

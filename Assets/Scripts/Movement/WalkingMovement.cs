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

        controller.SimpleMove(moveVector);

        if (Mathf.Approximately(0, moveVector.magnitude))
        {
            Animator.SetBool("IsWalking", false);
        }
        else
        {
            Animator.SetBool("IsWalking", true);
            if(forwardVelocity > 0)
            {
                Animator.SetBool("Forwards", true);
            }
            else
            {
                Animator.SetBool("Forwards", false);
            }
        }
    }

    public void ReloadCharacterController()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}

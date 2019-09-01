using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class WalkingMovement : Movement
{
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
    }

    public void ReloadCharacterController()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
}

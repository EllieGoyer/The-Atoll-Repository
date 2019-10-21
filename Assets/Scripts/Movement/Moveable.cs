using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Moveable : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public Quaternion AngularVelocity;
    public Quaternion AngularAcceleration;
    public float Mass;
    public float Radius;
    public float Drag;
    public float AngularDrag;
    public float CollisionElasticity;

    protected CharacterController characterController;

    public float AngularInertia
    {
        get
        {
            //Computes angular inertia at a given point using a simplified model
            //assumes the object is a sphere.
            //With the assumption, I = (2/5)MR^2
            //Where I is angular inertia, M is mass, and R is radius
            return 0.4F * Mass * Radius * Radius;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        Acceleration += force / Mass;
    }

    public void ApplyTorque(Vector3 torque)
    {
        AngularAcceleration *= Quaternion.Euler(torque / AngularInertia);
    }

    public void ApplyForceAt(Vector3 force, Vector3 position)
    {
        ApplyTorque(Vector3.Cross(force, -position + transform.position));
        ApplyForce(force);
    }

    public bool RefreshController()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        return characterController != null;
    }
    
    void Start()
    {
        RefreshController();
    }
    
    void Update()
    {
        AngularVelocity *= Quaternion.Slerp(Quaternion.identity, AngularAcceleration, Time.deltaTime);
        AngularVelocity = Quaternion.Slerp(Quaternion.identity, AngularVelocity, 1 - AngularDrag);
        transform.rotation *= Quaternion.Slerp(Quaternion.identity, AngularVelocity, Time.deltaTime);

        Velocity = (Velocity + Acceleration * Time.deltaTime) * (1 - Drag);
        characterController.Move(Velocity * Time.deltaTime);

        //Acceleration is reset at the end of each frame so all forces have to be
        //continuously applied each frame
        Acceleration = Vector3.zero;
        AngularAcceleration = Quaternion.identity;

    }

    void OnCollisionEnter(Collision other)
    {
        Moveable otherMoveable = other.gameObject.GetComponent<Moveable>();

        Vector3 meanNormal = Vector3.zero;
        int contactCount = other.contactCount;
        for (int i = contactCount - 1; i >= 0; i--)
        {
            meanNormal += other.GetContact(i).normal / contactCount;
        }

        Vector3 targetDirection = Vector3.Reflect(Velocity, meanNormal).normalized;
        float speed = Velocity.magnitude;
        if(otherMoveable == null)
        {
            Velocity = CollisionElasticity * speed * targetDirection;
        }
        else
        {
            float otherSpeed = otherMoveable.Velocity.magnitude;
            Velocity = (CollisionElasticity * otherMoveable.Mass * Mathf.Abs(otherSpeed - speed) + Mass * speed + otherSpeed * otherMoveable.Mass) / (Mass + otherMoveable.Mass) * targetDirection;
        }
    }
}

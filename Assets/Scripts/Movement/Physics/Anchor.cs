using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(Rigidbody))]
public class Anchor : MonoBehaviour
{
    public float Cooldown;
    protected SpringJoint spring;
    protected Rigidbody rb;
    protected bool coolingDown = false;
    void Awake()
    {
        spring = GetComponent<SpringJoint>();
        rb = GetComponent<Rigidbody>();
    }

    public void Disengage()
    {
        if(enabled)
        {
            rb.isKinematic = false;
            Invoke("ResetCooldown", Cooldown);
            coolingDown = true;
        }
    }

    public void ResetCooldown()
    {
        coolingDown = false;
    }

    private void FixedUpdate()
    {
        if(spring.currentForce.magnitude > 2 * spring.spring)
        {
            Disengage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!coolingDown && collision.rigidbody != spring.connectedBody)
        {
            rb.isKinematic = true;
        }
    }
}

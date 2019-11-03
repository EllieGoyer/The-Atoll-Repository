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
            enabled = false;
        }
    }

    public void ResetCooldown()
    {
        enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(enabled && collision.rigidbody != spring.connectedBody)
        {
            rb.isKinematic = true;
        }
    }
}

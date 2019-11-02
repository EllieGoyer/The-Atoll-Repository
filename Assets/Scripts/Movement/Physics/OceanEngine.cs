using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanEngine : MonoBehaviour
{
    protected Rigidbody rb;
    public float MaxThrust = 100;
    public float MinThrust = -100;
    public int Direction = 0;
    void Awake()
    {
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if(pos.y < World.CURRENT.ActiveOceanRenderer.GenerationModel.HeightAt(new Vector2(pos.x, pos.z), Time.time))
        {
            float thrust = Direction > 0 ? MaxThrust : Direction < 0 ? MinThrust : 0;
            rb.AddForce(transform.forward * thrust);
        }
    }
}

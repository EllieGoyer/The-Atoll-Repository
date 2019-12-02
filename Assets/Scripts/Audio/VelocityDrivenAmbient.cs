using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDrivenAmbient : MonoBehaviour
{
    public AK.Wwise.RTPC Parameter;
    public float MinValue = 0;
    public float MaxValue = 100;
    public float MinSpeed = 0;
    public float MaxSpeed = 10;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
        float scaledValue = Mathf.Lerp(MinValue, MaxValue, (speed - MinSpeed) / (MaxSpeed - MinSpeed));
        Parameter.SetValue(gameObject, scaledValue);
    }
}

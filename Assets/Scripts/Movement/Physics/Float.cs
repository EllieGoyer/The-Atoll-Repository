using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public abstract class Float : MonoBehaviour
{
    protected Rigidbody rb;
    public static readonly float WATER_DENSITY = 1000;
    public static readonly float GRAVITY_CONSTANT = 9.8F;
    protected abstract IEnumerable<Tuple<Vector3, float, float>> samplePoints
    {
        get;
    }

    protected virtual void Awake()
    {
        rb = gameObject.GetComponent<Collider>().attachedRigidbody;
    }

    protected virtual void FixedUpdate()
    {
        WaveGenerationModel model = World.CURRENT.ActiveOceanRenderer.GenerationModel;
        foreach(Tuple<Vector3, float, float> sample in samplePoints)
        {
            float waterHeight = model.HeightAt(new Vector2(sample.Item1.x, sample.Item1.z), Time.time);
            float displacement = sample.Item2 * Math.Max(0, Math.Min(sample.Item3, waterHeight - sample.Item1.y));
            rb.AddForceAtPosition(new Vector3(0, displacement * GRAVITY_CONSTANT * WATER_DENSITY, 0), sample.Item1, ForceMode.Force);
        }
    }
}

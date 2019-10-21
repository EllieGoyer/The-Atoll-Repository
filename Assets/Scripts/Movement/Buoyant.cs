using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Buoyant : MonoBehaviour
{
    public static readonly float OCEAN_DENSITY = 1000;
    public static readonly float GRAVITATIONAL_CONSTANT = -9.8F;

    [Serializable]
    public struct ContactPoint
    {
        public Transform transform;
        public float BaseArea;
        public float Height;
    }
    public ContactPoint[] ContactPoints;
    public WaveRenderer OceanRenderer;

    protected Moveable moveable;

    public bool RefreshMoveable()
    {
        moveable = gameObject.GetComponent<Moveable>();
        return moveable != null;
    }

    void Start()
    {
        RefreshMoveable();
    }

    // Update is called once per frame
    void Update()
    {
        SpectralWaveGenerationModel model = OceanRenderer.GenerationModel;
        foreach(ContactPoint pt in ContactPoints)
        {
            Vector3 position = pt.transform.position;
            float waterHeight = model.HeightAt(new Vector2(position.x, position.z), Time.time);

            if(waterHeight > position.y)
            {
                float displacement = OCEAN_DENSITY * Mathf.Min(waterHeight - position.y, pt.Height) * pt.BaseArea;
                moveable.ApplyForceAt(new Vector3(0, -displacement * GRAVITATIONAL_CONSTANT, 0), position);
            }
        }
    }
}

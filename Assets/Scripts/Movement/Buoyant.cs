using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]

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

    protected Rigidbody moveable;

    public bool RefreshMoveable()
    {
        moveable = gameObject.GetComponent<Rigidbody>();
        return moveable != null;
    }

    void Start()
    {
        RefreshMoveable();
    }

    // Update is called once per frame
    void Update()
    {
        SpectralWaveGenerationModel model = World.CURRENT.ActiveOceanRenderer.GenerationModel;
        foreach(ContactPoint pt in ContactPoints)
        {
            Vector3 position = pt.transform.position;
            float waterHeight = model.HeightAt(new Vector2(position.x, position.z), Time.time);

            if(waterHeight > position.y)
            {
                float displacement = OCEAN_DENSITY * Mathf.Min(waterHeight - position.y, pt.Height) * pt.BaseArea;
                moveable.AddForceAtPosition(new Vector3(0, -displacement * GRAVITATIONAL_CONSTANT, 0), position, ForceMode.Force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        
        if (World.CURRENT != null && World.CURRENT.ActiveOcean != null)
        {
            SpectralWaveGenerationModel model = World.CURRENT.ActiveOceanRenderer.GenerationModel;
            foreach (ContactPoint pt in ContactPoints)
            {
                float rootBase = Mathf.Sqrt(pt.BaseArea);
                Vector3 pos = pt.transform.position;
                float waterHeight = model.HeightAt(new Vector2(pos.x, pos.z), Time.time);
                float dispHeight = Mathf.Min(pt.Height, Mathf.Max(0, waterHeight - pos.y));
                Gizmos.DrawWireCube(new Vector3(pos.x, pos.y + 0.5F * pt.Height, pos.z), new Vector3(rootBase, pt.Height, rootBase));
                Gizmos.DrawCube(new Vector3(pos.x, pos.y + 0.5F * dispHeight, pos.z), new Vector3(rootBase, dispHeight, rootBase));
            }
        }
    }
}

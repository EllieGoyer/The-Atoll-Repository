using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxFloat : Float
{
    public Vector3Int Resolution;
    protected override IEnumerable<Tuple<Vector3, float, float>> samplePoints
    {
        get
        {
            Matrix4x4 basis = gameObject.transform.localToWorldMatrix;
            foreach(Tuple<Vector3, float, float> sample in sampleCache)
            {
                yield return new Tuple<Vector3, float, float>(basis.MultiplyPoint(sample.Item1), sample.Item2, sample.Item3);
            }
        }
    }

    protected BoxCollider box;
    protected List<Tuple<Vector3, float, float>> sampleCache = new List<Tuple<Vector3, float, float>>();

    public List<Tuple<Vector3, float, float>> GenerateSamples()
    {
        float totalVolume = box.size.x * box.size.y * box.size.z;
        int totalSamples = Resolution.x * Resolution.y * Resolution.z;

        float xStep = box.size.x / Resolution.x;
        float yStep = box.size.y / Resolution.y;
        float zStep = box.size.z / Resolution.z;

        float sampleVolume = totalVolume / totalSamples;

        float minX = -box.size.x / 2 + xStep / 2, maxX = box.size.x / 2;
        float minY = -box.size.y / 2 + yStep / 2, maxY = box.size.y / 2;
        float minZ = -box.size.z / 2 + zStep / 2, maxZ = box.size.z / 2;

        List<Tuple<Vector3, float, float>> samples = new List<Tuple<Vector3, float, float>>();
        for (float x = minX; x < maxX; x += xStep)
            for (float y = minY; y < maxY; y += yStep)
                for (float z = minZ; z < maxZ; z += zStep)
                    samples.Add(new Tuple<Vector3, float, float>(new Vector3(x, y, z), xStep * zStep, yStep));

        return samples;
    }

    protected override void Awake()
    {
        base.Awake();

        box = gameObject.GetComponent<BoxCollider>();
        sampleCache = GenerateSamples();
        Debug.Log(sampleCache[0].Item1);
    }
}

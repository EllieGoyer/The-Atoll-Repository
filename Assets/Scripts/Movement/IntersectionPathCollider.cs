using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionPathCollider : PathCollider
{
    public float BaseLevel;
    public float BuildStep;
    public float SweepStep;
    public Vector3 BuildStart;
    protected TerrainData data;
    protected override Vector3[] points
    {
        get { return new Vector3[0]; }
    }

    protected override int[] segments
    {
        get { return new int[0]; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionPathCollider : PathCollider
{
    public float BaseLevel = 85;
    public float BuildStep = 10;
    public float LoopDistance = 30;
    public Terrain Terrain;
    public Vector3[] pts;
    public int[] segs;
    protected override Vector3[] points
    {
        get { return pts ?? new Vector3[0]; }
    }

    protected override int[] segments
    {
        get { return segs ?? new int[0]; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePathCollider : PathCollider
{
    public Transform[] Points;
    protected override Vector3[] points
    {
        get
        {
            if (Points == null) return null;
            else {
                Vector3[] pts = new Vector3[Points.Length];
                for (int i = 0; i < Points.Length; i++)
                {
                    if (Points[i] == null) return null;
                    pts[i] = Points[i].position;
                }
                return pts;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePathCollider : PathCollider
{
    protected override Vector3[] points
    {
        get
        {
            Vector3[] pts = new Vector3[transform.childCount];
            for(int i = 0; i < pts.Length; i++)
            {
                pts[i] = transform.GetChild(i).transform.position;
            }
            return pts;
        }
    }
    protected override int[] segments
    {
        get
        {
            int[] segs = new int[Mathf.Max(0, 2 * points.Length - 2)];
            for(int i = 0; i < segs.Length; i += 2)
            {
                segs[i] = i / 2;
                segs[i + 1] = i / 2 + 1;
            }
            return segs;
        }
    }
}

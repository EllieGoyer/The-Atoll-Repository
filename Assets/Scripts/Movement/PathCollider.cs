using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathCollider : MonoBehaviour
{
    public static Vector3 SegmentColliderCenter(Vector3 start, Vector3 end)
    {
        return (start + end) / 2;
    }

    public static Vector3 SegmentColliderSize(Vector3 start, Vector3 end, float thickness, float height, float capLength)
    {
        return new Vector3((start - end).magnitude + 2 * capLength, height, thickness);
    }

    public static Quaternion SegmentColliderOrientation(Vector3 start, Vector3 end)
    {
        Vector3 dvector = (start - end).normalized;
        dvector = new Vector3(-dvector.z, dvector.y, dvector.x);
        return Quaternion.LookRotation(dvector, Vector3.up);
    }
    public static GameObject SegmentToCollider(Vector3 start, Vector3 end, float thickness, float height, float capLength)
    {
        GameObject obj = new GameObject();
        BoxCollider result = obj.AddComponent<BoxCollider>();
        result.center = Vector3.zero;
        result.size = SegmentColliderSize(start, end, thickness, height, capLength);
        obj.transform.position = SegmentColliderCenter(start, end);
        obj.transform.rotation = SegmentColliderOrientation(start, end);
        return obj;
    }

    [HideInInspector]
    protected GameObject[] colliderObjects;
    protected abstract Vector3[] points
    {
        get;
    }
    public bool IsClosed;
    public float Thickness;
    public float Height;
    public float CapLength;


    public void GenerateColliders()
    {
        Vector3[] pts = points;
        if(colliderObjects != null)
        {
            foreach(GameObject obj in colliderObjects)
            {
                Destroy(obj);
            }
        }
        colliderObjects = new GameObject[IsClosed ? pts.Length : pts.Length - 1];
        for(int i = 0; i < pts.Length - 1; i++)
        {
            colliderObjects[i] = SegmentToCollider(pts[i], pts[i + 1], Thickness, Height, CapLength);
            colliderObjects[i].transform.parent = gameObject.transform;
        }

        if(IsClosed && pts.Length > 1)
        {
            colliderObjects[pts.Length - 1] = SegmentToCollider(pts[pts.Length - 1], pts[0], Thickness, Height, CapLength);
            colliderObjects[pts.Length - 1].transform.parent = gameObject.transform;
        }
    }

    private void Awake()
    {
        GenerateColliders();
    }

    private void OnDrawGizmos()
    {
        Vector3[] pts = points;
        Gizmos.color = Color.green;
        if (pts != null)
        {
            for (int i = 0; i < pts.Length - 1; i++)
            {
                Gizmos.matrix = Matrix4x4.TRS(SegmentColliderCenter(pts[i], pts[i + 1]), SegmentColliderOrientation(pts[i], pts[i + 1]), Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, SegmentColliderSize(pts[i], pts[i + 1], Thickness, Height, CapLength));
            }
            if (IsClosed && pts.Length > 1)
            {
                Gizmos.matrix = Matrix4x4.TRS(SegmentColliderCenter(pts[pts.Length - 1], pts[0]), SegmentColliderOrientation(pts[pts.Length - 1], pts[0]), Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, SegmentColliderSize(pts[pts.Length - 1], pts[0], Thickness, Height, CapLength));
            }
        }
    }
}

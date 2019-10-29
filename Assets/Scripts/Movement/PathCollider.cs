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
    protected abstract int[] segments
    {
        get;
    }
    public float Thickness;
    public float Height;
    public float CapLength;


    public void GenerateColliders()
    {
        Vector3[] pts = points;
        int[] segs = segments;
        if(colliderObjects != null)
        {
            foreach(GameObject obj in colliderObjects)
            {
                Destroy(obj);
            }
        }
        colliderObjects = new GameObject[segs.Length / 2];
        Matrix4x4 baseTransform = gameObject.transform.localToWorldMatrix;
        for(int i = 0; i < segs.Length; i += 2)
        {
            colliderObjects[i / 2] = SegmentToCollider(pts[segs[i]], pts[segs[i + 1]], Thickness, Height, CapLength);
            colliderObjects[i / 2].transform.SetParent(gameObject.transform, true);
            colliderObjects[i / 2].layer = gameObject.layer;
        }
    }

    private void Awake()
    {
        GenerateColliders();
    }

    private void OnDrawGizmos()
    {
        Vector3[] pts = points;
        int[] segs = segments;
        Gizmos.color = Color.green;
        if (pts != null)
        {
            for (int i = 0; i < segs.Length; i += 2)
            {
                Gizmos.matrix = Matrix4x4.TRS(SegmentColliderCenter(pts[segs[i]], pts[segs[i + 1]]), SegmentColliderOrientation(pts[segs[i]], pts[segs[i + 1]]), Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, SegmentColliderSize(pts[segs[i]], pts[segs[i + 1]], Thickness, Height, CapLength));
            }
        }
    }
}

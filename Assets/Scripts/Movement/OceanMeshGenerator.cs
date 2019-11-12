using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OceanMeshGenerator
{
    public static Mesh MeshFromCamera(Camera camera, float baseInterval, float minDistance, float maxDistance, float maxWidth, float distanceScaling)
    {
        Mesh result = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        for(float x = -maxWidth; x < maxWidth; x += baseInterval)
        {
            for(float z = minDistance; z < maxDistance; z += baseInterval)
            {
                vertices.Add(new Vector3(x, 0, z));
            }
        }

        Vector3 expRight = Vector3.right * baseInterval;
        Vector3 expForward = Vector3.forward * baseInterval;
        Vector3 expLeft = -expRight;
        Vector3 expBack = -expForward;

        for(int i = 0; i < vertices.Count; i++)
        {
            Vector3 bl = vertices[i];
            int? br = null;
            int? tl = null;
            for(int j = 0; j < vertices.Count; j++)
            {
                if(Mathf.Approximately(Vector3.Distance(expRight, vertices[j] - bl), 0))
                {
                    br = j;
                }

                if (Mathf.Approximately(Vector3.Distance(expForward, vertices[j] - bl), 0))
                {
                    tl = j;
                }
            }

            if(br != null && tl != null)
            {
                triangles.Add(i);
                triangles.Add(tl.Value);
                triangles.Add(br.Value);
            }
        }

        for (int i = 0; i < vertices.Count; i++)
        {
            Vector3 tr = vertices[i];
            int? br = null;
            int? tl = null;
            for (int j = 0; j < vertices.Count; j++)
            {
                if (Mathf.Approximately(Vector3.Distance(expLeft, vertices[j] - tr), 0))
                {
                    tl = j;
                }

                if (Mathf.Approximately(Vector3.Distance(expBack, vertices[j] - tr), 0))
                {
                    br = j;
                }
            }

            if (br != null && tl != null)
            {
                triangles.Add(i);
                triangles.Add(br.Value);
                triangles.Add(tl.Value);
            }
        }

        for(int i = 0; i < vertices.Count; i++)
        {
            Vector3 vi = vertices[i];
            vertices[i] = new Vector3(
                Mathf.Sign(vi.x) * Mathf.Pow(Mathf.Abs(vi.x), distanceScaling),
                 Mathf.Sign(vi.y) * Mathf.Pow(Mathf.Abs(vi.y), distanceScaling),
                  Mathf.Sign(vi.z) * Mathf.Pow(Mathf.Abs(vi.z), distanceScaling)
                  );
        }

        result.vertices = vertices.ToArray();
        result.triangles = triangles.ToArray();
        result.Optimize();
        result.RecalculateNormals();
        result.RecalculateBounds();

        return result;
    }
}

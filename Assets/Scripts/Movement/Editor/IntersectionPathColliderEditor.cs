using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IntersectionPathCollider))]
public class IntersectionPathColliderEditor : Editor
{
    public float Target;
    protected IntersectionPathCollider collider;
    protected Terrain terrain;
    protected Vector3[] points;

    public Vector3 FineSearchHeight(float x1, float y1, float x2, float y2)
    {
        float left = 0, right = 1;
        while (!Mathf.Approximately(left, right))
        {
            float mid = (left + right) / 2;
            float height = terrain.SampleHeight(new Vector3(Mathf.Lerp(x1, x2, mid), 0, Mathf.Lerp(y1, y2, mid)));

            if (height < Target)
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }
        float trueX = Mathf.Lerp(x1, x2, left), trueY = Mathf.Lerp(y1, y2, left);
        return new Vector3(trueX, terrain.SampleHeight(new Vector3(trueX, 0, trueY)), trueY);
    }

    protected static readonly int[][] DIRECTION_ARRAY = new int[8][]
    {
        new int[2]{1, 0},
        new int[2]{0, 1},
        new int[2]{1, 1},
        new int[2]{-1, 0},
        new int[2]{0, -1},
        new int[2]{-1, -1},
        new int[2]{1, -1},
        new int[2]{-1, 1}
    };

    public Vector3[] FindCandidatePoints()
    {
        List<Vector3> candidates = new List<Vector3>();

        
        float minH = terrain.transform.position.z, minW = terrain.transform.position.x;
        float maxH = terrain.terrainData.size.z + minH, maxW = terrain.terrainData.size.x + minW;

        for (float r = minH + 1; r < maxW - 1; r++)
        {
            for(int c = 1; c < maxH - 1; c++)
            {
                bool center = (terrain.SampleHeight(new Vector3(r, 0, c)) > Target);
                foreach(int[] dir in DIRECTION_ARRAY)
                {
                    if(center != (terrain.SampleHeight(new Vector3(r + dir[0], 0, c + dir[1])) > Target))
                    {
                        float x2 = r + dir[0], y2 = c + dir[1];
                        candidates.Add(FineSearchHeight(r, c, x2, y2));
                    }
                }
            }
        }

        return candidates.ToArray();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BaseLevel"));
        serializedObject.ApplyModifiedProperties();
        if(GUILayout.Button("Regenerate"))
        {
            collider = ((IntersectionPathCollider)target);
            terrain = collider.gameObject.GetComponent<Terrain>();
            Target = serializedObject.FindProperty("BaseLevel").floatValue;
            points = FindCandidatePoints().Where(x => Mathf.Approximately(x.y, Target)).ToArray();
            SerializedProperty prop = serializedObject.FindProperty("tpts");
            prop.arraySize = points.Length;
            Vector3 bmat = collider.transform.position;
            for (int i = 0; i < points.Length; i++)
                prop.GetArrayElementAtIndex(i).vector3Value = points[i];
            Debug.Log(points[0]);
            serializedObject.ApplyModifiedProperties();
            Debug.Log(points.Length);
        }
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
    public static void DrawCandidates(IntersectionPathCollider collider, GizmoType type)
    {
        if(collider.tpts != null)
        {
            foreach (Vector3 p in collider.tpts)
            {
                Gizmos.DrawSphere(p, 0.2F);
            }
        }
    }
}

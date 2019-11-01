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

        float minH = terrain.transform.position.x, minW = terrain.transform.position.z;
        float maxH = terrain.terrainData.size.x + minH, maxW = terrain.terrainData.size.z + minW;

        for(int d = 1; d <= 3; d++)
        {
            for (float r = minH + d; r < maxH - d; r++)
            {
                for (float c = minW + d; c < maxW - d; c++)
                {
                    bool center = (terrain.SampleHeight(new Vector3(r, 0, c)) > Target);

                    foreach (int[] dir in DIRECTION_ARRAY)
                    {
                        if (center != (terrain.SampleHeight(new Vector3(r + d * dir[0], 0, c + d * dir[1])) > Target))
                        {
                            float x2 = r + d * dir[0], y2 = c + d * dir[1];
                            candidates.Add(FineSearchHeight(r, c, x2, y2));
                        }
                    }
                }
            }
        }


        return candidates.ToArray();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Terrain"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Thickness"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Height"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("CapLength"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BaseLevel"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("BuildStep"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("LoopDistance"));
        EditorGUILayout.LabelField("Points: " + serializedObject.FindProperty("pts").arraySize);
        EditorGUILayout.LabelField("Segments: " + serializedObject.FindProperty("segs").arraySize / 2);
        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Regenerate"))
        {
            collider = ((IntersectionPathCollider)target);
            terrain = collider.Terrain;
            Target = serializedObject.FindProperty("BaseLevel").floatValue;

            List<Vector3> candidates = FindCandidatePoints().Where(x => Mathf.Approximately(x.y, Target)).Distinct().ToList();
            FilterCandidates(candidates, serializedObject.FindProperty("BuildStep").floatValue);

            SerializedProperty prop = serializedObject.FindProperty("pts");
            prop.arraySize = candidates.Count;
            Vector3 bmat = collider.transform.position;
            for (int i = 0; i < candidates.Count; i++)
                prop.GetArrayElementAtIndex(i).vector3Value = candidates[i];

            prop = serializedObject.FindProperty("segs");

            List<int> candSegs = new List<int>();
            bool[] used = new bool[candidates.Count];
            float maxLoopDist = serializedObject.FindProperty("LoopDistance").floatValue;
            while (!used.All(x => x))
            {
                for (int k = 0; k < candidates.Count; k++)
                {
                    if(!used[k])
                    {
                        used[k] = true;
                        List<int> loopIndices = new List<int>();
                        loopIndices.Add(k);

                        bool newEntries = true;
                        while(newEntries)
                        {
                            newEntries = false;

                            for(int i = 0; i < candidates.Count; i++)
                            {
                                if(!used[i])
                                {
                                    float minDist = float.PositiveInfinity;

                                    for (int j = 0; j < loopIndices.Count; j++)
                                    {
                                        minDist = Mathf.Min(minDist, Vector3.Distance(candidates[loopIndices[j]], candidates[i]));
                                    }

                                    if(minDist < maxLoopDist)
                                    {
                                        loopIndices.Add(i);
                                        used[i] = true;
                                        newEntries = true;
                                    }
                                }
                            }
                        }

                        for(int i = 0; i < loopIndices.Count - 1; i++)
                        {
                            float minDist = float.PositiveInfinity;
                            int minIndex = i + 1;

                            for(int j = i + 1; j < loopIndices.Count; j++)
                            {
                                float newDist = Vector3.Distance(candidates[loopIndices[i]], candidates[loopIndices[j]]);

                                if(newDist < minDist)
                                {
                                    minDist = newDist;
                                    minIndex = j;
                                }
                            }

                            int temp = loopIndices[i + 1];
                            loopIndices[i + 1] = loopIndices[minIndex];
                            loopIndices[minIndex] = temp;
                        }

                        loopIndices.Add(loopIndices[0]);

                        for(int i = 0; i < loopIndices.Count - 1; i++)
                        {
                            candSegs.Add(loopIndices[i]);
                            candSegs.Add(loopIndices[i + 1]);
                        }
                    }
                }
            }

            prop.arraySize = candSegs.Count;
            for(int i = 0; i < candSegs.Count; i++)
            {
                prop.GetArrayElementAtIndex(i).intValue = candSegs[i];
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

    public static bool FilterCandidates(List<Vector3> candidates, float minDist)
    {
        bool anyRemoved = false;

        for (int i = 0; i < candidates.Count; i++)
        {
            for (int j = candidates.Count - 1; j > i; j--)
            {
                if (Mathf.Approximately(0, Mathf.Max(0, Vector3.Distance(candidates[i], candidates[j]) - minDist)))
                {
                    candidates.RemoveAt(j);
                    anyRemoved = true;
                }
            }
        }

        return anyRemoved;
    }
}

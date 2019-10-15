using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DrawGizmoSurface : MonoBehaviour
{
    public abstract Color GetColor();

    private void OnDrawGizmos() {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Gizmos.color = GetColor();
        Gizmos.DrawMesh(meshFilter.sharedMesh, transform.position, transform.rotation, transform.lossyScale);
    }
}

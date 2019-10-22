using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugColliderVisualizer : MonoBehaviour
{
    public BoxCollider VisualizedCollider;

    private void Awake() {
        transform.localScale = VisualizedCollider.size;
        transform.localPosition = VisualizedCollider.center;
    }
}

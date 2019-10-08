using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransformTracker : MonoBehaviour {
    public Vector3 UIOffset;
    public Transform TrackedTransform;
    public Vector3 LocalPositionOffset;

    RectTransform rect;

    private void Awake() {
        rect = GetComponent<RectTransform>();
    }

    protected void LateUpdate() {
        Vector3 transformPosition = TrackedTransform.TransformPoint(LocalPositionOffset);
        rect.position = Camera.main.WorldToScreenPoint(transformPosition) + UIOffset;
    }
}

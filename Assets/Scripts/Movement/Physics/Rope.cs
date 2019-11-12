using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SpringJoint))]
public class Rope : MonoBehaviour
{
    protected LineRenderer lr;
    protected SpringJoint spring;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        spring = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] points = new Vector3[2];
        points[0] = transform.localToWorldMatrix.MultiplyPoint(spring.anchor);
        points[1] = spring.connectedBody.transform.localToWorldMatrix.MultiplyPoint(spring.connectedAnchor);
        lr.SetPositions(points);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipositionDrivenValue : MonoBehaviour
{
    public AK.Wwise.RTPC RTPC;
    private Vector3[] positions = new Vector3[0];
    private float[] radii = new float[0];
    public float DepthFalloff = 10;
    public float MinValue = 0;
    public float MaxValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> pos = new List<Vector3>();
        List<float> rad = new List<float>();
        foreach(MPVSubSphere subSphere in gameObject.GetComponentsInChildren<MPVSubSphere>())
        {
            pos.Add(subSphere.transform.position);
            rad.Add(subSphere.Radius);
        }
        positions = pos.ToArray();
        radii = rad.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = World.CURRENT.ActivePlayer.transform.position;
        float maxDepth = 0;
        for(int i = 0; i < positions.Length; i++)
        {
            maxDepth = Mathf.Max(maxDepth, radii[i] - Vector3.Distance(positions[i], playerPos));
        }
        RTPC.SetValue(World.CURRENT.ActiveCamera.gameObject, Mathf.Lerp(MinValue, MaxValue, maxDepth / DepthFalloff));
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Gizmos.DrawWireSphere(positions[i], radii[i]);
        }
    }
}

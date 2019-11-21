using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRenderer : MonoBehaviour
{
    public Space WaveSpace;
    [SerializeField]
    public SpectralWaveGenerationModel GenerationModel;

    [HideInInspector]
    protected MeshFilter filter;
    [HideInInspector]
    protected Vector3[] vertices;

    public float MinOceanDistance;
    public float MaxOceanDistance;
    public float OceanInterval;
    public float OceanWidth;
    public float DistanceScaling;

    void Start()
    {
        filter = gameObject.GetComponent<MeshFilter>();
        filter.mesh = OceanMeshGenerator.MeshFromCamera(World.CURRENT.ActiveCamera.GetComponent<Camera>(), OceanInterval, MinOceanDistance, MaxOceanDistance, OceanWidth, DistanceScaling);
        vertices = filter.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 actualPosition = WaveSpace == Space.World ? transform.TransformPoint(vertices[i]) : vertices[i];
            vertices[i].y = GenerationModel.HeightAt(new Vector2(actualPosition.x, actualPosition.z), Time.time);
        }

        filter.mesh.vertices = vertices;
        filter.mesh.RecalculateNormals();
    }
}

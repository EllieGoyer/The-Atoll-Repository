using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class World : MonoBehaviour
{
    public static World CURRENT;

    [SerializeField]
    protected GameObject activePlayer;
    public GameObject ActivePlayer
    {
        get { return activePlayer; }
        set {
            activePlayer = value; 
        }
    }

    [SerializeField]
    protected GameObject activeOcean;
    [SerializeField]
    protected WaveRenderer activeOceanRenderer;
    public GameObject ActiveOcean
    {
        get { return activeOcean; }
        set {
            activeOcean = value;
            activeOceanRenderer = activeOcean == null ? null : activeOcean.GetComponent<WaveRenderer>();
        }
    }
    public WaveRenderer ActiveOceanRenderer
    {
        get { return activeOceanRenderer; }
    }

    [SerializeField]
    protected GameObject activeCamera;
    [SerializeField]
    protected CameraFollow activeCameraFollow;
    public GameObject ActiveCamera
    {
        get { return activeCamera; }
        set {
            activeCamera = value;
            activeCameraFollow = activeCamera == null ? null : activeCamera.GetComponent<CameraFollow>();
        }
    }
    public CameraFollow ActiveCameraFollow
    {
        get { return activeCameraFollow; }
    }
    public Light ActiveSun;
    private void Awake()
    {
        CURRENT = this;
        activeCamera.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }
}

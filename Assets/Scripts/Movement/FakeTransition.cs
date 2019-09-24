using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTransition : MonoBehaviour
{
    [HideInInspector]
    protected CameraFollow cameraFollow;
    public WalkingMovement LandTarget;
    public OceanMovement OceanTarget;
    public bool IsOceanMode;
    public string TransitionButton;
    public float OceanDistance;
    public float OceanAngle;
    public float LandDistance;
    public float LandAngle;

    void Start()
    {
        cameraFollow = gameObject.GetComponent<CameraFollow>();
        UpdateControllers();
    }

    public void ToggleMode()
    {
        if(IsOceanMode)
        {
            LandTarget.gameObject.tag = "Player";
            OceanTarget.gameObject.tag = "Untagged";
        }
        else
        {
            LandTarget.gameObject.tag = "Untagged";
            OceanTarget.gameObject.tag = "Player";
        }
        IsOceanMode = !IsOceanMode;
        UpdateControllers();
    }

    public void UpdateControllers()
    {
        if (IsOceanMode)
        {
            cameraFollow.Target = OceanTarget.gameObject.GetComponent<CharacterController>();
            cameraFollow.FollowDistance = OceanDistance;
            cameraFollow.FollowElevation = OceanAngle;
            OceanTarget.enabled = true;
            LandTarget.enabled = false;
        }
        else
        {
            cameraFollow.Target = LandTarget.gameObject.GetComponent<CharacterController>();
            cameraFollow.FollowDistance = LandDistance;
            cameraFollow.FollowElevation = LandAngle;
            OceanTarget.enabled = false;
            LandTarget.enabled = true;
        }
    }
}

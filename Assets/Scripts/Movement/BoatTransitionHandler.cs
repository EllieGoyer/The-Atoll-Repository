using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoatTransitionHandler : MonoBehaviour {

    public static BoatTransitionHandler Instance; // singleton design pattern

    //public UnityEvent OnEnterOceanMode;
    //public UnityEvent OnEnterLandMode;

    [HideInInspector]
    protected CameraFollow cameraFollow;
    public WalkingMovement LandTarget;
    public GameObject LandPrefab;
    public Vector3 ShipDropoffOffset;
    public OceanMovement OceanTarget;
    public bool IsOceanMode;
    public string TransitionButton;
    public float OceanDistance;
    public float OceanAngle;
    public float OceanHeightOffset;
    public float LandDistance;
    public float LandAngle;
    public float LandHeightOffset;

    void Awake()
    {
        // set object up as a singleton
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        cameraFollow = gameObject.GetComponent<CameraFollow>();
        UpdateControllers();
    }

    public void EnterOceanMode() {
        if (IsOceanMode) return;

        LandTarget.gameObject.tag = "Untagged";
        OceanTarget.gameObject.tag = "Player";
        Destroy(LandTarget.gameObject);

        IsOceanMode = true;
        UpdateControllers();

        OceanTarget.gameObject.GetComponent<InteractableTriggerResetter>().FixTouchedInteractables();
    }

    public void EnterLandMode(Transform LandSpawnPoint) {
        if (!IsOceanMode) return;

        LandTarget = Instantiate(LandPrefab).GetComponent<WalkingMovement>();
        LandTarget.transform.position = LandSpawnPoint.position;
        LandTarget.transform.rotation = LandSpawnPoint.rotation;
        LandTarget.gameObject.tag = "Player";
        OceanTarget.gameObject.tag = "Untagged";

        IsOceanMode = false;
        UpdateControllers();

        OceanTarget.gameObject.GetComponent<InteractableTriggerResetter>().FixTouchedInteractables();
    }

    public void UpdateControllers()
    {
        if (IsOceanMode)
        {
            cameraFollow.Target = OceanTarget.gameObject.GetComponent<CharacterController>();
            cameraFollow.FollowDistance = OceanDistance;
            cameraFollow.FollowElevation = OceanAngle;
            cameraFollow.FollowHeightOffset = OceanHeightOffset;
            OceanTarget.enabled = true;
            LandTarget.enabled = false;
        }
        else
        {
            cameraFollow.Target = LandTarget.gameObject.GetComponent<CharacterController>();
            cameraFollow.FollowDistance = LandDistance;
            cameraFollow.FollowElevation = LandAngle;
            cameraFollow.FollowHeightOffset = LandHeightOffset;
            OceanTarget.enabled = false;
            LandTarget.enabled = true;
        }
    }
}

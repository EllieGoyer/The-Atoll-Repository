using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoatTransitionHandler : MonoBehaviour {

    public static BoatTransitionHandler Instance; // singleton design pattern

    //public UnityEvent OnEnterOceanMode;
    //public UnityEvent OnEnterLandMode;

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
        //DontDestroyOnLoad(gameObject);
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

        LandTarget = Instantiate(LandPrefab, LandSpawnPoint.transform.position, LandSpawnPoint.transform.rotation).GetComponent<WalkingMovement>();
        Debug.Log(LandSpawnPoint.position);
        //LandTarget.transform.position = LandSpawnPoint.position;
        //LandTarget.transform.rotation = LandSpawnPoint.rotation;
        LandTarget.gameObject.tag = "Player";
        OceanTarget.gameObject.tag = "Untagged";

        IsOceanMode = false;
        UpdateControllers();

        OceanTarget.gameObject.GetComponent<InteractableTriggerResetter>().FixTouchedInteractables();
    }

    public void UpdateControllers()
    {
        CameraFollow cameraFollow = World.CURRENT.ActiveCameraFollow;
        if (IsOceanMode)
        {
            World.CURRENT.ActivePlayer = OceanTarget.gameObject;
            cameraFollow.FollowDistance = OceanDistance;
            cameraFollow.FollowElevation = OceanAngle;
            cameraFollow.FollowHeightOffset = OceanHeightOffset;
            OceanTarget.AcceptingInput = true;
            LandTarget.AcceptingInput = false;
        }
        else
        {
            World.CURRENT.ActivePlayer = LandTarget.gameObject;
            cameraFollow.FollowDistance = LandDistance;
            cameraFollow.FollowElevation = LandAngle;
            cameraFollow.FollowHeightOffset = LandHeightOffset;
            OceanTarget.AcceptingInput = false;
            LandTarget.AcceptingInput = true;
        }

    }
}

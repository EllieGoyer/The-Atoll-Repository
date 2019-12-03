using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraFollow : MonoBehaviour
{
    /// <summary>
    /// how far above the bottom of our character controller should the camera look?
    /// </summary>
    public float FollowHeightOffset;

    [HideInInspector] public float YawElasticity;
    [HideInInspector] public float PitchElasticity;
    [HideInInspector] public Transform FocalPoint;
    
    // Update is called once per frame
    void Update()
    {
        CharacterController Target = World.CURRENT.ActivePlayer.GetComponent<CharacterController>();

        Vector3 targetPosition = World.CURRENT.ActivePlayer.transform.position + Vector3.up * FollowHeightOffset;

        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
    }
}

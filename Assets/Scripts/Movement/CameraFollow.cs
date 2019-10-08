﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CharacterController Target;

    /// <summary>
    /// Minimum elevation of the camera in terms of degrees.
    /// </summary>
    public float MinElevation;
    public float MaxElevation;

    public float CameraTopSpeed;
    public float CameraAcceleration;
    public float CameraDeceleration;

    /// <summary>
    /// how far from the target to follow from
    /// </summary>
    public float FollowDistance;
    /// <summary>
    /// what angle should the camera prefer
    /// </summary>
    public float FollowElevation;
    /// <summary>
    /// how far above the bottom of our character controller should the camera look?
    /// </summary>
    public float FollowHeightOffset;

    /// <summary>
    /// Maximum snap of the camera in terms of degrees per second.
    /// </summary>
    public float SnapSpeed;

    public string DragInputName;
    public string DragVerticalAxisName;
    public string DragHorizontalAxisName;

    [HideInInspector]
    protected Vector3 cameraPolarPosition;
    [HideInInspector]
    protected Vector3 cameraPolarVelocity;

    static Vector3 Polar2Cartesian(Vector3 polar)
    {
        float lateralRadius = polar.z * Mathf.Cos(Mathf.Deg2Rad * polar.y);

        float x = lateralRadius * Mathf.Sin(Mathf.Deg2Rad * polar.x);
        float y = polar.z * Mathf.Sin(Mathf.Deg2Rad * polar.y);
        float z = lateralRadius * Mathf.Cos(Mathf.Deg2Rad * polar.x);
        return new Vector3(x, y, z);
    }

    void Update()
    {
        Vector3 targetPosition = Target.transform.position + Vector3.up * FollowHeightOffset;

        

        if(Input.GetButton(DragInputName))
        {
            float verticalDrag = Input.GetAxis(DragVerticalAxisName) * -1;
            float horizontalDrag = Input.GetAxis(DragHorizontalAxisName);

            Vector3 polarDirectionVector = new Vector3(horizontalDrag, verticalDrag, 0);
            float inputMagnitude = polarDirectionVector.magnitude;
            polarDirectionVector.Normalize();

            if (!Mathf.Approximately(inputMagnitude, 0))
            {
                cameraPolarVelocity = Vector3.ClampMagnitude(cameraPolarVelocity + polarDirectionVector * CameraAcceleration, CameraTopSpeed * Mathf.Clamp01(inputMagnitude));
            }
            else
            {
                float newPolarSpeed = Mathf.Clamp(cameraPolarVelocity.magnitude - CameraDeceleration, 0, CameraTopSpeed * Mathf.Clamp01(inputMagnitude));
                cameraPolarVelocity = cameraPolarVelocity.normalized * newPolarSpeed;
            }
        }
        else if(!Mathf.Approximately(Target.velocity.sqrMagnitude, 0))
        {
            Vector3 targetPolar = new Vector3(((Target.gameObject.transform.rotation.eulerAngles.y + 180) % 360 + 360) % 360, FollowElevation, FollowDistance);
            Vector3 polarDirection = targetPolar - cameraPolarPosition;
            polarDirection.x = Mathf.Abs(polarDirection.x) > 180 ? -Mathf.Sign(polarDirection.x) * (360 - Mathf.Abs(polarDirection.x)) : polarDirection.x;
            polarDirection.y = Mathf.Abs(polarDirection.y) > 180 ? -Mathf.Sign(polarDirection.y) * (360 - Mathf.Abs(polarDirection.y)) : polarDirection.y;
            float difference = polarDirection.magnitude;
            polarDirection.Normalize();

            cameraPolarVelocity = difference * SnapSpeed * polarDirection / 45;
        }
        else
        {
            float newPolarSpeed = Mathf.Clamp(cameraPolarVelocity.magnitude - CameraDeceleration, 0, CameraTopSpeed);
            cameraPolarVelocity = cameraPolarVelocity.normalized * newPolarSpeed;
        }

        cameraPolarPosition += Time.deltaTime * cameraPolarVelocity;
        cameraPolarPosition.x = (cameraPolarPosition.x % 360 + 360) % 360;
        cameraPolarPosition.y = Mathf.Clamp((cameraPolarPosition.y % 360 + 360) % 360, MinElevation, MaxElevation);

        //TODO in the future this will include transitions between land and sea distance
        cameraPolarPosition.z = FollowDistance;

        gameObject.transform.position = targetPosition + Polar2Cartesian(cameraPolarPosition);

        Vector3 targetForward = (targetPosition - gameObject.transform.position).normalized;
        gameObject.transform.forward = targetForward;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraTrigger : MonoBehaviour
{
    public Transform FocalPoint;
    public float YawElasticity = 90;
    public float PitchElasticity = 45;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            World.CURRENT.ActiveCameraFollow.BeginFixedCamera(this);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            World.CURRENT.ActiveCameraFollow.EndFixedCamera();
        }
    }

    private void OnDrawGizmosSelected() {
        Vector3 forward = (FocalPoint.position - transform.position).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward);
        Vector3 up = Vector3.Cross(forward, right);

        float distance = Vector3.Distance(FocalPoint.position, transform.position);


        Gizmos.DrawLine(transform.position, FocalPoint.position);

        float sinx = Mathf.Sin(Mathf.Deg2Rad * YawElasticity);
        Gizmos.DrawLine(FocalPoint.position + right * sinx * distance, FocalPoint.position - right * sinx * distance);

        float siny = Mathf.Sin(Mathf.Deg2Rad * PitchElasticity);
        Gizmos.DrawLine(FocalPoint.position + up * siny * distance, FocalPoint.position - up * siny * distance);


    }
}

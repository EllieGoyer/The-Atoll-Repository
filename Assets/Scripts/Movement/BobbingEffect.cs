using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEffect : MonoBehaviour {

    public Transform EffectModel;
    public float rotationRate;
    public float AirborneHeightOffset;
    public float rotationalDrag;

    public Vector3 rotationAxis;
    public float rotationSpeed;

    public Transform ContactPointFront;
    public Transform ContactPointBackLeft;
    public Transform ContactPointBackRight;
    Vector3 normal;
    public WaveRenderer WaveRenderer;
    SpectralWaveGenerationModel WaveModel;

    private void Awake() {
        WaveModel = WaveRenderer.GenerationModel;
        rotationAxis = Vector3.up;
        rotationSpeed = 0;
        
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(transform.position, GetNormal() * 5, Color.green);

        if(!isAirborne()) {
            /*
            Quaternion targetRotation = GetNewRotation(GetNormal());
            Quaternion currentRotation = EffectModel.rotation;

            Vector3 TargetAxis;
            float TargetSpeed;
            targetRotation.ToAngleAxis*/

            EffectModel.rotation = Quaternion.RotateTowards(EffectModel.rotation, GetNewRotation(GetNormal()), rotationRate * Time.deltaTime);
        }
    }

    Vector3 GetNormal() {
        Vector3 a = GetWavePosition(ContactPointBackRight.position) - GetWavePosition(ContactPointFront.position);
        Vector3 b = GetWavePosition(ContactPointBackLeft.position) - GetWavePosition(ContactPointFront.position);

        return Vector3.Cross(a, b).normalized;
    }

    Vector3 GetWavePosition(Vector3 position) {
        position.y = WaveModel.HeightAt(new Vector2(position.x, position.z), Time.time);

        Debug.DrawLine(transform.position, position, Color.blue);
        return position;
    }
    Quaternion GetNewRotation(Vector3 NewUp) {
        Vector3 left = Vector3.Cross(transform.forward, NewUp);

        Vector3 newForward = Vector3.Cross(NewUp, left);


        return Quaternion.LookRotation(newForward, NewUp);
    }
    bool isAirborne() {
        float physicalHeight = transform.position.y + AirborneHeightOffset;

        float seaHeight = WaveModel.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        return physicalHeight > seaHeight;
    }
}

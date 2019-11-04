using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class OceanMovement : Movement {
    public float BuoyancyStrength = 20.5F;
    public float GravityStrength = 9.8F;
    public float MaxDisplacement = 1;

    [HideInInspector]
    protected Rigidbody controller;
    [HideInInspector]
    protected float forwardVelocity;
    [HideInInspector]
    protected float angularVelocity;

    protected float verticalVelocity = 0;
    public float AirDrag;
    public float WaterDrag;

    public OceanEngine Engine;
    public Winch AnchorWinch;
    public Anchor Anchor;
    public GameObject AnchorPrefab;

    protected override float ForwardVelocity {
        get => Vector3.Project(controller.velocity, transform.forward).magnitude * Mathf.Sign(Vector3.Dot(controller.velocity, transform.forward));
        set
        {
        }
    }
    protected override float AngularVelocity {
        set
        {
        }
    }

    // Start is called before the first frame update
    void Awake() {
        ReloadReferences();
    }

    public void ReloadReferences() {
        controller = gameObject.GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        if(AcceptingInput)
        {
            float forwardAxis = Input.GetAxis(ForwardAxisInputName), sideAxis = Input.GetAxis(SideAxisInputName);

            if (Anchor != null)
            {
                Anchor.Disengage();
                AnchorWinch.enabled = false;
                Destroy(Anchor.gameObject);
            }

            if (forwardAxis > 0)
            {
                Engine.Direction = 1;
            }
            else if (forwardAxis < 0)
            {
                Engine.Direction = -1;
            }
            else
            {
                Engine.Direction = 0;
            }

            if (sideAxis > 0)
            {
                controller.AddTorque(0, 50000, 0);
            }
            else if (sideAxis < 0)
            {
                controller.AddTorque(0, -50000, 0);
            }
        }
        else
        {
            Engine.Direction = 0;
            if (Anchor == null)
            {
                Anchor = Instantiate(AnchorPrefab, AnchorWinch.transform.position - Vector3.up * AnchorWinch.MinLength, Quaternion.identity).GetComponent<Anchor>();
                Anchor.GetComponent<SpringJoint>().connectedBody = controller;
                AnchorWinch.Target = Anchor.GetComponent<SpringJoint>();
                AnchorWinch.enabled = true;
            } else if (!Anchor.IsEngaged)
            {
                AnchorWinch.CurrentAction = Winch.Action.Extend;
            } else
            {
                AnchorWinch.CurrentAction = Winch.Action.None;
            }
        }
    }

    public bool IsAirborne() {
        float shipHeight = transform.position.y;
        float waterHeight = World.CURRENT.ActiveOceanRenderer.GenerationModel.HeightAt(new Vector2(transform.position.x, transform.position.z), Time.time);

        return shipHeight >= waterHeight;
    }
}

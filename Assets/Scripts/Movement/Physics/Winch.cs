using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winch : MonoBehaviour
{
    public enum Action
    {
        None,
        Extend,
        Retract
    }

    public float MaxLength;
    public float MinLength;
    public float MaxExtendRate;
    public float MaxRetractRate;
    public Action CurrentAction;
    public SpringJoint Target;

    public float Position
    {
        get { return Target.maxDistance; }
        set { Target.maxDistance = value; }
    }
    void FixedUpdate()
    {
        if(Target != null)
        {
            if (CurrentAction == Action.Extend)
            {
                Position = Mathf.Clamp(Position + MaxExtendRate * Time.fixedDeltaTime, MinLength, MaxLength);
            }
            else if (CurrentAction == Action.Retract)
            {
                Position = Mathf.Clamp(Position - MaxRetractRate * Time.fixedDeltaTime, MinLength, MaxLength);
            }
        }
    }
}

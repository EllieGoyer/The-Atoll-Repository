using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanFollow : MonoBehaviour
{
    public GameObject Target;
    
    void Update()
    {
        gameObject.transform.position = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
    }
}

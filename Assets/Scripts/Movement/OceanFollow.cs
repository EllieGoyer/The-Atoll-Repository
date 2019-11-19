﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanFollow : MonoBehaviour
{
    void Update()
    {
        Vector3 position = World.CURRENT.ActivePlayer.transform.position;
        gameObject.transform.position = new Vector3(position.x, 0, position.z);
        gameObject.transform.rotation = Quaternion.Euler(0, World.CURRENT.ActiveCamera.transform.rotation.eulerAngles.y, 0);
    }
}

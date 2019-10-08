using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCanvas : MonoBehaviour
{
    public static GlobalCanvas Instance;

    private void Awake() {
        Instance = this;
    }
}

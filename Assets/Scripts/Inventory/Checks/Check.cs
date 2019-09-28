using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Check : MonoBehaviour
{
    /// <summary>
    /// Returns true if the check passes, or false if it does not
    /// </summary>
    /// <returns></returns>
    public abstract bool Perform();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckOceanMode : Check
{
    public enum Type { InOceanMode, InLandMode };
    public Type checkType;

    public override bool Perform() {
        bool mode = BoatTransitionHandler.Instance.IsOceanMode;

        // if we should be in ocean mode, return whether or not we are in ocean mode
        // otherwise, check for the inverse
        return (checkType == Type.InOceanMode) ? mode : !mode;
    }
}

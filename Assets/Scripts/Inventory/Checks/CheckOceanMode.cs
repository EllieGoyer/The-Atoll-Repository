using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckOceanMode : Check
{
    [Tooltip(tooltip:"Hook up to the FakeTransition component in the scene")]
    public FakeTransition fakeTransition;
    public enum Type { InOceanMode, InLandMode };
    public Type checkType;

    public override bool Perform() {
        bool mode = fakeTransition.IsOceanMode;

        // if we should be in ocean mode, return whether or not we are in ocean mode
        // otherwise, check for the inverse
        return (checkType == Type.InOceanMode) ? mode : !mode;
    }
}

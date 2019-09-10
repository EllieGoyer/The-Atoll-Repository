using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WaveGenerationModel
{
    float HeightAt(Vector2 position, float time);
}

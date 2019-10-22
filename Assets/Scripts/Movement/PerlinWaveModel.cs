using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinWaveModel : WaveGenerationModel
{
    public float Amplitude;
    public Vector2 Offset;
    public Vector2 Wavelength;
    public Vector2 Velocity;

    public float HeightAt(Vector2 position, float time)
    {
        return Mathf.PerlinNoise((position.x + Offset.x + Velocity.x * time) / Wavelength.x % 1,
            (position.y + Offset.y + Velocity.y * time) / Wavelength.y % 1);
    }
}

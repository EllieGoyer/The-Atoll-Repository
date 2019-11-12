using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpectralWaveGenerationModel : WaveGenerationModel
{
    [SerializeField]
    public Wavelet[] wavelets;

    public float HeightAt(Vector2 position, float time)
    {
        float cumulativeHeight = 0;

        foreach(Wavelet wavelet in wavelets)
        {
            float standardizedHeight = (Mathf.Sin((position.x - wavelet.Offset.x + wavelet.Velocity.x * time) / wavelet.Wavelength.x)
                + Mathf.Sin((position.y  - wavelet.Offset.y + wavelet.Velocity.y * time) / wavelet.Wavelength.y)) / 2;

            cumulativeHeight += standardizedHeight * wavelet.Amplitude + wavelet.Mean;
        }

        return cumulativeHeight;
    }
}

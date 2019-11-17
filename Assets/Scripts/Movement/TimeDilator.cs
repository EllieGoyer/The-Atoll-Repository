using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDilator : MonoBehaviour
{
    public Color DayColor;
    public Color NightColor;
    public Color DayAmbient;
    public float DayAmbientIntensity;
    public Color NightAmbient;
    public float NightAmbientIntensity;
    public float ToggleRate = 0.2F;
    public bool IsDayTime = true;
    public float TimeOffset = 0;
    public float LengthOfDay = 90;
    
    public void FastForward(float amount)
    {
        TimeOffset = (TimeOffset + amount) % LengthOfDay;
    }

    public float GetTimeOfDay()
    {
        return (Mathf.Cos(2 * Mathf.PI * ((Time.time + TimeOffset) % LengthOfDay) / LengthOfDay) + 1) / 2;
    }

    private void Update()
    {
        float t = GetTimeOfDay();
        World.CURRENT.ActiveSun.color = Color.Lerp(NightColor, DayColor, t);
        RenderSettings.ambientLight = Color.Lerp(NightAmbient, DayAmbient, t);
        RenderSettings.ambientIntensity = Mathf.Lerp(NightAmbientIntensity, DayAmbientIntensity, t);
        /*
        if (IsDayTime)
        {
            World.CURRENT.ActiveSun.color = Color.Lerp(World.CURRENT.ActiveSun.color, DayColor, ToggleRate * Time.deltaTime);
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, DayAmbient, ToggleRate * Time.deltaTime);
            RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, DayAmbientIntensity, ToggleRate * Time.deltaTime);
        }
        else
        {
            World.CURRENT.ActiveSun.color = Color.Lerp(World.CURRENT.ActiveSun.color, NightColor, ToggleRate * Time.deltaTime);
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, NightAmbient, ToggleRate * Time.deltaTime);
            RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, NightAmbientIntensity, ToggleRate * Time.deltaTime);
        }*/
    }
}

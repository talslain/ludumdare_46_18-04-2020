using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SunlightController : MonoBehaviour
{
    [SerializeField] Light2D sunLightBeam;

    public float sunLightIntensity;
    void Start()
    {
    }

    void Update()
    {
        float sunLightIntensity = Mathf.Sin(EventManager.main.timeOfDay * Mathf.Deg2Rad);
        sunLightBeam.intensity = sunLightIntensity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MIrrorController : MonoBehaviour
{
    SunlightReceiver receiver;
    LightSource light;
    [SerializeField] Light2D areaLight;

    void Start()
    {
        receiver = GetComponent<SunlightReceiver>();
        light = GetComponent<LightSource>();
    }

    void Update()
    {
        float intensity = receiver.GetLightIntensity();
        light.SetLightIntensity(intensity);
        this.areaLight.intensity = intensity;
    }
}

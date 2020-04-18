using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIrrorController : MonoBehaviour
{
    SunlightReceiver receiver;
    LightSource light;

    void Start()
    {
        receiver = GetComponent<SunlightReceiver>();
        light = GetComponent<LightSource>();
    }

    void Update()
    {
        float intensity = receiver.GetLightIntensity();
        light.SetLightIntensity(intensity);
    }
}

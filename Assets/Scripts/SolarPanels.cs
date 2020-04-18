using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanels : MonoBehaviour
{
    SunlightReceiver receiver;

    void Start()
    {
        receiver = GetComponent<SunlightReceiver>();
    }

    void Update()
    {
        float sunIntensity = receiver.GetLightIntensity();
        EventManager.main.ChargeEnergy(((sunIntensity)) * Time.deltaTime);
    }
}

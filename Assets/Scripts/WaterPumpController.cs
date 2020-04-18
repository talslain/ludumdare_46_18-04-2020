using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPumpController : MonoBehaviour
{
    [SerializeField] Toggler toggler;
    [SerializeField] float energyDeplete = 0.5f;
    [SerializeField] float waterPower = 2f;
    [SerializeField] float waterDecay = 0.1f;

    void Update()
    {
        bool changed = false;
        if (toggler.toggle)
            if (EventManager.main.ChargeEnergy(-1 * energyDeplete * Time.deltaTime))
                changed = true;

        float waterPowerChange = changed ? waterPower : -1*waterDecay;
        EventManager.main.ChangeWaterPressure(waterPowerChange*Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager main;
    public static Color INTERACT_LIGHT = new Color(1, 1, 1);

    public float energy
    {
        get;
        private set;
    }
    public float waterPressure
    {
        get;
        private set;
    }

    [SerializeField] float secondsPerDay;

    private void Start()
    {
        EventManager.main = this;
        waterPressure = 100.0f;
        energy = 100.0f;
    }

    public float timeOfDay
    {
        private set;
        get;
    }

    internal bool ChargeEnergy(float v)
    {
        float e = this.energy;
        this.energy += v;
        this.energy = Mathf.Clamp(this.energy, 0, 100);
        return e != this.energy;
    }

    internal void ChangeWaterPressure(float v)
    {
        this.waterPressure += v;
        this.waterPressure = Mathf.Clamp(this.waterPressure, 0, 100);
    }

    void Update()
    {
        timeOfDay += Time.deltaTime;
        timeOfDay %= secondsPerDay;

        Debug.Log("energy:" + energy + ", water:" + waterPressure);
    }
}

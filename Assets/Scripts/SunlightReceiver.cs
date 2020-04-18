﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SunlightReceiver : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] LightSource lightToReceive;
    [SerializeField] Transform lightReceivePoint;

    public float lightIntensity
    {
        get;
        private set;
    }

    public float GetLightIntensity()
    {
        Vector2 direction = lightToReceive.transform.position - transform.position;
        if (Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask) &&
            lightToReceive.AmIInView(lightReceivePoint.position))
        {
            return lightToReceive.GetLightIntensity();
        }
        else
        {
            return 0;
        }
    }
}

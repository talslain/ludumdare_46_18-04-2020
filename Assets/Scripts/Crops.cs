using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [SerializeField] float sunLightMultiplier = 1f;
    [SerializeField] float waterMultiplier = 0.009f;
    [SerializeField] float sunLightDecay = 0.3f;
    [SerializeField] float waterDecay = 0.3f;
    [SerializeField] float healthDecay = 5f;

    [SerializeField] float health = 100;
    [SerializeField] float sunlight = 10;
    [SerializeField] float water = 10;
    [SerializeField] float growth = 0;


    SunlightReceiver receiver;

    void Start()
    {
        receiver = GetComponent<SunlightReceiver>();
    }

    void Update()
    {
        growth += Time.deltaTime;
        float sunIntensity = receiver.GetLightIntensity();

        sunlight += ((sunIntensity * sunLightMultiplier)-(sunLightDecay))*Time.deltaTime;
        sunlight = Mathf.Clamp(sunlight, 0, 10);
        water += ((EventManager.main.waterPressure * waterMultiplier) - (waterDecay)) * Time.deltaTime;
        water = Mathf.Clamp(water, 0, 10);

        if (sunlight == 0)
            health -= (healthDecay * Time.deltaTime);
        if (water == 0)
            health -= (healthDecay * Time.deltaTime);

        if (health <= 0)
        {
            //lose
        }
        if (growth >= 900)
        {
            //win!
        }
    }
}

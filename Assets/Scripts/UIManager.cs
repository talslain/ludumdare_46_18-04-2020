using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Slider powerBar;
    [SerializeField] Slider waterPressureBar;
    [SerializeField] Slider sunlightBar;
    [SerializeField] Slider plantWaterBar;

    [SerializeField] Crops crops;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.value = EventManager.main.energy;
        waterPressureBar.value = EventManager.main.waterPressure;
        sunlightBar.value = crops.sunlight;
        plantWaterBar.value = crops.water;

        Vector2 dayTime = EventManager.main.GetTime();
        string hour, minute;
        if (dayTime.x < 10)
        {
            hour = "0" + dayTime.x.ToString();
        } else 
        { 
            hour = dayTime.x.ToString();
        }
        if (dayTime.y < 10)
        {
            minute = "0" + dayTime.y.ToString();

        }
        else
        {
            minute = dayTime.y.ToString();
        }
        timerText.text = "Day " + EventManager.main.day + " - " + hour + " : " + minute;
    }
}

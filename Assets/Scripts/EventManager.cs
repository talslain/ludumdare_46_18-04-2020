using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager main;
    public static Color INTERACT_LIGHT = new Color(0, 1, 0);

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
    public float timeOfDay
    {
        private set;
        get;
    }

    [SerializeField] float secondsPerDay;

    public int day;

    private void Start()
    {
        EventManager.main = this;
        waterPressure = 100.0f;
        energy = 100.0f;
        day = 1;
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
        float tod = timeOfDay;
        timeOfDay += Time.deltaTime;
        timeOfDay %= secondsPerDay;
        if (tod > 100 && timeOfDay < 1)
            day++;
        Debug.Log(day);
    }

    public Vector2 GetTime()
    {
        int daySeconds = (int) ((timeOfDay / 180.0f) * (24 * 60 * 60));
        Vector2 dayTime = new Vector2();
        dayTime.x = ((int) (daySeconds / (60.0f * 60)));
        dayTime.y = ((int)(daySeconds / 60.0f) % 60);
        return dayTime;
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("win-scene");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("lose-scene");
    }
}

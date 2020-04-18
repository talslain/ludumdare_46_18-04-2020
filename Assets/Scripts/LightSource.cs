using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSource : MonoBehaviour
{
    SunlightController sunlight;
    [SerializeField] Light2D light;

    void Start()
    {
        if(light==null)
            light = GetComponent<Light2D>();
    }

    public void SetLightIntensity(float value)
    {
        this.light.intensity = value;
    }

    public float GetLightIntensity()
    {
        return this.light.intensity;
    }

    public bool AmIInView(Vector2 position)
    {
        Vector2 dir = ((Vector2) transform.position) - position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg - (transform.eulerAngles.z - 180) - 90;
        if (angle < this.light.pointLightInnerAngle/2 && angle > -1*(this.light.pointLightOuterAngle / 2))
        {
            return true;
        }
        return false;
    }
}

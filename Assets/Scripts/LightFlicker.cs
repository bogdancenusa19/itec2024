using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public new Light2D light;

    public float maxIntensity;
    public float minIntensity;
    public float changeSpeed;

    private float intensity;
    private bool increasing;


    // Start is called before the first frame update
    void Start()
    {
        intensity = maxIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (increasing)
        {
            light.intensity += changeSpeed * Time.deltaTime;
            if (light.intensity >= maxIntensity)
            {
                increasing = false;
            }
        }
        else
        {
            light.intensity -= changeSpeed * Time.deltaTime;
            if (light.intensity <= minIntensity)
            {
                increasing = true;
            }
        }
    }
}
